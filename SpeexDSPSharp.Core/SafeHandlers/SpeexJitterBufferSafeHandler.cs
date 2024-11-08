﻿using System;
using System.Runtime.InteropServices;

namespace SpeexDSPSharp.Core.SafeHandlers
{
    public class SpeexJitterBufferSafeHandler : SafeHandle
    {
        public SpeexJitterBufferSafeHandler() : base(IntPtr.Zero, true)
        {

        }

        public override bool IsInvalid => handle == IntPtr.Zero;
        protected override bool ReleaseHandle()
        {
            NativeSpeexDSP.jitter_buffer_destroy(handle);
            return true;
        }
    }
}
