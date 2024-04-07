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

namespace ChateauDuNoxWebsite.App_Start.App_Admin
{
  public partial class ManageWine : System.Web.UI.Page
  {
    public class WineData
    {
      public int WineId { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public int Price { get; set; }
      public byte[] Image { get; set; }
      public string Varietal { get; set; }
      public int Vintage { get; set; }
      public int Volume { get; set; }
      public string Body { get; set; }
      public string Tannin { get; set; }
      public string Acidity { get; set; }
      public string ABV { get; set; }
      public string Origin { get; set; }
      public int Stock { get; set; }
      public int Active { get; set; }
      public int TypeId { get; set; }
    }

    public List<WineData> GetWineByStatus(SqlConnection conn, int status)
    {
      string fetchWineQuery = "SELECT * FROM [Wine] WHERE Active = @Status";
      SqlCommand fetchCommand = new SqlCommand(fetchWineQuery, conn);
      fetchCommand.Parameters.AddWithValue("@Status", status);

      SqlDataReader reader = fetchCommand.ExecuteReader();
      List<WineData> wines = new List<WineData>();

      while (reader.Read())
      {
        WineData wine = new WineData
        {
          WineId = Convert.ToInt32(reader["WineId"].ToString()),
          Name = reader["Name"].ToString(),
          Description = reader["Description"].ToString(),
          Price = Convert.ToInt32(reader["Price"]),
          Image = (byte[])reader["Image"],
          Varietal = reader["Varietal"].ToString(),
          Vintage = Convert.ToInt32(reader["Vintage"].ToString()),
          Volume = Convert.ToInt32(reader["Volume"].ToString()),
          Body = reader["Body"].ToString(),
          Tannin = reader["Tannin"].ToString(),
          Acidity = reader["Acidity"].ToString(),
          ABV = reader["ABV"].ToString(),
          Origin = reader["Origin"].ToString(),
          Stock = Convert.ToInt32(reader["Stock"].ToString()),
          Active = Convert.ToInt32(reader["Active"].ToString()),
          TypeId = Convert.ToInt32(reader["TypeId"].ToString())
        };

        wines.Add(wine);
      }

      reader.Close();
      return wines;
    }

