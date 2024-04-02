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
  public partial class Register : System.Web.UI.Page
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

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
      try
      {
        if ((UsernameInput.Text != "") && (PasswordInput.Text != "") && (EmailInput.Text != ""))
        {
          if (PasswordInput.Text == ConfirmInput.Text)
          {
            if (PasswordInput.Text.Length > 9)
            {
              SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
              conn.Open();

              string query = "SELECT COUNT(*) FROM [User] WHERE EmailAddress = @Email";
              SqlCommand command = new SqlCommand(query, conn);
              command.Parameters.AddWithValue("@Email", EmailInput.Text.Trim());

              int check = Convert.ToInt32(command.ExecuteScalar().ToString());
              if (check > 0)
              {
                Response.Write(
                  "<script>alert('Email address already in use.');</script>"
                );
              }
              else
              {
                RegisterSDS.InsertParameters["Avatar"].DefaultValue = "0x";
                RegisterSDS.InsertParameters["Role"].DefaultValue = "User";
                RegisterSDS.InsertParameters["RegisteredDate"].DefaultValue = DateTime.Now.ToString();
                RegisterSDS.InsertParameters["Active"].DefaultValue = "1";
                RegisterSDS.Insert();

                Response.Write(
                  "<script>alert('Your account is created. Chateau du Nox welcomes you. Please proceed to login.'); document.location.href='./Login.aspx';</script>"
                );
              }

              conn.Close();
            }
            else
            {
              Response.Write(
                "<script>alert('Password must be more than 10 characters.');</script>"
              );
            }
          }
          else
          {
            Response.Write(
              "<script>alert('Passwords are not the same. Please check again.');</script>"
            );
          }
        }
        else
        {
          Response.Write(
            "<script>alert('Please fill in all empty fields.');</script>"
          );
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Register Error: ", ex.Message);
      }
    }
  }
}