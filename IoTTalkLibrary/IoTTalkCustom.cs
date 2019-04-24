using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IoTTalkLib.Library
{
    class IoTTalkCustom
    {
        public string Mac_Addr = "";
        public string SSLIoTTalkServer = "https://iottalk.chu.edu.tw"; //For SSL/TLS/HTTPS
        public string IoTTalkServer = "http://iottalk.chu.edu.tw"+":9999"; //For SSL/TLS/HTTPS
        public string Device_Name = "TestDevice";
        public string Device_Model = "Dummy_Device";
        public List<string> Device_Feature;
        public string passwordkey = "";

        public List<string> InputDeviceFeature()
        {
            List<string> IDF = new List<string>();
            IDF.Add("Dummy_Sensor");
            return IDF;
        }
        public List<string> OutputDeviceFeature()
        {
            List<string> ODF = new List<string>();
            ODF.Add("Dummy_Control");
            return ODF;
        }

        public string MACAddressAuto()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            List<string> macList = new List<string>();
            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    macList.Add(nic.GetPhysicalAddress().ToString());
            return macList[0];
        }
    }
}
