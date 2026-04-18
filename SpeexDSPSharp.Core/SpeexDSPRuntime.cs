using System.Runtime.InteropServices;

//Resharper disable all
namespace SpeexDSPSharp.Core
{
    internal static class SpeexDSPRuntime
    {
        public static bool ShouldUseStaticImports(bool? useStatic)
        {
            return useStatic ?? IsStaticallyLinkedPlatform();
        }

        private static bool IsStaticallyLinkedPlatform()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS"));
        }
    }
}