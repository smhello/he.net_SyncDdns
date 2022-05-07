using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
namespace DDNS_END
{
    public partial class Form1 : Form
    {
        //初始化的基本信息
        //用户名  密码
        string user, passwd;
        //同步的时间
        int count = 0;
        //开始关闭标志
        bool flag = false;
        //同步反复执行标志
        bool sync_flag = true;
        //多线程委托
        delegate void addip();
        delegate void addDDNS();
        //2个线程
        Thread thread_1, thread_2;
        //时间计数器秒为单位
        int count_timer = 0;



        public Form1()
        {
            InitializeComponent();

        }
        //更新公网Ip触发的事件
        public void Updateipthread()
        {
            while (sync_flag)
            {

                try
                {
                    this.BeginInvoke(new addip(Updatepublicip));
                }
                catch (Exception error_message)
                {

                }
                Thread.Sleep(10000);
            }
        }
        //更新公网Ip执行的事件
        public void Updatepublicip()
        {
            try
            {
                Text_ip.Text = Getpublicip();
            }
            catch (Exception error_message)
            {
                Text_error.Text = "请检查网络是否正常";
            }
        }
        //同步更新ddns触发的事件
        public void Updateddnsthread()
        {
            while (sync_flag)
            {
                try
                {
                    this.BeginInvoke(new addDDNS(Updatddns));
                    Thread.Sleep(count * 1000 * 60);
                }
                catch (Exception error_message)
                {

                }
            }
        }
        //同步更新ddns执行的事件
        public void Updatddns()
        {
            try
            {
                //判断计时器是否走完如果没有走完重置计时器
                if (count_timer <= (count * 60))
                {
                    timer2.Stop();
                    count_timer = 0;
                    progressBar1.Value = 0;
                    timer2.Start();
                }

                //错误清空
                Text_error.Text = "";

                //临时错误信息
                string sync_message = "";

                sync_message = Syncip(user, passwd);
                //写入日志
                Writelog("sync_log", sync_message, true);
                //获取更新日志
                Text_sync_message.Text = sync_message;

            }
            catch (Exception error_message)
            {
                Text_error.Text = "同步出错，继续重新同步";
                try
                {
                    if (count_timer <= (count * 60))
                    {
                        timer2.Stop();
                        count_timer = 0;
                        progressBar1.Value = 0;
                        timer2.Start();
                    }
                    Text_error.Text = "";
                    Text_sync_message.Text = Syncip(user, passwd);

                }
                catch
                {
                    Text_error.Text = "同步出错，继续重新同步";
                }
            }
        }

        //保存日志
        public void Writelog(string fileNnme, string sinfo, bool bAppend)
        {
            //获取当前程序运行的文件夹
            string sDir = System.AppDomain.CurrentDomain.BaseDirectory;

            //拼接当前程序文件和日志文件
            sDir = Path.Combine(sDir);

            //创建存放日志文件名称
            if (!Directory.Exists(sDir))
            {
                Directory.CreateDirectory(sDir);
            }
            //拼接日志文件路径和日志文件名称得到日志全路径
            sDir = Path.Combine(sDir, fileNnme + ".txt");

            try
            {
                FileMode fm;
                if (bAppend)
                {
                    fm = FileMode.Append;
                }
                else
                {
                    fm = FileMode.Create;
                }
                //获取文件全路径
                FileStream fs = new FileStream(sDir, fm, FileAccess.Write);

                //根据文件流获得写入
                StreamWriter sw = new StreamWriter(fs);

                //获取当前时间

                string sTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //写入
                sw.Write("[" + sTime + "]" + sinfo + "\r\n");
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Text_error.Text = "日志保存错误查看是否有日志";
            }



        }

        //获取公网ip接口
        public string Getpublicip()
        {
            string result = null;
            WebRequest request = WebRequest.Create("http://ifconfig.cc");
            //认证校验信息
            request.Method = "GET";
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                streamReader.Close();

            }

            return result;

        }
        //获取ddns接口
        public string Syncip(string user, string passwd)
        {
            string result = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dyn.dns.he.net/nic/update?");

            //认证校验信息
            request.PreAuthenticate = true;
            NetworkCredential My = new NetworkCredential(user, passwd);
            request.Credentials = My;
            request.Method = "GET";


            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                if (httpResponse != null)
                {
                    streamReader.Close();
                    httpResponse.Close();
                    request.Abort();

                }


            }



