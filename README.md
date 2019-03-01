# IoTTalk C#
![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)

此為物聯網平台(IoTTalk) 的C#範例，透過此範例可以容易建構出C#的IoTTalk連線技術

GitHub Architecture
  - IotTalkSample (A Sample with C# )
  - IoTTalkLibrary (IoTTalk LibraryFile)

## HowTo use IoTalkLibrary with C#
  - Create a new C# project 
    
    >You also can create a Window Form or other you want
  - Add Reference with NuGet
    
    >Install Newtonsoft.Json
  - Download IoTTalkLibrary and Add File to your project
  
    | FileName | README |
    | ------ | ------ |
    | IoTTalkCsmapi.cs | Communication with IoTTalk |
    | IoTTalkCustom.cs | Customer definition IDF, ODF, MAC_Address, IPServer |
    | IoTTalkDAN.cs | Easy Develop with DAI |
    | IoTTalkModel.cs | The Model with IoTTalkLibrary |

  - Add Using header
    >using IoTTalkLib.Model;,    
    >using IoTTalkLib.Library;
    
Finish XD　Enjoy your project!!

## Some Problem You Need to Know
  - 請勿重複註冊
  
    >重複註冊會將原先的設備替換掉會導致ＰＵＬＬ的資料會變成空的
    
