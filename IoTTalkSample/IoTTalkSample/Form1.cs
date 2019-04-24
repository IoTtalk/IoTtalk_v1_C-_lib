using IoTTalkLib.Library;
using IoTTalkLib.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace IoTTalkSample
{
    public partial class Form1 : Form
    {
        IoTTalkDAN DAN = new IoTTalkDAN();
        IoTTalkCustom custom = new IoTTalkCustom();
        IoTTalkCsmapi csmapi = new IoTTalkCsmapi();
       
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            custom = DAN.custom;
        }
        #region CSMAPI TEST
        private void CSM_RegBTN_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            string feedback = csmapi.Register(custom.IoTTalkServer, "3345678", System.IO.File.ReadAllText(@"TestFile\RegisterData.txt"), ref statusCode);
            if(statusCode == (int)WebExceptionStatus.ProtocolError)
            {
                TestCSMAPI_textBox.Text = feedback;
            }
            TestCSMAPI_textBox.Text = feedback;
        }
        private void CSM_DeRBTN_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            string feedback = csmapi.Deregister(custom.SSLIoTTalkServer, "3345678", System.IO.File.ReadAllText(@"TestFile\RegisterData.txt"), "00", ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError)
                TestCSMAPI_textBox.Text = feedback;
            TestCSMAPI_textBox.Text = feedback;
        }
        private void CSM_ChkMACBTN_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            string feedback = csmapi.ProfileCheck(custom.SSLIoTTalkServer, "3345678", ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError)
                TestCSMAPI_textBox.Text = feedback;
            TestCSMAPI_textBox.Text = feedback;
        }
        private void CSM_ChkkeyBTN_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            string feedback = csmapi.PasswordkeyCheck(custom.SSLIoTTalkServer, "3345678", ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError)
                TestCSMAPI_textBox.Text = feedback;
            TestCSMAPI_textBox.Text = feedback;
        }
        private void CSM_PushBTN_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            string feedback = csmapi.Push(custom.SSLIoTTalkServer, "3345678", "Dummy_Sensor", System.IO.File.ReadAllText(@"TestFile\pushSample.txt"), "00", ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError)
                TestCSMAPI_textBox.Text = feedback;
            TestCSMAPI_textBox.Text = feedback;
        }
        private void CSM_PullBTN_Click(object sender, EventArgs e)
        {
            int statusCode = 0;
            string feedback = csmapi.Pull(custom.SSLIoTTalkServer, "3345678", "Dummy_Sensor", "00", ref statusCode);
            if (statusCode == (int)WebExceptionStatus.ProtocolError)
                TestCSMAPI_textBox.Text = feedback;
            TestCSMAPI_textBox.Text = feedback;
        }


        #endregion

        #region DAN TEST
        private void DAN_REGISTER_BTN_Click(object sender, EventArgs e)
        {
            RegisterModel registerModel = DAN.REGISTERDEVICE();
            TestDAN_textbox.Text = "device : " + registerModel.d_name +"\r\n"+ "password : " + registerModel.password;
        }

        private void DAN_DELETE_BTN_Click(object sender, EventArgs e)
        {
            string deletefeedback = DAN.DELETEDEVICE();
            TestDAN_textbox.Text = deletefeedback;
        }

        #endregion

        private void DAN_PUSH_BTN_Click(object sender, EventArgs e)
        {
            PushModel PM = new PushModel();
            List<object> list = new List<object>();
            list.Add("sakaki");
            list.Add(1234);
            list.Add(5.7F);
            PM.data = list;
            DAN.PUSH(custom.Device_Feature[0], PM);
            TestDAN_textbox.Text = "D_name : " + custom.Device_Name + "D_feature" + custom.Device_Feature[0];
            string datashow = "";
            foreach (var data in PM.data)
            {
                datashow += "\r\n"+ data.ToString() ;
            }
            TestDAN_textbox.Text += datashow;
        }

        private void DAN_PULL_BTN_Click(object sender, EventArgs e)
        {

            PullDataProcessModel PDPM = DAN.PULL(custom.Device_Feature[0]);
            TestDAN_textbox.Text = "Timestamp: " + PDPM.TimeStamp1 + "\r\n" + "unspliteData : " + PDPM.unspliteData1;
            string[] dataVerse = new string[0];
            if (PDPM.unspliteData1 != null)
            {
                Array.Resize(ref dataVerse, PDPM.unspliteData1.Split(',').Length);
                dataVerse = PDPM.unspliteData1.Split(',');
            }

        }
    }
}
       