            return result;
        }
        private void Text_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //加载窗口初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            Text_list.Items.Add("1分钟");
            Text_list.Items.Add("5分钟");
            Text_list.Items.Add("10分钟");
            Text_list.Items.Add("30分钟");
            Text_list.Items.Add("60分钟");
            Text_list.SelectedIndex = Text_list.Items.IndexOf("1分钟");
            timer1.Start();



            //触发最小化事件
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);


        }
        //最小化接口
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        //右下角最小化按钮事件
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        //时间同步
        private void timer1_Tick(object sender, EventArgs e)
        {
            current_data.Text = "当前时间：" + DateTime.Now.ToString("dd/MM HH:mm:ss");
        }
        //时间进度条
        private void timer2_Tick(object sender, EventArgs e)
        {
            count_timer++;
            progressBar1.Value = count_timer;
            try
            {
                //如果触碰到计时器立马停止
                if (count_timer == count * 60)
                {
                    timer2.Stop();
                    count_timer = 0;
                    progressBar1.Value = 0;
                    timer2.Start();
                }
            }
            catch (Exception error_message)
            {
                Text_error.Text = "计时器已经超出";
            }



        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        //同步执行代码
        private void B_sync_Click(object sender, EventArgs e)
        {
            if (this.flag == false)
            {
                if (Text_user.Text != "" && Text_passwd.Text != "")
                {
                    string time = Text_list.SelectedItem.ToString();

                    switch (time)
                    {
                        case "1分钟":
                            //初始化的信息
                            count = 1;
                            B_sync.BackColor = System.Drawing.Color.Red;
                            B_sync.Text = "关闭";
                            this.flag = true;
                            this.sync_flag = true;
                            this.user = Text_user.Text;
                            this.passwd = Text_passwd.Text;
                            Text_error.Text = "";

                            progressBar1.Maximum = this.count * 60;

                            //创建多线程处理
                            try
                            {
                                this.thread_1 = new Thread(new ThreadStart(Updateipthread));
                                this.thread_2 = new Thread(new ThreadStart(Updateddnsthread));
                                thread_1.Start();
                                thread_2.Start();
                            }
                            catch (Exception error_message)
                            {
                                Text_error.Text = error_message.Message;
                            }


                            break;
                        case "5分钟":
                            //初始化的信息
                            count = 5;
                            B_sync.BackColor = System.Drawing.Color.Red;
                            B_sync.Text = "关闭";
                            this.flag = true;
                            this.sync_flag = true;
                            this.user = Text_user.Text;
                            this.passwd = Text_passwd.Text;
                            Text_error.Text = "";

                            progressBar1.Maximum = this.count * 60;

                            //创建多线程处理
                            try
                            {
                                this.thread_1 = new Thread(new ThreadStart(Updateipthread));
                                this.thread_2 = new Thread(new ThreadStart(Updateddnsthread));
                                thread_1.Start();
                                thread_2.Start();
                            }
                            catch (Exception error_message)
                            {
                                Text_error.Text = error_message.Message;
                            }



                            break;
                        case "10分钟":
                            //初始化的信息
                            this.count = 10;
                            B_sync.BackColor = System.Drawing.Color.Red;
                            B_sync.Text = "关闭";
                            this.flag = true;
                            this.sync_flag = true;
                            this.user = Text_user.Text;
                            this.passwd = Text_passwd.Text;
                            Text_error.Text = "";
                            Text_error.Text = "";

                            progressBar1.Maximum = this.count * 60;

                            //创建多线程处理
                            try
                            {
                                this.thread_1 = new Thread(new ThreadStart(Updateipthread));
                                this.thread_2 = new Thread(new ThreadStart(Updateddnsthread));
                                thread_1.Start();
                                thread_2.Start();
                            }
                            catch (Exception error_message)
                            {
                                Text_error.Text = error_message.Message;
                            }

                            break;
                        case "30分钟":
                            //初始化的信息
                            this.count = 30;
                            B_sync.BackColor = System.Drawing.Color.Red;
                            B_sync.Text = "关闭";
                            this.flag = true;
                            this.sync_flag = true;
                            this.user = Text_user.Text;
                            this.passwd = Text_passwd.Text;
                            Text_error.Text = "";
                            Text_error.Text = "";
                            progressBar1.Maximum = this.count * 60;
                            //创建多线程处理
                            try
                            {
                                this.thread_1 = new Thread(new ThreadStart(Updateipthread));
                                this.thread_2 = new Thread(new ThreadStart(Updateddnsthread));
                                thread_1.Start();
                                thread_2.Start();
                            }
                            catch (Exception error_message)
                            {
                                Text_error.Text = error_message.Message;
                            }


                            break;
                        case "60分钟":
                            //初始化的信息
                            this.count = 60;
                            B_sync.BackColor = System.Drawing.Color.Red;
                            B_sync.Text = "关闭";
                            this.flag = true;
                            this.sync_flag = true;
                            this.user = Text_user.Text;
                            this.passwd = Text_passwd.Text;
                            Text_error.Text = "";
                            Text_error.Text = "";
                            progressBar1.Maximum = count * 60;

                            //创建多线程处理
                            try
                            {
                                this.thread_1 = new Thread(new ThreadStart(Updateipthread));
                                this.thread_2 = new Thread(new ThreadStart(Updateddnsthread));
                                thread_1.Start();
                                thread_2.Start();
                            }
                            catch (Exception error_message)
                            {
                                Text_error.Text = error_message.Message;
                            }


                            break;

                        default:
                            break;


                    }
                }
                else
                {
                    Text_error.Text = "请输入你的账号或密码";
                }
            }
            else
            {
                if (this.flag == true)
                {
                    //同步ddns关闭
                    this.sync_flag = false;
                    //开始关闭
                    this.flag = false;
                    //进度条清空
                    timer2.Stop();
                    count_timer = 0;
                    progressBar1.Value = 0;



                    B_sync.Text = "开始";
                    B_sync.BackColor = System.Drawing.Color.White;
                    Text_error.Text = "";
                    Text_sync_message.Text = "";
                    Text_ip.Text = "";
                }

            }




        }

        private void B_exit_Click(object sender, EventArgs e)
        {
            Text_ip.Text = "";
            Text_sync_message.Text = "";
            Text_list.Text = "";
            Text_error.Text = "";
        }
    }
}
