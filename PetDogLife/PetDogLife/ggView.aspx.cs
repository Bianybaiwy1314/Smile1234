﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;


public partial class news : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {



            showInfo();

        }
    }

    protected void showInfo()
    {
        //判断是否传递id
        if (Request.QueryString["id"] != null)
        {

            //根据编号得到相应的记录
            SqlDataReader sdr = SqlHelper.ExecuteReader("select  * from dog where did=" + Request.QueryString["id"]);
            if (sdr.Read())
            {

                lbdname.Text = sdr["dname"].ToString();
                //lbaddtime.Text = sdr["addtime"].ToString();
                imgphoto.ImageUrl = "uploads/" + sdr["photo"].ToString();
                lbmemo.Text = sdr["memo"].ToString();

            }

        }
    }






}
