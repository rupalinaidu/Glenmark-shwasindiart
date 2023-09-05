using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class camp_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current != null)
        {
            int cookieCount = HttpContext.Current.Request.Cookies.Count;
            HttpCookie ck = HttpContext.Current.Request.Cookies["glenmark_camps"];
            if (ck != null)
            {
                ck.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(ck);
                //Response.Redirect("../index.html");
                Response.Redirect("https://shwasindiart.com/index.html");
            }
            else
            {
                Response.Redirect("https://shwasindiart.com/index.html");
            }


        }

        else
        {


            Response.Redirect("index.html");

        }
    }
}