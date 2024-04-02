using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start.App_Admin
{
  public partial class ManageWine : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["Role"] as string != "Admin")
      {
        Response.Write(
          "<script>alert('Only admin has access to this page.'); document.location.href='../Home.aspx';</script>"
        );
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
          typeId >= 0 &&
          !string.IsNullOrWhiteSpace(varietal) &&
          vintage >= 1500 &&
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

    protected void EditWineButton_Click(object sender, EventArgs e)
    {

    }
  }
}