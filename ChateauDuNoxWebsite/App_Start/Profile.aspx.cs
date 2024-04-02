using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start
{
  public partial class Profile : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["Name"] == null)
      {
        Response.Write(
          "<script>alert('Please login to view your profile page. If you do not have an account, please kindly register a new account.'); document.location.href='./Login.aspx';</script>"
        );
      }
    }

    protected void ChangePass_Click(object sender, EventArgs e)
    {
      Response.Redirect("Forget.aspx");
    }
  }
}