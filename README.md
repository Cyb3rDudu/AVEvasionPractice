# Evasion-Practice #

A place for practicing various evasion techniques in C#. The base code will remain constant for future work, while the evasion techniques will vary. Many techniques are inspired by [this PDF](https://blog.sevagas.com/IMG/pdf/BypassAVDynamics.pdf).

### 00-BaseCode
The base code that will remain constant across all trials.

### 01-AllocateAndFill
Allocates a ~1.07GB byte array and fills it with zeros, then verifies if the last value is 0. The idea is that an antivirus engine will skip zeroing out all this memory, causing the program to terminate before the shellcode runner can be analyzed.

### 02-ManyIterations
Loops nine hundred million times to discourage antivirus software from emulating the rest of the program.

### 03-OpenSystemProcess
This code attempts to open PID 4, which is a SYSTEM process. Normally, a regular user should not be able to open this process, while an antivirus engine might be able to. This would result in a null handle when executed by a legitimate user. The Win32 API OpenProcess is imported for this snippet. Since this API is commonly used in malicious code, this evasion technique might generate more detections. The value 0x001F0FFF is the hexadecimal representation of PROCESS_ALL_ACCESS.

### 04-NonExistingURL
This code makes an HTTP request to a fictitious domain. If no response is received (the expected outcome), the shellcode runner will execute. If a response is received, it indicates potential interference. Antivirus sandboxes often cannot make outbound requests and may instead reply with a fake response to allow the code to continue executing. Therefore, if the code fails, it is likely running in the real world; otherwise, it might be in an AV sandbox.

### 05-KnownPath
If the target's username is known, it may be possible to specify actions that will only execute in the context of that user. For example, in this code, a file is written to the desktop of the user "User". The contents of that file are then read back, and if they match what was written, the shellcode will execute.

### 06-VirtualAllocExNuma
Some antivirus engines cannot emulate all known Windows APIs. If they encounter an unknown API, they may stop examining the program. In this code, we import the Win32 API VirtualAllocExNuma, which is used to configure memory management in multiprocessing systems. If the allocated memory is not NULL, the shellcode will execute.

### 07-FlsAlloc
Similar to logic in example 06, some AV emulators will return a failure when FlsAlloc is called. For reference, UInt32 is the C# equivalent of DWORD and IntPtr.Zero is equivalent to NULL. The value 0xFFFFFFFF equates to -1, representing a failure condition, and the original code uses FLS_OUT_OF_INDEXES.

