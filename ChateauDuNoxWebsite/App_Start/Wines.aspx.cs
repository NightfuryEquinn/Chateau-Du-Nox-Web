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
  public partial class Wines : System.Web.UI.Page
  {
    public class WineData
    {
      public int WineId { get; set; }
      public string Name { get; set; }
      public byte[] Image { get; set; }
      public int Price { get; set; }
    }

    public class WineType
    {
      public int TypeId { get; set; }
      public string TypeName { get; set; }
      public List<WineData> TypeWines { get; set; }
    }

    private List<WineType> GetWineTab(SqlConnection conn)
    {
      string fetchTypeQuery = "SELECT * FROM [Type] WHERE Active = 1";
      SqlCommand fetchTypeCommand = new SqlCommand(fetchTypeQuery, conn);

      SqlDataReader typeReader = fetchTypeCommand.ExecuteReader();
      List<WineType> types = new List<WineType>();

      while (typeReader.Read())
      {
        WineType type = new WineType
        {
          TypeId = Convert.ToInt32(typeReader["TypeId"].ToString()),
          TypeName = typeReader["Name"].ToString()
        };

        types.Add(type);
      }

      typeReader.Close();

      return types;
    }

    private List<WineType> GetWineTypeAndWine(SqlConnection conn)
    {
      string fetchWineTypeAndWineQuery = @"
                                        SELECT Wine.*, Type.Name as TypeName, Type.Active as TypeActive FROM Wine
                                        INNER JOIN Type ON Wine.TypeId = Type.TypeId
                                        WHERE Wine.Active = 1 AND Type.Active = 1
                                        ";
      SqlCommand fetchWTAWCommand = new SqlCommand(fetchWineTypeAndWineQuery, conn);

      SqlDataReader reader = fetchWTAWCommand.ExecuteReader();
      List<WineType> wineTypes = new List<WineType>();

      while (reader.Read())
      {
        int typeId = Convert.ToInt32(reader["TypeId"].ToString());

        WineType wineType = wineTypes.FirstOrDefault(wt => wt.TypeId == typeId);
        if (wineType == null)
        {
          wineType = new WineType
          {
            TypeId = typeId,
            TypeName = reader["TypeName"].ToString(),
            TypeWines = new List<WineData>()
          };

          wineTypes.Add(wineType);
        }

        wineType.TypeWines.Add(new WineData
        {
          WineId = Convert.ToInt32(reader["WineId"].ToString()),
          Name = reader["Name"].ToString(),
          Image = (byte[])reader["Image"],
          Price = Convert.ToInt32(reader["Price"].ToString())
        });
      }

      reader.Close();

      return wineTypes;
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        TabRepeater.DataSource = GetWineTab(conn);
        TabRepeater.DataBind();

        TypeRepeater.DataSource = GetWineTypeAndWine(conn);
        TypeRepeater.DataBind();

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Wines Error:", ex.Message);
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        loadPageContent();
      }
    }
  }
}