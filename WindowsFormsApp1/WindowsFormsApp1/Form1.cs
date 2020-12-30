using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取所有设备
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //获取连接
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            this.videoSourcePlayer1.VideoSource = videoSource;
            this.videoSourcePlayer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.videoSourcePlayer1.SignalToStop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string imgName = DateTime.Now.ToString("yyyy,mm,dd,HH,mm,ss");
            string path = @"./"+imgName+".jpg";
            if (videoSourcePlayer1 == null) { return; }
            Bitmap bitmap = this.videoSourcePlayer1.GetCurrentVideoFrame();
            bitmap.Save(path);
            this.pictureBox1.ImageLocation = "./" + path;
        }
    }
}
