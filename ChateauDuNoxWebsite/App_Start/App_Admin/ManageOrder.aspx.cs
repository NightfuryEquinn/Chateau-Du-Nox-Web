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
  public partial class ManageOrder : System.Web.UI.Page
  {
    public class OrderData
    {
      public int OrderId { get; set; }
      public string Name { get; set; }
      public byte[] Avatar { get; set; }
      public string EmailAddress { get; set; }
      public string OrderedDate { get; set; }
      public string DeliveredDate { get; set; }
      public int TotalPayable { get; set; }
      public string ReviewWritten { get; set; }
    }

    public List<OrderData> GetOrderByStatus(SqlConnection conn, string status)
    {
      string fetchQuery = @"
                        SELECT [Order].*, [User].Name, [User].Avatar, [User].EmailAddress 
                        FROM [Order]
                        JOIN [User] ON [Order].UserId = [User].UserId
                        WHERE [Order].Status = @Status
                        ";
      SqlCommand fetchCommand = new SqlCommand(fetchQuery, conn);
      fetchCommand.Parameters.AddWithValue("@Status", status);

      SqlDataReader reader = fetchCommand.ExecuteReader();
      List<OrderData> orders = new List<OrderData>();

      while (reader.Read())
      {
        // Check if delivered date is null or not
        string deliveredDate = null;
        if (reader["DeliveredDate"] != DBNull.Value)
        {
          deliveredDate = DateTime.Parse(reader["DeliveredDate"].ToString()).ToShortDateString();
        }

        int reviewBool = Convert.ToInt32(reader["ReviewWritten"].ToString());
        string reviewWritten = null;
        if (reviewBool == 1)
        {
          reviewWritten = "Yes";
        }
        else
        {
          reviewWritten = "No";
        }

        OrderData order = new OrderData
        {
          OrderId = Convert.ToInt32(reader["OrderId"].ToString()),
          Name = reader["Name"].ToString(),
          Avatar = (byte[])reader["Avatar"],
          EmailAddress = reader["EmailAddress"].ToString(),
          OrderedDate = DateTime.Parse(reader["OrderedDate"].ToString()).ToShortDateString(),
          DeliveredDate = deliveredDate ?? default,
          TotalPayable = Convert.ToInt32(reader["TotalPayable"].ToString()),
          ReviewWritten = reviewWritten
        };

        orders.Add(order);
      }

      reader.Close();
      return orders;
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        ShippingRepeater.DataSource = GetOrderByStatus(conn, "Shipping");
        ShippingRepeater.DataBind();

        DeliveredRepeater.DataSource = GetOrderByStatus(conn, "Delivered");
        DeliveredRepeater.DataBind();

        CompletedRepeater.DataSource = GetOrderByStatus(conn, "Completed");
        CompletedRepeater.DataBind();

        CancelledRepeater.DataSource = GetOrderByStatus(conn, "Cancelled");
        CancelledRepeater.DataBind();

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Order Error: ", ex.Message);
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

    protected void ConfirmShipping_Click(object sender, EventArgs e)
    {
      Button confirmShipping = (Button)sender;
      string orderId = confirmShipping.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string confirmQuery = "UPDATE [Order] SET DeliveredDate = @DeliveredDate, Status = 'Delivered' WHERE OrderId = @OrderId";
        SqlCommand confirmCommand = new SqlCommand(confirmQuery, conn);
        confirmCommand.Parameters.AddWithValue("@OrderId", orderId);
        confirmCommand.Parameters.AddWithValue("@DeliveredDate", DateTime.Now);

        confirmCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Order status has changed to Delivered.'); document.location.href='./ManageOrder.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Confirm Shipping Error: ", ex.Message);
      }
    }

    protected void ConfirmPayment_Click(object sender, EventArgs e)
    {
      Button confirmDelivered = (Button)sender;
      string orderId = confirmDelivered.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string confirmQuery = "UPDATE [Order] SET Status = 'Completed' WHERE OrderId = @OrderId";
        SqlCommand confirmCommand = new SqlCommand(confirmQuery, conn);
        confirmCommand.Parameters.AddWithValue("@OrderId", orderId);

        confirmCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Order status has changed to Completed.'); document.location.href='./ManageOrder.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Confirm Payment Error: ", ex.Message);
      }
    }
  }
}