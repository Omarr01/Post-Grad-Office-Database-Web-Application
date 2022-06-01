using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PostGrad
{
    public partial class Examiner : System.Web.UI.Page
    {

        bool CheckLetters(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ' && i == 0)
                {
                    return false;
                }
                else if (s[i] == ' ')
                {
                    if (s[i + 1] == ' ')
                    {
                        return false;
                    }

                }
                else if (char.IsDigit(s[i]))
                {
                    return false;
                }


            }
            return true;
        }

        bool CheckThesis(string s, string y)
        {
            bool f = false;
            int x = 0;
            if (y.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < s.Length; i++)
            {
                int z = i;
                if (s[i] == y[0])
                {
                    for (int j = 0; j < y.Length && z < s.Length; j++)
                    {
                        x = j;
                        if (s[z] != y[j])
                        {
                            f = false;
                            break;
                        }
                        else
                        {
                            f = true;
                        }
                        z++;

                    }

                }
                if (f == true && x == y.Length - 1)
                {
                    return f;
                }

            }
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            else if((string)Session["userType"] != "examiner")
            {
                if(((string)Session["userType"] == "supervisor"))
                {
                    Response.Redirect("Supervisor.aspx");
                }
                else if (((string)Session["userType"] == "gucianstudent" || (string)Session["userType"] == "nongucianstudent"))
                {
                    Response.Redirect("Student.aspx");
                }
                else
                {
                    Response.Redirect("Admin.aspx");
                }
            }

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewExamProfilePROC = new SqlCommand("viewExamProfile", conn);
            viewExamProfilePROC.CommandType = CommandType.StoredProcedure;

            viewExamProfilePROC.Parameters.Add(new SqlParameter("@id", Session["user"]));


            conn.Open();

            SqlDataReader rdr = viewExamProfilePROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String stdFirstName = rdr.GetString(rdr.GetOrdinal("name"));
                String stdLastName = rdr.GetString(rdr.GetOrdinal("fieldOfWork"));

                HtmlTableRow tRow = new HtmlTableRow();
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = stdFirstName;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = stdLastName;
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                ExaminerProfileTable.Rows.Add(tRow);
            }
            conn.Close();
        }

        protected void editPrfBtn(object sender, EventArgs e)
        {
            ExaminerProfileTable.Visible = true;
            Table1.Visible = false;
            Table2.Visible = false;
            EditProfile.Visible = false;
            upname.Visible = true;
            upfield.Visible = true;
            newname.Visible = true;
            newfield.Visible = true;
            UpdateProfile.Visible = true;
            ViewDefenseInfo.Visible = true;
            AddComments.Visible = true;
            AddComments2.Visible = false;
            thesserno.Visible = false;
            enterthesserno.Visible = false;
            cmntslabel.Visible = false;
            cmtstext.Visible = false;
            AddGrade.Visible = true;
            AddGrade2.Visible = false;
            GradeLabel.Visible = false;
            GradeText.Visible = false;
            SelectThesis.Visible = true;
            SelectThesis2.Visible = false;
            Thesissearch.Visible = false;
            ThesisText.Visible = false;
        }
        protected void updatePrfBtn(object sender, EventArgs e)
        {


            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand editExamProfilePROC = new SqlCommand("editExamProfile", conn);
            editExamProfilePROC.CommandType = CommandType.StoredProcedure;

            string newName = newname.Text;
            string newField = newfield.Text;
            if (CheckLetters(newName) == false || CheckLetters(newField) == false)
            {
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please enter a valid name and field!Please remove all unnecessary spaces or digits (Dont have spaces at the beginning or multiple spaces in sequence)!!</div>");
            }


            else if (newName.Replace(" ", "") == "" || newField.Replace(" ", "") == "")
            {
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please enter a valid name and field!</div>");
            }

            else
            {

                editExamProfilePROC.Parameters.Add(new SqlParameter("@id", Session["user"]));
                editExamProfilePROC.Parameters.Add(new SqlParameter("@name", newName));
                editExamProfilePROC.Parameters.Add(new SqlParameter("@fieldOfWork", newField));

                conn.Open();
                editExamProfilePROC.ExecuteNonQuery();
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Update successful! To see it in the table above please choose another button then return to this page!! </div>");
                conn.Close();

            }

        }
        protected void dfnsInfBtn(object sender, EventArgs e)
        {
            ExaminerProfileTable.Visible = false;
            Table1.Visible = true;
            Table2.Visible = false;
            EditProfile.Visible = true;
            upname.Visible = false;
            upfield.Visible = false;
            newname.Visible = false;
            newfield.Visible = false;
            UpdateProfile.Visible = false;
            ViewDefenseInfo.Visible = true;
            AddComments.Visible = true;
            AddComments2.Visible = false;
            thesserno.Visible = false;
            enterthesserno.Visible = false;
            cmntslabel.Visible = false;
            cmtstext.Visible = false;
            AddGrade.Visible = true;
            AddGrade2.Visible = false;
            GradeLabel.Visible = false;
            GradeText.Visible = false;
            SelectThesis.Visible = true;
            SelectThesis2.Visible = false;
            Thesissearch.Visible = false;
            ThesisText.Visible = false;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewExamDefenseInfoPROC = new SqlCommand("viewExamDefenseInfo", conn);
            viewExamDefenseInfoPROC.CommandType = CommandType.StoredProcedure;

            viewExamDefenseInfoPROC.Parameters.Add(new SqlParameter("@id", Session["user"]));

            conn.Open();

            SqlDataReader rdr = viewExamDefenseInfoPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String thesistitle = rdr.GetString(rdr.GetOrdinal("title"));
                String supname = "";
                try
                {
                    supname = rdr.GetString(rdr.GetOrdinal("name"));
                }
                catch (Exception e1)
                {
                }

                String stdFirstName = "";
                try
                {
                    stdFirstName = rdr.GetString(rdr.GetOrdinal("firstname"));
                }
                catch (Exception e1)
                {
                }
                String stdLastName = "";
                try
                {
                    stdLastName = rdr.GetString(rdr.GetOrdinal("lastname"));
                }
                catch (Exception e1)
                {
                }
                HtmlTableRow tRow = new HtmlTableRow();
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = thesistitle;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = supname;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = stdFirstName;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = stdLastName;
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);
                Table1.Rows.Add(tRow);
            }
            conn.Close();
        }


        protected void addCmntsBtn(object sender, EventArgs e)
        {
            ExaminerProfileTable.Visible = true;
            Table1.Visible = false;
            Table2.Visible = false;
            EditProfile.Visible = true;
            upname.Visible = false;
            upfield.Visible = false;
            newname.Visible = false;
            newfield.Visible = false;
            UpdateProfile.Visible = false;
            ViewDefenseInfo.Visible = true;
            AddComments.Visible = false;
            AddComments2.Visible = true;
            thesserno.Visible = true;
            enterthesserno.Visible = true;
            cmntslabel.Visible = true;
            cmtstext.Visible = true;
            AddGrade.Visible = true;
            AddGrade2.Visible = false;
            GradeLabel.Visible = false;
            GradeText.Visible = false;
            SelectThesis.Visible = true;
            SelectThesis2.Visible = false;
            Thesissearch.Visible = false;
            ThesisText.Visible = false;
        }
        protected void addCmntsBtn2(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkForExamibilityPROC = new SqlCommand("checkForExamibility", conn);
            checkForExamibilityPROC.CommandType = CommandType.StoredProcedure;

            checkForExamibilityPROC.Parameters.Add(new SqlParameter("@id", Session["user"]));
            string thesis = enterthesserno.Text;
            int thesisno = 0;
            if (thesis != "")
            {
                thesisno = Int32.Parse(thesis);
            }

            string comments = "";
            try
            {
                comments = cmtstext.Text;
            }
            catch (Exception e1)
            {
            }
            checkForExamibilityPROC.Parameters.Add(new SqlParameter("@thesis", thesisno));

            SqlParameter success = checkForExamibilityPROC.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter date = checkForExamibilityPROC.Parameters.Add("@date", SqlDbType.DateTime);


            success.Direction = ParameterDirection.Output;
            date.Direction = ParameterDirection.Output;
            conn.Open();
            checkForExamibilityPROC.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "1" && comments.Replace(" ", "") != "")
            {
                DateTime date2 = Convert.ToDateTime(date.Value);
                SqlConnection conn1 = new SqlConnection(connStr);

                SqlCommand AddCommentsGradePROC = new SqlCommand("AddCommentsGrade", conn1);
                AddCommentsGradePROC.CommandType = CommandType.StoredProcedure;


                AddCommentsGradePROC.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisno));
                AddCommentsGradePROC.Parameters.Add(new SqlParameter("@DefenseDate", date2));
                AddCommentsGradePROC.Parameters.Add(new SqlParameter("@comments", comments));
                conn1.Open();
                AddCommentsGradePROC.ExecuteNonQuery();
                conn1.Close();
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> Comment Added Successfully!!</div>");

            }
            else
            {
                if (!(thesisno > 0))
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> Enter a valid Thesis no.!! Thesis No. start from 1!!</div>");
                }
                else if (comments == "" || comments.Replace(" ", "") == "")
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> Enter a valid comment!!</div>");
                }
                else
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> You Do Not Have Access To This Thesis Serial No.!!</div>");
                }
            }

        }

        protected void addGrdBtn(object sender, EventArgs e)
        {
            ExaminerProfileTable.Visible = true;
            Table1.Visible = false;
            Table2.Visible = false;
            EditProfile.Visible = true;
            upname.Visible = false;
            upfield.Visible = false;
            newname.Visible = false;
            newfield.Visible = false;
            UpdateProfile.Visible = false;
            ViewDefenseInfo.Visible = true;
            AddComments.Visible = true;
            AddComments2.Visible = false;
            thesserno.Visible = true;
            enterthesserno.Visible = true;
            cmntslabel.Visible = false;
            cmtstext.Visible = false;
            AddGrade.Visible = false;
            AddGrade2.Visible = true;
            GradeLabel.Visible = true;
            GradeText.Visible = true;
            SelectThesis.Visible = true;
            SelectThesis2.Visible = false;
            Thesissearch.Visible = false;
            ThesisText.Visible = false;
        }

        protected void addGrdBtn2(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkForExamibilityPROC = new SqlCommand("checkForExamibility", conn);
            checkForExamibilityPROC.CommandType = CommandType.StoredProcedure;

            checkForExamibilityPROC.Parameters.Add(new SqlParameter("@id", Session["user"]));
            string thesis = enterthesserno.Text;
            int thesisno = 0;
            if (thesis != "")
            {
                thesisno = Int32.Parse(thesis);
            }

            double Grade = -1;
            try
            {
                Grade = double.Parse(GradeText.Text);
            }
            catch (Exception e1)
            {
            }
            checkForExamibilityPROC.Parameters.Add(new SqlParameter("@thesis", thesisno));

            SqlParameter success = checkForExamibilityPROC.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter date = checkForExamibilityPROC.Parameters.Add("@date", SqlDbType.DateTime);


            success.Direction = ParameterDirection.Output;
            date.Direction = ParameterDirection.Output;
            conn.Open();
            checkForExamibilityPROC.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "1" && Grade >= 0 && Grade < 100)
            {
                DateTime date2 = Convert.ToDateTime(date.Value);
                SqlConnection conn1 = new SqlConnection(connStr);

                SqlCommand AddDefenseGradePROC = new SqlCommand("AddDefenseGrade", conn1);
                AddDefenseGradePROC.CommandType = CommandType.StoredProcedure;


                AddDefenseGradePROC.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisno));
                AddDefenseGradePROC.Parameters.Add(new SqlParameter("@DefenseDate", date2));
                AddDefenseGradePROC.Parameters.Add(new SqlParameter("@grade", Grade));
                conn1.Open();
                AddDefenseGradePROC.ExecuteNonQuery();
                conn1.Close();
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> Grade Added Successfully!!</div>");

            }
            else
            {
                if (!(thesisno > 0))
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> Enter a valid Thesis no.!! Thesis No. start from 1!!</div>");
                }
                else if (!(Grade >= 0 && Grade < 100))
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> Enter a valid Grade!!All grades should be less than 100 and atleast 0</div>");
                }
                else
                {
                    int x = 705;
                    int y = 400;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> You Do Not Have Access To This Thesis Serial No.!!</div>");
                }
            }

        }

        protected void slctThsBtn(object sender, EventArgs e)
        {
            ExaminerProfileTable.Visible = false;
            Table1.Visible = false;

            EditProfile.Visible = true;
            upname.Visible = false;
            upfield.Visible = false;
            newname.Visible = false;
            newfield.Visible = false;
            UpdateProfile.Visible = false;
            ViewDefenseInfo.Visible = true;
            AddComments.Visible = true;
            AddComments2.Visible = false;
            thesserno.Visible = false;
            enterthesserno.Visible = false;
            cmntslabel.Visible = false;
            cmtstext.Visible = false;
            AddGrade.Visible = true;
            AddGrade2.Visible = false;
            GradeLabel.Visible = false;
            GradeText.Visible = false;
            SelectThesis.Visible = false;
            SelectThesis2.Visible = true;
            Thesissearch.Visible = true;
            ThesisText.Visible = true;
        }
        protected void slctThsBtn2(object sender, EventArgs e)
        {
            Table2.Visible = true;
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand searchThesisPROC = new SqlCommand("SearchThesis", conn);
            searchThesisPROC.CommandType = CommandType.StoredProcedure;

            string thesistext = ThesisText.Text;


            conn.Open();

            SqlDataReader rdr = searchThesisPROC.ExecuteReader(CommandBehavior.CloseConnection);
            bool f = false;
            while (rdr.Read())
            {
                Int32 thesisserial = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                String thesisfield = "";
                try
                {
                    thesisfield = rdr.GetString(rdr.GetOrdinal("field"));
                }
                catch (Exception e1)
                {
                }

                String thesistype = rdr.GetString(rdr.GetOrdinal("type"));
                String thesistitle = rdr.GetString(rdr.GetOrdinal("title"));
                DateTime thesisstart = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                DateTime thesisend = rdr.GetDateTime(rdr.GetOrdinal("endDate"));

                String thesisdef = "";
                try
                {
                    thesisdef = (rdr.GetDateTime(rdr.GetOrdinal("defenseDate"))).ToString();
                }
                catch (Exception e1)
                {
                }

                Int32 thesisyears = rdr.GetInt32(rdr.GetOrdinal("years"));
                String thesisgrade = "";
                try
                {
                    thesisgrade = (rdr.GetDecimal(rdr.GetOrdinal("grade"))).ToString();
                }
                catch (Exception e1)
                {
                }

                String thesispay = "";
                try
                {
                    thesispay = (rdr.GetInt32(rdr.GetOrdinal("payment_id"))).ToString();
                }
                catch (Exception e1)
                {
                }

                String thesisExt = "";
                try
                {
                    thesisExt = (rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"))).ToString();
                }
                catch (Exception e1)
                {
                }

                if (thesistext.Replace(" ", "") != "" && CheckThesis(thesistitle.ToLower(), thesistext.ToLower()) == true)
                {
                    HtmlTableRow tRow = new HtmlTableRow();
                    HtmlTableCell tb1 = new HtmlTableCell();
                    tb1.InnerText = thesisserial.ToString();
                    HtmlTableCell tb2 = new HtmlTableCell();
                    tb2.InnerText = thesisfield;
                    HtmlTableCell tb3 = new HtmlTableCell();
                    tb3.InnerText = thesistype;
                    HtmlTableCell tb4 = new HtmlTableCell();
                    tb4.InnerText = thesistitle;
                    HtmlTableCell tb5 = new HtmlTableCell();
                    tb5.InnerText = "" + thesisstart;
                    HtmlTableCell tb6 = new HtmlTableCell();
                    tb6.InnerText = "" + thesisend;
                    HtmlTableCell tb7 = new HtmlTableCell();

                    tb7.InnerText = thesisdef;
                    HtmlTableCell tb8 = new HtmlTableCell();
                    tb8.InnerText = "" + thesisyears;
                    HtmlTableCell tb9 = new HtmlTableCell();
                    tb9.InnerText = thesisgrade;
                    HtmlTableCell tb10 = new HtmlTableCell();
                    tb10.InnerText = thesispay;
                    HtmlTableCell tb11 = new HtmlTableCell();
                    tb11.InnerText = thesisExt;

                    tRow.Controls.Add(tb1);
                    tRow.Controls.Add(tb2);
                    tRow.Controls.Add(tb3);
                    tRow.Controls.Add(tb4);
                    tRow.Controls.Add(tb5);
                    tRow.Controls.Add(tb6);
                    tRow.Controls.Add(tb7);
                    tRow.Controls.Add(tb8);
                    tRow.Controls.Add(tb9);
                    tRow.Controls.Add(tb10);
                    tRow.Controls.Add(tb11);

                    Table2.Rows.Add(tRow);
                    f = true;
                }

            }
            if (f == false)
            {
                int x = 705;
                int y = 400;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'> There is no Thesis Title containing that Keyword(s)!! Please enter a valid Keyword(s) and Remove Unnecessary Spaces!!</div>");
            }
            conn.Close();






        }
        protected void logOutBtn(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userType"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}