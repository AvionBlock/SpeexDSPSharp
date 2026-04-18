using System;

namespace SpeexDSPSharp.Core.Interfaces
{    
    /// <summary>
    /// A Speexdsp echo preprocessor interface.
    /// </summary>
    public interface ISpeexDSPPreprocessor : IDisposable
    {
        #if NETSTANDARD2_1_OR_GREATER || NET8_0_OR_GREATER
        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        int Run(Span<byte> x);

        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        int Run(Span<short> x);

        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        int Run(Span<float> x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        void EstimateUpdate(Span<byte> x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        void EstimateUpdate(Span<short> x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        void EstimateUpdate(Span<float> x);
#endif

        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        int Run(byte[] x);

        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        int Run(short[] x);

        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        int Run(float[] x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        void EstimateUpdate(byte[] x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        void EstimateUpdate(short[] x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="SpeexDSPPreprocessor(int, int)" />.</param>
        void EstimateUpdate(float[] x);

        /// <summary>
        /// Performs a ctl request.
        /// </summary>
        /// <typeparam name="T">The type you want to input/output.</typeparam>
        /// <param name="request">The request you want to specify.</param>
        /// <param name="value">The input/output value.</param>
        /// <returns></returns>
        int Ctl<T>(PreprocessorCtl request, ref T value) where T : unmanaged;
    }
}