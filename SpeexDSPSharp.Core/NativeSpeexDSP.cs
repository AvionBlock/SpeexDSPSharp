using SpeexDSPSharp.Core.SafeHandlers;
using SpeexDSPSharp.Core.Structures;
using System;
using System.Runtime.InteropServices;

//Resharper disable all
namespace SpeexDSPSharp.Core
{
    /// <summary>
    /// Native speexdsp handler that directly calls the exported speexdsp functions.
    /// </summary>
    public static class NativeSpeexDSP
    {
        private const string DllName = "speexdsp";

        //Jitter Buffer
        /// <summary>
        /// Initializes jitter buffer.
        /// </summary>
        /// <param name="step_size">Starting value for the size of concealment packets and delay adjustment steps. Can be changed at any time using <see cref="JitterBufferCtl.JITTER_BUFFER_SET_DELAY_STEP"/> and <see cref="JitterBufferCtl.JITTER_BUFFER_GET_CONCEALMENT_SIZE"/>.</param>
        /// <returns>Newly created jitter buffer state.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpeexDSPJitterBufferSafeHandler jitter_buffer_init(int step_size);

        /// <summary>
        /// Restores jitter buffer to its original state.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void jitter_buffer_reset(SpeexDSPJitterBufferSafeHandler jitter);

        /// <summary>
        /// Destroys jitter buffer.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void jitter_buffer_destroy(IntPtr jitter);

        /// <summary>
        /// Put one packet into the jitter buffer.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        /// <param name="packet">Incoming packet.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void jitter_buffer_put(SpeexDSPJitterBufferSafeHandler jitter, ref SpeexDSPJitterBufferPacket packet);

        /// <summary>
        /// Get one packet from the jitter buffer.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        /// <param name="packet">Returned packet.</param>
        /// <param name="desired_span">Number of samples (or units) we wish to get from the buffer (no guarantee).</param>
        /// <param name="start_offset">Timestamp for the returned packet.</param>
        /// <returns><see cref="JitterBufferState"/></returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int jitter_buffer_get(SpeexDSPJitterBufferSafeHandler jitter, ref SpeexDSPJitterBufferPacket packet, int desired_span, int* start_offset);

        /// <summary>
        /// Used right after <see cref="jitter_buffer_get(SpeexDSPJitterBufferSafeHandler, ref SpeexDSPJitterBufferPacket, int, int*)"/> to obtain another packet that would have the same timestamp. This is mainly useful for media where a single "frame" can be split into several packets.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        /// <param name="packet">Returned packet.</param>
        /// <returns><see cref="JitterBufferState"/></returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int jitter_buffer_get_another(SpeexDSPJitterBufferSafeHandler jitter, ref SpeexDSPJitterBufferPacket packet);

        /// <summary>
        /// N.A.
        /// </summary>
        /// <param name="jitter"></param>
        /// <param name="packet"></param>
        /// <param name="start_offset"></param>
        /// <returns></returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int jitter_buffer_update_delay(SpeexDSPJitterBufferSafeHandler jitter, ref SpeexDSPJitterBufferPacket packet, int* start_offset);

        /// <summary>
        /// Get pointer timestamp of jitter buffer.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        /// <returns>The pointer timestamp.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int jitter_buffer_get_pointer_timestamp(SpeexDSPJitterBufferSafeHandler jitter);

        /// <summary>
        /// Advance by one tick.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void jitter_buffer_tick(SpeexDSPJitterBufferSafeHandler jitter);

        /// <summary>
        /// Telling the jitter buffer about the remaining data in the application buffer.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        /// <param name="rem">Amount of data buffered by the application (timestamp units).</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void jitter_buffer_remaining_span(SpeexDSPJitterBufferSafeHandler jitter, int rem);

        /// <summary>
        /// Used like the ioctl function to control the jitter buffer parameters.
        /// </summary>
        /// <param name="jitter">Jitter buffer state.</param>
        /// <param name="request">ioctl-type request (one of the <see cref="JitterBufferCtl"/> macros).</param>
        /// <param name="ptr">Data exchanged to-from function.</param>
        /// <returns>0 if no error, -1 if request is unknown.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int jitter_buffer_ctl(SpeexDSPJitterBufferSafeHandler jitter, int request, void* ptr);


        //Echo Cancellation
        /// <summary>
        /// Creates a new echo canceler state.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms).</param>
        /// <param name="filter_length">Number of samples of echo to cancel (should generally correspond to 100-500 ms).</param>
        /// <returns>Newly-created echo canceler state.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpeexDSPEchoStateSafeHandler speex_echo_state_init(int frame_size, int filter_length);

