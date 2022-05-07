
namespace DDNS_END
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_list = new System.Windows.Forms.ComboBox();
            this.B_exit = new System.Windows.Forms.Button();
            this.Text_error = new System.Windows.Forms.TextBox();
            this.Text_user = new System.Windows.Forms.TextBox();
            this.Text_passwd = new System.Windows.Forms.TextBox();
            this.Text_sync_message = new System.Windows.Forms.TextBox();
            this.Text_ip = new System.Windows.Forms.TextBox();
            this.B_sync = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.current_data = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 31);
            this.label6.TabIndex = 28;
            this.label6.Text = "错误信息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 31);
            this.label5.TabIndex = 27;
            this.label5.Text = "同步频率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 31);
            this.label4.TabIndex = 26;
            this.label4.Text = "同步反馈报文：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 31);
            this.label3.TabIndex = 25;
            this.label3.Text = "He.net密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 31);
            this.label2.TabIndex = 24;
            this.label2.Text = "He.net账号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "获取到的IP：";
            // 
            // Text_list
            // 
            this.Text_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Text_list.FormattingEnabled = true;
            this.Text_list.Location = new System.Drawing.Point(202, 253);
            this.Text_list.Name = "Text_list";
            this.Text_list.Size = new System.Drawing.Size(388, 39);
            this.Text_list.TabIndex = 22;
            this.Text_list.SelectedIndexChanged += new System.EventHandler(this.Text_list_SelectedIndexChanged);
            // 
            // B_exit
            // 
            this.B_exit.Location = new System.Drawing.Point(344, 387);
            this.B_exit.Name = "B_exit";
            this.B_exit.Size = new System.Drawing.Size(249, 70);
            this.B_exit.TabIndex = 21;
            this.B_exit.Text = "清除全部";
            this.B_exit.UseVisualStyleBackColor = true;
            this.B_exit.Click += new System.EventHandler(this.B_exit_Click);
            // 
            // Text_error
            // 
            this.Text_error.Location = new System.Drawing.Point(200, 320);
            this.Text_error.Name = "Text_error";
            this.Text_error.Size = new System.Drawing.Size(390, 38);
            this.Text_error.TabIndex = 20;
            // 
            // Text_user
            // 
            this.Text_user.Location = new System.Drawing.Point(199, 71);
            this.Text_user.Name = "Text_user";
            this.Text_user.Size = new System.Drawing.Size(392, 38);
            this.Text_user.TabIndex = 19;
            // 
            // Text_passwd
            // 
            this.Text_passwd.Location = new System.Drawing.Point(200, 134);
            this.Text_passwd.Name = "Text_passwd";
            this.Text_passwd.Size = new System.Drawing.Size(392, 38);
            this.Text_passwd.TabIndex = 18;
            // 
            // Text_sync_message
            // 
            this.Text_sync_message.Location = new System.Drawing.Point(200, 195);
            this.Text_sync_message.Name = "Text_sync_message";
            this.Text_sync_message.Size = new System.Drawing.Size(392, 38);
            this.Text_sync_message.TabIndex = 17;
            // 
            // Text_ip
            // 
            this.Text_ip.Location = new System.Drawing.Point(199, 16);
            this.Text_ip.Name = "Text_ip";
            this.Text_ip.Size = new System.Drawing.Size(392, 38);
            this.Text_ip.TabIndex = 16;
            // 
            // B_sync
            // 
            this.B_sync.Location = new System.Drawing.Point(15, 387);
            this.B_sync.Name = "B_sync";
            this.B_sync.Size = new System.Drawing.Size(242, 70);
            this.B_sync.TabIndex = 15;
            this.B_sync.Tag = "";
            this.B_sync.Text = "开始";
            this.B_sync.UseVisualStyleBackColor = true;
            this.B_sync.Click += new System.EventHandler(this.B_sync_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "he.netDDNS";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // current_data
            // 
            this.current_data.AutoSize = true;
            this.current_data.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.current_data.Location = new System.Drawing.Point(15, 489);
            this.current_data.Name = "current_data";
            this.current_data.Size = new System.Drawing.Size(0, 31);
            this.current_data.TabIndex = 29;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(323, 509);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(269, 18);
            this.progressBar1.TabIndex = 30;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 31);
            this.label7.TabIndex = 31;
            this.label7.Text = "下次同步进度";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 541);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.current_data);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_list);
            this.Controls.Add(this.B_exit);
            this.Controls.Add(this.Text_error);
            this.Controls.Add(this.Text_user);
            this.Controls.Add(this.Text_passwd);
            this.Controls.Add(this.Text_sync_message);
            this.Controls.Add(this.Text_ip);
            this.Controls.Add(this.B_sync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Ddns_v1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Text_list;
        private System.Windows.Forms.Button B_exit;
        private System.Windows.Forms.TextBox Text_error;
        private System.Windows.Forms.TextBox Text_user;
        private System.Windows.Forms.TextBox Text_passwd;
        private System.Windows.Forms.TextBox Text_sync_message;
        private System.Windows.Forms.TextBox Text_ip;
        private System.Windows.Forms.Button B_sync;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label current_data;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label7;
    }
}

