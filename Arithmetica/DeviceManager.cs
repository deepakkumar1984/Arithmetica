using Arithmetica.Cpu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica
{
    internal class DeviceManager
    {
        public static IAllocator Current { get; set; } = new CpuAllocator();

        //public static bool IsCuda { get; set; }

        //public static void SetBackend(Backend deviceType, int gpuId = 0)
        //{
        //    switch (deviceType)
        //    {
        //        case Backend.CPU:
        //            Current = new CpuAllocator();
        //            break;
        //        case Backend.CUDA:
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }

    public enum Backend
    {
        CPU,
        CUDA
    }
}
