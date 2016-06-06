using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            SHDocVw.InternetExplorer ie;
            object vPost, vHeaders, vFlags, vTargetFrame, vUrl;
            string username, password, cPostData;
            vFlags = null;
            vTargetFrame = null;
            vUrl = " https://mail.126.com/entry/cgi/ntesdoor";
            username = txtUsername.Text;
            password = txtPassword.Text;
            cPostData = "funcid=loginone&passtype=1&product=mail126&username="+username+"&password="+password;
            vHeaders = "Content-Type: application/x-www-form-urlencoded" + Convert.ToChar(10) + Convert.ToChar(13);
            
            //Convert the string to post to an array of bytes.
            vPost = ASCIIEncoding.ASCII.GetBytes(cPostData);
            //Create an instance of Internet Explorer and make it visible.
            ie = new SHDocVw.InternetExplorer();
            ie.Visible = true;
            ie.Navigate2(ref vUrl, ref vFlags, ref vTargetFrame, ref vPost, ref vHeaders);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ///以默认密码方式显示密码字符
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
