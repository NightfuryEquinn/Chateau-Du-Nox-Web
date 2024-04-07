using System;
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
      if (Session["Name"] != null)
      {
        Response.Write(
          "<script>alert('You have logged in already.'); document.location.href='./Home.aspx';</script>"
        );
      }
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

          string userId = "";
          string username = "";
          string role = "";

          if (reader.Read())
          {
            userId = reader["UserId"].ToString().Trim();
            username = reader["Name"].ToString().Trim();
            role = reader["Role"].ToString().Trim();
          }

          reader.Close();

          string checkActiveQuery = "SELECT Active FROM [User] WHERE UserId = @UserId";
          SqlCommand checkActiveCommand = new SqlCommand(checkActiveQuery, conn);
          checkActiveCommand.Parameters.AddWithValue("@UserId", userId);

          int status = Convert.ToInt32(checkActiveCommand.ExecuteScalar()?.ToString());

          if (status == 1)
          {
            Session["UserId"] = userId;
            Session["Name"] = username;
            Session["Role"] = role;

            Response.Write(
              "<script>alert('Welcome back, " + username + ".'); document.location.href='./Home.aspx';</script>"
            );
          }
          else
          {
            Response.Write(
              "<script>alert('Your account has been suspended or deactivated by our admin. Please contact our customer service at service@chateaudunox.com.'); document.location.href='./Home.aspx';</script>"
            );
          }
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