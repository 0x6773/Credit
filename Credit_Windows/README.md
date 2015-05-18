### Credit/Credit_Windows

# [```Credit for Windows```](https://github.com/mafiya69/Credit/tree/master/Credit_Linux) ReadMe

## Difference between [```Credit_JSON```](https://github.com/mafiya69/Credit/tree/ReadMe/Credit_Windows/Credit_JSON) and [```Credit_TSQL```](https://github.com/mafiya69/Credit/tree/ReadMe/Credit_Windows/Credit_TSQL)

[```Credit_JSON```](https://github.com/mafiya69/Credit/tree/ReadMe/Credit_Windows/Credit_JSON) uses ```Newtonsoft.Json``` Library to Read/Write data in JSON format to a file 
whereas [```Credit_TSQL```](https://github.com/mafiya69/Credit/tree/ReadMe/Credit_Windows/Credit_TSQL) uses Microsoft SQL Server Management Studio 2014 (Which I used) to save data to a SQL DataBase.

## How to Use ?

I think I used Visual Studio 2013.6 Ultimate to build these projects.
Move into respective folders to Open using Visual Studio and build. 
or instead to build using ```Comand Prompt``` :
```
cd Credit_JSON REM or Credit_TSQL
%MSBUILD%
```
```MSBUILD``` should be set to ```msbuild.exe``` in environmental Paths. If this doesn`t works Build using Visual Studio.

## How to Contribute ?

Use Visual Studio to Edit, Debug, and send PR!
You can also use Visual Studio 2015!

## Want to report an Issue ?

[```Report Issue```](https://github.com/mafiya69/Credit/issues/new) or just e-mail me at [```gsiitbhu@gmail.com```](mailto:gsiitbhu@gmail.com)

## External Libraries Used

I used ```Newtonsoft.Json``` Library to write and parse data to/from file in JSON Format.
(Already there in Project but you can download it using Visual Studio ```Package Manager```.)
