using System;

namespace OpenCl.Compiler
{
    //
    // SPIR-V enumerations
    //

    enum ExecutionModel
    {
        Vertex,
        TesselationControl,
        TesseleationEvaluation,
        Geometry,
        Fragement,
        GLCompute,
        Kernel
    }

    enum AddressingModel
    {
        Logical,
        Physical32,
        Physical64
    }

    enum MemoryModel
    {
        Simple,
        GLSL450,
        OpenCL
    }

    enum ExecutionMode
    {
        Invocations,
        SpacingEqual,
        SpacingFractalEven,
        SpacingFractalOdd,
        VertexOrderCw,
        VertexOrderCcw,
        PixelCenterInteger,
        OriginUpperLeft,
        OriginLowerLeft,
        EarlyFragmentTests,
        PointMode,
        Xfb,
        DepthReplacing,
        DepthGreater,
        DepthLess,
        DepthUnchanged,
        LocalSize,
        LocalSizeHint,
        InputPoints,
        InputLines,
        InputLinesAdjacency,
        Triangles,
        InputTrianglesAdjacency,
        Quads,
        Isolines,
        OuputVertices,
        OutputPoints,
        OutputLineStrip,
        OutputTriangleStrip,
        VecTypeHint,
        ContractionOff,
        Initializer,
        Finalizer,
        SubgroupSize,
        SubgroupsPerWorkgroup
    }

    enum StorageClass
    {
        UniformConstant,
        Input,
        Uniform,
        Output,
        Workgroup,
        CrossWorkgroup,
        Private,
        Function,
        Generic,
        PushConstant,
        AtomicCounter,
        Image
    }

    enum Dim
    {
        D1,
        D2,
        D3,
        Cube,
        Rect,
        Buffer,
        SubpassData
    }

    enum SamplerAddressing
    {
        None,
        ClampToEdge,
        Clamp,
        Repeat,
        RepeatMirrored
    }

    enum SamplerFilterMode
    {
        Nearest,
        Linear
    }

    enum ImageFormat
    {
        Unknown,
        Rgba32f,
        Rgba16f,
        R32f,
        Rgba8,
        Rgba8Snorm,
        Rg32f,
        Rg16f,
        R11fG11fB10f,
        R16f,
        Rgba16,
        Rgb10A2,
        Rg16,
        Rg8,
        R16,
        R8,
        Rgba16Snorm,
        Rg16Snorm,
        Rg8Snorm,
        R16Snorm,
        R8Snorm,
        Rgba32i,
        Rgba16i,
        Rgba8i,
        R32i,
        Rg32i,
        Rg16i,
        Rg8i,
        R16i,
        R8i,
        Rgba32ui,
        Rgba16ui,
        Rgba8ui,
        R32ui,
        Rgba10a2ui,
        Rg32ui,
        Rg16ui,
        Rg8ui,
        R16ui,
        R8ui
    }

    enum ImageChannelorder
    {
        R,
        A,
        RG,
        RA,
        RGB,
        RGBA,
        BGRA,
        ARGB,
        Intensity,
        Luminance,
        Rx,
        RGx,
        RGBx,
        Depth,
        DepthStencil,
        sRGB,
        sRGBx,
        sRGBA,
        sBGRA,
        ABGR
    }

    enum ImageChannelDataType
    {
        SnormInt8,
        SnormInt16,
        UnormInt8,
        UnormInt16,
        UnormShort565,
        UnormShort555,
        UnormInt101010,
        SignedInt8,
        SignedInt16,
        SignedInt32,
        UnsignedInt8,
        UnsignedInt16,
        UnsignedInt32,
        HalfFloat,
        Float,
        UnormInt24,
        UnormInt101010_2
    }

    [Flags]
    enum ImageOperands
    {
        None         = 0x00,
        Bias         = 0x01,
        Lod          = 0x02,
        Grad         = 0x04,
        ConstOffset  = 0x08,
        Offset       = 0x10,
        ConstOffsets = 0x20,
        Sample       = 0x40,
        MinLod       = 0x80
    }

    [Flags]
    enum FpFastMathMode
    {
        None       = 0x00,
        NotNaN     = 0x01,
        NotInf     = 0x02,
        NSZ        = 0x04,
        AllowRecip = 0x08,
        Fast       = 0x10
    }

