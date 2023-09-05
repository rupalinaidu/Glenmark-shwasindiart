using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Specialized;
using System.Web.Services;
using System.Net.Mail;
using System.Text;
using System.Web.Script.Services;


public partial class camp_data_AllWebMethods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string Userlogin(string emp_code, string password)
    {

        if (emp_code != null || password != null)
        {
            try
            {

                string CS = ConfigurationManager.ConnectionStrings["dbglenmark_camp"].ConnectionString;

                DataSet dt = new DataSet();
                using (SqlConnection con = new SqlConnection(CS))
                {

                    using (SqlCommand cmd = new SqlCommand("USP_CAMP_CLINIC_MANAGEMENT"))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@TYPE", "9");
                        cmd.Parameters.AddWithValue("@emp_code", emp_code);
                        cmd.Parameters.AddWithValue("@pass", password);

                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }

                        if (dt.Tables[0].Rows[0]["DATA"].ToString() == "1")
                        {
                            string empcode = dt.Tables[1].Rows[0]["emp_code"].ToString().ToUpper();
                            string name = dt.Tables[1].Rows[0]["name"].ToString().Trim();
                            string email = dt.Tables[1].Rows[0]["email"].ToString().Trim();
                            string mobile = dt.Tables[1].Rows[0]["mobile"].ToString();
                            string desg = dt.Tables[1].Rows[0]["desg"].ToString();
                            string reportingto = dt.Tables[1].Rows[0]["reportingto"].ToString();
                            


                            HttpCookie cookie = new HttpCookie("glenmark_camps");
                            cookie.Values["empcode"] = empcode;
                            cookie.Values["emp_name"] = name;
                            cookie.Values["email"] = email;
                            cookie.Values["mobile"] = mobile;
                            cookie.Values["desg"] = desg;
                            cookie.Values["reportingto"] = reportingto;
                            cookie.Expires = DateTime.Now.AddDays(1);
                            HttpContext.Current.Response.Cookies.Add(cookie);
                            return string.Format("1");
                        }
                        else
                        {
                            return string.Format(dt.Tables[0].Rows[0]["DATA"].ToString());
                        }

                    }

                }
                //}
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return string.Format(ex.Message.ToString());
            }


        }
        else
        {
            return "Please fill the required fields.";
        }
    }
}