using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start
{
  public partial class Review : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      OneStar.Attributes.Add("value", "one");
      TwoStar.Attributes.Add("value", "two");
      ThreeStar.Attributes.Add("value", "three");
      FourStar.Attributes.Add("value", "four");
      FiveStar.Attributes.Add("value", "five");
    }
  }
}