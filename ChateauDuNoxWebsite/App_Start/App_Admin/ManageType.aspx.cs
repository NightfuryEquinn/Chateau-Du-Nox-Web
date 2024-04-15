using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start.App_Admin
{
  public partial class ManageType : System.Web.UI.Page
  {
    public class TypeData
    {
      public int TypeId { get; set; }
      public string Name { get; set; }
      public string Count { get; set; }
      public int Active { get; set; }
    }

    public List<TypeData> GetTypeByStatus(SqlConnection conn, int status)
    {
      string fetchTypeQuery = @"
                              SELECT t.*, COUNT(w.typeId) AS Count
                              FROM Type t
                              LEFT JOIN Wine w ON t.TypeId = w.typeId
                              WHERE t.Active = @Status
                              GROUP BY t.TypeId, t.Name, t.Active
                              ";
      SqlCommand fetchTypeCommand = new SqlCommand(fetchTypeQuery, conn);
      fetchTypeCommand.Parameters.AddWithValue("@Status", status);

      SqlDataReader reader = fetchTypeCommand.ExecuteReader();
      List<TypeData> types = new List<TypeData>();

      while (reader.Read())
      {
        TypeData type = new TypeData
        {
          TypeId = Convert.ToInt32(reader["TypeId"].ToString()),
          Name = reader["Name"].ToString(),
          Count = reader["Count"].ToString(),
          Active = Convert.ToInt32(reader["Active"].ToString())
        };

        types.Add(type);
      }

      reader.Close();
      return types;
    }

    private void loadPageContent()
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        List<TypeData> activeTypes = GetTypeByStatus(conn, 1);
        List<TypeData> inactiveTypes = GetTypeByStatus(conn, 0);

        ActiveRepeater.DataSource = activeTypes;
        ActiveRepeater.DataBind();

        InactiveRepeater.DataSource = inactiveTypes;
        InactiveRepeater.DataBind();

        if (Request.QueryString["TypeId"] != null)
        {
          string fetchTypeQuery = "SELECT * FROM [Type] WHERE TypeId = @TypeId";
          SqlCommand fetchTypeCommand = new SqlCommand(fetchTypeQuery, conn);
          fetchTypeCommand.Parameters.AddWithValue("@TypeId", Convert.ToInt32(Request.QueryString["TypeId"]));

          SqlDataReader reader = fetchTypeCommand.ExecuteReader();

          if (reader.Read())
          {
            EditTypeName.Text = reader["Name"].ToString();
          }

          reader.Close();
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Fetch Type Error:", ex.Message);
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

    protected void EditType_Click(object sender, EventArgs e)
    {
      Button editButton = (Button)sender;
      string typeId = editButton.CommandArgument;

      Uri currentUri = HttpContext.Current.Request.Url;
      if (string.IsNullOrEmpty(currentUri.Query))
      {
        StringBuilder builder = new StringBuilder("ManageType.aspx?TypeId=" + typeId);
        Response.Redirect(builder.ToString());
      }
    }

    protected void DeleteType_Click(object sender, EventArgs e)
    {
      Button deleteButton = (Button)sender;
      string typeId = deleteButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string deleteQuery = "UPDATE [Type] SET Active = 0 WHERE TypeId = @TypeId";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn);
        deleteCommand.Parameters.AddWithValue("@TypeId", typeId);

        deleteCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Type with ID " + typeId + " has been switched to inactive status.'); document.location.href='./ManageType.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Delete Type Error:", ex.Message);
      }
    }

    protected void RecoverType_Click(object sender, EventArgs e)
    {
      Button recoverButton = (Button)sender;
      string typeId = recoverButton.CommandArgument;

      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string recoverQuery = "UPDATE [Type] SET Active = 1 WHERE TypeId = @TypeId";
        SqlCommand recoverCommand = new SqlCommand(recoverQuery, conn);
        recoverCommand.Parameters.AddWithValue("@TypeId", typeId);

        recoverCommand.ExecuteNonQuery();

        Response.Write(
          "<script>alert('Type with ID " + typeId + " has been switched to active status.'); document.location.href='./ManageType.aspx';</script>"
        );

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Recover Type Error:", ex.Message);
      }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        int typeId = Convert.ToInt32(Request.QueryString["TypeId"]);

        string name = EditTypeName.Text.Trim();

        if (!string.IsNullOrEmpty(name))
        {
          string updateQuery = "UPDATE [Type] SET Name = @Name WHERE TypeId = @TypeId";
          SqlCommand updateCommand = new SqlCommand(updateQuery, conn);
          updateCommand.Parameters.AddWithValue("@Name", name);
          updateCommand.Parameters.AddWithValue("@TypeId", typeId);

          updateCommand.ExecuteNonQuery();

          Response.Write(
            "<script>alert('" + name + " has been edited successfully.'); document.location.href='./ManageType.aspx';</script>"
          );
        }
        else
        {
          Response.Write(
            "<script>alert('Please fill up all empty fields. Image is optional unless change is required.'); document.location.href='./ManageType.aspx';</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Edit Type Error:", ex.Message);
      }
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
      try
      {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChateauString"].ConnectionString);
        conn.Open();

        string name = AddTypeName.Text.Trim();

        if (!string.IsNullOrEmpty(name))
        {
          string insertQuery = "INSERT INTO [Type] (Name) VALUES (@Name)";
          SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
          insertCommand.Parameters.AddWithValue("@Name", AddTypeName.Text.Trim());

          insertCommand.ExecuteNonQuery();

          Response.Write(
            "<script>alert('New wine type has been added successfully.'); document.location.href='./ManageType.aspx';</script>"
          );
        }
        else
        {
          Response.Write(
            "<script>alert('Please fill in a new wine type.'); document.location.href='./ManageType.aspx';</script>"
          );
        }

        conn.Close();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("Add Type Error:", ex.Message);
      }
    }
  }
}