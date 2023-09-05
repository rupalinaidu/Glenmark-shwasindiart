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



public partial class v1_data_all_webmethods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


	[System.Web.Services.WebMethod(EnableSession = true)]
    public static string logincheck(string empid, string pass)
    {
        string UnreadText = "";
		string empdata = "";
        string constring = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        string query = "select * from employeelist where emp_no='"+empid+"' and pass='"+pass+"' and active=1 ";

        DataSet dss = new DataSet();
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dss);

                }
            }
        }
        int x = dss.Tables[0].Rows.Count;
		
		if (x>0){
			empdata= dss.Tables[0].Rows[0]["emp_no"]+"~"+dss.Tables[0].Rows[0]["name"]+"~"+dss.Tables[0].Rows[0]["zone"]+"~"+dss.Tables[0].Rows[0]["region"]+"~"+dss.Tables[0].Rows[0]["state"]+"~"+dss.Tables[0].Rows[0]["desg"]+"~"+dss.Tables[0].Rows[0]["hq"]+"~"+dss.Tables[0].Rows[0]["email"]+"~"+dss.Tables[0].Rows[0]["reportingto"];	
		}
		
			
        if (empdata.ToString() == "")
        {
            return string.Format("0");

        }
        else
        {
            return empdata.ToString();

        }



    }


	
[WebMethod]
    public static string insert_tourplan(string machine_number,  string region, string hqname, string city, string druid, string drname, string drgender, string drnumber, string dradd, string cliniccode, string spocname, string spocnumber, string date, string day, string month, string year, string starttime, string endtime, string created_by)
    {
		
		string ckUserEmail;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);


           
            try
            {
				
				
				using (conn)
            {
                conn.Open();
                    
               
                    DateTime dateTime = datetimegetcurrentime();
                    string createdOn = dateTime.ToString("MM/dd/yyyy;hh:mm:tt");
               
			   
                SqlCommand cmd = new SqlCommand(" INSERT INTO tour_plan(mac_id,region,hq,month,campdate,campday,starttime,endtime,city,dr_name,dr_gender,dr_id,dr_mobile,clinic_address,clinic_pincode,zydus_spoc_name,zydus_spoc_number,status,deleted,created_by,created_on) values(@mac_id,@region,@hq,@month,@campdate,@campday,@starttime,@endtime,@city,@dr_name,@dr_gender,@dr_id,@dr_mobile,@clinic_address,@clinic_pincode,@zydus_spoc_name,@zydus_spoc_number,'Approved',0,@createdBy,@createdOn)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mac_id", machine_number);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@hq", hqname);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@campdate", date);
                cmd.Parameters.AddWithValue("@campday", day);
				cmd.Parameters.AddWithValue("@starttime", starttime);
				cmd.Parameters.AddWithValue("@endtime", endtime);
				cmd.Parameters.AddWithValue("@city", city);
				cmd.Parameters.AddWithValue("@dr_name", drname);
				cmd.Parameters.AddWithValue("@dr_gender", drgender);
				cmd.Parameters.AddWithValue("@dr_id", druid);
				cmd.Parameters.AddWithValue("@dr_mobile", drnumber);
				cmd.Parameters.AddWithValue("@clinic_address", dradd);
				cmd.Parameters.AddWithValue("@clinic_pincode", cliniccode);
				cmd.Parameters.AddWithValue("@zydus_spoc_name", spocname);
				cmd.Parameters.AddWithValue("@zydus_spoc_number", spocnumber);
				cmd.Parameters.AddWithValue("@createdBy", created_by);
				cmd.Parameters.AddWithValue("@createdOn", createdOn);

				
                cmd.ExecuteNonQuery();
                conn.Close();
                
                    return "1";
			}                

            
            }
            catch (Exception ex)
            {
                return "failure: "+ex;
            }

        
        

	}
                

