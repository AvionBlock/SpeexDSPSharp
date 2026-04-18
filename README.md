# SpeexDSPSharp
SpeexDSPSharp aims to be a cross platform C# compatible version of the native speexdsp library. The code uses the native compiled DLL's with instructions on how to compile your own. Currently, Windows, Android and Linux binaries are available.

> [!NOTE]
> While SpeexDSPSharp.Core contains minimal pre-made jitter buffer, preprocessor and echo canceler handlers, you can create your own as all the
> SafeHandlers and NativeSpeexDSP functions are exposed and fully documented. However to get a minimal setup working, check
> the example below.

## JitterBuffer Example

Simple JitterBuffer example.

```csharp
using SpeexDSPSharp.Core;
using SpeexDSPSharp.Core.Structures;

var jitter = new SpeexJitterBuffer();

var inputData = new byte[960];
for(byte i = 0; i < 25; i++)
{
    inputData[i] = (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue);
    Console.WriteLine($"Input: {inputData[i]}");
}
jitter.Put(inputData);

Console.WriteLine();
jitter.Get(); //Found Packet
jitter.Get(); //Missing Packet

public class SpeexJitterBuffer
{
    private readonly SpeexDSPJitterBuffer buffer = new SpeexDSPJitterBuffer(1);
    private uint timestamp = 1;

    public void Get()
    {
        var data = new byte[960];
        var outPacket = new SpeexDSPJitterBufferPacket(data, (uint)data.Length);

        int temp = 0;
        if (buffer.Get(ref outPacket, 1, ref temp) != JitterBufferState.JITTER_BUFFER_OK)
        {
            Console.WriteLine("Missing Packet");
        }
        else
        {
            Console.WriteLine("Found Packet");
            for (byte i = 0; i < 25; i++)
            {
                Console.WriteLine($"Output: {data[i]}");
            }
        }

        buffer.Tick();
    }

    public void Put(byte[] frameData)
    {
        var inPacket = new SpeexDSPJitterBufferPacket(frameData, (uint)frameData.Length);
        if (frameData == null)
            throw new ArgumentNullException("frameData");

        inPacket.sequence = 0;
        inPacket.span = 1;
        inPacket.timestamp = timestamp++;

        buffer.Put(ref inPacket);
    }
}
```

## Preprocessor Example

Simple preprocessor example for initializing and processing (with NAudio).

```csharp
using NAudio.Wave;
using SpeexDSPSharp.Core;

var format = new WaveFormat(48000, 1);
var preprocessor = new SpeexDSPPreprocessor(20 * format.SampleRate / 1000, format.SampleRate);
var @true = 1;
preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_AGC, ref @true);
preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_DENOISE, ref @true);
preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_VAD, ref @true);
var gain = 30000;
preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_AGC_TARGET, ref gain);
var buffer = new BufferedWaveProvider(format) { ReadFully = true };
var recorder = new WaveInEvent()
{
    WaveFormat = format,
    BufferMilliseconds = 20
};
var output = new WaveOutEvent()
{
    DesiredLatency = 100
};

recorder.DataAvailable += Recorder_DataAvailable;

output.Init(buffer);

Task.Delay(500).Wait();
output.Play();
recorder.StartRecording();

void Recorder_DataAvailable(object? sender, WaveInEventArgs e)
{
    try
    {
        Console.WriteLine($"Detecting Voice: {(preprocessor.Run(e.Buffer) == 1? true : false)}");
        buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

Console.ReadLine();
```

## Static Usage Example

This example shows a forced usage of SpeexDSPSharp to use the statically linked speexdsp binary.

```csharp
// On iOS SpeexDSPSharp switches to StaticNativeSpeexDSP automatically.
// You can still force the same behavior manually with use_static: true.
var jitterBuffer = new SpeexDSPJitterBuffer(1, true);
```

> [!NOTE]
> While disposing of the wrappers are handled by the GC (garbage collector) since unmanaged states are
> wrapped in a SafeHandler, It is still recommended to directly call the Dispose() function due to different runtime
> environments such as unity's mono runtime (at the time of writing this) which can take an impact on performance
> depending on how many is initialized and dereferenced over time.

## Supported Devices

- ✅ Fully and natively supported.
- ❎ Can be supported but no reason to.
- ❗ Not yet available.
- ❌ Not planned, Not supported.

| Device  | x64 | x86 | arm32 | arm64 |
|---------|---|----|------|----|
| Linux   | ✅ | ✅  | ✅    | ✅  |
| Android | ✅ | ✅  | ✅    | ✅  |
| Windows | ✅ | ✅  | ✅    | ✅  |
| iOS     | ❌ | ❌  | ❌    | ❌   |
| MacOS   | ❌  | ❌  | ❌    | ❌   |
| WASM    | ❌  | ❌   | ❌     | ❌   |

## Installation

Please check [QuickStart](https://avionblock.github.io/SpeexDSPSharp/quick-start/index.html)
OR [Nuget](https://www.nuget.org/packages/SpeexDSPSharp).
For the default cross-platform experience, install [SpeexDSPSharp](https://www.nuget.org/packages/SpeexDSPSharp). It brings in
both `SpeexDSPSharp.Core` and the prebuilt native assets.

If you want to manage native binaries yourself, only install the `SpeexDSPSharp.Core` package.

## API Documentation

https://avionblock.github.io/SpeexDSPSharp/api/SpeexDSPSharp.Core.html

## SpeexDSP License

https://github.com/xiph/speexdsp?tab=License-1-ov-file

## Support The Creator
Kofi Donations only go through to SineVector241. Sponsoring hasn't been setup yet...

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z0MLA2P)

# Docs
https://avionblock.github.io/SpeexDSPSharp/index.html