using System;

namespace OpenCl
{
    public static class Cl
    {
        [ThreadStatic] private static int work_dim;
        [ThreadStatic] private static int[] global_size;
        [ThreadStatic] private static int[] global_id;
        [ThreadStatic] private static int[] local_size;
        [ThreadStatic] private static int[] local_id;
        [ThreadStatic] private static int[] num_groups;
        [ThreadStatic] private static int[] group_id;

//        get_work_dim    Number of dimensions in use
//        get_global_size Number of global work items
//        get_global_id   Global work item ID value
//        get_local_size  Number of local work items
//        get_enqueued_local_size Same as get_local_size(dimindx) if the kernel is executed with a uniform work-group size
//        get_local_id    Local work item ID
//        get_num_groups  Number of work groups
//        get_group_id    Work group ID
//        get_global_offset   Work offset
//        get_global_linear_id    Work-items 1-dimensional global ID
//        get_local_linear_id

        [ClName("get_work_dim")]
        public static int GetWorkDim()
        {
            return work_dim;
        }
        
        [ClName("get_global_size")]
        public static int GetGlobalSize(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return global_size[dim];
        }

        [ClName("get_global_id")]
        public static int GetGlobalId(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return global_id[dim];
        }

        [ClName("get_local_size")]
        public static int GetLocalSize(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return local_size[dim];
        }

        [ClName("get_enqueued_local_size")]
        public static int GetEnqueuedLocalSize(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return local_size[dim];
        }

        [ClName("get_local_id")]
        public static int GetLocalId(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return local_id[dim];
        }

        [ClName("get_num_groups")]
        public static int GetNumGroups(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return num_groups[dim];
        }

        [ClName("get_group_id")]
        public static int GetGroupId(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return group_id[dim];
        }

        [ClName("get_global_offset")]
        public static int GetGlobalOffset(int dim)
        {
            if (dim < 0 || dim >= work_dim) {
                throw new ArgumentOutOfRangeException(String.Format("Invalid value for dim: expected 0 <= dim < {0}, found dim = {1}", work_dim, dim));
            }
            return 0;
        }

        [ClName("get_global_linear_id")]
        public static int GetGlobalLinearId()
        {
            var dimprod = 1;
            var result = 0;
            for (var d=work_dim-1; d>=0; d--) {
                result += global_id[d]*dimprod;
                dimprod *= global_size[d];
            }
            return result;
        }

        [ClName("get_local_linear_id")]
        public static int GetLocalLinearId()
        {
            var dimprod = 1;
            var result = 0;
            for (var d=work_dim-1; d>=0; d--) {
                result += local_id[d]*dimprod;
                dimprod *= local_size[d];
            }
            return result;
        }

        public static void RunKernel(int[] globalSize, int[] localSize, Delegate kernel, params object[] args)
        {
            var ndims = globalSize.Length;
            work_dim = ndims;
            global_size = new int[ndims];
            Array.Copy(globalSize, global_size, ndims);
            local_size = new int[ndims];
            Array.Copy(localSize, local_size, ndims);
            num_groups = new int[ndims];
            for (var i=0; i<ndims; i++) {
                var gi = global_size[i]/local_size[i];
                if (gi*local_size[i] != global_size[i]) {
                    throw new ArgumentException($"Incompatible global and local work size in dimension {i}: {global_size[i]}/{local_size[i]}.");
                }
                num_groups[i] = gi;
            }
            global_id = new int[ndims];
            local_id = new int[ndims];
            group_id = new int[ndims];
            for (var i=0; i<ndims; i++) {
                global_id[i] = 0;
                local_id[i] = 0;
                group_id[i] = 0;
            }
            while (true)
            {
                //Console.WriteLine("invoke kernel for ({0},{1})", global_id[0], global_id[1]);
                kernel.DynamicInvoke(args);
                for (var i=ndims-1; i>=0; i--) {
                    global_id[i]++;
                    local_id[i]++;
                    if (local_id[i] == local_size[i]) {
                        local_id[i] = 0;
                        group_id[i]++;
                    }
                    if (global_id[i] < global_size[i] || i == 0) {
                        break;
                    }
                    global_id[i] = 0;
                    local_id[i] = 0;
                    group_id[i] = 0;
                }
                if (global_id[0] == global_size[0]) {
                    break;
                }
            }
        }
    }
}

