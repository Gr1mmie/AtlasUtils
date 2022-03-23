## TimeStomp
Assem capable of performing TimeStomping technique (T1070.006). Allows for modification of M/A/C timestamps via either duplication or user choice


#### View the MAC values of an object

```
TimeStomp.ReturnObjTime("[path to file/dir]")
```

#### Duplicate MAC values from another object

```
TimeStomp.StompFromDupObjFileTime("[path of file/dir to change]", "[path of file/dir to duplicate dates from]")
```

#### Modify individual MAC values

```
Creation date - TimeStomp.StompCreationDate("[path to file/dir]", [new date])
Last Modified - TimeStomp.StomppLastModified("[path to file/dir]", [new date])
Last Accessed - TimeStomp.StompLastAccessed("[path to file/dir]", [new date])
```

#### Modify all MAC values

```
TimeStomp.StompAll("[path to file/dir]", [new date])
```

Heavily influenced by https://github.com/FuzzySecurity/Sharp-Suite/tree/2837f1fcd40c038a02537e77ec6ad794375bdca9/MaceTrap

### What are MAC values?

MAC values are the first three of the MACE values. M(odified) A(ccessed) C(reated) E(ntry) values are dates the provide information on when a file was last M(odified), last A(ccessed), or (C)reated. This util only modifies the MAC portion of the MACE values. The final value, E(ntry) is the raw date the file was created which allows forensics to determine the real creation date of a file and would allow them to determine if a file was potentially timestopmed (see tradecraft tips for more on this).

### TradeCraft tips in regards to TimeStomping module:
 * migrate into a process that  is known to modify filetimes
 * if absolutely neccesary to drop files to disk, do it within the context of a process that regurlarly performs such file operations (and don't name em some obv shit bruh)
  * keep in mind the TimeStomp module doesn't modify entry time, which is the raw MS file creation time, though this will require more effort to check. Only values modified are (M)odified, (A)ccessed, (C)reated filetime properties. MSF (E)ntry time can be modified via NtSetInformationFile() API.
  * Sysmon Event ID (2) - notifies of change to creation date of file 