[WebMethod]
    public static string insert_leaveplan(string mod_machine_number,  string leavetype, string date, string day, string month, string year, string created_by)
    {
		
		string ckUserEmail;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);


           
            try
            {
				
				
				using (conn)
            {
                conn.Open();
                    
               
                    DateTime dateTime = datetimegetcurrentime();
                    string createdOn = dateTime.ToString("MM/dd/yyyy;hh:mm:tt");
               
			   
                SqlCommand cmd = new SqlCommand(" INSERT INTO tour_plan(mac_id,month,campdate,campday,status,deleted,created_by,created_on) values(@mac_id,@month,@campdate,@campday,@status,0,@createdBy,@createdOn)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mac_id", mod_machine_number);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@campdate", date);
                cmd.Parameters.AddWithValue("@campday", day);
				cmd.Parameters.AddWithValue("@status", leavetype);
				cmd.Parameters.AddWithValue("@createdBy", created_by);
				cmd.Parameters.AddWithValue("@createdOn", createdOn);

				
                cmd.ExecuteNonQuery();
                conn.Close();
                
                    return "1";
                

                
            }
				
				
                


            }
            catch (Exception ex)
            {
                return "failure: "+ex;
            }

        
        

	}
	
	
	
	
	
	
	
	[WebMethod]
    public static string cancel_tourplan(string id, string cancelled_by, string reason)
    {
		
		string ckUserEmail;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);


           
            try
            {
				
				
				using (conn)
            {
                conn.Open();
                    
               
                    DateTime dateTime = datetimegetcurrentime();
                    string createdOn = dateTime.ToString("MM/dd/yyyy;hh:mm:tt");
               
			   
                SqlCommand cmd = new SqlCommand(" Update tour_plan set status='Cancelled', cancelled=1, cancelled_by=@cancelled_by,flag2=@reason, flag4=@createdOn where id=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@cancelled_by", cancelled_by);
				cmd.Parameters.AddWithValue("@reason", reason);
				cmd.Parameters.AddWithValue("@createdOn", createdOn);

				
                cmd.ExecuteNonQuery();
                conn.Close();
                
                    return "1";
                

                
            }
				
				
                


            }
            catch (Exception ex)
            {
                return "failure: "+ex;
            }

        
        

	}
	
	
	
	[WebMethod]
    public static string approve_tourplan(string id, string approved_by)
    {
		
		string ckUserEmail;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);


           
            try
            {
				
				
				using (conn)
            {
                conn.Open();
                    
               
                    DateTime dateTime = datetimegetcurrentime();
                    string createdOn = dateTime.ToString("MM/dd/yyyy;hh:mm:tt");
               
			   
                SqlCommand cmd = new SqlCommand(" Update tour_plan set status='Approved', approval_by=@approved_by, approval_date=@createdOn where id=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@approved_by", approved_by);
				cmd.Parameters.AddWithValue("@createdOn", createdOn);

				
                cmd.ExecuteNonQuery();
                conn.Close();
                
                    return "1";
                

                
            }
				
				
                


            }
            catch (Exception ex)
            {
                return "failure: "+ex;
            }

        
        

	}
	
	
	
	[WebMethod]
    public static string dispprove_tourplan(string id, string approved_by, string reason)
    {
		
		string ckUserEmail;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);


           
            try
            {
				
				
				using (conn)
            {
                conn.Open();
                    
               
                    DateTime dateTime = datetimegetcurrentime();
                    string createdOn = dateTime.ToString("MM/dd/yyyy;hh:mm:tt");
               
			   
                SqlCommand cmd = new SqlCommand(" Update tour_plan set status='Disapproved', approval_by=@approved_by, flag2=@reason, approval_date=@createdOn where id=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@approved_by", approved_by);
				cmd.Parameters.AddWithValue("@reason", reason);
				cmd.Parameters.AddWithValue("@createdOn", createdOn);

				
                cmd.ExecuteNonQuery();
                conn.Close();
                
                    return "1";
                

                
            }
				
				
                


            }
            catch (Exception ex)
            {
                return "failure: "+ex;
            }

        
        

	}
	
	
	
	
	[System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
    public static object GetData_userlist()
    {
        string str = "";
        SqlConnection sqlCnn;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		
		string empno = HttpContext.Current.Request.QueryString["empno"];
		string status = HttpContext.Current.Request.QueryString["status"];
		string month = HttpContext.Current.Request.QueryString["month"];


        string CS = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        sqlCnn = new SqlConnection(CS);

        //where flag1='0' order by date_added DESC"
        string sql = "select * from register_qrscan ";
        try
        {

            using (SqlConnection con = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("sp_tour_plan"))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@action", "select");
                    cmd.Parameters.AddWithValue("@emp_no", empno);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@month", month);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "pipeusers");
                    DataTable dt = ds.Tables["pipeusers"];
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);




                }


            }
           
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return ex;
        }

        //return str;
    }
	
	
	
	[System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
    public static object GetData_userlist_week()
    {
        string str = "";
        SqlConnection sqlCnn;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		
		string empno = HttpContext.Current.Request.QueryString["empno"];
		string status = HttpContext.Current.Request.QueryString["status"];
		string month = HttpContext.Current.Request.QueryString["month"];
		string startdate = HttpContext.Current.Request.QueryString["startdate"];
		string enddate = HttpContext.Current.Request.QueryString["enddate"];


        string CS = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        sqlCnn = new SqlConnection(CS);

        //where flag1='0' order by date_added DESC"
        string sql = "select * from register_qrscan ";
        try
        {

            using (SqlConnection con = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("sp_tour_plan"))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@action", "select");
                    cmd.Parameters.AddWithValue("@emp_no", empno);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "pipeusers");
                    DataTable dt = ds.Tables["pipeusers"];
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);




                }


            }
           
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return ex;
        }

        //return str;
    }
	
	
	
	[WebMethod]
    public static string insert_postremark(string mac_id,  string rbo, string rcity, string rdate, string rdrname, string rmanager, int rpatients, int rplanid, int rrxions, string rempid, string lypa_pres, string lypa_pob, string sita_pres, string sita_pob, string xremark, string rdrid)
    {
		
		string ckUserEmail;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbms"].ConnectionString);


           
            try
            {
				
				
				using (conn)
            {
                conn.Open();
                    
               
                    DateTime dateTime = datetimegetcurrentime();
                    string createdOn = dateTime.ToString("MM/dd/yyyy;hh:mm:tt");
               
			   
                SqlCommand cmd = new SqlCommand(" INSERT INTO postremark(planid,mac_id,campdate,city,dr_name,manager_attended,bo_attended,patient_screened,rxions_received,lypa_pres,lypa_pob,sita_pres,sita_pob,created_on,created_by, xremark,dr_id) values(@rplanid,@mac_id,@rdate,@rcity,@rdrname,@rmanager,@rbo,@rpatients,@rrxions,@lypa_pres,@lypa_pob,@sita_pres,@sita_pob,@createdOn,@rempid,@xremark,@rdrid)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mac_id", mac_id);
                cmd.Parameters.AddWithValue("@rbo", rbo);
                cmd.Parameters.AddWithValue("@rcity", rcity);
                cmd.Parameters.AddWithValue("@rdate", rdate);
                cmd.Parameters.AddWithValue("@rdrname", rdrname);
                cmd.Parameters.AddWithValue("@rmanager", rmanager);
				cmd.Parameters.AddWithValue("@rpatients", rpatients);
				cmd.Parameters.AddWithValue("@rplanid", rplanid);
				cmd.Parameters.AddWithValue("@rrxions", rrxions);
				cmd.Parameters.AddWithValue("@rempid", rempid);
				cmd.Parameters.AddWithValue("@lypa_pres", lypa_pres);
				cmd.Parameters.AddWithValue("@lypa_pob", lypa_pob);
				cmd.Parameters.AddWithValue("@sita_pres", sita_pres);
				cmd.Parameters.AddWithValue("@sita_pob", sita_pob);
				cmd.Parameters.AddWithValue("@createdOn", createdOn);
				cmd.Parameters.AddWithValue("@xremark", xremark);
				cmd.Parameters.AddWithValue("@rdrid", rdrid);

				
                cmd.ExecuteNonQuery();
                conn.Close();
                
                    return "1";
                

                
            }
				
				
                


            }
            catch (Exception ex)
            {
                return "failure: "+ex;
            }

        
        

	}
	
	
	
	[System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
    public static object GetData_remarklist()
    {
        string str = "";
        SqlConnection sqlCnn;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		
		string empno = HttpContext.Current.Request.QueryString["empno"];


        string CS = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        sqlCnn = new SqlConnection(CS);

        
        try
        {

            using (SqlConnection con = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("sp_postremark"))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@action", "select");
                    cmd.Parameters.AddWithValue("@emp_no", empno);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "pipeusers");
                    DataTable dt = ds.Tables["pipeusers"];
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);




                }


            }
           
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            return "error";
        }

        //return str;
    }
	
	
	
	
	[System.Web.Services.WebMethod(EnableSession = true)]
    public static string checkdr(string drid)
    {
		string drdata = "";
        string constring = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
        string query = "select * from doctor_details where dr_code='"+drid+"'";

        DataSet dss = new DataSet();
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dss);

                }
            }
        }
        int x = dss.Tables[0].Rows.Count;
		
		if (x>0){
			drdata= dss.Tables[0].Rows[0]["dr_name"].ToString();	
		}
		
			
        if (drdata.ToString() == "")
        {
            return string.Format("0");

        }
        else
        {
            return drdata.ToString();

        }



    }
	
	
	
	
	[System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
    public static object get_mac_weekly()
    {
        string str = "";
        SqlConnection sqlCnn;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		
		string startday = HttpContext.Current.Request.QueryString["startday"];
		string endday = HttpContext.Current.Request.QueryString["endday"];
        string UnreadText = "";
		string empdata = "";
        string constring = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
		
		string query;
		
			 query = "select  mac_id,count(case when campday = 'Monday' then 1 end) as monday, count(case when campday = 'tuesday' then 1 end) as tuesday,count(case when campday = 'wednesday' then 1 end) as wednesday,count(case when campday = 'thursday' then 1 end) as thursday,count(case when campday = 'friday' then 1 end) as friday,count(case when campday = 'saturday' then 1 end) as saturday,count(case when campday = 'sunday' then 1 end) as sunday from  tour_plan where (campdate between '"+startday+"' and '"+endday+"') and status != 'Cancelled'  group by  mac_id  order by mac_id asc";
		



        DataSet dss = new DataSet();
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dss);
					DataTable dt = dss.Tables[0];
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
					return serializer.Serialize(rows);

                }
				
                    
                    
                    
            }
        }
        //int x = dss.Tables[0].Rows.Count;
		
    }
	
	
	[System.Web.Services.WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
    public static object get_mac_yesterday()
    {
        string str = "";
        SqlConnection sqlCnn;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		
		string yesterday = HttpContext.Current.Request.QueryString["yesterday"];
		string daybefore = HttpContext.Current.Request.QueryString["daybefore"];
        string UnreadText = "";
		string empdata = "";
        string constring = ConfigurationManager.ConnectionStrings["dbms"].ConnectionString;
		
		string query;
		
			 query = "   select  mac_id,count(case when campdate = '"+daybefore+"' then 1 end) as daybefore, count(case when campdate = '"+yesterday+"' then 1 end) as yesterday from  postremark where (campdate between '"+daybefore+"' and '"+yesterday+"')  group by  mac_id  order by mac_id asc";
		



        DataSet dss = new DataSet();
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dss);
					DataTable dt = dss.Tables[0];
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
					return serializer.Serialize(rows);

                }
				
                    
                    
                    
            }
        }
        //int x = dss.Tables[0].Rows.Count;
		
    }







	
	public static DateTime datetimegetcurrentime()
    {
        DateTime timeUtc = DateTime.UtcNow;
        TimeZoneInfo mumbaitimezoon = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, mumbaitimezoon);
        return cstTime;
    }
}