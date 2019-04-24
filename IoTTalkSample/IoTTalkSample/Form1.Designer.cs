namespace IoTTalkSample
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CSM_RegBTN = new System.Windows.Forms.Button();
            this.CSM_DeRBTN = new System.Windows.Forms.Button();
            this.CSM_ChkMACBTN = new System.Windows.Forms.Button();
            this.CSM_ChkkeyBTN = new System.Windows.Forms.Button();
            this.CSM_PushBTN = new System.Windows.Forms.Button();
            this.CSM_PullBTN = new System.Windows.Forms.Button();
            this.TestCSMAPI_textBox = new System.Windows.Forms.TextBox();
            this.DAN_PULL_BTN = new System.Windows.Forms.Button();
            this.DAN_PUSH_BTN = new System.Windows.Forms.Button();
            this.DAN_DELETE_BTN = new System.Windows.Forms.Button();
            this.DAN_REGISTER_BTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TestDAN_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "TestCSMAPI (MAC :3345678)";
            // 
            // CSM_RegBTN
            // 
            this.CSM_RegBTN.Location = new System.Drawing.Point(12, 24);
            this.CSM_RegBTN.Name = "CSM_RegBTN";
            this.CSM_RegBTN.Size = new System.Drawing.Size(75, 23);
            this.CSM_RegBTN.TabIndex = 1;
            this.CSM_RegBTN.Text = "Register";
            this.CSM_RegBTN.UseVisualStyleBackColor = true;
            this.CSM_RegBTN.Click += new System.EventHandler(this.CSM_RegBTN_Click);
            // 
            // CSM_DeRBTN
            // 
            this.CSM_DeRBTN.Location = new System.Drawing.Point(93, 24);
            this.CSM_DeRBTN.Name = "CSM_DeRBTN";
            this.CSM_DeRBTN.Size = new System.Drawing.Size(75, 23);
            this.CSM_DeRBTN.TabIndex = 2;
            this.CSM_DeRBTN.Text = "DeRegister";
            this.CSM_DeRBTN.UseVisualStyleBackColor = true;
            this.CSM_DeRBTN.Click += new System.EventHandler(this.CSM_DeRBTN_Click);
            // 
            // CSM_ChkMACBTN
            // 
            this.CSM_ChkMACBTN.Location = new System.Drawing.Point(174, 24);
            this.CSM_ChkMACBTN.Name = "CSM_ChkMACBTN";
            this.CSM_ChkMACBTN.Size = new System.Drawing.Size(75, 23);
            this.CSM_ChkMACBTN.TabIndex = 3;
            this.CSM_ChkMACBTN.Text = "CheckMAC";
            this.CSM_ChkMACBTN.UseVisualStyleBackColor = true;
            this.CSM_ChkMACBTN.Click += new System.EventHandler(this.CSM_ChkMACBTN_Click);
            // 
            // CSM_ChkkeyBTN
            // 
            this.CSM_ChkkeyBTN.Location = new System.Drawing.Point(255, 24);
            this.CSM_ChkkeyBTN.Name = "CSM_ChkkeyBTN";
            this.CSM_ChkkeyBTN.Size = new System.Drawing.Size(75, 23);
            this.CSM_ChkkeyBTN.TabIndex = 4;
            this.CSM_ChkkeyBTN.Text = "CheckKey";
            this.CSM_ChkkeyBTN.UseVisualStyleBackColor = true;
            this.CSM_ChkkeyBTN.Click += new System.EventHandler(this.CSM_ChkkeyBTN_Click);
            // 
            // CSM_PushBTN
            // 
            this.CSM_PushBTN.Location = new System.Drawing.Point(336, 24);
            this.CSM_PushBTN.Name = "CSM_PushBTN";
            this.CSM_PushBTN.Size = new System.Drawing.Size(75, 23);
            this.CSM_PushBTN.TabIndex = 5;
            this.CSM_PushBTN.Text = "Push";
            this.CSM_PushBTN.UseVisualStyleBackColor = true;
            this.CSM_PushBTN.Click += new System.EventHandler(this.CSM_PushBTN_Click);
            // 
            // CSM_PullBTN
            // 
            this.CSM_PullBTN.Location = new System.Drawing.Point(418, 23);
            this.CSM_PullBTN.Name = "CSM_PullBTN";
            this.CSM_PullBTN.Size = new System.Drawing.Size(75, 23);
            this.CSM_PullBTN.TabIndex = 6;
            this.CSM_PullBTN.Text = "Pull";
            this.CSM_PullBTN.UseVisualStyleBackColor = true;
            this.CSM_PullBTN.Click += new System.EventHandler(this.CSM_PullBTN_Click);
            // 
            // TestCSMAPI_textBox
            // 
            this.TestCSMAPI_textBox.Location = new System.Drawing.Point(12, 54);
            this.TestCSMAPI_textBox.Multiline = true;
            this.TestCSMAPI_textBox.Name = "TestCSMAPI_textBox";
            this.TestCSMAPI_textBox.Size = new System.Drawing.Size(481, 48);
            this.TestCSMAPI_textBox.TabIndex = 7;
            // 
            // DAN_PULL_BTN
            // 
            this.DAN_PULL_BTN.Location = new System.Drawing.Point(255, 120);
            this.DAN_PULL_BTN.Name = "DAN_PULL_BTN";
            this.DAN_PULL_BTN.Size = new System.Drawing.Size(75, 23);
            this.DAN_PULL_BTN.TabIndex = 8;
            this.DAN_PULL_BTN.Text = "PULL";
            this.DAN_PULL_BTN.UseVisualStyleBackColor = true;
            this.DAN_PULL_BTN.Click += new System.EventHandler(this.DAN_PULL_BTN_Click);
            // 
            // DAN_PUSH_BTN
            // 
            this.DAN_PUSH_BTN.Location = new System.Drawing.Point(174, 120);
            this.DAN_PUSH_BTN.Name = "DAN_PUSH_BTN";
            this.DAN_PUSH_BTN.Size = new System.Drawing.Size(75, 23);
            this.DAN_PUSH_BTN.TabIndex = 9;
            this.DAN_PUSH_BTN.Text = "PUSH";
            this.DAN_PUSH_BTN.UseVisualStyleBackColor = true;
            this.DAN_PUSH_BTN.Click += new System.EventHandler(this.DAN_PUSH_BTN_Click);
            // 
            // DAN_DELETE_BTN
            // 
            this.DAN_DELETE_BTN.Location = new System.Drawing.Point(93, 120);
            this.DAN_DELETE_BTN.Name = "DAN_DELETE_BTN";
            this.DAN_DELETE_BTN.Size = new System.Drawing.Size(75, 23);
            this.DAN_DELETE_BTN.TabIndex = 10;
            this.DAN_DELETE_BTN.Text = "DELETE";
            this.DAN_DELETE_BTN.UseVisualStyleBackColor = true;
            this.DAN_DELETE_BTN.Click += new System.EventHandler(this.DAN_DELETE_BTN_Click);
            // 
            // DAN_REGISTER_BTN
            // 
            this.DAN_REGISTER_BTN.Location = new System.Drawing.Point(12, 120);
            this.DAN_REGISTER_BTN.Name = "DAN_REGISTER_BTN";
            this.DAN_REGISTER_BTN.Size = new System.Drawing.Size(75, 23);
            this.DAN_REGISTER_BTN.TabIndex = 11;
            this.DAN_REGISTER_BTN.Text = "REGISTER";
            this.DAN_REGISTER_BTN.UseVisualStyleBackColor = true;
            this.DAN_REGISTER_BTN.Click += new System.EventHandler(this.DAN_REGISTER_BTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "TestDAN";
            // 
            // TestDAN_textbox
            // 
            this.TestDAN_textbox.Location = new System.Drawing.Point(19, 156);
            this.TestDAN_textbox.Multiline = true;
            this.TestDAN_textbox.Name = "TestDAN_textbox";
            this.TestDAN_textbox.Size = new System.Drawing.Size(481, 69);
            this.TestDAN_textbox.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 361);
            this.Controls.Add(this.TestDAN_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DAN_REGISTER_BTN);
            this.Controls.Add(this.DAN_DELETE_BTN);
            this.Controls.Add(this.DAN_PUSH_BTN);
            this.Controls.Add(this.DAN_PULL_BTN);
            this.Controls.Add(this.TestCSMAPI_textBox);
            this.Controls.Add(this.CSM_PullBTN);
            this.Controls.Add(this.CSM_PushBTN);
            this.Controls.Add(this.CSM_ChkkeyBTN);
            this.Controls.Add(this.CSM_ChkMACBTN);
            this.Controls.Add(this.CSM_DeRBTN);
            this.Controls.Add(this.CSM_RegBTN);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CSM_RegBTN;
        private System.Windows.Forms.Button CSM_DeRBTN;
        private System.Windows.Forms.Button CSM_ChkMACBTN;
        private System.Windows.Forms.Button CSM_ChkkeyBTN;
        private System.Windows.Forms.Button CSM_PushBTN;
        private System.Windows.Forms.Button CSM_PullBTN;
        private System.Windows.Forms.TextBox TestCSMAPI_textBox;
        private System.Windows.Forms.Button DAN_PULL_BTN;
        private System.Windows.Forms.Button DAN_PUSH_BTN;
        private System.Windows.Forms.Button DAN_DELETE_BTN;
        private System.Windows.Forms.Button DAN_REGISTER_BTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TestDAN_textbox;
    }
}

