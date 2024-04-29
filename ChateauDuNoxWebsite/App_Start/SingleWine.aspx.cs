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
  public partial class SingleWine : System.Web.UI.Page
  {
    public class ReviewData
    {
      public int ReviewId { get; set; }
      public string Content { get; set; }
      public int Rating { get; set; }
      public string WrittenDate { get; set; } 
      public int Active { get; set; }
      public int WineId { get; set; }
      public int UserId { get; set; }
      public string Name { get; set; }
      public byte[] Avatar { get; set; }
    }
    private void loadPageContent()
    {
      if (!string.IsNullOrEmpty(Request.QueryString["WineId"]))
      {
        int wineId = Convert.ToInt32(Request.QueryString["WineId"]);
        string wineQuantity = Request.QueryString["Amount"];

        try
        {
          SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
          conn.Open();

          string fetchInfoQuery = "SELECT Wine.*, Type.Name AS TypeName FROM Wine JOIN [Type] ON Wine.TypeId = [Type].TypeId WHERE Wine.WineId = @WineId";
          SqlCommand fetchInfoCommand = new SqlCommand(fetchInfoQuery, conn);
          fetchInfoCommand.Parameters.AddWithValue("@WineId", wineId);

          SqlDataReader reader = fetchInfoCommand.ExecuteReader();

          if (reader.Read())
          {
            byte[] imageBytes = (byte[])reader["Image"];
            string base64string = Convert.ToBase64String(imageBytes);
            string imageUrl = "data:image/jpeg;base64," + base64string;

            image.ImageUrl = imageUrl;

            name.Text = reader["Name"].ToString();
            description.Text = reader["Description"].ToString();
            vintage.Text = reader["Vintage"].ToString();
            body.Text = reader["Body"].ToString();
            type.Text = reader["TypeName"].ToString();
            tannin.Text = reader["Tannin"].ToString();
            acidity.Text = reader["Acidity"].ToString();
            varietal.Text = reader["Varietal"].ToString();
            volume.Text = reader["Volume"].ToString();
            abv.Text = reader["ABV"].ToString();
            origin.Text = reader["Origin"].ToString();
            stock.Text = reader["Stock"].ToString();
            price.Text = reader["Price"].ToString();
            price.Attributes.Add("data-price", reader["Price"].ToString());
          }

          reader.Close();

          string fetchReviewQuery = @"
                                  SELECT Review.*, [User].Name, [User].Avatar FROM Review
                                  JOIN [User] ON Review.UserId = [User].UserId
                                  WHERE Review.WineId = @WineId AND Review.Active = 1
                                  ORDER BY Review.WrittenDate DESC
                                  ";
          SqlCommand fetchReviewCommand = new SqlCommand(fetchReviewQuery, conn);
          fetchReviewCommand.Parameters.AddWithValue("@WineId", wineId);

          SqlDataReader reviewReader = fetchReviewCommand.ExecuteReader();
          List<ReviewData> reviews = new List<ReviewData>();

          while (reviewReader.Read())
          {
            ReviewData review = new ReviewData
            {
              ReviewId = Convert.ToInt32(reviewReader["ReviewId"].ToString()),
              Content = reviewReader["Content"].ToString(),
              Rating = Convert.ToInt32(reviewReader["Rating"].ToString()),
              WrittenDate = DateTime.Parse(reviewReader["WrittenDate"].ToString()).ToShortDateString(),
              Active = Convert.ToInt32(reviewReader["Active"].ToString()),
              WineId = Convert.ToInt32(reviewReader["WineId"].ToString()),
              UserId = Convert.ToInt32(reviewReader["UserId"].ToString()),
              Name = reviewReader["Name"].ToString(),
              Avatar = (byte[])reviewReader["Avatar"]
            };

            reviews.Add(review);
          }

          TotalReview.Text = reviews.Count.ToString();

          ReviewRepeater.DataSource = reviews;
          ReviewRepeater.DataBind();

          reviewReader.Close();

          if (wineQuantity != null)
          {
            int initialQuantity = Convert.ToInt32(wineQuantity);
            int winePrice = Convert.ToInt32(price.Text.ToString());
            int totalPrice = initialQuantity * winePrice;

            Quantity.Text = initialQuantity.ToString();
            price.Text = totalPrice.ToString();
          }

          conn.Close();
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Fetch Single Wine Error:", ex.Message);
        }
      }
      else
      {
        Response.Write(
          "<script>alert('Invalid wine ID. Please make sure that you are in the correct catalog list. If issue still persist, contact our customer service.'); document.location.href='./Wines.aspx';</script>"
        );
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        loadPageContent();
      }
    }

    protected void AddWishlist_Click(object sender, EventArgs e)
    {
      if (Session["UserId"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"].ToString());
        int wineId = Convert.ToInt32(Request.QueryString["WineId"]);
        int wineQuantity = Convert.ToInt32(Quantity.Text);

        try
        {
          SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
          conn.Open();

          string getStockQuery = "SELECT * FROM Wine WHERE Active = 1";
          SqlCommand getStockCommand = new SqlCommand(getStockQuery, conn);

          SqlDataReader getStockReader = getStockCommand.ExecuteReader();

          if (getStockReader.Read())
          {
            int stockQuantity = Convert.ToInt32(getStockReader["Stock"].ToString());

            getStockReader.Close();

            if (wineQuantity < stockQuantity)
            {
              string checkExistInWish = "SELECT COUNT(*) FROM Wishlist WHERE WineId = @WineId AND UserId = @UserId";
              SqlCommand checkExistInWishCommand = new SqlCommand(checkExistInWish, conn);
              checkExistInWishCommand.Parameters.AddWithValue("@WineId", wineId);
              checkExistInWishCommand.Parameters.AddWithValue("@UserId", userId);

              int check = Convert.ToInt32(checkExistInWishCommand.ExecuteScalar().ToString());

              if (check == 1)
              {
                string getExistInWish = "SELECT * FROM Wishlist WHERE WineId = @WineId AND UserId = @UserId";
                SqlCommand getExistInWishCommand = new SqlCommand(getExistInWish, conn);
                getExistInWishCommand.Parameters.AddWithValue("@WineId", wineId);
                getExistInWishCommand.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader getReader = getExistInWishCommand.ExecuteReader();

                if (getReader.Read())
                {
                  int existedQuantity = Convert.ToInt32(getReader["Amount"].ToString());
                  int newQuantity = existedQuantity + wineQuantity;

                  string updateQuery = "UPDATE Wishlist SET Amount = @Amount WHERE WineId = @WineId AND UserId = @UserId";
                  SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                  updateCommand.Parameters.AddWithValue("@Amount", newQuantity);
                  updateCommand.Parameters.AddWithValue("@WineId", wineId);
                  updateCommand.Parameters.AddWithValue("@UserId", userId);

                  getReader.Close();

                  updateCommand.ExecuteNonQuery();

                  Response.Write(
                    "<script>alert('Updated amount to your wishlist. Please review to confirm.'); document.location.href='./Profile.aspx#wishlist';</script>"
                  );
                }
              }
              else
              {
                string insertQuery = "INSERT INTO Wishlist (Amount, WineId, UserId) VALUES (@Amount, @WineId, @UserId)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                insertCommand.Parameters.AddWithValue("@Amount", Convert.ToInt32(Quantity.Text));
                insertCommand.Parameters.AddWithValue("@WineId", wineId);
                insertCommand.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"].ToString()));

                insertCommand.ExecuteNonQuery();

                Response.Write(
                  "<script>alert('Wine has been added into your wishlist. Please review to confirm.'); document.location.href='./Profile.aspx#shipping';</script>"
                );
              }
              
            }
            else
            {
              Response.Write(
                "<script>alert('Stock is not enough to cater your need. Please buy according to the stock availability.');</script>"
              );
            }
          }

          conn.Close();
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Insert Single Wine to Wishlist Error:", ex.Message);
        }
      }
      else
      {
        Response.Write(
          "<script>alert('Please login before adding wine into wishlist or cart.'); document.location.href='./Login.aspx';</script>"
        );
      }
    }

    protected void AddCart_Click(object sender, EventArgs e)
    {
      if (Session["Name"] != null)
      {
        int userId = Convert.ToInt32(Session["UserId"].ToString());
        int wineId = Convert.ToInt32(Request.QueryString["WineId"].ToString());
        int wineQuantity = Convert.ToInt32(Quantity.Text);

        try
        {
          SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
          conn.Open();

          string getStockQuery = "SELECT * FROM Wine WHERE Active = 1";
          SqlCommand getStockCommand = new SqlCommand(getStockQuery, conn);

          SqlDataReader getStockReader = getStockCommand.ExecuteReader();

          if (getStockReader.Read())
          {
            int stockQuantity = Convert.ToInt32(getStockReader["Stock"].ToString());

            getStockReader.Close();

            if (wineQuantity < stockQuantity)
            {
              string checkExistInCart = "SELECT COUNT(*) FROM Cart WHERE WineId = @WineId AND UserId = @UserId";
              SqlCommand checkExistInCartCommand = new SqlCommand(checkExistInCart, conn);
              checkExistInCartCommand.Parameters.AddWithValue("@WineId", wineId);
              checkExistInCartCommand.Parameters.AddWithValue("@UserId", userId);

              int check = Convert.ToInt32(checkExistInCartCommand.ExecuteScalar().ToString());

              if (check == 1)
              {
                string getExistInCart = "SELECT * FROM Cart WHERE WineId = @WineId AND UserId = @UserId";
                SqlCommand getExistInCartCommand = new SqlCommand(getExistInCart, conn);
                getExistInCartCommand.Parameters.AddWithValue("@WineId", wineId);
                getExistInCartCommand.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader getReader = getExistInCartCommand.ExecuteReader();

                if (getReader.Read())
                {
                  int existedQuantity = Convert.ToInt32(getReader["Amount"].ToString());
                  int newQuantity = existedQuantity + wineQuantity;

                  string updateQuery = "UPDATE Cart SET Amount = @Amount WHERE WineId = @WineId AND UserId = @UserId";
                  SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
                  updateCommand.Parameters.AddWithValue("@Amount", newQuantity);
                  updateCommand.Parameters.AddWithValue("@WineId", wineId);
                  updateCommand.Parameters.AddWithValue("@UserId", userId);

                  getReader.Close();

                  updateCommand.ExecuteNonQuery();

                  Response.Write(
                    "<script>alert('Updated amount to your cart. Please review to confirm.'); document.location.href='./Profile.aspx#wishlist';</script>"
                  );
                }
              }
              else
              {
                string insertQuery = "INSERT INTO Cart (Amount, WineId, UserId) VALUES (@Amount, @WineId, @UserId)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                insertCommand.Parameters.AddWithValue("@Amount", wineQuantity);
                insertCommand.Parameters.AddWithValue("@WineId", wineId);
                insertCommand.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"].ToString()));

                insertCommand.ExecuteNonQuery();

                Response.Write(
                  "<script>alert('Wine has been added into your cart. Please review to confirm.'); document.location.href='./Profile.aspx#wishlist';</script>"
                );
              }  
            }
            else
            {
              Response.Write(
                "<script>alert('Stock is not enough to cater your need. Please buy according to the stock availability.');</script>"
              );
            }
          }

          conn.Close();
        }
        catch (Exception ex)
        {
          Debug.WriteLine("Insert Single Wine to Cart Error:", ex.Message);
        }
      }
      else
      {
        Response.Write(
          "<script>alert('Please login before adding wine into wishlist or cart.'); document.location.href='./Login.aspx';</script>"
        );
      }
    }

    protected void Increment_Click(object sender, EventArgs e)
    {
      int initialQuantity = Convert.ToInt32(Quantity.Text.ToString());
      int winePrice = Convert.ToInt32(price.Text.ToString());
      int singlePrice = winePrice / initialQuantity;

      initialQuantity += 1;
      int newPrice = singlePrice * initialQuantity;

      Quantity.Text = initialQuantity.ToString();
      price.Text = newPrice.ToString();
    }

    protected void Decrement_Click(object sender, EventArgs e)
    {
      int initialQuantity = Convert.ToInt32(Quantity.Text.ToString());
      int winePrice = Convert.ToInt32(price.Text.ToString());
      int singlePrice = winePrice / initialQuantity;
      int newPrice = 0;

      if (initialQuantity > 1)
      {
        initialQuantity -= 1;
        newPrice = winePrice - singlePrice;
      }

      Quantity.Text = initialQuantity.ToString();
      price.Text = newPrice.ToString();
    }
  }
}