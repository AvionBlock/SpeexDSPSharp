using System;
using SpeexDSPSharp.Core.Structures;

//Resharper disable all
namespace SpeexDSPSharp.Core.Interfaces
{
    /// <summary>
    /// A Speexdsp echo jitter buffer interface.
    /// </summary>
    public interface ISpeexDSPJitterBuffer : IDisposable
    {
        /// <summary>
        /// Reset the jitter buffer to its original state.
        /// </summary>
        void Reset();

        /// <summary>
        /// Put one packet into the jitter buffer.
        /// </summary>
        /// <param name="packet">Incoming packet.</param>
        void Put(ref SpeexDSPJitterBufferPacket packet);

        /// <summary>
        /// Get one packet from the jitter buffer.
        /// </summary>
        /// <param name="packet">Returned packet.</param>
        /// <param name="desired_span">Number of samples (or units) we wish to get from the buffer (no guarantee).</param>
        /// <param name="start_offset">Timestamp for the returned packet.</param>
        /// <returns><see cref="JitterBufferState"/></returns>
        public unsafe JitterBufferState Get(ref SpeexDSPJitterBufferPacket packet, int desired_span,
            ref int start_offset);

        /// <summary>
        /// Used right after jitter_buffer_get() to obtain another packet that would have the same timestamp. This is mainly useful for media where a single "frame" can be split into several packets.
        /// </summary>
        /// <param name="packet">Returned packet.</param>
        /// <returns><see cref="JitterBufferState"/></returns>
        int GetAnother(ref SpeexDSPJitterBufferPacket packet);

        /// <summary>
        /// N.A.
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="start_offset"></param>
        /// <returns></returns>
        int UpdateDelay(ref SpeexDSPJitterBufferPacket packet, ref int start_offset);

        /// <summary>
        /// Get pointer timestamp of jitter buffer.
        /// </summary>
        /// <returns>I have no clue what this returns.</returns>
        int GetPointerTimestamp();

        /// <summary>
        /// Advance by one tick.
        /// </summary>
        void Tick();

        /// <summary>
        /// Telling the jitter buffer about the remaining data in the application buffer.
        /// </summary>
        /// <param name="remaining_span">Amount of data buffered by the application (timestamp units).</param>
        void RemainingSpan(int remaining_span);

        /// <summary>
        /// Performs a ctl request.
        /// </summary>
        /// <typeparam name="T">The type you want to input/output.</typeparam>
        /// <param name="request">The request you want to specify.</param>
        /// <param name="value">The input/output value.</param>
        /// <returns>0 if no error, -1 if request is unknown.</returns>
        int Ctl<T>(JitterBufferCtl request, ref T value) where T : unmanaged;
    }
}