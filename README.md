## Prerequisites

You need to have the following installed on your machine:

- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/8.0)

## How to build and run tests

1. Clone the repository
	```shell
	git clone git@github.com:marinazzio/PhonePadLib.git
	```
	or
	```shell
	git clone https://github.com/marinazzio/PhonePadLib.git
	```
1. Build the project
	```shell
	cd PhonePadLib
	dotnet build
	```
1. Run the tests
	```shell
	dotnet test
	```

## Example of usage

The simple console application is provided to demonstrate the usage of the library: [Nokia3100](marinazzio/nokia3100)

## Platform support

The library is built using .NET Core 8.0 and should run on any platform that supports .NET Core 8.0.
It was tested on Windows 11 and Ubuntu 22.04.
Here is the output of `dotnet --info` on my machine

### Windows 11
```
> dotnet --info
.NET SDK:
 Version:           8.0.302
 Commit:            ef14e02af8
 Workload version:  8.0.300-manifests.5273bb1c
 MSBuild version:   17.10.4+10fbfbf2e

Runtime Environment:
 OS Name:     Windows
 OS Version:  10.0.22631
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\8.0.302\

.NET workloads installed:
There are no installed workloads to display.

Host:
  Version:      8.0.6
  Architecture: x64
  Commit:       3b8b000a0e

.NET SDKs installed:
  8.0.302 [C:\Program Files\dotnet\sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.31 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 7.0.20 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 8.0.6 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.16 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 6.0.31 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 7.0.20 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 8.0.6 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.WindowsDesktop.App 6.0.31 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 7.0.20 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 8.0.6 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]

Other architectures found:
  x86   [C:\Program Files (x86)\dotnet]
    registered at [HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\x86\InstallLocation]

Environment variables:
  Not set

global.json file:
  Not found
```

### Ubuntu 22.04
```
» dotnet --info
.NET SDK:
 Version:           8.0.105
 Commit:            eae90abaaf
 Workload version:  8.0.100-manifests.796a77f8

Runtime Environment:
 OS Name:     ubuntu
 OS Version:  22.04
 OS Platform: Linux
 RID:         ubuntu.22.04-x64
 Base Path:   /usr/lib/dotnet/sdk/8.0.105/

.NET workloads installed:
 Workload version: 8.0.100-manifests.796a77f8
There are no installed workloads to display.

Host:
  Version:      8.0.5
  Architecture: x64
  Commit:       087e15321b

.NET SDKs installed:
  8.0.105 [/usr/lib/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 8.0.5 [/usr/lib/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 8.0.5 [/usr/lib/dotnet/shared/Microsoft.NETCore.App]

Other architectures found:
  None

Environment variables:
  Not set

global.json file:
  Not found
```

## Build results

### Windows 11
```
> dotnet build
  Determining projects to restore...
  Restored C:\#####\PhonePadLib\PhonePadTranslation\PhonePadTranslation.csproj (in 75 ms).
  Restored C:\#####\PhonePadLib\PhonePadTranslation.Tests\PhonePadTranslation.Tests.csproj (in 288 ms).
  PhonePadTranslation -> C:\#####\PhonePadLib\PhonePadTranslation\bin\Debug\net8.0\PhonePadTranslation.dll
  PhonePadTranslation.Tests -> C:\#####\PhonePadLib\PhonePadTranslation.Tests\bin\Debug\net8.0\PhonePadTranslation.Tests.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:03.74
```

### Ubuntu 22.04
```
» dotnet build
MSBuild version 17.8.5+b5265ef37 for .NET
  Determining projects to restore...
  Restored /home/#####/PhonePadLib/PhonePadTranslation.Tests/PhonePadTranslation.Tests.csproj (in 2.75 sec).
  1 of 2 projects are up-to-date for restore.
  PhonePadTranslation -> /home/#####/PhonePadLib/PhonePadTranslation/bin/Release/net8.0/PhonePadTranslation.dll
  PhonePadTranslation.Tests -> /home/#####/PhonePadLib/PhonePadTranslation.Tests/bin/Debug/net8.0/PhonePadTranslation.Tests.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:06.94
```

## Test results

### Windows 11
```
> dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  PhonePadTranslation -> C:\#####\PhonePadLib\PhonePadTranslation\bin\Debug\net8.0\PhonePadTranslation.dll
  PhonePadTranslation.Tests -> C:\#####\PhonePadLib\PhonePadTranslation.Tests\bin\Debug\net8.0\PhonePadTranslation.Tests.dll
Test run for C:\#####\PhonePadLib\PhonePadTranslation.Tests\bin\Debug\net8.0\PhonePadTranslation.Tests.dll (.NETCoreApp,Version=v8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.10.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
  Skipped OldPhonePad_GivenTest1 [< 1 ms]
  Skipped OldPhonePad_GivenTest2 [< 1 ms]
  Skipped OldPhonePad_GivenTest3 [< 1 ms]
  Skipped OldPhonePad_GivenTest4 [< 1 ms]

Passed!  - Failed:     0, Passed:    24, Skipped:     4, Total:    28, Duration: 487 ms - PhonePadTranslation.Tests.dll (net8.0)
```

### Ubuntu 22.04
```
» dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  PhonePadTranslation -> /home/#####/PhonePadLib/PhonePadTranslation/bin/Release/net8.0/PhonePadTranslation.dll
  PhonePadTranslation.Tests -> /home/#####/PhonePadLib/PhonePadTranslation.Tests/bin/Debug/net8.0/PhonePadTranslation.Tests.dll
Test run for /home/#####/PhonePadLib/PhonePadTranslation.Tests/bin/Debug/net8.0/PhonePadTranslation.Tests.dll (.NETCoreApp,Version=v8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.8.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
  Skipped OldPhonePad_GivenTest1 [< 1 ms]
  Skipped OldPhonePad_GivenTest2 [< 1 ms]
  Skipped OldPhonePad_GivenTest3 [< 1 ms]
  Skipped OldPhonePad_GivenTest4 [< 1 ms]

Passed!  - Failed:     0, Passed:    24, Skipped:     4, Total:    28, Duration: 167 ms - PhonePadTranslation.Tests.dll (net8.0)
```

# Library description

## Classes (ordered by the workflow)

| Class | Description |
| --- | --- |
| `PadTranslator` | The main class with the required `OldPhonePad` method with the given signature |
| `Preprocessor` | Prepares passed string for further parsing: compacts and trims sequent whitspaces, cuts everything after the first terminator symbol |
| `InputValidator` | Checks the validity of the given string, raises exceptions if the string is empty or contains invalid characters |
| `Parser` | Converts prepared string into the list of commands for `PadDictionary` |
| `PadDictionary` | Contains the dictionary of the phone pad characters accessed by digit and position |

# TODO

Though the installation procedure includes git cloning by HTTPS, it wasn't tested using this way, so the procedure might not work as expected. I'll test it and update the README later.

I use the plain directory structure due to the simplicity of the project. In a real project I would use a more complex structure.

I didn't add any logging to the project. As it is a library supposed to either return a string or throw an exception.

This library could be easy enhanced with reverse encoding by simple adding the reverse translator.

I don't really like current names of the classes, they are too generic and somewhere do not arrange with each other. I would rename them to something more straight and clear, considering the naming is the most difficult part of the development.