    enum FpFastRoundingMode
    {
        RTE,
        RTZ,
        RTP,
        RTN
    }

    enum LinkageType
    {
        Export,
        Import
    }

    enum AccessQualifier
    {
        ReadOnly,
        WriteOnly,
        ReadWrite
    }

    enum FunctionParameterAttribute
    {
        Zext,
        Sext,
        ByVal,
        Sret,
        NoAlias,
        NoCapture,
        NoWrite,
        NoReadWrite
    }

    enum Decoration
    {
        RelaxedPrecision        =  0,
        SpecId                  =  1,
        Block                   =  2,
        BufferBlock             =  3,
        RowMajor                =  4,
        ColMajor                =  5,
        ArrayStride             =  6,
        MatrixStride            =  7,
        GLSLShared              =  8,
        GLSLPacked              =  9,
        CPacked                 = 10,
        BuiltIn                 = 11,
        NoPerspective           = 13,
        Flat                    = 14,
        Patch                   = 15,
        Centroid                = 16,
        Sample                  = 17,
        Invariant               = 18,
        Restrict                = 19,
        Aliased                 = 20,
        Volatile                = 21,
        Constant                = 22,
        Coherent                = 23,
        NonWritable             = 24,
        NonReadable             = 25,
        Uniform                 = 26,
        SaturatedConversion     = 28,
        Stream                  = 29,
        Location                = 30,
        Component               = 31,
        Index                   = 32,
        Binding                 = 33,
        DescriptorSet           = 34,
        Offset                  = 35,
        XfbBuffer               = 36,
        XfbStride               = 37,
        FuncParamAttr           = 38,
        FPRoundingMode          = 39,
        FPFastMathMode          = 40,
        LinkageAttributes       = 41,
        NoContraction           = 42,
        InputAttachmentIndex    = 43,
        Alignment               = 44,
        MaxByteOffset           = 45
    }

    enum BuiltIn
    {
        Position                    =  0,
        PointSize                   =  1,
        ClipDistance                =  3,
        CullDistance                =  4,
        VertexId                    =  5,
        InstanceId                  =  6,
        PrimitiveId                 =  7,
        InvocationId                =  8,
        Layer                       =  9,
        ViewportIndex               = 10,
        TessLevelOuter              = 11,
        TessLevelInner              = 12,
        TessCoord                   = 13,
        PatchVertices               = 14,
        FragCoord                   = 15,
        PointCoord                  = 16,
        FrontFacing                 = 17,
        SampleId                    = 18,
        SamplePosition              = 19,
        SampleMask                  = 20,
        FragDepth                   = 22,
        HelperInvocation            = 23,
        NumWorkgroups               = 24,
        WorkgroupSize               = 25,
        WorkgroupId                 = 26,
        LocalInvocationId           = 27,
        GlobalInvocationId          = 28,
        LocalInvocationIndex        = 29,
        WorkDim                     = 30,
        GlobalSize                  = 31,
        EnqueuedWorkgroupSize       = 32,
        GlobalOffset                = 33,
        GlobalLinearId              = 34,
        SubgroupSize                = 36,
        SubgroupMaxSize             = 37,
        NumSubgroups                = 38,
        NumEnqueuedSubgroups        = 39,
        SubgroupId                  = 40,
        SubgroupLocalInvocationId   = 41,
        VertexIndex                 = 42,
        InstanceIndex               = 43,

        SubgroupEqMaskKHR           = 4416,
        SubgroupGeMaskKHR           = 4417,
        SubgroupGtMaskKHR           = 4418,
        SubgroupLeMaskKHR           = 4419,
        SubgroupLtMaskKHR           = 4420,
        BaseVertex                  = 4424,
        BaseInstance                = 4425,
        DrawIndex                   = 4426
    }

    [Flags]
    enum SelectionControl
    {
        None        = 0x00,
        Flatten     = 0x01,
        DontFlatten = 0x02
    }

    [Flags]
    enum LoopControl
    {
        None               = 0x00,
        Unroll             = 0x01,
        DontUnroll         = 0x02,
        DependencyInfinite = 0x04,
        DependencyLength   = 0x08
    }

    [Flags]
    enum FunctionControl
    {
        None       = 0x00,
        Inlince    = 0x01,
        DontInline = 0x02,
        Pure       = 0x04,
        Const      = 0x08
    }

