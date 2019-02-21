using IoTTalkLib.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace IoTTalkLib.Library
{
    public class IoTTalkCsmapi
    {
        public string ENDPOINT { get; set; }
        static private int TIMEOUT = 100;
        static public string passwordKey = null;    //FeedBackPassword
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
        private string CreateProfileJson(string deviceName, string deviceModelName, string[] deviceFeatureList, string UserName,bool is_sim)
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
        /// IotTalk 模組註冊。 mac_addr:裝置的MAC位址,proifle:裝置註冊資訊,statusCode 回傳之狀態
        /// <para>profile 請由IoTTalkCsmapi.CreateProfileJson 方法建立避免出錯。而statusCode 請使用ref value 宣告取得回傳資訊</para>
        /// </summary>
        public string Register(string mac_addr, string profile, ref int statusCode)
        {    
            string apiUrl = ENDPOINT+ "/" + mac_addr;
            string jsonString = profile;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
                httpWebRequest.Timeout = TIMEOUT;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if(httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        string data = result.ToString();
                        statusCode = (int)httpResponse.StatusCode;
                        return data;
                    }
                }
                else
                {
                    statusCode = (int)httpResponse.StatusCode;
                    return "Error";
                }
            }
        }
        /// <summary>
        /// IoTTalk 模組取消註冊。 mac_addr:裝置的MAC位址,proifle:裝置註冊資訊
        /// </summary>
        public bool Deregister(string mac_addr, string profile,string passwordkey,ref int statusCode)
        {
            string apiUrl = ENDPOINT +"/"+ mac_addr;
            string jsonString = JsonConvert.SerializeObject(profile);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Headers.Add("password-key", passwordkey);
            httpWebRequest.Method = "DELETE";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
                httpWebRequest.Timeout = TIMEOUT;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    statusCode = (int)httpResponse.StatusCode;
                    return true;
                }
                else
                {
                    statusCode = (int)httpResponse.StatusCode;
                    return false;
                }

            }
        }
        /// <summary>
        /// IotTalk 數據上傳。 mac_addr:裝置的MAC位址,df_name:特性名稱,data:上傳數據,passwordkey:設備註冊key
        /// <para>data 上傳應為{"data":[value1,value2,value3......]}</para>
        /// </summary>
        public bool Push(string mac_addr, string df_name, string data,string passwordkey,ref int statusCode )
        {
            string apiUrl = ENDPOINT + "/" + mac_addr + "/" + df_name;
            string jsonString = data;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.ContentType = "application/json; charset=utf-8;";
            httpWebRequest.Headers.Add("password-key", passwordkey);
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
                httpWebRequest.Timeout = TIMEOUT;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    statusCode = (int)httpResponse.StatusCode;
                    return true;
                }
                else
                {
                    statusCode = (int)httpResponse.StatusCode;
                    return false;
                }
            }
        }
        /// <summary>
        /// IotTalk 數據回傳。 mac_addr:裝置的MAC位址,df_name:特性名稱,passwordkey:設備註冊key
        /// <para>回傳數據應為{"samples":[<timestamp>, <data>]</para>
        /// </summary>
        public string Pull(string mac_addr, string df_name, string passwordkey, ref int statusCode)
        {
            string apiUrl = ENDPOINT + "/" + mac_addr + "/" + df_name;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Headers.Add("password-key", passwordkey);
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = TIMEOUT;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string data = result.ToString();
                    statusCode = (int)httpResponse.StatusCode;
                    return data;
                }
            }
            else
            {
                statusCode = (int)httpResponse.StatusCode;
                return "";
            }
        }
    }
}
