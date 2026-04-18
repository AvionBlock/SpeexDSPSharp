using System;
using SpeexDSPSharp.Core.Interfaces;

//Resharper disable all
namespace SpeexDSPSharp.Core
{
    /// <summary>
    /// A Speexdsp echo canceller.
    /// </summary>
    public class SpeexDSPEchoCanceler : ISpeexDSPEchoCanceler
    {
        /// <summary>
        /// Direct echo canceler for <see cref="SpeexDSPEchoCanceler"/>. You can close this directly.
        /// </summary>
        protected ISpeexDSPEchoCanceler _echoCanceler;

        /// <summary>
        /// Creates a new speexdsp echo canceler.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms).</param>
        /// <param name="filter_length">Number of samples of echo to cancel (should generally correspond to 100-500 ms).</param>
        /// <param name="use_static">Set to <see langword="true"/> to force static imports, <see langword="false"/> to force dynamic imports, or <see langword="null"/> to auto-select based on platform.</param>
        public SpeexDSPEchoCanceler(int frame_size, int filter_length, bool? use_static = null)
        {
            var useStatic = SpeexDSPRuntime.ShouldUseStaticImports(use_static);
            _echoCanceler = useStatic 
                ? (ISpeexDSPEchoCanceler)new Static.SpeexDSPEchoCanceler(frame_size, filter_length) : 
                new Dynamic.SpeexDSPEchoCanceler(frame_size, filter_length);
        }

        /// <summary>
        /// Creates a new multi-channel speexdsp echo canceler.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms).</param>
        /// <param name="filter_length">Number of samples of echo to cancel (should generally correspond to 100-500 ms).</param>
        /// <param name="nb_mic">Number of microphone channels.</param>
        /// <param name="nb_speaker">Number of speaker channels.</param>
        /// <param name="use_static">Set to <see langword="true"/> to force static imports, <see langword="false"/> to force dynamic imports, or <see langword="null"/> to auto-select based on platform.</param>
        public SpeexDSPEchoCanceler(int frame_size, int filter_length, int nb_mic, int nb_speaker, bool use_static)
        {
            _echoCanceler = use_static 
                ? (ISpeexDSPEchoCanceler)new Static.SpeexDSPEchoCanceler(frame_size, filter_length, nb_mic, nb_speaker) : 
                new Dynamic.SpeexDSPEchoCanceler(frame_size, filter_length, nb_mic, nb_speaker);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _echoCanceler.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public void Reset()
        {
            _echoCanceler.Reset();
        }

#if NETSTANDARD2_1_OR_GREATER || NET8_0_OR_GREATER
        /// <inheritdoc/>
        public void EchoPlayback(Span<byte> play)
        {
            _echoCanceler.EchoPlayback(play);
        }

        /// <inheritdoc/>
        public void EchoPlayback(Span<short> play)
        {
            _echoCanceler.EchoPlayback(play);
        }

        /// <inheritdoc/>
        public void EchoPlayback(Span<float> play)
        {
            _echoCanceler.EchoPlayback(play);
        }
        
        /// <inheritdoc/>
        public void EchoCapture(Span<byte> rec, Span<byte> output)
        {
            _echoCanceler.EchoCapture(rec, output);
        }

        /// <inheritdoc/>
        public void EchoCapture(Span<short> rec, Span<short> output)
        {
            _echoCanceler.EchoCapture(rec, output);
        }

        /// <inheritdoc/>
        public void EchoCapture(Span<float> rec, Span<float> output)
        {
            _echoCanceler.EchoCapture(rec, output);
        }
        
        /// <inheritdoc/>
        public void EchoCancel(Span<byte> rec, Span<byte> play, Span<byte> output)
        {
            _echoCanceler.EchoCancel(rec, play, output);
        }

        /// <inheritdoc/>
        public void EchoCancel(Span<short> rec, Span<short> play, Span<short> output)
        {
            _echoCanceler.EchoCancel(rec, play, output);
        }

        /// <inheritdoc/>
        public void EchoCancel(Span<float> rec, Span<float> play, Span<float> output)
        {
            _echoCanceler.EchoCancel(rec, play, output);
        }
#endif
        /// <inheritdoc/>
        public void EchoPlayback(byte[] play)
        {
            _echoCanceler.EchoPlayback(play);
        }

        /// <inheritdoc/>
        public void EchoPlayback(short[] play)
        {
            _echoCanceler.EchoPlayback(play);
        }

        /// <inheritdoc/>
        public void EchoPlayback(float[] play)
        {
            _echoCanceler.EchoPlayback(play);
        }
        
        /// <inheritdoc/>
        public void EchoCapture(byte[] rec, byte[] output)
        {
            _echoCanceler.EchoCapture(rec, output);
        }

        /// <inheritdoc/>
        public void EchoCapture(short[] rec, short[] output)
        {
            _echoCanceler.EchoCapture(rec, output);
        }

        /// <inheritdoc/>
        public void EchoCapture(float[] rec, float[] output)
        {
            _echoCanceler.EchoCapture(rec, output);
        }
        
        /// <inheritdoc/>
        public void EchoCancel(byte[] rec, byte[] play, byte[] output)
        {
            _echoCanceler.EchoCancel(rec, play, output);
        }

        /// <inheritdoc/>
        public void EchoCancel(short[] rec, short[] play, short[] output)
        {
            _echoCanceler.EchoCancel(rec, play, output);
        }

        /// <inheritdoc/>
        public void EchoCancel(float[] rec, float[] play, float[] output)
        {
            _echoCanceler.EchoCancel(rec, play, output);
        }
        
        /// <inheritdoc/>
        public int Ctl<T>(EchoCancellationCtl request, ref T value) where T : unmanaged
        {
            return _echoCanceler.Ctl(request, ref value);
        }
    }
}
