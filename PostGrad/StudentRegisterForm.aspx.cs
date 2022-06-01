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
    public partial class StudentRegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void onRegisterClicked(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string password = Password.Text;
            string faculty = Faculty.Text;
            string email = Email.Text;
            string address = Address.Text;
            string studentType = DropDownList.SelectedValue;
            int isGucian;
            if (studentType == "gucian")
            {
                isGucian = 1;
            }
            else
            {
                isGucian = 0;
            }
            if ((firstName.Replace(" ", "") == "") || (lastName.Replace(" ", "") == "") || (password.Replace(" ", "") == "") || (faculty.Replace(" ", "") == "") || (email.Replace(" ", "") == "") || (address.Replace(" ", "") == "") || (studentType.Replace(" ", "") == ""))
            {
                int x = 755;
                int y = 625;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill all the fields!</div>");
            }
            else
            {
                if (firstName.Length > 20)
                {
                    int x = 690;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>First name has to be less than 20 characters.</div>");
                }
                else if (lastName.Length > 20)
                {
                    int x = 690;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Last name has to be less than 20 characters.</div>");
                }
                else if (email.Length > 50)
                {
                    int x = 690;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Email has to be less than 50 characters.</div>");
                }
                else if (password.Length > 20)
                {
                    int x = 690;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Password has to be less than 20 characters.</div>");
                }
                else if (faculty.Length > 20)
                {
                    int x = 690;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Faculty name has to be less than 20 characters.</div>");
                }
                else if (address.Length > 50)
                {
                    int x = 690;
                    int y = 550;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Address has to be less than 50 characters.</div>");
                }
                else
                {
                    string connstr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
                    SqlConnection connection = new SqlConnection(connstr);

                    SqlCommand emailExistsPROC = new SqlCommand("emailExists", connection);
                    emailExistsPROC.CommandType = CommandType.StoredProcedure;
                    emailExistsPROC.Parameters.Add(new SqlParameter("@email", email));
                    SqlParameter emailExists = emailExistsPROC.Parameters.Add("@emailAlreadyExists", SqlDbType.Int);

                    emailExists.Direction = ParameterDirection.Output;

                    connection.Open();
                    emailExistsPROC.ExecuteNonQuery();
                    connection.Close();

                    if (emailExists.Value.ToString() == "1")
                    {
                        int x = 755;
                        int y = 625;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Email already taken,</div>");
                        int x2 = 755;
                        int y2 = 642;
                        Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>please choose another one!</div>");
                    }
                    else
                    {
                        SqlCommand registerStudentProc = new SqlCommand("studentRegister", connection);
                        registerStudentProc.CommandType = CommandType.StoredProcedure;

                        registerStudentProc.Parameters.Add(new SqlParameter("@first_name", firstName));
                        registerStudentProc.Parameters.Add(new SqlParameter("@last_name", lastName));
                        registerStudentProc.Parameters.Add(new SqlParameter("@password", password));
                        registerStudentProc.Parameters.Add(new SqlParameter("@faculty", faculty));
                        registerStudentProc.Parameters.Add(new SqlParameter("@Gucian", isGucian));
                        registerStudentProc.Parameters.Add(new SqlParameter("@email", email));
                        registerStudentProc.Parameters.Add(new SqlParameter("@address", address));

                        connection.Open();
                        registerStudentProc.ExecuteNonQuery();
                        connection.Close();

                        string yourID;

                        SqlCommand yourNewIdPROC = new SqlCommand("yourID", connection);
                        yourNewIdPROC.CommandType = CommandType.StoredProcedure;

                        SqlParameter id = yourNewIdPROC.Parameters.Add("@id", SqlDbType.Int);
                        id.Direction = ParameterDirection.Output;

                        connection.Open();
                        yourNewIdPROC.ExecuteNonQuery();
                        connection.Close();

                        yourID = id.Value.ToString();

                        int x = 775;
                        int y = 625;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You registered successfully, your ID: " + yourID + "</div>");
                        int x2 = 730;
                        int y2 = 642;
                        Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>Make sure you remember it!</div>");
                    }

                

                }






            }
        }

    }
}