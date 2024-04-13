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
  public partial class Review : System.Web.UI.Page
  {
    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        int orderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());

        string fetchWineQuery = "SELECT Wine.Name FROM [Order] JOIN Wine ON [Order].WineId = Wine.WineId WHERE [Order].OrderID = @OrderId";
        SqlCommand fetchWineCommand = new SqlCommand(fetchWineQuery, conn);
        fetchWineCommand.Parameters.AddWithValue("@OrderId", orderId);

        SqlDataReader reader = fetchWineCommand.ExecuteReader();

        if (reader.Read())
        {
          ReviewWine.Text = reader["Name"].ToString();
        }

        reader.Close();

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Review Error:", ex.Message);
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      OneStar.Attributes.Add("value", "one");
      TwoStar.Attributes.Add("value", "two");
      ThreeStar.Attributes.Add("value", "three");
      FourStar.Attributes.Add("value", "four");
      FiveStar.Attributes.Add("value", "five");

      if (Request.QueryString["OrderId"] != null)
      {
        if (!Page.IsPostBack)
        {
          loadPageContent();
        }
      }
      else
      {
        Response.Write(
          "<script>alert('Please check whether your order has arrived and checked the condition of your order before writing a review.'); document.location.href='./Profile.aspx';</script>"
        );
      }
    }

    protected void RateButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        int orderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());

        string fetchWineQuery = "SELECT Wine.WineId FROM [Order] JOIN Wine ON [Order].WineId = Wine.WineId WHERE [Order].OrderID = @OrderId";
        SqlCommand fetchWineCommand = new SqlCommand(fetchWineQuery, conn);
        fetchWineCommand.Parameters.AddWithValue("@OrderId", orderId);

        SqlDataReader reader = fetchWineCommand.ExecuteReader();
        int wineId = 0;

        if (reader.Read())
        {
          wineId = Convert.ToInt32(reader["WineId"].ToString());
        }

        reader.Close();

        string content = TextareaInput.Text.Trim();
        int rating = 0;

        if (OneStar.Checked)
        {
          rating = 1;
        }
        else if (TwoStar.Checked)
        {
          rating = 2;
        }
        else if (ThreeStar.Checked)
        {
          rating = 3;
        }
        else if (FourStar.Checked)
        {
          rating = 4;
        }
        else if (FiveStar.Checked)
        {
          rating = 5;
        }

        DateTime writtenDate = DateTime.Now;
        int userId = Convert.ToInt32(Session["UserId"].ToString());

        string insertQuery = "INSERT INTO Review (Content, Rating, WrittenDate, WineId, UserId) VALUES (@Content, @Rating, @WrittenDate, @WineId, @UserId)";
        SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
        insertCommand.Parameters.AddWithValue("@Content", content);
        insertCommand.Parameters.AddWithValue("@Rating", rating);
        insertCommand.Parameters.AddWithValue("@WrittenDate", writtenDate);
        insertCommand.Parameters.AddWithValue("@WineId", wineId);
        insertCommand.Parameters.AddWithValue("@UserId", userId);

        insertCommand.ExecuteNonQuery();

        string updateQuery = "UPDATE [Order] SET ReviewWritten = 1 WHERE OrderId = @OrderId";
        SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
        updateCommand.Parameters.AddWithValue("@OrderId", orderId);

        updateCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Your review has been saved. Thank you for giving us your feedback.'); document.location.href='./SingleWine.aspx?WineId=" + wineId + "';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Write Review Error:", ex.Message);
      }
    }
  }
}