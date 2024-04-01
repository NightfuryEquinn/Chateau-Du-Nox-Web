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
  public partial class Forget : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
      try
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
            if (check == 1)
            {
              string getIdQuery = "SELECT * FROM [User] WHERE EmailAddress = @Email";
              SqlCommand getIdCommand = new SqlCommand(getIdQuery, conn);
              getIdCommand.Parameters.AddWithValue("@Email", EmailInput.Text.Trim());

              SqlDataReader reader = getIdCommand.ExecuteReader();
              string theUserId = "";

              while (reader.Read())
              {
                theUserId = reader["UserId"].ToString().Trim();
              }

              reader.Close();

              string updateQuery = "UPDATE [User] SET Password = @Password WHERE UserId = @UserId";
              SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
              updateCommand.Parameters.AddWithValue("@Password", PasswordInput.Text.Trim());
              updateCommand.Parameters.AddWithValue("@UserId", theUserId);

              updateCommand.ExecuteNonQuery();

              Response.Write(
                "<script>alert('Your password has been reset successfully.'); document.location.href='./Login.aspx';</script>"
              );
            }
            else
            {
              Response.Write(
                "<script>alert('Email address does not exist. Please try again.');</script>"
              );
            }  
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
      catch (Exception ex)
      {
        Debug.WriteLine("Forget Error: ", ex.Message);
      }
    }
  }
}