using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTTalkLib.Library;
using IoTTalkLib.Model;
using System.Net.NetworkInformation;

namespace IoTTalkLib.Library
{

    class IoTTalkCustom
    {
        public string MACAddressAuto()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            List<string> macList = new List<string>();
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    macList.Add(nic.GetPhysicalAddress().ToString());
            return macList[0];
        }

        public string DeviceMac()
        {
            string deviceMac = MACAddressAuto();
            if (deviceMac == null)
                deviceMac = "80AC842437";
            return deviceMac;
        }
        public string HostServerIP()
        {
            string hostServerIP = "https://ServerIP";
            return hostServerIP;
        }
        public CustomSetModel custom()
        {
            CustomSetModel CSM = new CustomSetModel();
            CSM.deviceName = "D1";
            CSM.deviceModel = "MorSensor";
            CSM.passwordkey = "bedd1388-d136-406a-92b4-f78c35d729dc";
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