    [Flags]
    enum MemorySemantics
    {
        None                  = 0x000,
        Acquire               = 0x002,
        Release               = 0x004,
        AcquireRealease       = 0x008,
        SquentiallyConsistent = 0x010,
        UniformMemory         = 0x040,
        SubgroupMemory        = 0x080,
        WorkgroupMemory       = 0x100,
        CrossWorkgroupMemory  = 0x200,
        AtomicCounterMemory   = 0x400,
        ImageMemory           = 0x800
    }

    [Flags]
    enum MemoryAccess
    {
        None        = 0x00,
        Volatile    = 0x01,
        Aligned     = 0x02,
        Nontemporal = 0x04
    }

    enum Scope
    {
        CrossDevice,
        Device,
        Workgroup,
        Subgroup,
        Invocation
    }

    enum GroupOperation
    {
        Reduce,
        InclusiveScan,
        ExclusiveScan
    }

    enum KernelEnqueueFlags
    {
        NoWait,
        WaitKernel,
        WaitWorkgroup
    }

    enum KernelProfilingInfo
    {
        None,
        CmdExecTime
    }

    enum Capability
    {
        Matrix                                       = 0,
        Shader                                       = 1,
        Geometry                                     = 2,
        Tesselation                                  = 3,
        Addresses                                    = 4,
        Linkage                                      = 5,
        Kernel                                       = 6,
        Vector16                                     = 7,
        Float16Buffer                                = 8,
        Float16                                      = 9,
        Float64                                      = 10,
        Int64                                        = 11,
        Int64Atomics                                 = 12,
        ImageBasics                                  = 13,
        ImageReadWrite                               = 14,
        ImageMipmap                                  = 15,
        Pipes                                        = 17,
        Groups                                       = 18,
        DeviceEnqueue                                = 19,
        LiteralSampler                               = 20,
        AtomicStorage                                = 21,
        Int16                                        = 22,
        TesselationPoitnSize                         = 23,
        GeometryPointSize                            = 24,
        ImageGatherExtended                          = 25,
        StorageImageMultisample                      = 27,
        UniformBufferArrayDynamicIndexing            = 28,
        SampledImageArrayDynamicIndexing             = 29,
        StorageBufferArrayDynamicIndexingBufferBlock = 30,
        StorageImageArrayDynamicIndexing             = 31,
        ClipDistance                                 = 32,
        CullDistance                                 = 33,
        ImageCubeArray                               = 34,
        SampleRateShading                            = 35,
        ImageRect                                    = 36,
        SampledRect                                  = 37,
        GenericPointer                               = 38,
        Int8                                         = 39,
        InputAttachment                              = 40,
        SparseResidency                              = 41,
        MinLod                                       = 42,
        Sampled1D                                    = 43,
        Image1D                                      = 44,
        SampledCubeArray                             = 45,
        SampledBuffer                                = 46,
        ImageBuffer                                  = 47,
        ImageMSArray                                 = 48,
        StorageImageExtendedFormats                  = 49,
        ImageQuery                                   = 50,
        DerivativeControl                            = 51,
        InterpolationFunction                        = 52,
        TransformFeedback                            = 53,
        GeometryStreams                              = 54,
        StorageImageReadWithoutFormat                = 55,
        StorageImageWriteWithoutFormat               = 56,
        MultiViewport                                = 57,
        SubgroupDispatch                             = 58,
        NamedBarrier                                 = 59,
        PipeStorage                                  = 60,
        SubgroupBallotKHR                            = 4423,
        DrawParameters                               = 4427,
        SubgroupVoteKHR                              = 4431,
        StorageBuffer16BitAccess                     = 4433,
        StorageUniformBufferBlock1                   = 4433,
        UniformAndStorageBuffer16BitAccess           = 4434,
        StorageUniform16                             = 4434,
        StoragePushConstant16                        = 4435,
        StorageInputOutput16                         = 4436,
        DeviceGroup                                  = 4437,
        MultiView                                    = 4439,
        VariablePointersStorageBuffer                = 4441,
        VariablePointers                             = 4442,
        SampleMaskOverrideCoverageNV                 = 4449,
        GeometryShaderPassthroughNV                  = 4451,
        ShaderViewportIndexLayerNV                   = 4454,
        ShaderViewportMaskNV                         = 4455,
        ShaderStereoViewNV                           = 4459,
        PerViewAttributesNV                          = 4460
    }
}
