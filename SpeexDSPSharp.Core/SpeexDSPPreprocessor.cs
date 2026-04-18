using System;
using SpeexDSPSharp.Core.Interfaces;

//Resharper disable all
namespace SpeexDSPSharp.Core
{
    /// <summary>
    /// Speexdsp preprocessor.
    /// </summary>
    public class SpeexDSPPreprocessor : ISpeexDSPPreprocessor
    {
        /// <summary>
        /// Direct speex preprocessor for <see cref="SpeexDSPPreprocessor"/>. You can close this directly.
        /// </summary>
        protected ISpeexDSPPreprocessor _preprocessor;

        /// <summary>
        /// Creates a new speexdsp echo canceler.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms). Must be the same value as that used for the echo canceler for residual echo cancellation to work.</param>
        /// <param name="sample_rate">Sampling rate used for the input.</param>
        /// <param name="use_static">Set to <see langword="true"/> to force static imports, <see langword="false"/> to force dynamic imports, or <see langword="null"/> to auto-select based on platform.</param>
        public SpeexDSPPreprocessor(int frame_size, int sample_rate, bool? use_static = null)
        {
            var useStatic = SpeexDSPRuntime.ShouldUseStaticImports(use_static);
            _preprocessor = useStatic 
                ? (ISpeexDSPPreprocessor)new Static.SpeexDSPPreprocessor(frame_size, sample_rate) : 
                new Dynamic.SpeexDSPPreprocessor(frame_size, sample_rate);
        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            _preprocessor.Dispose();
            GC.SuppressFinalize(this);
        }

#if NETSTANDARD2_1_OR_GREATER || NET8_0_OR_GREATER
        /// <inheritdoc/>
        public int Run(Span<byte> x)
        {
            return _preprocessor.Run(x);
        }

        /// <inheritdoc/>
        public int Run(Span<short> x)
        {
            return _preprocessor.Run(x);
        }

        /// <inheritdoc/>
        public int Run(Span<float> x)
        {
            return _preprocessor.Run(x);
        }
        
        /// <inheritdoc/>
        public void EstimateUpdate(Span<byte> x)
        {
            _preprocessor.EstimateUpdate(x);
        }

        /// <inheritdoc/>
        public void EstimateUpdate(Span<short> x)
        {
            _preprocessor.EstimateUpdate(x);
        }

        /// <inheritdoc/>
        public void EstimateUpdate(Span<float> x)
        {
            _preprocessor.EstimateUpdate(x);
        }
#endif

        /// <inheritdoc/>
        public int Run(byte[] x)
        {
            return _preprocessor.Run(x);
        }

        /// <inheritdoc/>
        public int Run(short[] x)
        {
            return _preprocessor.Run(x);
        }

        /// <inheritdoc/>
        public int Run(float[] x)
        {
            return _preprocessor.Run(x);
        }
        
        /// <inheritdoc/>
        public void EstimateUpdate(byte[] x)
        {
            _preprocessor.EstimateUpdate(x);
        }

        /// <inheritdoc/>
        public void EstimateUpdate(short[] x)
        {
            _preprocessor.EstimateUpdate(x);
        }

        /// <inheritdoc/>
        public void EstimateUpdate(float[] x)
        {
            _preprocessor.EstimateUpdate(x);
        }

        /// <inheritdoc/>
        public int Ctl<T>(PreprocessorCtl request, ref T value) where T : unmanaged
        {
            return _preprocessor.Ctl(request, ref value);
        }
    }
}
