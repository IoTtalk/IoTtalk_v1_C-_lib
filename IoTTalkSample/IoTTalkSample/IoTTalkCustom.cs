using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTTalkLib.Library;
using IoTTalkLib.Model;

namespace IoTTalkLib.Library
{

    class IoTTalkCustom
    {
        public string DeviceMac()
        {
            string deviceMac = "80AC842437";
            return deviceMac;
        }
        public string HostServerIP()
        {
            string hostServerIP = "https://iottalk.chu.edu.tw";
            return hostServerIP;
        }
        public CustomSetModel custom()
        {
            CustomSetModel CSM = new CustomSetModel();
            CSM.deviceName = "D1";
            CSM.deviceModel = "MorSensor";
            CSM.passwordkey = "";
            return CSM;
        }
        public List<string>InputDeviceFeature()
        {
            List<string> IDF = new List<string>();
            IDF.Add("Tempature");
            IDF.Add("Humidity");
            return IDF;
        }
        public List<string> OutputDeviceFeature()
        {
            List<string> ODF = new List<string>();
            ODF.Add("Display");
            ODF.Add("Print");
            return ODF;
        }
    }
}
