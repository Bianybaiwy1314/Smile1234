﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public partial class admin_pass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    /// <summary>
    /// 修改密码
    ///</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {   
               //判断两次密码输入是否相同
        if (TextBox1.Text == TextBox2.Text)
        {
            //根据用户编号和原密码得到用户信息
            SqlDataReader sdr = SqlHelper.ExecuteReader("select * from admin where lname='" + Session["bh"].ToString() + "' and pwd='" + txt_pwd.Text + "'");

            //判断原密码是否正确
            if (sdr.Read())
            {
                //更新新密码
                SqlHelper.ExecuteNonQuery("update admin set pwd='" + TextBox1.Text + "' where lname='" + Session["bh"].ToString()+ "'");
                MessageBox.Show(this, "修改成功!");

            }
            else
            {
                MessageBox.Show(this, "原密码不正确!");
            }
            sdr.Close();
        }
        else
        {
            MessageBox.Show(this, "两次密码输入不一致!");
        }

    }

}

