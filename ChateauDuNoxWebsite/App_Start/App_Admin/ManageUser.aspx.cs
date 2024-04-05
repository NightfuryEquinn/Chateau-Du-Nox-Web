using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start.App_Admin
{
  public partial class ManageUser : System.Web.UI.Page
  {
    public class UserData
    {
      public int UserId { get; set; }
      public string Name { get; set; }
      public byte[] Avatar { get; set; }
      public string Role { get; set; }
      public string EmailAddress { get; set; }
      public string Password { get; set; }
      public string PhoneNumber { get; set; }
      public string ShippingAddress { get; set; }
      public string BillingAddress { get; set; }
      public string RegisteredDate { get; set; }
      public int Active { get; set; } 
    }

    public List<UserData> GetUserByRoleStatus(SqlConnection conn, string role, int status)
    {
      string fetchUserQuery = "SELECT * FROM [User] WHERE Active = @Status";
      if (!string.IsNullOrEmpty(role))
      {
        fetchUserQuery += " AND Role = @Role";
      }

      SqlCommand fetchCommand = new SqlCommand(fetchUserQuery, conn);
      fetchCommand.Parameters.AddWithValue("@Status", status);
      if (!string.IsNullOrEmpty(role))
      {
        fetchCommand.Parameters.AddWithValue("@Role", role);
      }

      SqlDataReader reader = fetchCommand.ExecuteReader();
      List<UserData> users = new List<UserData>();

      while (reader.Read())
      {
        UserData user = new UserData
        {
          UserId = Convert.ToInt32(reader["UserId"]),
          Name = reader["Name"].ToString(),
          Avatar = (byte[])reader["Avatar"],
          Role = reader["Role"].ToString(),
          EmailAddress = reader["EmailAddress"].ToString(),
          Password = reader["Password"].ToString(),
          PhoneNumber = reader["PhoneNumber"].ToString(),
          ShippingAddress = reader["ShippingAddress"].ToString(),
          BillingAddress = reader["BillingAddress"].ToString(),
          RegisteredDate = DateTime.Parse(reader["RegisteredDate"].ToString()).ToShortDateString(),
          Active = Convert.ToInt32(reader["Active"].ToString())
        };

        users.Add(user);
      }

      reader.Close();
      return users;
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        List<UserData> admins = GetUserByRoleStatus(conn, "Admin", 1);
        List<UserData> activeUsers = GetUserByRoleStatus(conn, "User", 1);
        List<UserData> inactiveUsers = GetUserByRoleStatus(conn, null, 0);

        AdminRepeater.DataSource = admins;
        AdminRepeater.DataBind();

        ActiveRepeater.DataSource = activeUsers;
        ActiveRepeater.DataBind();

        InactiveRepeater.DataSource = inactiveUsers;
        InactiveRepeater.DataBind();

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch User Error:", ex.Message);
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["Role"] as string != "Admin")
      {
        Response.Write(
          "<script>alert('Only admin has access to this page.'); document.location.href='../Home.aspx';</script>"
        );
      }
      else if (!Page.IsPostBack)
      {
        loadPageContent();
      }
    }

    protected void ChangeRole_Click(object sender, EventArgs e)
    {
      Button changeButton = (Button)sender;
      string userId = changeButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string roleQuery = "SELECT Role FROM [User] WHERE UserId = @UserId";
        SqlCommand roleCommand = new SqlCommand(roleQuery, conn);
        roleCommand.Parameters.AddWithValue("@UserId", userId);

        string currentRole = roleCommand.ExecuteScalar()?.ToString();

        // If is user, then to admin; vice versa
        string newRole = (currentRole == "Admin") ? "User" : "Admin";

        string updateQuery = "UPDATE [User] SET Role = @Role WHERE UserId = @UserId";
        SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
        updateCommand.Parameters.AddWithValue("@UserId", userId);
        updateCommand.Parameters.AddWithValue("@Role", newRole);

        if (Session["UserId"] as string != userId)
        {
          updateCommand.ExecuteNonQuery();

          Response.Write(
            "<script>alert('" + (newRole == "User" ? "Admin" : "User") + " with ID " + userId + " has been changed to " + (newRole == "User" ? "user" : "admin") + ".'); document.location.href='./ManageUser.aspx';</script>"
          );
        }
        else
        {
          Response.Write(
            "<script>alert('You cannot edit yourself. Please switch to another admin account to do so.');</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Change Admin to User Role Error:", ex.Message);
      }
    }

    protected void ViewProfile_Click(object sender, EventArgs e)
    {

    }

    protected void DeleteUser_Click(object sender, EventArgs e)
    {

    }
  }
}