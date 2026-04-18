using SpeexDSPSharp.Core.SafeHandlers;
using System;
using SpeexDSPSharp.Core.Interfaces;

//Resharper disable all
namespace SpeexDSPSharp.Core.Dynamic
{
    /// <summary>
    /// Speexdsp echo cancellation using dynamic binding calls.
    /// </summary>
    public class SpeexDSPEchoCanceler : ISpeexDSPEchoCanceler
    {
        /// <summary>
        /// Direct safe handle for the <see cref="SpeexDSPEchoCanceler"/>. IT IS NOT RECOMMENDED TO CLOSE THE HANDLE DIRECTLY! Instead use <see cref="Dispose(bool)"/> to dispose the handle and object safely.
        /// </summary>
        protected readonly SpeexDSPEchoStateSafeHandler _handler;
        private bool _disposed;

        /// <summary>
        /// Creates a new speexdsp echo canceler.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms).</param>
        /// <param name="filter_length">Number of samples of echo to cancel (should generally correspond to 100-500 ms).</param>
        public SpeexDSPEchoCanceler(int frame_size, int filter_length)
        {
            _handler = NativeSpeexDSP.speex_echo_state_init(frame_size, filter_length);
        }

        /// <summary>
        /// Creates a new multi-channel speexdsp echo canceler.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms).</param>
        /// <param name="filter_length">Number of samples of echo to cancel (should generally correspond to 100-500 ms).</param>
        /// <param name="nb_mic">Number of microphone channels.</param>
        /// <param name="nb_speaker">Number of speaker channels.</param>
        public SpeexDSPEchoCanceler(int frame_size, int filter_length, int nb_mic, int nb_speaker)
        {
            _handler = NativeSpeexDSP.speex_echo_state_init_mc(frame_size, filter_length, nb_mic, nb_speaker);
        }

        /// <summary>
        /// Speexdsp echo canceler destructor.
        /// </summary>
        ~SpeexDSPEchoCanceler()
        {
            Dispose(false);
        }
        
