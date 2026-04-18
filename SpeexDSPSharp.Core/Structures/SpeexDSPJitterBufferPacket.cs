using System.Runtime.InteropServices;

//Resharper disable all
namespace SpeexDSPSharp.Core.Structures
{
    /// <summary>
    /// Definition of an incoming packet.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SpeexDSPJitterBufferPacket
    {
        /// <summary>
        /// Data bytes contained in the packet.
        /// </summary>
        public byte* data;

        /// <summary>
        /// Length of the packet in bytes.
        /// </summary>
        public uint len;

        /// <summary>
        /// Timestamp for the packet
        /// </summary>
        public uint timestamp;

        /// <summary>
        /// Time covered by the packet (same units as timestamp).
        /// </summary>
        public uint span;

        /// <summary>
        /// RTP Sequence number if available (0 otherwise).
        /// </summary>
        public ushort sequence;

        /// <summary>
        /// Put whatever data you like here (it's ignored by the jitter buffer).
        /// </summary>
        public uint user_data;

        /// <summary>
        /// Constructs a new <see cref="SpeexDSPJitterBufferPacket(byte[], uint)"/>.
        /// </summary>
        /// <param name="inputData">The data you want to input/output.</param>
        /// <param name="length">The length of the input data.</param>
        public SpeexDSPJitterBufferPacket(byte[] inputData, uint length)
        {
            fixed (byte* inputPtr = inputData)
            {
                data = inputPtr;
            }
            len = length;
            timestamp = 0;
            span = 0;
            sequence = 0;
            user_data = 0;
        }
    }
}