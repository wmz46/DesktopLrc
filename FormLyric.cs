using Fleck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLrc
{
    public partial class FormLyric : Form
    { 

        private WebSocketServer _server;
        private static List<IWebSocketConnection> _allSockets = new List<IWebSocketConnection>();
        private string _wsAddr = "ws://127.0.0.1:15577";
        private List<Lyric> _lrc;
        private string lastMessage;
        private string fontFamily = "黑体";
        private Color color1 = Color.Yellow;
        private Color color2 = Color.LightBlue;
        private Color color3 = Color.Black;
        FormSettings formSetting = null;

        public FormLyric()
        {
            InitializeComponent();
              
            //背景改为灰色，避免透明时字体锯齿过于明显
            this.BackColor = Color.DarkGray; 
            //双缓存处理
            this.DoubleBuffered = true;
            this.TransparencyKey = this.BackColor;
            this.MouseHover += Form1_MouseHover;
            this.LostFocus += Form1_LostFocus;
            //置顶
            this.TopMost = true;
            //不允许最小化
            this.MinimizeBox = false;
            //不允许最大化
            this.MaximizeBox = false;
            //不显示在任务栏
            this.ShowInTaskbar = false;

            ResizeForm();

            this.StartPosition = FormStartPosition.Manual;

            this.FormBorderStyle = FormBorderStyle.None;
            this.FormClosed += Form1_FormClosed;
            this.Resize += FormLyric_Resize;
            StartServer();

        }

        private void FormLyric_Resize(object sender, EventArgs e)
        {
            PrintForm();
        }

        private void _notifyIcon_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopServer();
        }

        public void ResizeForm()
        {
            //主屏幕宽度和高度
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //50为预留任务栏高度，不想写WinApi获取 
            int taskbarHeight = 50;
            int margin = 40;
            if (Settings.horizontalMode)
            {
                int windowWidth = screenWidth < 1000 ? screenWidth : 1000;
                int windowHeight = 200;
                this.Width = windowWidth;
                this.Height = windowHeight;
                int top = screenHeight - windowHeight - taskbarHeight;
                int left = (screenWidth - windowWidth) / 2;
                this.Location = new Point(left, top);
            }
            else
            {
                int windowWidth = 200;
                int windowHeight = screenHeight - taskbarHeight - margin < 1000 ? screenHeight - taskbarHeight - margin : 1000;

                this.Width = windowWidth;
                this.Height = windowHeight;
                int top = (screenHeight - windowHeight - taskbarHeight) / 2;
                int left = screenWidth - windowWidth - margin;
                this.Location = new Point(left, top);

            }
        }
        private void Form1_LostFocus(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.TransparencyKey = this.BackColor; 
            }
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.TransparencyKey = Color.Transparent; 
            }
        }



        private void StartServer()
        {
            try
            {
                _server = new WebSocketServer(_wsAddr);
                _server.Start(socket =>
                {
                    socket.OnOpen = () =>
                    {
                        _allSockets.Add(socket);
                    };
                    socket.OnClose = () =>
                    {
                        _allSockets.Remove(socket);
                    };
                    socket.OnMessage = message =>
                    {
                        _lrc = JsonSerializer.Deserialize<List<Lyric>>(message);
                        if (lastMessage != message)
                        {
                            PrintForm();
                            lastMessage = message;
                        }

                    };
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("开启服务失败，端口可能被占用。\n错误信息:" + ex.Message);
                Application.Exit();
            }
        }
        public void PrintForm()
        {

            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Font font = new Font(fontFamily, Settings.fontSize);
            if (_lrc != null && _lrc.Count > 0)
            {
                for (var i = 0; i < _lrc.Count; i++)
                {
                    int lineHeight = (int)(Settings.fontSize * 1.5);
                    Point txtPoint = Settings.horizontalMode ? new Point(0, i * lineHeight) : new Point(i * lineHeight, 0);

                    StringFormat stringFormat = Settings.horizontalMode ? new StringFormat() : new StringFormat(StringFormatFlags.DirectionVertical);
                    string txt = _lrc[i].text;
                    // 绘制左背景文字  
                    txtPoint.Offset(-1, 0);
                    g.DrawString(txt, font, new SolidBrush(color3), txtPoint, stringFormat);
                    // 绘制右背景文字  
                    txtPoint.Offset(2, 0);
                    g.DrawString(txt, font, new SolidBrush(color3), txtPoint, stringFormat);
                    // 绘制下背景文字  
                    txtPoint.Offset(-1, -1);
                    g.DrawString(txt, font, new SolidBrush(color3), txtPoint, stringFormat);
                    // 绘制上背景文字  
                    txtPoint.Offset(0, 2);
                    g.DrawString(txt, font, new SolidBrush(color3), txtPoint, stringFormat);
                    // 定位点归位 
                    txtPoint.Offset(0, -1);
                    g.DrawString(txt, font, new SolidBrush(_lrc[i].active ? color1 : color2), txtPoint, stringFormat);
                }
            }
        }
        private void StopServer()
        {
            _server.Dispose();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (formSetting == null || !formSetting.Visible)
            {
                formSetting = new FormSettings(this);
                formSetting.Show();
            }

        }
    }
}
