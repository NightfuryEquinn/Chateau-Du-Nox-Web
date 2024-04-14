using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start.App_Admin
{
  public partial class ManageReview : System.Web.UI.Page
  {
    public class ReviewData
    {
      public int ReviewId { get; set; }
      public string Content { get; set; }
      public string Name { get; set; }
      public byte[] Avatar { get; set; }
      public int Rating { get; set; }
      public string WrittenDate { get; set; }
      public string WineName { get; set; }
    }

    public List<ReviewData> GetReviewByStatus(SqlConnection conn, int status)
    {
      string fetchQuery = @"
                        SELECT Review.*, [User].Name, [User].Avatar, Wine.Name as WineName
                        FROM Review
                        JOIN [User] ON Review.UserId = [User].UserId
                        JOIN Wine ON Review.WineId = Wine.WineId
                        WHERE Review.Active = @Status
                        ";
      SqlCommand fetchCommand = new SqlCommand(fetchQuery, conn);
      fetchCommand.Parameters.AddWithValue("@Status", status);

      SqlDataReader reader = fetchCommand.ExecuteReader();
      List<ReviewData> reviews = new List<ReviewData>();

      while (reader.Read())
      {
        ReviewData review = new ReviewData
        {
          ReviewId = Convert.ToInt32(reader["ReviewId"]),
          Content = reader["Content"].ToString(),
          Name = reader["Name"].ToString(),
          Avatar = (byte[])reader["Avatar"],
          Rating = Convert.ToInt32(reader["Rating"].ToString()),
          WrittenDate = DateTime.Parse(reader["WrittenDate"].ToString()).ToShortDateString(),
          WineName = reader["WineName"].ToString()
        };

        reviews.Add(review);
      }

      reader.Close();
      return reviews;
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        List<ReviewData> activeReviews = GetReviewByStatus(conn, 1);
        List<ReviewData> inactiveReviews = GetReviewByStatus(conn, 0);

        ActiveRepeater.DataSource = activeReviews;
        ActiveRepeater.DataBind();

        InactiveRepeater.DataSource = inactiveReviews;
        InactiveRepeater.DataBind();

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Review Error: ", ex.Message);
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

    protected void DeleteReview_Click(object sender, EventArgs e)
    {
      Button deleteButton = (Button)sender;
      string reviewId = deleteButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string deleteQuery = "UPDATE Review SET Active = 0 WHERE ReviewId = @ReviewId";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
        deleteCommand.Parameters.AddWithValue("@ReviewId", reviewId);

        deleteCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Review with ID " + reviewId + " has been deleted successfully.'); document.location.href='./ManageReview.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Delete Review Error: ", ex.Message);
      }
    }

    protected void RecoverReview_Click(object sender, EventArgs e)
    {
      Button recoverButton = (Button)sender;
      string reviewId = recoverButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string recoverQuery = "UPDATE Review SET Active = 1 WHERE ReviewId = @ReviewId";
        SqlCommand recoverCommand = new SqlCommand(recoverQuery, conn);
        recoverCommand.Parameters.AddWithValue("@ReviewId", reviewId);

        recoverCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Review with ID " + reviewId + " has been recovered successfully.'); document.location.href='./ManageReview.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Recover Review Error: ", ex.Message);
      }
    }
  }
}