        /// <inheritdoc/>
        public void Reset()
        {
            ThrowIfDisposed();
            NativeSpeexDSP.speex_echo_state_reset(_handler);
        }

#if NETSTANDARD2_1_OR_GREATER || NET8_0_OR_GREATER
        /// <inheritdoc/>
        public unsafe void EchoPlayback(Span<byte> play)
        {
            ThrowIfDisposed();
            fixed (byte* playPtr = play)
            {
                NativeSpeexDSP.speex_echo_playback(_handler, (short*)playPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoPlayback(Span<short> play)
        {
            ThrowIfDisposed();
            fixed (short* playPtr = play)
            {
                NativeSpeexDSP.speex_echo_playback(_handler, playPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoPlayback(Span<float> play)
        {
            ThrowIfDisposed();
            fixed (float* playPtr = play)
            {
                NativeSpeexDSP.speex_echo_playback(_handler, (short*)playPtr);
            }
        }
        
        /// <inheritdoc/>
        public unsafe void EchoCapture(Span<byte> rec, Span<byte> output)
        {
            ThrowIfDisposed();
            fixed (byte* recPtr = rec)
            fixed (byte* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_capture(_handler, (short*)recPtr, (short*)outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCapture(Span<short> rec, Span<short> output)
        {
            ThrowIfDisposed();
            fixed (short* recPtr = rec)
            fixed (short* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_capture(_handler, recPtr, outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCapture(Span<float> rec, Span<float> output)
        {
            ThrowIfDisposed();
            fixed (float* recPtr = rec)
            fixed (float* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_capture(_handler, (short*)recPtr, (short*)outPtr);
            }
        }
        
        /// <inheritdoc/>
        public unsafe void EchoCancel(Span<byte> rec, Span<byte> play, Span<byte> output)
        {
            ThrowIfDisposed();

            fixed (byte* recPtr = rec)
            fixed (byte* playPtr = play)
            fixed (byte* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_cancellation(_handler, (short*)recPtr, (short*)playPtr, (short*)outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCancel(Span<short> rec, Span<short> play, Span<short> output)
        {
            ThrowIfDisposed();

            fixed (short* recPtr = rec)
            fixed (short* playPtr = play)
            fixed (short* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_cancellation(_handler, recPtr, playPtr, outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCancel(Span<float> rec, Span<float> play, Span<float> output)
        {
            ThrowIfDisposed();

            fixed (float* recPtr = rec)
            fixed (float* playPtr = play)
            fixed (float* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_cancellation(_handler, (short*)recPtr, (short*)playPtr, (short*)outPtr);
            }
        }
#endif
        /// <inheritdoc/>
        public unsafe void EchoPlayback(byte[] play)
        {
            ThrowIfDisposed();
            fixed (byte* playPtr = play)
            {
                NativeSpeexDSP.speex_echo_playback(_handler, (short*)playPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoPlayback(short[] play)
        {
            ThrowIfDisposed();
            fixed (short* playPtr = play)
            {
                NativeSpeexDSP.speex_echo_playback(_handler, playPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoPlayback(float[] play)
        {
            ThrowIfDisposed();
            fixed (float* playPtr = play)
            {
                NativeSpeexDSP.speex_echo_playback(_handler, (short*)playPtr);
            }
        }
        
        /// <inheritdoc/>
        public unsafe void EchoCapture(byte[] rec, byte[] output)
        {
            ThrowIfDisposed();
            fixed (byte* recPtr = rec)
            fixed (byte* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_capture(_handler, (short*)recPtr, (short*)outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCapture(short[] rec, short[] output)
        {
            ThrowIfDisposed();
            fixed (short* recPtr = rec)
            fixed (short* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_capture(_handler, recPtr, outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCapture(float[] rec, float[] output)
        {
            ThrowIfDisposed();
            fixed (float* recPtr = rec)
            fixed (float* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_capture(_handler, (short*)recPtr, (short*)outPtr);
            }
        }
        
        /// <inheritdoc/>
        public unsafe void EchoCancel(byte[] rec, byte[] play, byte[] output)
        {
            ThrowIfDisposed();

            fixed (byte* recPtr = rec)
            fixed (byte* playPtr = play)
            fixed (byte* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_cancellation(_handler, (short*)recPtr, (short*)playPtr, (short*)outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCancel(short[] rec, short[] play, short[] output)
        {
            ThrowIfDisposed();

            fixed (short* recPtr = rec)
            fixed (short* playPtr = play)
            fixed (short* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_cancellation(_handler, recPtr, playPtr, outPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EchoCancel(float[] rec, float[] play, float[] output)
        {
            ThrowIfDisposed();

            fixed (float* recPtr = rec)
            fixed (float* playPtr = play)
            fixed (float* outPtr = output)
            {
                NativeSpeexDSP.speex_echo_cancellation(_handler, (short*)recPtr, (short*)playPtr, (short*)outPtr);
            }
        }
        
        /// <inheritdoc/>
        public unsafe int Ctl<T>(EchoCancellationCtl request, ref T value) where T : unmanaged
        {
            ThrowIfDisposed();
            fixed (void* valuePtr = &value)
            {
                var result = NativeSpeexDSP.speex_echo_ctl(_handler, (int)request, valuePtr);
                CheckError(result);
                return result;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose logic.
        /// </summary>
        /// <param name="disposing">Set to true if fully disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (!_handler.IsClosed)
                    _handler.Close();
            }

            _disposed = true;
        }

        /// <summary>
        /// Throws an exception if this object is disposed or the handler is closed.
        /// </summary>
        /// <exception cref="ObjectDisposedException" />
        protected virtual void ThrowIfDisposed()
        {
            if (_disposed || _handler.IsClosed)
                throw new ObjectDisposedException(GetType().FullName);
        }

        /// <summary>
        /// Checks if there is an speex dsp error and throws if the error is a negative value.
        /// </summary>
        /// <param name="error">The error code to input.</param>
        /// <exception cref="SpeexDSPException"></exception>
        protected static void CheckError(int error)
        {
            if (error < 0)
                throw new SpeexDSPException(error.ToString());
        }
    }
}
