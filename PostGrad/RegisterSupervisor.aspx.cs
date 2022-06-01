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
    public partial class RegisterSupervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //    Response.Redirect("Login.aspx");

        }

        protected void regBtn(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string fname = firstName.Text;
            string lname = lastName.Text;
            string email = emailSup.Text;
            string pass = passwordSup.Text;
            string faculty = facultySup.Text;

            if(fname.Replace(" ", "") == "" || lname.Replace(" ", "") == "" || email.Replace(" ", "") == "" || pass.Replace(" ", "") == "" || faculty.Replace(" ", "") == "")
            {
                int x = 755;
                int y = 550;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill all the fields!</div>");
            }
            else
            {
                SqlCommand emailExistsPROC = new SqlCommand("emailExists", conn);
                emailExistsPROC.CommandType = CommandType.StoredProcedure;

                emailExistsPROC.Parameters.Add(new SqlParameter("@email", email));
                SqlParameter emailExists = emailExistsPROC.Parameters.Add("@emailAlreadyExists", SqlDbType.Int);

                emailExists.Direction = ParameterDirection.Output;

                conn.Open();
                emailExistsPROC.ExecuteNonQuery();
                conn.Close();

                if (emailExists.Value.ToString() == "1")
                {
                    int x = 755;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Email already used,</div>");
                    int x2 = 755;
                    int y2 = 567;
                    Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>please choose another one!</div>");
                }
                else
                {
                    if(fname.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>First name has to be less than 20 characters.</div>");
                    }
                    else if(lname.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Last name has to be less than 20 characters.</div>");
                    }
                    else if(email.Length > 50)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Email has to be less than 50 characters.</div>");
                    }
                    else if(pass.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Password has to be less than 20 characters.</div>");
                    }
                    else if(faculty.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Faculty name has to be less than 20 characters.</div>");
                    }
                    else
                    {
                        SqlCommand supervisorRegisterPROC = new SqlCommand("supervisorRegister", conn);
                        supervisorRegisterPROC.CommandType = CommandType.StoredProcedure;

                        supervisorRegisterPROC.Parameters.Add(new SqlParameter("@first_name", fname));
                        supervisorRegisterPROC.Parameters.Add(new SqlParameter("@last_name", lname));
                        supervisorRegisterPROC.Parameters.Add(new SqlParameter("@password", pass));
                        supervisorRegisterPROC.Parameters.Add(new SqlParameter("@faculty ", faculty));
                        supervisorRegisterPROC.Parameters.Add(new SqlParameter("@email", email));

                        conn.Open();
                        supervisorRegisterPROC.ExecuteNonQuery();
                        conn.Close();


                        SqlCommand yourIDPROC = new SqlCommand("yourID", conn);
                        yourIDPROC.CommandType = CommandType.StoredProcedure;

                        SqlParameter supervisorID = yourIDPROC.Parameters.Add("@id", SqlDbType.Int);

                        supervisorID.Direction = ParameterDirection.Output;

                        conn.Open();
                        yourIDPROC.ExecuteNonQuery();
                        conn.Close();

                        int x = 715;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You registered successfully, your ID: " + supervisorID.Value + "</div>");
                        int x2 = 743;
                        int y2 = 567;
                        Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>Make sure you remember it!</div>");
                    }


                }

                
            }

        }

        

        
    }
}