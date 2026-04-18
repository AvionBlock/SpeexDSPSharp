using System;
using System.Runtime.InteropServices;

//Resharper disable all
namespace SpeexDSPSharp.Core.SafeHandlers
{
    /// <summary>
    /// Managed wrapper over the SpeexDSPEcho state.
    /// </summary>
    public class SpeexDSPEchoStateSafeHandler : SafeHandle
    {
        /// <summary>
        /// Creates a new <see cref="SpeexDSPEchoStateSafeHandler"/>.
        /// </summary>
        public SpeexDSPEchoStateSafeHandler() : base(IntPtr.Zero, true)
        {

        }

        /// <inheritdoc/>
        public override bool IsInvalid => handle == IntPtr.Zero;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            NativeSpeexDSP.speex_echo_state_destroy(handle);
            return true;
        }
    }

    /// <summary>
    /// Managed wrapper over the StaticSpeexDSPEcho state.
    /// </summary>
    public class StaticSpeexDSPEchoStateSafeHandler : SpeexDSPEchoStateSafeHandler
    {
        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            StaticNativeSpeexDSP.speex_echo_state_destroy(handle);
            return true;
        }
    }
}
