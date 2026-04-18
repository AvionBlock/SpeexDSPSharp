using System;

//Resharper disable all
namespace SpeexDSPSharp.Core
{
    /// <summary>
    /// A speexdsp exception.
    /// </summary>
    public class SpeexDSPException : Exception
    {
        /// <summary>
        /// Constructs a speexdsp exception.
        /// </summary>
        SpeexDSPException() { }

        /// <summary>
        /// Constructs a speexdsp exception.
        /// </summary>
        /// <param name="message"></param>
        public SpeexDSPException(string message) : base(message) { }

        /// <summary>
        /// Constructs a speexdsp exception.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The root exception.</param>
        public SpeexDSPException(string message, Exception innerException) : base(message, innerException) { }
    }
}
