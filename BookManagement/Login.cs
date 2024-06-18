﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\VScode\LibraryManagement\BookManagement\Data\BookStore.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void button3_Click(object sender, EventArgs e)//退出按钮
        {
            Application.Exit();
        }
        public static string userNameId = "";
        private void signIn_Click(object sender, EventArgs e)//登录按钮
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTb1 where UName='" + uNameInput.Text + "' and UPassword='" + uPasswordInput.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                userNameId = uNameInput.Text;
                Shopping obj = new Shopping();
                obj.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
                uPasswordInput.Text = "";
            }
            con.Close();
        }

        private void adminSignIn_Click(object sender, EventArgs e)//管理员登录
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void signUp_Click(object sender, EventArgs e)//注册按钮
        {
            MessageBox.Show("内测中，请与管理员联系");
        }
    }
}