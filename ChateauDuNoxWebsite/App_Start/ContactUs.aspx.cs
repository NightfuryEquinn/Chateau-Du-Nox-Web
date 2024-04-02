using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChateauDuNoxWebsite.App_Start
{
  public partial class ContactUs : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubscribeButton_Click(object sender, EventArgs e)
    {
      string subscribeEmail = SubscribeInput.Text.Trim();

      if (subscribeEmail != "")
      {
        Response.Write(
          "<script>alert('Thank you for subscribing our newsletter. We will send new updates and possible invitation to our chateau to " + subscribeEmail + ". Stay tuned and wined.');</script>"
        );

        SubscribeInput.Text = string.Empty;
      }
      else
      {
        Response.Write(
          "<script>alert('Please use a valid email address.');</script>"
        );
      }
    }
  }
}