    public DataTable GetWineTypes(SqlConnection conn)
    {
      string fetchTypeQuery = "SELECT * FROM [Type] WHERE Active = 1";
      SqlCommand fetchTypeCommand = new SqlCommand(fetchTypeQuery, conn);
      SqlDataAdapter adapter = new SqlDataAdapter(fetchTypeCommand);

      DataTable typesTable = new DataTable();
      adapter.Fill(typesTable);

      return typesTable;
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        List<WineData> activeWines = GetWineByStatus(conn, 1);
        List<WineData> inactiveWines = GetWineByStatus(conn, 0);

        ActiveRepeater.DataSource = activeWines;
        ActiveRepeater.DataBind();

        InactiveRepeater.DataSource = inactiveWines;
        InactiveRepeater.DataBind();

        DataTable typesTable = GetWineTypes(conn);
        if (typesTable.Rows.Count > 0)
        {
          AddWineDropdown.DataSource = typesTable;
          EditWineDropdown.DataSource = typesTable;

          AddWineDropdown.DataTextField = "Name";
          EditWineDropdown.DataTextField = "Name";

          AddWineDropdown.DataValueField = "TypeId";
          EditWineDropdown.DataValueField = "TypeId";

          AddWineDropdown.DataBind();
          EditWineDropdown.DataBind();

          AddWineDropdown.Items.Insert(0, new ListItem("-- Select Type --", "0"));
          EditWineDropdown.Items.Insert(0, new ListItem("-- Select Type --", "0"));
        }

        if (Request.QueryString["WineId"] != null)
        {
          string fetchWineQuery = "SELECT * FROM [Wine] WHERE WineId = @WineId";
          SqlCommand fetchWineCommand = new SqlCommand(fetchWineQuery, conn);
          fetchWineCommand.Parameters.AddWithValue("@WineId", Convert.ToInt32(Request.QueryString["WineId"]));

          SqlDataReader reader = fetchWineCommand.ExecuteReader();

          if (reader.Read())
          {
            EditWineName.Text = reader["Name"].ToString();
            EditWineDesc.Text = reader["Description"].ToString();
            EditWinePrice.Text = reader["Price"].ToString();
            EditWineDropdown.SelectedIndex = Convert.ToInt32(reader["TypeId"].ToString());
            EditWineVar.Text = reader["Varietal"].ToString();
            EditWineVint.Text = reader["Vintage"].ToString();
            EditWineML.Text = reader["Volume"].ToString();
            EditWineBody.Text = reader["Body"].ToString();
            EditWineTannin.Text = reader["Tannin"].ToString();
            EditWineAcid.Text = reader["Acidity"].ToString();
            EditWineABV.Text = reader["ABV"].ToString();
            EditWineOrigin.Text = reader["Origin"].ToString();
            EditWineStock.Text = reader["Stock"].ToString();
          }

          reader.Close();
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Wine Error:", ex.Message);
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

    protected void AddWineButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string name = AddWineName.Text.Trim();
        byte[] wineImage = AddWineFileUpload.FileBytes;
        string desc = AddWineDesc.Text.Trim();
        int price = Convert.ToInt32(AddWinePrice.Text.Trim());
        int typeId = AddWineDropdown.SelectedIndex;
        string varietal = AddWineVar.Text.Trim();
        int vintage = Convert.ToInt32(AddWineVint.Text.Trim());
        int volume = Convert.ToInt32(AddWineML.Text.Trim());
        string body = AddWineBody.Text.Trim();
        string tannin = AddWineTannin.Text.Trim();
        string acid = AddWineAcid.Text.Trim();
        string abv = AddWineABV.Text.Trim();
        string origin = AddWineOrigin.Text.Trim();
        int stock = Convert.ToInt32(AddWineStock.Text.Trim());

        if (!string.IsNullOrWhiteSpace(name) && 
          wineImage != null && 
          !string.IsNullOrWhiteSpace(desc) &&
          price >= 0 &&
          typeId > 0 &&
          !string.IsNullOrWhiteSpace(varietal) &&
          vintage >= 1000 &&
          volume >= 0 &&
          !string.IsNullOrWhiteSpace(body) &&
          !string.IsNullOrWhiteSpace(tannin) &&
          !string.IsNullOrWhiteSpace(acid) &&
          !string.IsNullOrWhiteSpace(abv) &&
          !string.IsNullOrWhiteSpace(origin) &&
          stock >= 0
        )
        {
          string insertQuery = "INSERT INTO [Wine] (Name, Description, Price, Image, Varietal, Vintage, Volume, Body, Tannin, Acidity, ABV, Origin, Stock, Active, TypeId) VALUES (@Name, @Desc, @Price, @Image, @Varietal, @Vintage, @Volume, @Body, @Tannin, @Acidity, @ABV, @Origin, @Stock, @Active, @TypeId)";
          SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
          insertCommand.Parameters.AddWithValue("@Name", name);
          insertCommand.Parameters.AddWithValue("@Desc", desc);
          insertCommand.Parameters.AddWithValue("@Price", price);
          SqlParameter wineImageParam = new SqlParameter("@Image", SqlDbType.VarBinary)
          {
            Value = wineImage
          };
          insertCommand.Parameters.Add(wineImageParam);
          insertCommand.Parameters.AddWithValue("@Varietal", varietal);
          insertCommand.Parameters.AddWithValue("@Vintage", vintage);
          insertCommand.Parameters.AddWithValue("@Volume", volume);
          insertCommand.Parameters.AddWithValue("@Body", body);
          insertCommand.Parameters.AddWithValue("@Tannin", tannin);
          insertCommand.Parameters.AddWithValue("@Acidity", acid);
          insertCommand.Parameters.AddWithValue("@ABV", abv);
          insertCommand.Parameters.AddWithValue("@Origin", origin);
          insertCommand.Parameters.AddWithValue("@Stock", stock);
          insertCommand.Parameters.AddWithValue("@Active", 1);
          insertCommand.Parameters.AddWithValue("@TypeId", typeId);

          insertCommand.ExecuteNonQuery();

          Response.Write(
            "<script>alert('A new wine has been added successfully.'); document.location.href='./ManageWine.aspx';</script>"
          );
        }
        else
        {
          Response.Write(
            "<script>alert('Please fill up all empty fields, including image.');</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Add Wine Error: ", ex.Message);
      }
    }

    protected void SaveWineButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        int wineId = Convert.ToInt32(Request.QueryString["WineId"]);

        string name = EditWineName.Text.Trim();
        byte[] wineImage = EditWineFileUpload.FileBytes;
        string desc = EditWineDesc.Text.Trim();
        int price = Convert.ToInt32(EditWinePrice.Text.Trim());
        int typeId = EditWineDropdown.SelectedIndex;
        string varietal = EditWineVar.Text.Trim();
        int vintage = Convert.ToInt32(EditWineVint.Text.Trim());
        int volume = Convert.ToInt32(EditWineML.Text.Trim());
        string body = EditWineBody.Text.Trim();
        string tannin = EditWineTannin.Text.Trim();
        string acid = EditWineAcid.Text.Trim();
        string abv = EditWineABV.Text.Trim();
        string origin = EditWineOrigin.Text.Trim();
        int stock = Convert.ToInt32(EditWineStock.Text.Trim());

        if (!string.IsNullOrWhiteSpace(name) &&
          !string.IsNullOrWhiteSpace(desc) &&
          price >= 0 &&
          typeId > 0 &&
          !string.IsNullOrWhiteSpace(varietal) &&
          vintage >= 1000 &&
          volume >= 0 &&
          !string.IsNullOrWhiteSpace(body) &&
          !string.IsNullOrWhiteSpace(tannin) &&
          !string.IsNullOrWhiteSpace(acid) &&
          !string.IsNullOrWhiteSpace(abv) &&
          !string.IsNullOrWhiteSpace(origin) &&
          stock >= 0
        )
        {
          if (wineImage != null && wineImage.Length != 0)
          {
            string updateQuery = @"
                                UPDATE [Wine] SET
                                Name = @Name, Description = @Desc, Price = @Price, Image = @Image, Varietal = @Varietal, Vintage = @Vintage, Volume = @Volume, Body = @Body, Tannin = @Tannin, Acidity = @Acidity, ABV = @ABV, Origin = @Origin, Stock = @Stock, Active = @Active, TypeId = @TypeId
                                WHERE WineId = @WineId
                                ";
            SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
            updateCommand.Parameters.AddWithValue("@WineId", wineId);
            updateCommand.Parameters.AddWithValue("@Name", name);
            updateCommand.Parameters.AddWithValue("@Desc", desc);
            updateCommand.Parameters.AddWithValue("@Price", price);
            SqlParameter wineImageParam = new SqlParameter("@Image", SqlDbType.VarBinary)
            {
              Value = wineImage
            };
            updateCommand.Parameters.Add(wineImageParam);
            updateCommand.Parameters.AddWithValue("@Varietal", varietal);
            updateCommand.Parameters.AddWithValue("@Vintage", vintage);
            updateCommand.Parameters.AddWithValue("@Volume", volume);
            updateCommand.Parameters.AddWithValue("@Body", body);
            updateCommand.Parameters.AddWithValue("@Tannin", tannin);
            updateCommand.Parameters.AddWithValue("@Acidity", acid);
            updateCommand.Parameters.AddWithValue("@ABV", abv);
            updateCommand.Parameters.AddWithValue("@Origin", origin);
            updateCommand.Parameters.AddWithValue("@Stock", stock);
            updateCommand.Parameters.AddWithValue("@Active", 1);
            updateCommand.Parameters.AddWithValue("@TypeId", typeId);

            updateCommand.ExecuteNonQuery();

            Response.Write(
              "<script>alert('Details and image of " + name + " has been edited successfully.'); document.location.href='./ManageWine.aspx';</script>"
            );
          }
          else
          {
            string updateQuery = @"
                                UPDATE [Wine] SET
                                Name = @Name, Description = @Desc, Price = @Price, Varietal = @Varietal, Vintage = @Vintage, Volume = @Volume, Body = @Body, Tannin = @Tannin, Acidity = @Acidity, ABV = @ABV, Origin = @Origin, Stock = @Stock, Active = @Active, TypeId = @TypeId
                                WHERE WineId = @WineId
                                ";
            SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
            updateCommand.Parameters.AddWithValue("@WineId", wineId);
            updateCommand.Parameters.AddWithValue("@Name", name);
            updateCommand.Parameters.AddWithValue("@Desc", desc);
            updateCommand.Parameters.AddWithValue("@Price", price);
            updateCommand.Parameters.AddWithValue("@Varietal", varietal);
            updateCommand.Parameters.AddWithValue("@Vintage", vintage);
            updateCommand.Parameters.AddWithValue("@Volume", volume);
            updateCommand.Parameters.AddWithValue("@Body", body);
            updateCommand.Parameters.AddWithValue("@Tannin", tannin);
            updateCommand.Parameters.AddWithValue("@Acidity", acid);
            updateCommand.Parameters.AddWithValue("@ABV", abv);
            updateCommand.Parameters.AddWithValue("@Origin", origin);
            updateCommand.Parameters.AddWithValue("@Stock", stock);
            updateCommand.Parameters.AddWithValue("@Active", 1);
            updateCommand.Parameters.AddWithValue("@TypeId", typeId);

            updateCommand.ExecuteNonQuery();

            Response.Write(
              "<script>alert('Details of " + name + " has been edited successfully.');  document.location.href='./ManageWine.aspx';</script>"
            );
          }
        }
        else
        {
          Response.Write(
            "<script>alert('Please fill up all empty fields. Image is optional unless change is required.'); document.location.href='./ManageWine.aspx';</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Edit Wine Error:", ex.Message);
      }
    }

