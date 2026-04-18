using SpeexDSPSharp.Core.Structures;
using System;
using SpeexDSPSharp.Core.Interfaces;

//Resharper disable all
namespace SpeexDSPSharp.Core
{
    /// <summary>
    /// Speexdsp jitter buffer.
    /// </summary>
    public class SpeexDSPJitterBuffer : ISpeexDSPJitterBuffer
    {
        /// <summary>
        /// Direct jitter buffer for <see cref="SpeexDSPJitterBuffer"/>. You can close this directly.
        /// </summary>
        protected ISpeexDSPJitterBuffer _jitterBuffer;

        /// <summary>
        /// Creates a new speexdsp jitter buffer.
        /// </summary>
        /// <param name="step_size">Starting value for the size of concealment packets and delay adjustment steps. Can be changed at any time using JITTER_BUFFER_SET_DELAY_STEP and JITTER_BUFFER_GET_CONCEALMENT_SIZE.</param>
        /// <param name="use_static">Set to <see langword="true"/> to force static imports, <see langword="false"/> to force dynamic imports, or <see langword="null"/> to auto-select based on platform.</param>
        public SpeexDSPJitterBuffer(int step_size, bool? use_static = null)
        {
            var useStatic = SpeexDSPRuntime.ShouldUseStaticImports(use_static);
            _jitterBuffer = useStatic 
                ? (ISpeexDSPJitterBuffer)new Static.SpeexDSPJitterBuffer(step_size) : 
                new Dynamic.SpeexDSPJitterBuffer(step_size);
        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            _jitterBuffer.Dispose();
            GC.SuppressFinalize(this);
        }
        
        /// <inheritdoc/>
        public void Reset()
        {
            _jitterBuffer.Reset();
        }

        /// <inheritdoc/>
        public void Put(ref SpeexDSPJitterBufferPacket packet)
        {
            _jitterBuffer.Put(ref packet);
        }

        /// <inheritdoc/>
        public unsafe JitterBufferState Get(ref SpeexDSPJitterBufferPacket packet, int desired_span, ref int start_offset)
        {
            return _jitterBuffer.Get(ref packet, desired_span, ref start_offset);
        }

        /// <inheritdoc/>
        public int GetAnother(ref SpeexDSPJitterBufferPacket packet)
        {
            return _jitterBuffer.GetAnother(ref packet);
        }

        /// <inheritdoc/>
        public unsafe int UpdateDelay(ref SpeexDSPJitterBufferPacket packet, ref int start_offset)
        {
            return _jitterBuffer.UpdateDelay(ref packet, ref start_offset);
        }

        /// <inheritdoc/>
        public int GetPointerTimestamp()
        {
            return _jitterBuffer.GetPointerTimestamp();
        }

        /// <inheritdoc/>
        public void Tick()
        {
            _jitterBuffer.Tick();
        }

        /// <inheritdoc/>
        public void RemainingSpan(int remaining_span)
        {
            _jitterBuffer.RemainingSpan(remaining_span);
        }

        /// <inheritdoc/>
        public unsafe int Ctl<T>(JitterBufferCtl request, ref T value) where T : unmanaged
        {
            return _jitterBuffer.Ctl(request, ref value);
        }
    }
}
