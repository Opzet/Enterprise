namespace MultiUserRealtimeApp
{
    partial class FrmMultiUserApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnWriteData = new System.Windows.Forms.Button();
            this.LblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LblEvents = new System.Windows.Forms.TextBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.BtnGetData = new System.Windows.Forms.Button();
            this.LblServerMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnWriteData
            // 
            this.BtnWriteData.Location = new System.Drawing.Point(371, 312);
            this.BtnWriteData.Name = "BtnWriteData";
            this.BtnWriteData.Size = new System.Drawing.Size(138, 67);
            this.BtnWriteData.TabIndex = 0;
            this.BtnWriteData.Text = "Write Api Data";
            this.BtnWriteData.UseVisualStyleBackColor = true;
            this.BtnWriteData.Click += new System.EventHandler(this.BtnWriteData_Click);
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.White;
            this.LblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTime.Location = new System.Drawing.Point(531, 137);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(124, 43);
            this.LblTime.TabIndex = 1;
            this.LblTime.Text = "HH:mm:ss";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 900;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LblEvents
            // 
            this.LblEvents.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblEvents.Location = new System.Drawing.Point(0, 0);
            this.LblEvents.Multiline = true;
            this.LblEvents.Name = "LblEvents";
            this.LblEvents.Size = new System.Drawing.Size(331, 450);
            this.LblEvents.TabIndex = 2;
            // 
            // LblUsername
            // 
            this.LblUsername.BackColor = System.Drawing.Color.White;
            this.LblUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblUsername.Location = new System.Drawing.Point(383, 137);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(130, 43);
            this.LblUsername.TabIndex = 3;
            this.LblUsername.Text = "username";
            this.LblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnGetData
            // 
            this.BtnGetData.Location = new System.Drawing.Point(577, 312);
            this.BtnGetData.Name = "BtnGetData";
            this.BtnGetData.Size = new System.Drawing.Size(138, 67);
            this.BtnGetData.TabIndex = 4;
            this.BtnGetData.Text = "Get Api Data";
            this.BtnGetData.UseVisualStyleBackColor = true;
            this.BtnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // LblServerMessage
            // 
            this.LblServerMessage.BackColor = System.Drawing.Color.White;
            this.LblServerMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblServerMessage.Location = new System.Drawing.Point(439, 19);
            this.LblServerMessage.Name = "LblServerMessage";
            this.LblServerMessage.Size = new System.Drawing.Size(216, 43);
            this.LblServerMessage.TabIndex = 5;
            this.LblServerMessage.Text = "...";
            this.LblServerMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(389, 208);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(292, 31);
            this.txtMessage.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox2.Location = new System.Drawing.Point(849, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(331, 450);
            this.textBox2.TabIndex = 7;
            // 
            // FrmMultiUserApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.LblServerMessage);
            this.Controls.Add(this.BtnGetData);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblEvents);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.BtnWriteData);
            this.Name = "FrmMultiUserApp";
            this.Text = "MultiUser ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnWriteData;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox LblEvents;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Button BtnGetData;
        private System.Windows.Forms.Label LblServerMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox textBox2;
    }
}