        /// <summary>
        /// Creates a new multi-channel echo canceler state.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms).</param>
        /// <param name="filter_length">Number of samples of echo to cancel (should generally correspond to 100-500 ms).</param>
        /// <param name="nb_mic">Number of microphone channels.</param>
        /// <param name="nb_speaker">Number of speaker channels.</param>
        /// <returns>Newly-created echo canceler state.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpeexDSPEchoStateSafeHandler speex_echo_state_init_mc(int frame_size, int filter_length, int nb_mic, int nb_speaker);

        /// <summary>
        /// Destroys an echo canceler state.
        /// </summary>
        /// <param name="st">Echo canceler state.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void speex_echo_state_destroy(IntPtr st);

        /// <summary>
        /// Performs echo cancellation a frame, based on the audio sent to the speaker (no delay is added to playback in this form).
        /// </summary>
        /// <param name="st">Echo canceler state.</param>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void speex_echo_cancellation(SpeexDSPEchoStateSafeHandler st, short* rec, short* play, short* output);

        /// <summary>
        /// Perform echo cancellation using internal playback buffer, which is delayed by two frames to account for the delay introduced by most sound cards (but it could be off!).
        /// </summary>
        /// <param name="st">Echo canceler state.</param>
        /// <param name="rec">Signal from the microphone (near end + far end echo).</param>
        /// <param name="output">Returns near-end signal with echo removed.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void speex_echo_capture(SpeexDSPEchoStateSafeHandler st, short* rec, short* output);

        /// <summary>
        /// Let the echo canceler know that a frame was just queued to the sound card.
        /// </summary>
        /// <param name="st">Echo canceler state.</param>
        /// <param name="play">Signal played to the speaker (received from far end).</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void speex_echo_playback(SpeexDSPEchoStateSafeHandler st, short* play);

        /// <summary>
        /// Reset the echo canceler to its original state.
        /// </summary>
        /// <param name="st">Echo canceler state.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void speex_echo_state_reset(SpeexDSPEchoStateSafeHandler st);

        /// <summary>
        /// Used like the ioctl function to control the echo canceler parameters.
        /// </summary>
        /// <param name="st">Echo canceler state.</param>
        /// <param name="request">ioctl-type request (one of the <see cref="EchoCancellationCtl"/> macros).</param>
        /// <param name="ptr">Data exchanged to-from function.</param>
        /// <returns>0 if no error, -1 if request in unknown.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int speex_echo_ctl(SpeexDSPEchoStateSafeHandler st, int request, void* ptr);


        //Preprocessor
        /// <summary>
        /// Creates a new preprocessing state. You MUST create one state per channel processed.
        /// </summary>
        /// <param name="frame_size">Number of samples to process at one time (should correspond to 10-20 ms). Must be the same value as that used for the echo canceler for residual echo cancellation to work.</param>
        /// <param name="sampling_rate">Sampling rate used for the input.</param>
        /// <returns>Newly created preprocessor state.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SpeexDSPPreprocessStateSafeHandler speex_preprocess_state_init(int frame_size, int sampling_rate);

        /// <summary>
        /// Destroys a preprocessor state.
        /// </summary>
        /// <param name="st">Preprocessor state to destroy.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void speex_preprocess_state_destroy(IntPtr st);

        /// <summary>
        /// Preprocess a frame.
        /// </summary>
        /// <param name="st">Preprocessor state.</param>
        /// <param name="x">Audio sample vector (in and out). Must be same size as specified in <see cref="speex_preprocess_state_init(int, int)"/>.</param>
        /// <returns>Bool value for voice activity (1 for speech, 0 for noise/silence), ONLY if VAD turned on.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int speex_preprocess_run(SpeexDSPPreprocessStateSafeHandler st, short* x);

        /// <summary>
        /// Update preprocessor state, but do not compute the output.
        /// </summary>
        /// <param name="st">Preprocessor state.</param>
        /// <param name="x">Audio sample vector (in only). Must be same size as specified in <see cref="speex_preprocess_state_init(int, int)"/>.</param>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void speex_preprocess_estimate_update(SpeexDSPPreprocessStateSafeHandler st, short* x);

        /// <summary>
        /// Used like the ioctl function to control the preprocessor parameters.
        /// </summary>
        /// <param name="st">Preprocessor state.</param>
        /// <param name="request">request ioctl-type request (one of the SPEEX_PREPROCESS_* macros).</param>
        /// <param name="ptr">Data exchanged to-from function.</param>
        /// <returns>0 if no error, -1 if request in unknown.</returns>
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int speex_preprocess_ctl(SpeexDSPPreprocessStateSafeHandler st, int request, void* ptr);
    }
}
