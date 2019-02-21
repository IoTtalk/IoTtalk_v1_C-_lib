using IoTTalkLib.Model;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace IoTTalkLib.Library
{
    class IoTTalkDAN
    {
        IoTTalkCsmapi csmapi = new IoTTalkCsmapi();
        public string Device_MAC { get; set; }
        public string Device_Name { get; set; }
        public string Device_Model { get; set; }
        public string[] Device_Feature { get; set; }
        public string ENDPOINT { get; set; }
        public string PASSWORDLEY { get; set; }
        public RegesterModel RegisterAndRetry()
        {
            int statusCode = 0;
            csmapi.ENDPOINT = ENDPOINT;
            string deviceProfile = csmapi.CreateProfileJson(Device_Name, Device_Model, Device_Feature);
            string registerInformation = csmapi.Register(Device_MAC, deviceProfile,ref statusCode);
            while(statusCode != 200)
                registerInformation = csmapi.Register(Device_MAC, deviceProfile, ref statusCode);
            RegesterModel regesterModel = JsonConvert.DeserializeObject<RegesterModel>(registerInformation);
            string passwordkey = regesterModel.password;
            return regesterModel;
        }

        public bool DeRegisterCancel()
        {
            int statusCode = 0;
            csmapi.ENDPOINT = ENDPOINT;
            string deviceProfile = csmapi.CreateProfileJson(Device_Name, Device_Model, Device_Feature);
            bool is_register = csmapi.Deregister(Device_MAC, deviceProfile, PASSWORDLEY,ref statusCode);
            return is_register;
        }

        public bool PushDataToIoTTalk(string device_Feature,PushModel pushdata)
        {
            int statusCode = 0;
            csmapi.ENDPOINT = ENDPOINT;
            string Jsondata = JsonConvert.SerializeObject(pushdata);
            bool is_success = csmapi.Push(Device_MAC, device_Feature, Jsondata, PASSWORDLEY, ref statusCode);
            return is_success;
        }
        public PullDataProcessModel PullDataFromIoTTalk(string device_Feature)
        {
            int statusCode = 0;
            csmapi.ENDPOINT = ENDPOINT;
            string feedbackData = csmapi.Pull(Device_MAC, device_Feature, PASSWORDLEY, ref statusCode);
            string[] dataSave = new string[0];
            PullModel PM = JsonConvert.DeserializeObject<PullModel>(feedbackData);
            foreach (var db in PM.samples)
            {
                int i = 0;
                foreach (var dc in db)
                {
                    Array.Resize(ref dataSave, dataSave.Length + 1);
                    dataSave[i] = dc.ToString();
                    i++;
                }
            }
            string result = System.Text.RegularExpressions.Regex.Replace(dataSave[dataSave.Length - 1], "[\r\n  ]", "").Trim(new char[] { '[', ']' });
            PullDataProcessModel PDPM = new PullDataProcessModel();
            PDPM.TimeStamp = Convert.ToDateTime(dataSave.FirstOrDefault());
            PDPM.unspliteData = result;
            return PDPM;
        }

    }
}
