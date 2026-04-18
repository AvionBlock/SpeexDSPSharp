using SpeexDSPSharp.Core.SafeHandlers;
using System;
using SpeexDSPSharp.Core.Interfaces;

//Resharper disable all
namespace SpeexDSPSharp.Core.Static
{
    /// <summary>
    /// Speexdsp preprocessor using static binding calls.
    /// </summary>
    public class SpeexDSPPreprocessor : ISpeexDSPPreprocessor
    {
        /// <summary>
        /// Direct safe handle for the <see cref="SpeexDSPPreprocessor"/>. IT IS NOT RECOMMENDED TO CLOSE THE HANDLE DIRECTLY! Instead use <see cref="Dispose(bool)"/> to dispose the handle and object safely.
        /// </summary>
        protected readonly SpeexDSPPreprocessStateSafeHandler _handler;
        private bool _disposed;

        /// <summary>
        /// Creates a new speexdsp echo canceler.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms). Must be the same value as that used for the echo canceller for residual echo cancellation to work.</param>
        /// <param name="sample_rate">Sampling rate used for the input.</param>
        public SpeexDSPPreprocessor(int frame_size, int sample_rate)
        {
            _handler = StaticNativeSpeexDSP.speex_preprocess_state_init(frame_size, sample_rate);
        }

        /// <summary>
        /// Speexdsp preprocessor destructor.
        /// </summary>
        ~SpeexDSPPreprocessor()
        {
            Dispose(false);
        }

#if NETSTANDARD2_1_OR_GREATER || NET8_0_OR_GREATER
        /// <inheritdoc/>
        public unsafe int Run(Span<byte> x)
        {
            ThrowIfDisposed();
            fixed (byte* xPtr = x)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_run(_handler, (short*)xPtr);
                CheckError(result);
                return result;
            }
        }

        /// <inheritdoc/>
        public unsafe int Run(Span<short> x)
        {
            ThrowIfDisposed();
            fixed (short* xPtr = x)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_run(_handler, xPtr);
                CheckError(result);
                return result;
            }
        }

        /// <inheritdoc/>
        public unsafe int Run(Span<float> x)
        {
            ThrowIfDisposed();
            fixed (float* xPtr = x)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_run(_handler, (short*)xPtr);
                CheckError(result);
                return result;
            }
        }
        
        /// <inheritdoc/>
        public unsafe void EstimateUpdate(Span<byte> x)
        {
            ThrowIfDisposed();
            fixed (byte* xPtr = x)
            {
                StaticNativeSpeexDSP.speex_preprocess_estimate_update(_handler, (short*)xPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EstimateUpdate(Span<short> x)
        {
            ThrowIfDisposed();
            fixed (short* xPtr = x)
            {
                StaticNativeSpeexDSP.speex_preprocess_estimate_update(_handler, xPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EstimateUpdate(Span<float> x)
        {
            ThrowIfDisposed();
            fixed (float* xPtr = x)
            {
                StaticNativeSpeexDSP.speex_preprocess_estimate_update(_handler, (short*)xPtr);
            }
        }
#endif

        /// <inheritdoc/>
        public unsafe int Run(byte[] x)
        {
            ThrowIfDisposed();
            fixed (byte* xPtr = x)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_run(_handler, (short*)xPtr);
                CheckError(result);
                return result;
            }
        }

        /// <inheritdoc/>
        public unsafe int Run(short[] x)
        {
            ThrowIfDisposed();
            fixed (short* xPtr = x)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_run(_handler, xPtr);
                CheckError(result);
                return result;
            }
        }

        /// <inheritdoc/>
        public unsafe int Run(float[] x)
        {
            ThrowIfDisposed();
            fixed (float* xPtr = x)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_run(_handler, (short*)xPtr);
                CheckError(result);
                return result;
            }
        }
        
        /// <inheritdoc/>
        public unsafe void EstimateUpdate(byte[] x)
        {
            ThrowIfDisposed();
            fixed (byte* xPtr = x)
            {
                StaticNativeSpeexDSP.speex_preprocess_estimate_update(_handler, (short*)xPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EstimateUpdate(short[] x)
        {
            ThrowIfDisposed();
            fixed (short* xPtr = x)
            {
                StaticNativeSpeexDSP.speex_preprocess_estimate_update(_handler, xPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe void EstimateUpdate(float[] x)
        {
            ThrowIfDisposed();
            fixed (float* xPtr = x)
            {
                StaticNativeSpeexDSP.speex_preprocess_estimate_update(_handler, (short*)xPtr);
            }
        }

        /// <inheritdoc/>
        public unsafe int Ctl<T>(PreprocessorCtl request, ref T value) where T : unmanaged
        {
            ThrowIfDisposed();
            fixed (void* valuePtr = &value)
            {
                var result = StaticNativeSpeexDSP.speex_preprocess_ctl(_handler, (int)request, valuePtr);
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
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
        }

        /// <summary>
        /// Checks if there is a speexdsp error and throws if the error is a negative value.
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
