using IoTTalkLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace IoTTalkLib.Library
{
    /// <summary>
    /// API of IoTTalk Version 2.0 by Chris Hsu (SmartPearls CO.&Ltd.)
    /// IoTTalk CSMAPI 主要是針對 IoTTalk 通訊的相關應用，主要為使用HttpWebRequest 來處理，提供下列方式：
    /// Register / POST (string IoTTalkServer, string mac_addr, string profile, ref int statusCode) return string
    /// Deregister/ DELETE (string IoTTalkServer,string mac_addr, string profile,string passwordkey,ref int statusCode) return string = "0"
    /// Passwordkey / GET (string IoTTalkServer, string mac_addr, ref int statusCode) retrun string 
    /// Profile / GET (string IoTTalkServer, string mac_addr, ref int statusCode) retrun string 
    /// Push / PUT (string IoTTalkServer, string mac_addr, string df_name, string data,string passwordkey,ref int statusCode ) return string = "0"
    /// Pull / GET (string IoTTalkServer,string mac_addr, string df_name, string passwordkey, ref int statusCode) return string
    /// 例外排除:
    ///     reference WebExceptionStatus 請參考：https://docs.microsoft.com/zh-tw/dotnet/api/system.net.webexceptionstatus?view=netframework-4.8
    ///     return string = WebException.Response.GetResponseStream()
    /// </summary>
    public class IoTTalkCsmapi
    {
        static private int TIMEOUT = 2000;
        /// <summary>
        /// IotTalk 模組註冊。 mac_addr:裝置的MAC位址,proifle:裝置註冊資訊,statusCode 回傳之狀態
        /// <para>profile 請由IoTTalkCsmapi.CreateProfileJson 方法建立避免出錯。而statusCode 請使用ref value 宣告取得回傳資訊</para>
        /// </summary>
        public string Register(string IoTTalkServer, string mac_addr, string profile, ref int statusCode)
        {
            string apiUrl = IoTTalkServer + "/" + mac_addr;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(profile);
                    streamWriter.Flush();
                    streamWriter.Close();
                    httpWebRequest.Timeout = TIMEOUT;
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        string data = result.ToString();
                        statusCode = (int)httpResponse.StatusCode;
                        return data;
                    }
                }
            }
            catch (WebException e)
            {
                statusCode = (int)e.Status;
                StreamReader SE = new StreamReader(e.Response.GetResponseStream());
                string str = SE.ReadToEnd();
                return str;
            }
        }
        /// <summary>
        /// IoTTalk 模組取消註冊。 mac_addr:裝置的MAC位址,proifle:裝置註冊資訊
        /// </summary>
        public string Deregister(string IoTTalkServer,string mac_addr, string profile,string passwordkey,ref int statusCode)
        {
            string apiUrl = IoTTalkServer +"/"+ mac_addr;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers.Add("password-key", passwordkey);
                httpWebRequest.Method = "DELETE";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(profile);
                    streamWriter.Flush();
                    streamWriter.Close();
                    httpWebRequest.Timeout = TIMEOUT;
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    statusCode = (int)httpResponse.StatusCode;
                    return "0";
                }
            }
            catch (WebException e)
            {
                statusCode = (int)e.Status;
                StreamReader SE = new StreamReader(e.Response.GetResponseStream());
                string str = SE.ReadToEnd();
                return str;
            }
        }
        /// <summary>
        /// 詢問感測器註冊key，若已經註冊會有獨立的key , 並回傳前2碼作為檢查碼
        /// </summary>
        public string PasswordkeyCheck(string IoTTalkServer, string mac_addr, ref int statusCode)
        {
            string apiUrl = IoTTalkServer + "/" + mac_addr + "/password";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = TIMEOUT;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string data = result.ToString();
                    statusCode = (int)httpResponse.StatusCode;
                    return data;
                }
            }
            catch (WebException e)
            {
                statusCode = (int)e.Status;
                StreamReader SE = new StreamReader(e.Response.GetResponseStream());
                string str = SE.ReadToEnd();
                return str;
            }
        }
        /// <summary>
        /// 詢問感測器註冊資訊並回傳相關資訊
        /// </summary>
        public string ProfileCheck(string IoTTalkServer, string mac_addr, ref int statusCode)
        {
            string apiUrl = IoTTalkServer + "/" + mac_addr + "/profile";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = TIMEOUT;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string data = result.ToString();
                    statusCode = (int)httpResponse.StatusCode;
                    return data;
                }
            }
            catch (WebException e)
            {
                statusCode = (int)e.Status;
                StreamReader SE = new StreamReader(e.Response.GetResponseStream());
                string str = SE.ReadToEnd();
                return str;
            }
        }
        /// <summary>
        /// IotTalk 數據上傳。 mac_addr:裝置的MAC位址,df_name:特性名稱,data:上傳數據,passwordkey:設備註冊key
        /// <para>data 上傳應為{"data":[value1,value2,value3......]}</para>
        /// </summary>
        public string Push(string IoTTalkServer, string mac_addr, string df_name, string data,string passwordkey,ref int statusCode )
        {
            string apiUrl = IoTTalkServer + "/" + mac_addr + "/" + df_name;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8;";
                httpWebRequest.Headers.Add("password-key", passwordkey);
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();
                    httpWebRequest.Timeout = TIMEOUT;
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    statusCode = (int)httpResponse.StatusCode;
                    return "0";
                }
            }
            catch (WebException e)
            {
                statusCode = (int)e.Status;
                StreamReader SE = new StreamReader(e.Response.GetResponseStream());
                string str = SE.ReadToEnd();
                return str;
            }
        }
        /// <summary>
        /// IotTalk 數據回傳。 mac_addr:裝置的MAC位址,df_name:特性名稱,passwordkey:設備註冊key
        /// <para>回傳數據應為{"samples":[<timestamp>, <data>]</para>
        /// </summary>
        public string Pull(string IoTTalkServer,string mac_addr, string df_name, string passwordkey, ref int statusCode)
        {
            string apiUrl = IoTTalkServer + "/" + mac_addr + "/" + df_name;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers.Add("password-key", passwordkey);
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = TIMEOUT;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string data = result.ToString();
                    statusCode = (int)httpResponse.StatusCode;
                    return data;
                }
            }
            catch (WebException e)
            {
                statusCode = (int)e.Status;
                StreamReader SE = new StreamReader(e.Response.GetResponseStream());
                string str = SE.ReadToEnd();
                return str;
            }
        }
    }
}
