using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WareHouseModels;
using System.Text.RegularExpressions;

namespace Main
{
    public partial class Form1 : Form
    {
        DataBase data = new DataBase();
        User ur = null;
        public static string userName;
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region 获取用户
        public User getUser(string userName, string pwd)
        {
            string sql = string.Format("select * from People where userName='{0}' and PassWord='{1}'", userName, pwd);
            DataTable dt = data.Query(sql);
            if (dt.Rows.Count > 0)//18259028360
            {
                ur = new User();
                ur.UserName = dt.Rows[0][1].ToString();
                ur.PassWord = dt.Rows[0][2].ToString();
            }
            return ur;
        }
        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        #region 正则表达式约束输入条件
        public void login(string ss)
        {
            if (!Regex.IsMatch(ss, @"^[a-zA-Z0-9-]{1,20}$"))
            {
                this.lblUserName.Text = "*请输入字母或者数字及分隔符，长度不超过20";
                this.lblUserName.Visible = true;
            }
            else
            {
                this.lblUserName.Visible = false;
            }
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            login(this.textBox1.Text.ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == null || this.textBox1.Text.Equals(""))
            {
                MessageBox.Show("用户名不能为空");
            }
            else if (this.textBox2.Text == null || this.textBox2.Text.Equals(""))
            {
                MessageBox.Show("密码不能为空");
            }
            else if (this.lblUserName.Visible || this.lblPassword.Visible)
            {
                MessageBox.Show("输入的格式有错");
            }
            else
            {
                getUser(this.textBox1.Text.ToString(), this.textBox2.Text.ToString());
                if (ur != null)
                {
                    userName = this.textBox1.Text;
                    FrmAdd ff = new FrmAdd();
                    ff.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}