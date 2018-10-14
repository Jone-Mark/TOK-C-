using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net;
using System.IO;

namespace TOK_IOT
{
    public partial class TOK_IOT : Form
    {
        public TOK_IOT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.axVLCPlugin21.playlist.add(@"http://bitdash-a.akamaihd.net/content/sintel/hls/video/250kbit.m3u8");
            this.axVLCPlugin21.playlist.add(@"rtsp://47.106.209.211:8554/tok.mp4");
            this.axVLCPlugin21.playlist.play();
        }
        string head = "";
        string str = System.IO.Directory.GetCurrentDirectory();
        private void button3_Click(object sender, EventArgs e)
        {
            string htmll = http.Gethtml(URL.Text, Cookie.Text);
            richTextBox1.AppendText(htmll);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string htmlp = http.post(URL.Text, Post.Text, Cookie.Text, refer.Text, head);
            richTextBox1.AppendText(htmlp);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://47.106.209.211:8888");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://47.106.209.211/TOK_IOT");
        }
    }
}
