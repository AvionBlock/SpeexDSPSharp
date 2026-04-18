using System;

//Resharper disable all
namespace SpeexDSPSharp.Core.Interfaces
{
    /// <summary>
    /// A Speexdsp echo cancellation interface.
    /// </summary>
    public interface ISpeexDSPEchoCanceler : IDisposable
    {
        /// <summary>
        /// Reset the echo canceler to its original state.
        /// </summary>
        void Reset();

#if NETSTANDARD2_1_OR_GREATER || NET8_0_OR_GREATER
        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        void EchoPlayback(Span<byte> play);

        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        void EchoPlayback(Span<short> play);

        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        void EchoPlayback(Span<float> play);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCapture(Span<byte> rec, Span<byte> output);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCapture(Span<short> rec, Span<short> output);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCapture(Span<float> rec, Span<float> output);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCancel(Span<byte> rec, Span<byte> play, Span<byte> output);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCancel(Span<short> rec, Span<short> play, Span<short> output);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCancel(Span<float> rec, Span<float> play, Span<float> output);
#endif
        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        void EchoPlayback(byte[] play);

        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        void EchoPlayback(short[] play);

        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        void EchoPlayback(float[] play);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCapture(byte[] rec, byte[] output);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCapture(short[] rec, short[] output);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCapture(float[] rec, float[] output);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCancel(byte[] rec, byte[] play, byte[] output);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCancel(short[] rec, short[] play, short[] output);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        void EchoCancel(float[] rec, float[] play, float[] output);

        /// <summary>
        /// Performs a ctl request.
        /// </summary>
        /// <typeparam name="T">The type you want to input/output.</typeparam>
        /// <param name="request">The request you want to specify.</param>
        /// <param name="value">The input/output value.</param>
        /// <returns>0 if no error, -1 if request is unknown.</returns>
        int Ctl<T>(EchoCancellationCtl request, ref T value) where T : unmanaged;
    }
}
