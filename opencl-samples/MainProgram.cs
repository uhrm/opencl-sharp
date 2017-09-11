using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenCl.Samples
{
    class MainProgram
    {
        private static void ListDevices()
        {
            var platforms = Platform.GetPlatformIDs();

            Console.WriteLine("*** {0} platform{1}", platforms.Length, platforms.Length > 1 ? "s" : "");
            Console.WriteLine("*** ");
            foreach (var p in platforms) {
                Console.WriteLine("*** platform {0}", p.Name);
                Console.WriteLine("***   version: {0}", p.Version);
                Console.WriteLine("***   profile: {0}", p.Profile);
                Console.WriteLine("***   vendor:  {0}", p.Vendor);
                Console.WriteLine("***   extensions:");
                foreach (var e in p.Extensions) {
                    Console.WriteLine("***     {0}", e);
                }
                Console.WriteLine("*** ");

                var devices = Device.GetDeviceIDs(p, DeviceType.All);
                Console.WriteLine("***   {0} device{1}", devices.Length, devices.Length > 1 ? "s" : "");
                Console.WriteLine("*** ");
                foreach (var d in devices) {
                    Console.WriteLine("***   device {0}", d.Name);
                    Console.WriteLine("***     type:  . . . . . . . . . {0}", d.Type);
                    Console.WriteLine("***     profile: . . . . . . . . {0}", d.Profile);
                    Console.WriteLine("***     version: . . . . . . . . {0}", d.Version);
                    Console.WriteLine("***     C version: . . . . . . . {0}", d.ClVersion);
                    Console.WriteLine("***     max workitem dimensions: {0}", d.MaxWorkItemDimensions);
                    Console.WriteLine("***     max workitem sizes:  . . {0}", String.Join(", ", d.MaxWorkItemSizes.Select(i => i.ToString())));
                    Console.WriteLine("***     max workgroup size:  . . {0}", d.MaxWorkGroupSize);
                    Console.WriteLine("***     max mem alloc size:  . . {0:0.0} MiB", ((float)d.MaxMemAllocSize)/1024.0/1024.0);
                    Console.WriteLine("***     global mem size: . . . . {0:0.0} MiB", ((float)d.GlobalMemSize)/1024.0/1024.0);
                    Console.WriteLine("***     local mem size:  . . . . {0:0.0} KiB", ((float)d.LocalMemSize)/1024.0);
                    Console.WriteLine("***     vendor:  . . . . . . . . {0}", d.Vendor);
                    Console.WriteLine("***     extensions:");
                    foreach (var e in d.Extensions) {
                        Console.WriteLine("***       {0}", e);
                    }
                    Console.WriteLine("*** ");
                }
            }
        }

        public static void Main(string[] args)
        {

//          var handle = dlopen("/System/Library/Frameworks/OpenCL.framework/OpenCL", RTLD_LAZY);
//          if (handle == IntPtr.Zero) {
//              throw new ApplicationException(Marshal.PtrToStringAnsi(dlerror()));
//          }
//
//            var func = dlsym(handle, "clGetPlatformIDs");
//            if (func == IntPtr.Zero)  {
//                throw new ApplicationException(Marshal.PtrToStringAnsi(dlerror()));
//            }
//
//            dlclose(handle);

            ListDevices();

            Console.WriteLine("*** Simple kernel sample");
            Console.WriteLine("*** ");
            SimpleKernelSample.Run();

            // Console.WriteLine("*** Convolve sample");
            // Console.WriteLine("*** ");
            // ConvolveSample.Run();

            // Console.WriteLine("*** BitronicSort sample");
            // Console.WriteLine("*** ");
            // BitonicSortSample.Run();

            // Console.WriteLine("*** Gemm sample");
            // Console.WriteLine("*** ");
            // GemmSample.Run();
        }

//      private const int RTLD_LAZY = 0x1;
//      private const int RTLD_NOW = 0x2;
//      private const int RTLD_LOCAL = 0x4;
//      private const int RTLD_GLOBAL = 0x8;
//
//      [DllImport("dl")]
//      internal static extern IntPtr dlopen(string name, int flag);
//
//      [DllImport("dl")]
//      internal static extern IntPtr dlsym(IntPtr handle, string symbol);
//
//      [DllImport("dl")]
//      internal static extern void dlclose(IntPtr handle);
//
//      [DllImport("dl")]
//      internal static extern IntPtr dlerror();

    }
}
