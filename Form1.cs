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

namespace hospitalmanagementsystem
{
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\grishma\OneDrive\Documents\hospitalManagement.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DocNameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda= new SqlDataAdapter("select Count(*) from DoctorTbl where DocName='"+DocNameTb.Text+"' and DocPass='"+PassTb.Text+"'",Con );
                DataTable dt=new DataTable();   
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                 Home H = new Home();
                H.Show();
                this.Hide();
                }
                else
                {
                    MessageBox.Show("wrong Username and Password");
                }
                Con.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            DocNameTb.Text = "";
            PassTb.Text = "";
        }
    }
}