    protected void EditWine_Click(object sender, EventArgs e)
    {
      Button editButton = (Button)sender;
      string wineId = editButton.CommandArgument;

      Uri currentUri = HttpContext.Current.Request.Url;
      if (string.IsNullOrEmpty(currentUri.Query))
      {
        StringBuilder builder = new StringBuilder("ManageWine.aspx?WineId=" + wineId);
        Response.Redirect(builder.ToString());
      }
    }

    protected void DeleteWine_Click(object sender, EventArgs e)
    {
      Button deleteButton = (Button)sender;
      string wineId = deleteButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string deleteQuery = "UPDATE [Wine] SET Active = 0 WHERE WineId = @WineId";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
        deleteCommand.Parameters.AddWithValue("@WineId", wineId);

        deleteCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Wine with ID " + wineId + " has been switched to inactive status.'); document.location.href='./ManageWine.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Delete Wine Error:", ex.Message);
      }
    }

    protected void RecoverWine_Click(object sender, EventArgs e)
    {
      Button recoverButton = (Button)sender;
      string wineId = recoverButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string recoverQuery = "UPDATE [Wine] SET Active = 1 WHERE WineId = @WineId";
        SqlCommand recoverCommand = new SqlCommand(recoverQuery, conn);
        recoverCommand.Parameters.AddWithValue("@WineId", wineId);

        recoverCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Wine with ID " + wineId + " has been switched to active status.'); document.location.href='./ManageWine.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Recover Wine Error:", ex.Message);
      }
    }
  }
}