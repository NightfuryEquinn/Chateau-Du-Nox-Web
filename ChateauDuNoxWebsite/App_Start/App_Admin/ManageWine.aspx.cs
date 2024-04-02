using System;
using System.Collections.Generic;
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
          "<script>alert('Only admin has access to this page.'); document.location.href='./Home.aspx';</script>"
        );
      }
    }
  }
}