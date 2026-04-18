#!/usr/bin/env sh
set -eu

rm -rf ./local-nuget
mkdir -p ./local-nuget

dotnet pack ./SpeexDSPSharp.Core/SpeexDSPSharp.Core.csproj -c Release -o ./local-nuget
dotnet pack ./SpeexDSPSharp.Natives/SpeexDSPSharp.Natives.csproj -c Release -o ./local-nuget
dotnet pack ./SpeexDSPSharp/SpeexDSPSharp.csproj -c Release -o ./local-nuget