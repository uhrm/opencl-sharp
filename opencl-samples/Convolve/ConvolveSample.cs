﻿using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenCl.Compiler;

namespace OpenCl.Samples
{
    public static class ConvolveSample
    {

        private const uint inputSignalWidth  = 8;
        private const uint inputSignalHeight = 8;
        private static uint[] inputSignal =
        {
            3, 1, 1, 4, 8, 2, 1, 3,
            4, 2, 1, 1, 2, 1, 2, 3,
            4, 4, 4, 4, 3, 2, 2, 2,
            9, 8, 3, 8, 9, 0, 0, 0,
            9, 3, 3, 9, 0, 0, 0, 0,
            0, 9, 0, 8, 0, 0, 0, 0,
            3, 0, 8, 8, 9, 4, 4, 4,
            5, 9, 8, 1, 8, 1, 1, 1
        };

        private const uint maskWidth  = 3;
        private const uint maskHeight = 3;
        private static uint[] mask =
        {
            1, 1, 1,
            1, 0, 1,
            1, 1, 1,
        };

        private const uint outputSignalWidth  = 6;
        private const uint outputSignalHeight = 6;
        private static uint[] outputSignal = new uint[outputSignalWidth*outputSignalHeight];

        private static void PrintArray(uint width, uint[] data) {
            var nrows = data.Length/width;
            if (nrows*width < data.Length) {
                nrows++;
            }
            for (var i=0; i<nrows; i++) {
                Console.Write("*** ");
                for (var j=0; j<width; j++) {
                    Console.Write("{0,3} ", data[i*width+j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("*** ");
        }

        // private static void RunConvolution(string source)
        // {
        //     Platform platform = Platform.GetPlatformIDs()[0];
        //     Device[] devices = Device.GetDeviceIDs(platform, DeviceType.Cpu);
        //     Context context = Context.CreateContext(platform, devices, null, null);
        //     var program = Program.CreateProgramWithSource(context, new String[] { source });
        //     try {
        //         program.BuildProgram(devices, null, null, null);
        //     }
        //     catch (OpenClException ex) {
        //         Console.WriteLine("*** Error building kernel 'conv'.");
        //         if (ex.ErrorCode == ErrorCode.BuildProgramFailure) {
        //             Console.WriteLine("*** Build log: {0}", program.BuildInfo.GetLog(devices[0]));
        //             Console.WriteLine("*** Source code:");
        //             Console.WriteLine(source);
        //         }
        //         return;
        //     }
        //     var kernel = Kernel.CreateKernel(program, "conv");
        //     var inputSignalBuffer = Mem<uint>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, inputSignal);
        //     if (inputSignalBuffer.Size < (uint)(Marshal.SizeOf<uint>()*inputSignal.Length)) {
        //         Console.WriteLine("*** Invalid MemObject size: expected >= {0}, found {1}.", Marshal.SizeOf<uint>()*inputSignal.Length, inputSignalBuffer.Size);
        //         return;
        //     }
        //     var maskBuffer = Mem<uint>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, mask);
        //     var outputSignalBuffer = Mem<uint>.CreateBuffer(context, MemFlags.WriteOnly, sizeof(uint)*outputSignalHeight*outputSignalWidth);
        //     var queue = CommandQueue.CreateCommandQueue(context, devices[0]);
        //     kernel.SetKernelArg(0, (HandleObject)inputSignalBuffer);
        //     kernel.SetKernelArg(1, (HandleObject)maskBuffer);
        //     kernel.SetKernelArg(2, (HandleObject)outputSignalBuffer);
        //     kernel.SetKernelArg(3, inputSignalWidth);
        //     kernel.SetKernelArg(4, maskWidth);
        //     var globalWorkSize = new uint[] { outputSignalWidth, outputSignalHeight };
        //     var localWorkSize  = new uint[] { 1, 1 };
        //     queue.EnqueueNDRangeKernel(kernel, null, globalWorkSize, localWorkSize, null);
        //     queue.EnqueueReadBuffer(outputSignalBuffer, true, outputSignal);
        //     PrintOutputSignal();
        // }

        [Kernel, ClName("conv")]
        private static void Conv([Global] uint[] data, [Global] uint[] mask, [Global] uint[] result, int dataWidth, int maskWidth)
        {
            var x = Cl.GetGlobalId(0);
            var y = Cl.GetGlobalId(1);
            var sum = 0u;
            for (var r=0; r<maskWidth; r++)
            {
                var idxData = (y+r)*dataWidth + x;
                var idxMask = r*maskWidth;
                for (var c=0; c<maskWidth; c++, idxData++, idxMask++)
                {
                    sum += mask[idxMask]*data[idxData];
                }
            }
            result[y*Cl.GetGlobalSize(0) + x] = sum;
        }

        private static void RunManaged()
        {
            Cl.RunKernel(
                new int[] { (int)outputSignalWidth, (int)outputSignalHeight },
                new int[] { 1, 1 },
                (Action<uint[],uint[],uint[],int,int>)Conv,
                inputSignal,
                mask,
                outputSignal,
                (int)inputSignalWidth,
                (int)maskWidth
            );
            PrintArray(outputSignalWidth, outputSignal);
        }

        private static void RunNative(byte[] module)
        {
            Device device = Device.GetDeviceIDs(null, DeviceType.All).First();
            using (var context = Context.CreateContext(null, device, null, null))
            using (var queue = CommandQueue.CreateCommandQueue(context, device))
            using (var program = Program.CreateProgramWithIL(context, module.ToArray()))
            {
                program.BuildProgram(device);
                using (var kernel = Kernel.CreateKernel(program, "conv"))
                using (var ms = Mem<uint>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, inputSignal))
                using (var mm = Mem<uint>.CreateBuffer(context, MemFlags.ReadOnly | MemFlags.CopyHostPtr, mask))
                using (var mr = Mem<uint>.CreateBuffer(context, MemFlags.WriteOnly, (int)outputSignalWidth*(int)outputSignalHeight*Marshal.SizeOf<int>()))
                {
                    kernel.SetKernelArg(0, (HandleObject)ms);
                    kernel.SetKernelArg(1, (HandleObject)mm);
                    kernel.SetKernelArg(2, (HandleObject)mr);
                    kernel.SetKernelArg(3, (int)inputSignalWidth);
                    kernel.SetKernelArg(4, (int)maskWidth);
                    queue.EnqueueNDRangeKernel(kernel, null, new uint[] { outputSignalWidth, outputSignalHeight }, new uint[] { 1, 1 }, null);
                    queue.Finish();
                    queue.EnqueueReadBuffer(mr, true, outputSignal);
                }
            }
            PrintArray(outputSignalWidth, outputSignal);
        }

        public static void Run()
        {
            Console.WriteLine("*** Managed:");
            Console.WriteLine("*** ");
            RunManaged();

            Console.WriteLine("*** Native SPIR-V:");
            Console.WriteLine("*** ");
            var module = new MemoryStream();
            SpirCompiler.EmitKernel("opencl-samples", "OpenCl.Samples.ConvolveSample", "Conv", module);

            var buf = module.ToArray();

            using (var stream = new FileStream("conv.spv", FileMode.Create))
            {
                stream.Write(buf, 0, buf.Length);
            }
            RunNative(buf);
        }
    }
}

