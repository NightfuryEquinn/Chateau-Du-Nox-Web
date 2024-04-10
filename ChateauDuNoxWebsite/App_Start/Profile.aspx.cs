using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start
{
  public partial class Profile : System.Web.UI.Page
  {
    public class ProfileData
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

    public class WishlistData
    {
      public int WishlistId { get; set; }
      public int Amount { get; set; }
      public int WineId { get; set; }
      public int UserId { get; set; }
    }

    public class CartData
    {
      public int CartId { get; set; }
      public int Amount { get; set; }
      public int WineId { get; set; }
      public int UserId { get; set; }
    }

    public class OrderData
    {
      public int OrderID { get; set; }
      public string Status { get; set; }
      public DateTime DeliveredDate { get; set; }
      public DateTime OrderedDate { get; set; }
      public int TotalPayable { get; set; }
      public int ReviewWritten { get; set; }
      public int Active { get; set; }
      public int WineId { get; set; }
      public int UserId { get; set; }
    }

    public class ReviewData
    {
      public int ReviewId { get; set; }
      public string Content { get; set; }
      public int Rating { get; set; }
      public DateTime WrittenDate { get; set; }
      public int Active { get; set; }
      public int WineId { get; set; }
      public int UserId { get; set; }
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        // Fetch for profile
        string fetchProfileQuery = "SELECT * FROM [User] WHERE UserId = @UserId";
        SqlCommand fetchProfileCommand = new SqlCommand(fetchProfileQuery, conn);
        fetchProfileCommand.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"].ToString()));

        SqlDataReader reader = fetchProfileCommand.ExecuteReader();
        List<ProfileData> profiles = new List<ProfileData>();

        if (reader.Read())
        {
          ProfileData profile = new ProfileData
          {
            UserId = Convert.ToInt32(reader["UserId"].ToString()),
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

          profiles.Add(profile);
        }

        ProfileRepeater.DataSource = profiles;
        ProfileRepeater.DataBind();

        EditName.Text = reader["Name"].ToString();
        EditEmailAddress.Text = reader["EmailAddress"].ToString();
        EditPhone.Text = reader["PhoneNumber"].ToString();
        EditShipping.Text = reader["ShippingAddress"].ToString();
        EditBilling.Text = reader["BillingAddress"].ToString();

        reader.Close();

        // Fetch for Wishlist


        // Fetch for Cart


        // Fetch for Order


        // Fetch for Review


        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Profile Error:", ex.Message);
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["Name"] == null)
      {
        Response.Write(
          "<script>alert('Please login to view your profile page. If you do not have an account, please kindly register a new account.'); document.location.href='./Login.aspx';</script>"
        );
      }
      else if (!Page.IsPostBack)
      {
        loadPageContent();
      }
    }

    protected void ChangePass_Click(object sender, EventArgs e)
    {
      Response.Redirect("Forget.aspx");
    }

    protected void EditProfile_Click(object sender, EventArgs e)
    {
      Button editButton = (Button)sender;
      string name = editButton.CommandArgument;

      Uri currentUri = HttpContext.Current.Request.Url;
      if (string.IsNullOrEmpty(currentUri.Query))
      {
        StringBuilder builder = new StringBuilder("Profile.aspx?Name=" + name);
        Response.Redirect(builder.ToString());
      }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        int userId = Convert.ToInt32(Session["UserId"].ToString());

        string name = EditName.Text.Trim();
        byte[] avatar = EditAvatarUpload.FileBytes;
        string email = EditEmailAddress.Text.Trim();
        string phone = EditPhone.Text.Trim();
        string shipping = EditShipping.Text.Trim();
        string billing = EditBilling.Text.Trim();

        if (!string.IsNullOrWhiteSpace(name) &&
          !string.IsNullOrWhiteSpace(email) &&
          !string.IsNullOrWhiteSpace(phone) &&
          !string.IsNullOrWhiteSpace(shipping) &&
          !string.IsNullOrWhiteSpace(billing)
        )
        {
          if (avatar != null && avatar.Length != 0)
          {
            string updateQuery = @"
                                UPDATE [User] SET
                                Name = @Name, Avatar = @Avatar, EmailAddress = @Email, PhoneNumber = @Phone, ShippingAddress = @Shipping, BillingAddress = @Billing
                                WHERE UserId = @UserId
                                ";
            SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
            updateCommand.Parameters.AddWithValue("@UserId", userId);
            updateCommand.Parameters.AddWithValue("@Name", name);
            SqlParameter avatarParam = new SqlParameter("@Avatar", SqlDbType.VarBinary)
            {
              Value = avatar
            };
            updateCommand.Parameters.Add(avatarParam);
            updateCommand.Parameters.AddWithValue("@Email", email);
            updateCommand.Parameters.AddWithValue("@Phone", phone);
            updateCommand.Parameters.AddWithValue("@Shipping", shipping);
            updateCommand.Parameters.AddWithValue("@Billing", billing);

            updateCommand.ExecuteNonQuery();

            Response.Write(
              "<script>alert('Details and image of " + name + " has been edited successfully.'); document.location.href='./Profile.aspx';</script>"
            );
          }
          else
          {
            string updateQuery = @"
                                UPDATE [User] SET
                                Name = @Name, EmailAddress = @Email, PhoneNumber = @Phone, ShippingAddress = @Shipping, BillingAddress = @Billing
                                WHERE UserId = @UserId
                                ";
            SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
            updateCommand.Parameters.AddWithValue("@UserId", userId);
            updateCommand.Parameters.AddWithValue("@Name", name);
            updateCommand.Parameters.AddWithValue("@Email", email);
            updateCommand.Parameters.AddWithValue("@Phone", phone);
            updateCommand.Parameters.AddWithValue("@Shipping", shipping);
            updateCommand.Parameters.AddWithValue("@Billing", billing);

            updateCommand.ExecuteNonQuery();

            Response.Write(
              "<script>alert('Details of " + name + " has been edited successfully.');  document.location.href='./Profile.aspx';</script>"
            );
          }
        }
        else
        {
          Response.Write(
            "<script>alert('Please fill up all empty fields. Image is optional unless change is required.'); document.location.href='./Profile.aspx';</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Edit Profile Error:", ex.Message);
      }
    }

    protected void WishlistRemove_Click(object sender, EventArgs e)
    {

    }

    protected void CartRemove_Click(object sender, EventArgs e)
    {

    }

    protected void CartCheckout_Click(object sender, EventArgs e)
    {

    }

    protected void OrderCancel_Click(object sender, EventArgs e)
    {

    }

    protected void OrderConfirm_Click(object sender, EventArgs e)
    {

    }

    protected void OrderRate_Click(object sender, EventArgs e)
    {

    }

    protected void ReviewView_Click(object sender, EventArgs e)
    {

    }
  }
}