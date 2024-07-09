# Evasion-Practice #

A place for practicing various evasion techniques in C#. The base code will remain constant for future work, while the evasion techniques will vary. Many techniques are inspired by [this PDF](https://blog.sevagas.com/IMG/pdf/BypassAVDynamics.pdf).

### 00-BaseCode.cs ###
The base code that will remain constant across all trials.

### 01-AllocateAndFill.cs ###
Allocates a ~1.07GB byte array and fills it with zeros, then verifies if the last value is 0. The idea is that an antivirus engine will skip zeroing out all this memory, causing the program to terminate before the shellcode runner can be analyzed.

### 02-ManyIterations.cs
Loops nine hundred million times to discourage antivirus software from emulating the rest of the program.