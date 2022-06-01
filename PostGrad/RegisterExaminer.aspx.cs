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
    public partial class RegisterExaminer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regBtn(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string nameEx = Name.Text;
            string email = emailExam.Text;
            string pass = Password.Text;
            string nationallity = DropDownList.SelectedValue;
            string fieldOfWork = fieldExam.Text;
            int egyptian;
            if(nationallity == "egyptian")
            {
                egyptian = 1;
            }
            else
            {
                egyptian = 0;
            }

            if (nameEx.Replace(" ", "") == "" || email.Replace(" ", "") == "" || pass.Replace(" ", "") == "" || nationallity.Replace(" ", "") == "" || fieldOfWork.Replace(" ","") == "")
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
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Email already taken,</div>");
                    int x2 = 755;
                    int y2 = 567;
                    Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>please choose another one!</div>");
                }
                else
                {
                    if (nameEx.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Name has to be less than 20 characters.</div>");
                    }
                    else if (email.Length > 50)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Email has to be less than 50 characters.</div>");
                    }
                    else if (pass.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Password has to be less than 20 characters.</div>");
                    }
                    else if (fieldOfWork.Length > 20)
                    {
                        int x = 690;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Field of work has to be less than 20 characters.</div>");
                    }
                    else
                    {
                        SqlCommand examinerRegisterPROC = new SqlCommand("examinerRegister", conn);
                        examinerRegisterPROC.CommandType = CommandType.StoredProcedure;

                        examinerRegisterPROC.Parameters.Add(new SqlParameter("@name", nameEx));
                        examinerRegisterPROC.Parameters.Add(new SqlParameter("@email", email));
                        examinerRegisterPROC.Parameters.Add(new SqlParameter("@password", pass));
                        examinerRegisterPROC.Parameters.Add(new SqlParameter("@nationalBit", egyptian));
                        examinerRegisterPROC.Parameters.Add(new SqlParameter("@fieldOfWork", fieldOfWork));

                        conn.Open();
                        examinerRegisterPROC.ExecuteNonQuery();
                        conn.Close();

                        SqlCommand yourIDPROC = new SqlCommand("yourID", conn);
                        yourIDPROC.CommandType = CommandType.StoredProcedure;

                        SqlParameter examinerID = yourIDPROC.Parameters.Add("@id", SqlDbType.Int);

                        examinerID.Direction = ParameterDirection.Output;

                        conn.Open();
                        yourIDPROC.ExecuteNonQuery();
                        conn.Close();

                        int x = 715;
                        int y = 550;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You registered successfully, your ID: " + examinerID.Value + "</div>");
                        int x2 = 743;
                        int y2 = 567;
                        Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>Make sure you remember it!</div>");
                    }
                }


            }
        }
    }
}