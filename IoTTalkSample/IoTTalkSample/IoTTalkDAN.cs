using IoTTalkLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace IoTTalkLib.Library
{
    class IoTTalkDAN
    {
        IoTTalkCsmapi csmapi = new IoTTalkCsmapi();
        public IoTTalkCustom custom = new IoTTalkCustom();

        #region 裝置資訊建立
        /// <summary>
        /// IoTTalk註冊資訊建立 deviceName:裝置名稱,deviceModelName(dm_name):模組名稱,deviceFeatureList(df_list):模組特性 。
        /// <para>在dm_name與df_list請與IoTTalk平台相同</para>
        /// </summary>
        public string CreateProfileJson(string deviceName, string deviceModelName, string[] deviceFeatureList)
        {
            Profile profile = new Profile();
            List<string> dflist = new List<string>();
            ProfileModel profileModel = new ProfileModel();
            foreach (string df in deviceFeatureList)
                dflist.Add(df);
            profile = new Profile { d_name = deviceName, dm_name = deviceModelName, u_name = "yb", is_sim = false };
            profile.df_list = dflist;
            profileModel.profile = profile;
            string jsonString = JsonConvert.SerializeObject(profileModel);
            return jsonString;
        }
        /// <summary>
        /// IoTTalk註冊資訊建立 deviceName:裝置名稱,deviceModelName(dm_name):模組名稱,deviceFeatureList(df_list):模組特性 ,UserName(u_name):使用者名稱。
        /// <para>在dm_name與df_list請與IoTTalk平台相同，使用者名稱為區分多感測的使用者提供之功能</para>
        /// </summary>
        private string CreateProfileJson(string deviceName, string deviceModelName, string[] deviceFeatureList, string UserName)
        {
            Profile profile = new Profile();
            List<string> dflist = new List<string>();
            ProfileModel profileModel = new ProfileModel();
            foreach (string df in deviceFeatureList)
                dflist.Add(df);
            profile = new Profile { d_name = deviceName, dm_name = deviceModelName, u_name = UserName, is_sim = false };
            profile.df_list = dflist;
            profileModel.profile = profile;
            string jsonString = JsonConvert.SerializeObject(profileModel);
            return jsonString;
        }
        /// <summary>
        /// IoTTalk註冊資訊建立 deviceName:裝置名稱,deviceModelName(dm_name):模組名稱,deviceFeatureList(df_list):模組特性 ,UserName(u_name):使用者名稱,is_sim:是否為模擬裝置。
        /// <para>在dm_name與df_list請與IoTTalk平台相同，使用者名稱為區分多感測的使用者提供之功能，透過is_sim可設定是否為模擬裝置</para>
        /// </summary>
        private string CreateProfileJson(string deviceName, string deviceModelName, string[] deviceFeatureList, string UserName, bool is_sim)
        {
            Profile profile = new Profile();
            List<string> dflist = new List<string>();
            ProfileModel profileModel = new ProfileModel();
            foreach (string df in deviceFeatureList)
                dflist.Add(df);
            profile = new Profile { d_name = deviceName, dm_name = deviceModelName, u_name = UserName, is_sim = is_sim };
            profile.df_list = dflist;
            profileModel.profile = profile;
            string jsonString = JsonConvert.SerializeObject(profileModel);
            return jsonString;
        }
        /// <summary>
        /// IoTTalk註冊資訊建立 deviceName:裝置名稱,deviceModelName(dm_name):模組名稱,deviceFeatureList(df_list):模組特性 ,UserName(u_name):使用者名稱,is_sim:是否為模擬裝置。
        /// <para>在dm_name與df_list請與IoTTalk平台相同，透過is_sim可設定是否為模擬裝置</para>
        /// </summary>
        public string CreateProfileJson(string deviceName, string deviceModelName, string[] deviceFeatureList, bool is_sim)
        {
            Profile profile = new Profile();
            List<string> dflist = new List<string>();
            ProfileModel profileModel = new ProfileModel();
            foreach (string df in deviceFeatureList)
                dflist.Add(df);
            profile = new Profile { d_name = deviceName, dm_name = deviceModelName, u_name = "yb", is_sim = is_sim };
            profile.df_list = dflist;
            profileModel.profile = profile;
            string jsonString = JsonConvert.SerializeObject(profileModel);
            return jsonString;
        }
        #endregion
        /// <summary>
        /// Device 註冊主要資訊會透過custom進行註冊並將註冊資訊存為txt檔案
        /// </summary>
        public void DefaultCreate()
        {
            custom.Mac_Addr = custom.MACAddressAuto();
            custom.Device_Feature = custom.InputDeviceFeature();
            custom.Device_Feature.AddRange(custom.OutputDeviceFeature());
        }
        public RegisterModel REGISTERDEVICE()
        {
            DefaultCreate();
            int statusCode = 0;
            RegisterModel registerModel = new RegisterModel();
            string profile = CreateProfileJson(custom.Device_Name, custom.Device_Model, custom.Device_Feature.ToArray());
            string registerInfo = csmapi.Register(custom.SSLIoTTalkServer, custom.Mac_Addr, profile, ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError)
            {
                return registerModel;
            }
            registerModel = JsonConvert.DeserializeObject<RegisterModel>(registerInfo);
            custom.passwordkey = registerModel.password;
            System.IO.File.WriteAllText("profile.txt", profile);
            System.IO.File.WriteAllText("registerInfo.txt", registerInfo);
            return registerModel;
        }
        public string DELETEDEVICE()
        {
            int statusCode = 0;
            string feedback = csmapi.Deregister(custom.SSLIoTTalkServer,custom.Mac_Addr, System.IO.File.ReadAllText("profile.txt"), custom.passwordkey, ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError && feedback != "0")
                return feedback;
            return "DELETE SUCCESS";
        }

        public bool PUSH(string device_Feature, PushModel pushdata)
        {
            int statusCode = 0;
            string Jsondata = JsonConvert.SerializeObject(pushdata);
            string is_success = csmapi.Push(custom.SSLIoTTalkServer, custom.Mac_Addr, device_Feature, Jsondata, custom.passwordkey, ref statusCode);
            return true;
        }
        public PullDataProcessModel PULL(string device_Feature)
        {
            int statusCode = 0;
            string feedbackData = csmapi.Pull(custom.SSLIoTTalkServer, custom.Mac_Addr, device_Feature, custom.passwordkey, ref statusCode);
            string[] dataSave = new string[0];
            PullModel PM = JsonConvert.DeserializeObject<PullModel>(feedbackData);
            PullDataProcessModel PDPM = new PullDataProcessModel();
            if (PM.samples.Count == 0)
                return PDPM;
            int i = 0;
            foreach (var db in PM.samples)
            {

                foreach (var dc in db)
                {
                    Array.Resize(ref dataSave, dataSave.Length + 1);
                    dataSave[i] = dc.ToString();
                    i++;
                }
            }
            string result, result2;
            if (PM.samples.Count == 1)
            {
                result = System.Text.RegularExpressions.Regex.Replace(dataSave[dataSave.Length - 1], "[\r\n  ]", "").Trim(new char[] { '[', ']' });
                PDPM.TimeStamp1 = Convert.ToDateTime(dataSave.FirstOrDefault());
                PDPM.unspliteData1 = result;
                return PDPM;
            }

            else if (PM.samples.Count == 2)
            {
                result = System.Text.RegularExpressions.Regex.Replace(dataSave[dataSave.Length - 3], "[\r\n  ]", "").Trim(new char[] { '[', ']' });
                result2 = System.Text.RegularExpressions.Regex.Replace(dataSave[dataSave.Length - 1], "[\r\n  ]", "").Trim(new char[] { '[', ']' });
                PDPM.TimeStamp1 = Convert.ToDateTime(dataSave.FirstOrDefault());
                PDPM.unspliteData1 = result;
                PDPM.TimeStamp2 = Convert.ToDateTime(dataSave[dataSave.Length - 2]);
                PDPM.unspliteData2 = result2;
                return PDPM;
            }
            else
                return PDPM;
        }
    }
}
