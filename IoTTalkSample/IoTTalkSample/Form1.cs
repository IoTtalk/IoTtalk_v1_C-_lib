using IoTTalkLib.Library;
using IoTTalkLib.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IoTTalkSample
{
    public partial class Form1 : Form
    {
        CustomSetModel CSM = new CustomSetModel();
        IoTTalkDAN DAN = new IoTTalkDAN();
        IoTTalkCustom custom = new IoTTalkCustom();
        public Form1()
        {
            CSM = custom.custom();
            CSM.deviceFeatureList = custom.InputDeviceFeature();
            DAN.Device_MAC = custom.DeviceMac();
            DAN.ENDPOINT = custom.HostServerIP();
            DAN.Device_Model = CSM.deviceModel;
            DAN.Device_Feature = CSM.deviceFeatureList.ToArray();
            DAN.Device_Name = CSM.deviceName;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            RegesterModel regesterResult = DAN.RegisterAndRetry();
            textBox1.Text = regesterResult.d_name;
            textBox2.Text = regesterResult.password;
            DAN.PASSWORDLEY = CSM.passwordkey =  regesterResult.password;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool is_deRegister = DAN.DeRegisterCancel();
            textBox2.Text = is_deRegister.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            PushModel PM = new PushModel();
            List<object> list = new List<object>();
            list.Add("sakaki");
            list.Add(1234);
            list.Add(5.7F);
            PM.data = list;
            DAN.PushDataToIoTTalk(CSM.deviceFeatureList[0], PM);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            PullDataProcessModel PDPM = DAN.PullDataFromIoTTalk(CSM.deviceFeatureList[0]);
            textBox3.Text = PDPM.TimeStamp.ToString();
            textBox4.Text = PDPM.unspliteData;
            string[] dataVerse = PDPM.unspliteData.Split(',');
        }

    }
}
       