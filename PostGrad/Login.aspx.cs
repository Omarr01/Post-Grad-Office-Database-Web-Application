using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGrad
{

    public partial class Login : System.Web.UI.Page
    {
        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string userEmailStr = userEmail.Text;
            string pass = password.Text;

            if(userEmailStr.Replace(" ", "") == "" || pass.Replace(" ", "") == "")
            {
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill all the fields!</div>");
            }
            else
            {
                
                SqlCommand loginPROC = new SqlCommand("userLoginEmail", conn);
                loginPROC.CommandType = CommandType.StoredProcedure;

                loginPROC.Parameters.Add(new SqlParameter("@email", userEmailStr));
                loginPROC.Parameters.Add(new SqlParameter("@password", pass));

                SqlParameter success = loginPROC.Parameters.Add("@success", SqlDbType.Int);
                SqlParameter userID = loginPROC.Parameters.Add("@id", SqlDbType.Int);

                success.Direction = ParameterDirection.Output;
                userID.Direction = ParameterDirection.Output;

                conn.Open();
                loginPROC.ExecuteNonQuery();
                conn.Close();

                if (success.Value.ToString() == "1")
                {
                    int x = 735;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You logged in successfully!</div>");

                    Session["user"] = userID.Value;

                    SqlCommand userTypePROC = new SqlCommand("userType", conn);
                    userTypePROC.CommandType = CommandType.StoredProcedure;

                    userTypePROC.Parameters.Add(new SqlParameter("@id", Session["user"]));

                    SqlParameter userType = userTypePROC.Parameters.Add("@type", SqlDbType.VarChar, 20);

                    userType.Direction = ParameterDirection.Output;

                    conn.Open();
                    userTypePROC.ExecuteNonQuery();
                    conn.Close();

                    Session["userType"] = userType.Value;

                    if ((string)Session["userType"] == "gucianstudent" || (string)Session["userType"] == "nongucianstudent")
                    {
                        Response.Redirect("Student.aspx");
                    }
                    else if((string)Session["userType"] == "supervisor")
                    {
                        Response.Redirect("Supervisor.aspx");
                    }
                    else if ((string)Session["userType"] == "examiner")
                    {
                        Response.Redirect("Examiner.aspx");
                    }
                    else
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    //redirect to homepage

                }
                else
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please enter a valid email and password!</div>");
                } 






            }


        }
    }
}