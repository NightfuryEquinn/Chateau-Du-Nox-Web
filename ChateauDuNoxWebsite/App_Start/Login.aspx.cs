﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start
{
  public partial class Login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string query = "SELECT COUNT(*) FROM [User] WHERE Name = @Name AND Password = @Password";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("@Name", UsernameInput.Text.Trim());
        command.Parameters.AddWithValue("@Password", PasswordInput.Text.Trim());

        int check = Convert.ToInt32(command.ExecuteScalar().ToString());

        if (check == 1)
        {
          string checkQuery = "SELECT * FROM [User] WHERE Name = @Name AND Password = @Password";
          SqlCommand commandCheck = new SqlCommand(checkQuery, conn);
          commandCheck.Parameters.AddWithValue("@Name", UsernameInput.Text.Trim());
          commandCheck.Parameters.AddWithValue("@Password", PasswordInput.Text.Trim());

          SqlDataReader reader = commandCheck.ExecuteReader();

          string username = "";
          string role = "";

          while (reader.Read())
          {
            username = reader["Name"].ToString().Trim();
            role = reader["Role"].ToString().Trim();
          }

          reader.Close();

          Session["Name"] = username;
          Session["Role"] = role;

          Response.Write(
            "<script>alert('Welcome back, " + username + ".'); document.location.href='./Home.aspx';</script>"
          );
        }
        else
        {
          Response.Write(
            "<script>alert('Invalid credentials. Please try again.'); document.location.href='./Login.aspx';</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Login Error: ", ex.Message);
      }
    }
  }
}