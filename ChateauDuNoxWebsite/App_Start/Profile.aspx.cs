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
      public string WineName { get; set; }
      public int UserId { get; set; }
    }

    public class CartData
    {
      public int CartId { get; set; }
      public int Amount { get; set; }
      public int WineId { get; set; }
      public string WineName { get; set; }
      public int WinePrice { get; set; }
      public int WineTotal { get; set; }
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
      public string WineName { get; set; }
    }

    public class ReviewData
    {
      public int ReviewId { get; set; }
      public string Content { get; set; }
      public int Rating { get; set; }
      public DateTime WrittenDate { get; set; }
      public int Active { get; set; }
      public int WineId { get; set; }
      public string WineName { get; set; }
      public int UserId { get; set; }
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        int userId = Convert.ToInt32(Session["UserId"].ToString());

        // Fetch for profile
        string fetchProfileQuery = "SELECT * FROM [User] WHERE UserId = @UserId";
        SqlCommand fetchProfileCommand = new SqlCommand(fetchProfileQuery, conn);
        fetchProfileCommand.Parameters.AddWithValue("@UserId", userId);

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
        string fetchWishlistQuery = @"
                                  SELECT Wishlist.*, Wine.Name FROM Wishlist 
                                  JOIN Wine on Wishlist.WineId = Wine.WineId 
                                  WHERE Wishlist.UserId = @UserId
                                  ";
        SqlCommand fetchWishlistCommand = new SqlCommand(fetchWishlistQuery, conn);
        fetchWishlistCommand.Parameters.AddWithValue("@UserId", userId);

        SqlDataReader wishlistReader = fetchWishlistCommand.ExecuteReader();
        List<WishlistData> wishlists = new List<WishlistData>();

        while (wishlistReader.Read())
        {
          WishlistData wishlist = new WishlistData
          {
            WishlistId = Convert.ToInt32(wishlistReader["WishlistId"].ToString()),
            Amount = Convert.ToInt32(wishlistReader["Amount"].ToString()),
            WineId = Convert.ToInt32(wishlistReader["WineId"].ToString()),
            WineName = wishlistReader["Name"].ToString(),
            UserId = Convert.ToInt32(wishlistReader["UserId"].ToString())
          };

          wishlists.Add(wishlist);
        }

        WishlistRepeater.DataSource = wishlists;
        WishlistRepeater.DataBind();

        wishlistReader.Close();

        // Fetch for Cart
        string fetchCartQuery = @"
                              SELECT Cart.*, Wine.Name, Wine.Price, (Cart.Amount * Wine.Price) AS Total FROM Cart 
                              JOIN Wine on Cart.WineId = Wine.WineId 
                              WHERE Cart.UserId = @UserId
                              ";
        SqlCommand fetchCartCommand = new SqlCommand(fetchCartQuery, conn);
        fetchCartCommand.Parameters.AddWithValue("@UserId", userId);

        SqlDataReader cartReader = fetchCartCommand.ExecuteReader();
        List<CartData> carts = new List<CartData>();
        int totalCartPrice = 0;

        while (cartReader.Read())
        {
          CartData cart = new CartData
          {
            CartId = Convert.ToInt32(cartReader["CartId"].ToString()),
            Amount = Convert.ToInt32(cartReader["Amount"].ToString()),
            WineId = Convert.ToInt32(cartReader["WineId"].ToString()),
            WineName = cartReader["Name"].ToString(),
            WinePrice = Convert.ToInt32(cartReader["Price"].ToString()),
            WineTotal = Convert.ToInt32(cartReader["Total"].ToString()),
            UserId = Convert.ToInt32(cartReader["UserId"].ToString())
          };

          carts.Add(cart);
          totalCartPrice += cart.WineTotal;
        }

        CartRepeater.DataSource = carts;
        CartRepeater.DataBind();

        CartTotal.Text = totalCartPrice.ToString();

        cartReader.Close();

        // Fetch for Order
        string fetchOrderQuery = @"
                              SELECT [Order].*, Wine.Name FROM [Order]
                              JOIN Wine on [Order].WineId = Wine.WineId 
                              WHERE [Order].UserId = @UserId
                              ORDER BY [Order].OrderId DESC
                              ";
        SqlCommand fetchOrderCommand = new SqlCommand(fetchOrderQuery, conn);
        fetchOrderCommand.Parameters.AddWithValue("@UserId", userId);

        SqlDataReader orderReader = fetchOrderCommand.ExecuteReader();
        List<OrderData> shippings = new List<OrderData>();
        List<OrderData> delivereds = new List<OrderData>();
        List<OrderData> completeds = new List<OrderData>();
        List<OrderData> cancelleds = new List<OrderData>();

        while (orderReader.Read())
        {
          // Check if delivered date is null or not
          DateTime? deliveredDate = null;
          if (orderReader["DeliveredDate"] != DBNull.Value)
          {
            deliveredDate = DateTime.Parse(orderReader["DeliveredDate"].ToString());
          }

          OrderData order = new OrderData
          {
            OrderID = Convert.ToInt32(orderReader["OrderId"].ToString()),
            Status = orderReader["Status"].ToString(),
            DeliveredDate = deliveredDate ?? default,
            OrderedDate = DateTime.Parse(orderReader["OrderedDate"].ToString()),
            TotalPayable = Convert.ToInt32(orderReader["TotalPayable"].ToString()),
            ReviewWritten = Convert.ToInt32(orderReader["ReviewWritten"].ToString()),
            Active = Convert.ToInt32(orderReader["Active"].ToString()),
            WineId = Convert.ToInt32(orderReader["WineId"].ToString()),
            UserId = Convert.ToInt32(orderReader["UserId"].ToString()),
            WineName = orderReader["Name"].ToString()
          };

          switch (order.Status)
          {
            case "Shipping":
              shippings.Add(order);
              break;
            case "Delivered":
              delivereds.Add(order);
              break;
            case "Completed":
              completeds.Add(order);
              break;
            case "Cancelled":
              cancelleds.Add(order);
              break;
            default:
              break;
          }
        }

        ShippingRepeater.DataSource = shippings;
        ShippingRepeater.DataBind();

        DeliveredRepeater.DataSource = delivereds;
        DeliveredRepeater.DataBind();

        CompletedRepeater.DataSource = completeds;
        CompletedRepeater.DataBind();

        CancelledRepeater.DataSource = cancelleds;
        CancelledRepeater.DataBind();

        orderReader.Close();

        // Fetch for Review
        string fetchReviewQuery = @"
                              SELECT Review.*, Wine.Name FROM [Review]
                              JOIN Wine on Review.WineId = Wine.WineId 
                              WHERE Review.UserId = @UserId
                              ORDER BY Review.ReviewId DESC
                              ";
        SqlCommand fetchReviewCommand = new SqlCommand(fetchReviewQuery, conn);
        fetchReviewCommand.Parameters.AddWithValue("@UserId", userId);

        SqlDataReader reviewReader = fetchReviewCommand.ExecuteReader();
        List<ReviewData> reviews = new List<ReviewData>();

        while (reviewReader.Read())
        {
          ReviewData review = new ReviewData
          {
            ReviewId = Convert.ToInt32(reviewReader["ReviewId"].ToString()),
            Content = reviewReader["Content"].ToString(),
            Rating = Convert.ToInt32(reviewReader["Rating"].ToString()),
            WrittenDate = DateTime.Parse(reviewReader["WrittenDate"].ToString()),
            Active = Convert.ToInt32(reviewReader["Active"].ToString()),
            WineId = Convert.ToInt32(reviewReader["WineId"].ToString()),
            WineName = reviewReader["Name"].ToString(),
            UserId = Convert.ToInt32(reviewReader["UserId"].ToString())
          };

          reviews.Add(review);
        }

        ReviewRepeater.DataSource = reviews;
        ReviewRepeater.DataBind();

        reviewReader.Close();

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
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        Button removeButton = (Button)sender;
        string wishlistId = removeButton.CommandArgument;

        string deleteQuery = "DELETE FROM Wishlist WHERE WishlistId = @WishlistId";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
        deleteCommand.Parameters.AddWithValue("@WishlistId", wishlistId);

        deleteCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Wishlist with ID " + wishlistId + " has been removed.'); document.location.href='./Profile.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Remove Wishlist Error:", ex.Message);
      }
    }

    protected void CartRemove_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        Button removeButton = (Button)sender;
        string cartId = removeButton.CommandArgument;

        string deleteQuery = "DELETE FROM Cart WHERE CartId = @CartId";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
        deleteCommand.Parameters.AddWithValue("@CartId", cartId);

        deleteCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Cart with ID " + cartId + " has been removed.'); document.location.href='./Profile.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Remove Cart Error:", ex.Message);
      }
    }

    protected void CartCheckout_Click(object sender, EventArgs e)
    {
      int userId = Convert.ToInt32(Session["UserId"].ToString());

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string fetchCartQuery = @"
                              SELECT Cart.*, Wine.Name, Wine.Price, Wine.Stock, (Cart.Amount * Wine.Price) AS Total FROM Cart 
                              JOIN Wine on Cart.WineId = Wine.WineId 
                              WHERE Cart.UserId = @UserId
                              ";
        SqlCommand fetchCartCommand = new SqlCommand(fetchCartQuery, conn);
        fetchCartCommand.Parameters.AddWithValue("@UserId", userId);

        SqlDataReader reader = fetchCartCommand.ExecuteReader();
        int readerCount = 0;

        while (reader.Read())
        {
          int orderAmount = Convert.ToInt32(reader["Amount"].ToString());
          int oriStock = Convert.ToInt32(reader["Stock"].ToString());
          int wineId = Convert.ToInt32(reader["WineId"].ToString());

          readerCount++;

          string cartToOrderQuery = @"
                                INSERT INTO [Order] (Status, OrderedDate, TotalPayable, WineId, UserId) 
                                VALUES (@Status, @OrderedDate, @TotalPayable, @WineId, @UserId)
                                ";
          SqlCommand cartToOrderCommand = new SqlCommand(cartToOrderQuery, conn);
          cartToOrderCommand.Parameters.AddWithValue("@Status", "Shipping");
          cartToOrderCommand.Parameters.AddWithValue("@OrderedDate", DateTime.Now);
          cartToOrderCommand.Parameters.AddWithValue("@TotalPayable", Convert.ToInt32(reader["Total"].ToString()));
          cartToOrderCommand.Parameters.AddWithValue("@WineId", Convert.ToInt32(reader["WineId"].ToString()));
          cartToOrderCommand.Parameters.AddWithValue("@UserId", userId);

          reader.Close();

          cartToOrderCommand.ExecuteNonQuery();

          reader = fetchCartCommand.ExecuteReader();

          if (reader.Read())
          {
            string deleteCartQuery = "DELETE FROM Cart WHERE CartId = @CartId";
            SqlCommand deleteCartCommand = new SqlCommand(deleteCartQuery, conn);
            deleteCartCommand.Parameters.AddWithValue("@CartId", Convert.ToInt32(reader["CartId"].ToString()));

            reader.Close();

            deleteCartCommand.ExecuteNonQuery();

            reader = fetchCartCommand.ExecuteReader();

            int updateStock = oriStock - orderAmount;

            string updateStockQuery = "UPDATE Wine SET Stock = @Stock WHERE WineId = @WineId";
            SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, conn);
            updateStockCommand.Parameters.AddWithValue("@WineId", wineId);
            updateStockCommand.Parameters.AddWithValue("@Stock", updateStock);

            reader.Close();

            updateStockCommand.ExecuteNonQuery();

            reader = fetchCartCommand.ExecuteReader();
          }
          else
          {
            break;
          }
        }

        reader.Close();

        if (readerCount > 1)
        {
          Response.Write(
            "<script>alert('" + readerCount + " wine orders have been placed. Please view your shipping order.'); document.location.href='./Profile.aspx';</script>"
          );
        }
        else
        {
          Response.Write(
            "<script>alert('" + readerCount + " wine order has been placed. Please view your shipping order.'); document.location.href='./Profile.aspx';</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Cart to Order Error:", ex.Message);
      }
    }

    protected void OrderCancel_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        Button cancelButton = (Button)sender;
        string orderId = cancelButton.CommandArgument;

        string cancelQuery = "UPDATE [Order] SET Status = 'Cancelled' WHERE OrderId = @OrderId";
        SqlCommand cancelCommand = new SqlCommand(cancelQuery, conn);
        cancelCommand.Parameters.AddWithValue("@OrderId", orderId);

        cancelCommand.ExecuteNonQuery();

        // Add back the quantity to stock

        Response.Write(
          "<script>alert('Your order with ID " + orderId + " has been cancelled. Please view your order history.'); document.location.href='./Profile.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Cancel Order Error:", ex.Message);
      }
    }

    protected void OrderConfirm_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        Button cancelButton = (Button)sender;
        string orderId = cancelButton.CommandArgument;

        string cancelQuery = "UPDATE [Order] SET Status = 'Completed' WHERE OrderId = @OrderId";
        SqlCommand cancelCommand = new SqlCommand(cancelQuery, conn);
        cancelCommand.Parameters.AddWithValue("@OrderId", orderId);

        cancelCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Your order with ID " + orderId + " has been completed. Please rate your order. Thank you for your trust in our wines.'); document.location.href='./Profile.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Cancel Order Error:", ex.Message);
      }
    }

    protected void OrderRate_Click(object sender, EventArgs e)
    {
      Button rateButton = (Button)sender;
      string orderId = rateButton.CommandArgument;

      StringBuilder builder = new StringBuilder("Review.aspx?OrderId=" + orderId);
      Response.Redirect(builder.ToString());
    }

    protected void ReviewView_Click(object sender, EventArgs e)
    {
      Button viewButton = (Button)sender;
      string wineId = viewButton.CommandArgument;

      StringBuilder builder = new StringBuilder("SingleWine.aspx?WineId=" + wineId + "#price");
      Response.Redirect(builder.ToString());
    }

    protected void CompletedRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        if (e.Item.DataItem is OrderData order)
        {
          if (e.Item.FindControl("OrderRate") is Button rateButton)
          {
            if (order.ReviewWritten == 0)
            {
              rateButton.Visible = true;
            }
            else
            {
              rateButton.Visible = false;
            }
          }
        }
      }
    }
  }
}