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
    public partial class Supervisor : System.Web.UI.Page
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
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            else if((string)Session["userType"] != "supervisor")
            {
                if(((string)Session["userType"] == "gucianstudent" || (string)Session["userType"] == "nongucianstudent"))
                {
                    Response.Redirect("Student.aspx");
                }
                else if((string)Session["userType"] == "examiner")
                {
                    Response.Redirect("Examiner.aspx");
                }
                else
                {
                    Response.Redirect("Admin.aspx");
                }
            }

            SupervisorProfileTable.Visible = false;

            StudentThesisYearsTable.Visible = false;

            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;

            AddNumberButton.Enabled = false;

            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;

            CancelThesisSerialNumberLabel.Visible = false;
            CancelThesisSerialNumberInput.Visible = false;
            CancelThesisBtn.Visible = false;

        }
        protected void onViewProfileClicked(object sender, EventArgs e)
        {
            StudentThesisYearsTable.Visible = false;

            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;

            SerialNumLabel.Visible = false;
            SerialNumInput.Visible = false;
            DefenceDateInput.Visible = false;
            DefenceLocationLabel.Visible = false;
            DefenceLocationInput.Visible = false;
            AddDefenceButtonAction.Visible = false;

            ExaminerSerialNumLabel.Visible = false;
            ExaminerSerialNumInput.Visible = false;
            ExaminerIdLabel.Visible = false;
            ExaminerIdInput.Visible = false;
            AddExaminer.Visible = false;

            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;



            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewProfilePROC = new SqlCommand("SupViewProfile", conn);
            viewProfilePROC.CommandType = CommandType.StoredProcedure;
            viewProfilePROC.Parameters.Add(new SqlParameter("@supervisorID", Session["user"]));

            conn.Open();

            SqlDataReader rdr = viewProfilePROC.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                Int32 supervisorId = 0;
                string email = "";
                string password = "";
                String name = "";
                string faculty = "";

                try
                {
                    supervisorId = rdr.GetInt32(rdr.GetOrdinal("id"));
                }
                catch (Exception e1) { }
                try
                {
                    email = rdr.GetString(rdr.GetOrdinal("email"));
                }
                catch (Exception e1) { }
                try
                {
                    password = rdr.GetString(rdr.GetOrdinal("password"));
                }
                catch (Exception e1) { }
                try
                {
                    name = rdr.GetString(rdr.GetOrdinal("name"));
                }
                catch (Exception e1) { }
                try
                {
                    faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                }
                catch (Exception e1) { }

                HtmlTableRow tableRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + supervisorId;
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = email;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = password;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = name;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = faculty;

                tableRow.Controls.Add(tb);
                tableRow.Controls.Add(tb1);
                tableRow.Controls.Add(tb2);
                tableRow.Controls.Add(tb3);
                tableRow.Controls.Add(tb4);

                SupervisorProfileTable.Rows.Add(tableRow);
            }
            conn.Close();
            SupervisorProfileTable.Visible = true;

        }
        protected void onViewStudentsClicked(object sender, EventArgs e)
        {
            SupervisorProfileTable.Visible = false;

            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;

            SerialNumLabel.Visible = false;
            SerialNumInput.Visible = false;
            DefenceDateInput.Visible = false;
            DefenceLocationLabel.Visible = false;
            DefenceLocationInput.Visible = false;
            AddDefenceButtonAction.Visible = false;

            ExaminerSerialNumLabel.Visible = false;
            ExaminerSerialNumInput.Visible = false;
            ExaminerIdLabel.Visible = false;
            ExaminerIdInput.Visible = false;
            AddExaminer.Visible = false;

            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;



            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewStudentYearsPROC = new SqlCommand("ViewSupStudentsYears", conn);
            viewStudentYearsPROC.CommandType = CommandType.StoredProcedure;
            viewStudentYearsPROC.Parameters.Add(new SqlParameter("@supervisorID", Session["user"]));

            conn.Open();

            SqlDataReader rdr = viewStudentYearsPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string firstName = "";
                string lastName = "";
                Int32 years = 0;

                try
                {
                    firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                }
                catch (Exception e1) { }
                try
                {
                    lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                }
                catch (Exception e1) { }
                try
                {
                    years = rdr.GetInt32(rdr.GetOrdinal("years"));
                }
                catch (Exception e1) { }

                HtmlTableRow tableRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = firstName;
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = lastName;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = "" + years;

                tableRow.Controls.Add(tb);
                tableRow.Controls.Add(tb1);
                tableRow.Controls.Add(tb2);

                StudentThesisYearsTable.Rows.Add(tableRow);

            }
            conn.Close();
            StudentThesisYearsTable.Visible = true;

        }
        protected void onViewPublicationClicked(object sender, EventArgs e)
        {
            SupervisorProfileTable.Visible = false;
            StudentThesisYearsTable.Visible = false;


            studentPublicationsTable.Visible = true;
            StudentIdInputForPublication.Visible = true;
            GetStudentPublications.Visible = true;
            StudentIdLabel.Visible = true;

            SerialNumLabel.Visible = false;
            SerialNumInput.Visible = false;
            DefenceDateInput.Visible = false;
            DefenceLocationLabel.Visible = false;
            DefenceLocationInput.Visible = false;
            AddDefenceButtonAction.Visible = false;

            ExaminerSerialNumLabel.Visible = false;
            ExaminerSerialNumInput.Visible = false;
            ExaminerIdLabel.Visible = false;
            ExaminerIdInput.Visible = false;
            AddExaminer.Visible = false;

            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;

        }

        protected void onGetPublicationClicked(object sender, EventArgs e)
        {
            string studentIdString = StudentIdInputForPublication.Text;
            StudentIdInputForPublication.Text = "";

            if (!IsAllDigits(studentIdString))
            {
                int x = 680;
                int y = 650;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Student ID has to be all digit numbers!</div>");
                studentPublicationsTable.Visible = true;
                StudentIdInputForPublication.Visible = true;
                GetStudentPublications.Visible = true;
                StudentIdLabel.Visible = true;

            }
            else if (studentIdString.Replace(" ", "") == "")
            {
                int x = 680;
                int y = 650;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill the required field!</div>");
                studentPublicationsTable.Visible = true;
                StudentIdInputForPublication.Visible = true;
                GetStudentPublications.Visible = true;
                StudentIdLabel.Visible = true;
            }
            else
            {
                int studentId = Int32.Parse(studentIdString);
                string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand studentExists = new SqlCommand("IsAStudent", conn);
                studentExists.CommandType = CommandType.StoredProcedure;

                studentExists.Parameters.Add(new SqlParameter("@id", studentId));
                SqlParameter success = studentExists.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;

                conn.Open();
                studentExists.ExecuteNonQuery();
                conn.Close();

                if (success.Value.ToString() == "0")
                {
                    int x = 680;
                    int y = 650;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>There are no students with this ID,Enter a valid Student ID!</div>");
                    studentPublicationsTable.Visible = true;
                    StudentIdInputForPublication.Visible = true;
                    GetStudentPublications.Visible = true;
                    StudentIdLabel.Visible = true;
                }
                else
                {
                    SqlCommand viewStudentPublicationPROC = new SqlCommand("ViewAStudentPublications", conn);
                    viewStudentPublicationPROC.CommandType = CommandType.StoredProcedure;
                    viewStudentPublicationPROC.Parameters.Add(new SqlParameter("@StudentID", studentId));

                    conn.Open();
                    SqlDataReader rdr = viewStudentPublicationPROC.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        int id = 0;
                        string title = "";
                        DateTime DateOfPublication = new DateTime();
                        string place = "";
                        bool isAccepted = false;
                        string host = "";

                        try
                        {
                            id = rdr.GetInt32(rdr.GetOrdinal("id"));
                        }
                        catch (Exception e1) { }
                        try
                        {
                            title = rdr.GetString(rdr.GetOrdinal("title"));
                        }
                        catch (Exception e1) { }
                        try
                        {
                            DateOfPublication = rdr.GetDateTime(rdr.GetOrdinal("dateOfPublication"));
                        }
                        catch (Exception e1) { }
                        try
                        {
                            place = rdr.GetString(rdr.GetOrdinal("place"));
                        }
                        catch (Exception e1) { }
                        try
                        {
                            isAccepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                        }
                        catch (Exception e1) { }
                        try
                        {
                            host = rdr.GetString(rdr.GetOrdinal("host"));
                        }
                        catch (Exception e1) { }

                        HtmlTableRow tableRow = new HtmlTableRow();

                        HtmlTableCell tb = new HtmlTableCell();
                        tb.InnerText = "" + id;
                        HtmlTableCell tb1 = new HtmlTableCell();
                        tb1.InnerText = title;
                        HtmlTableCell tb2 = new HtmlTableCell();
                        tb2.InnerText = DateOfPublication.ToString();
                        HtmlTableCell tb3 = new HtmlTableCell();
                        tb3.InnerText = place;
                        HtmlTableCell tb4 = new HtmlTableCell();
                        tb4.InnerText = "" + isAccepted;
                        HtmlTableCell tb5 = new HtmlTableCell();
                        tb5.InnerText = host;

                        tableRow.Controls.Add(tb);
                        tableRow.Controls.Add(tb1);
                        tableRow.Controls.Add(tb2);
                        tableRow.Controls.Add(tb3);
                        tableRow.Controls.Add(tb4);
                        tableRow.Controls.Add(tb5);

                        studentPublicationsTable.Rows.Add(tableRow);

                    }
                    conn.Close();

                    studentPublicationsTable.Visible = true;
                    StudentIdInputForPublication.Visible = true;
                    GetStudentPublications.Visible = true;
                    StudentIdLabel.Visible = true;
                }
            }
        }

        protected void onAddDefenceClicked(object sender, EventArgs e)
        {

            SupervisorProfileTable.Visible = false;

            StudentThesisYearsTable.Visible = false;

            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;

            SerialNumLabel.Visible = true;
            SerialNumInput.Visible = true;
            DefenceDateInput.Visible = true;
            DefenceLocationLabel.Visible = true;
            DefenceLocationInput.Visible = true;
            AddDefenceButtonAction.Visible = true;

            ExaminerSerialNumLabel.Visible = false;
            ExaminerSerialNumInput.Visible = false;
            ExaminerIdLabel.Visible = false;
            ExaminerIdInput.Visible = false;
            AddExaminer.Visible = false;

            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;


        }
        protected void onAddDefenceActionClicked(object sender, EventArgs e)
        {
            string serialNo = SerialNumInput.Text;
            DateTime defenceDate = DefenceDateInput.SelectedDate;
            string location = DefenceLocationInput.Text;

            if (!IsAllDigits(serialNo))
            {
                int x = 680;
                int y = 300;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Serial numbers must be all digits!</div>");
                SerialNumLabel.Visible = true;
                SerialNumInput.Visible = true;
                SerialNumInput.Text = "";
                DefenceDateInput.Visible = true;
                DefenceLocationLabel.Visible = true;
                DefenceLocationInput.Visible = true;
                AddDefenceButtonAction.Visible = true;
            }
            else if (serialNo.Replace(" ", "") == "" || location.Replace(" ", "") == "" || defenceDate == null)
            {
                int x = 680;
                int y = 300;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>All the inputs must be specified!</div>");
                SerialNumLabel.Visible = true;
                SerialNumInput.Visible = true;
                SerialNumInput.Text = "";
                DefenceDateInput.Visible = true;
                DefenceLocationLabel.Visible = true;
                DefenceLocationInput.Visible = true;
                AddDefenceButtonAction.Visible = true;
            }
            else if (DateTime.Compare(defenceDate, DateTime.Now) < 0)
            {
                int x = 680;
                int y = 300;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You must choose a date in the future!</div>");
                SerialNumLabel.Visible = true;
                SerialNumInput.Visible = true;
                DefenceDateInput.Visible = true;
                DefenceLocationLabel.Visible = true;
                DefenceLocationInput.Visible = true;
                AddDefenceButtonAction.Visible = true;

            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand doesMyThesisExistPROC = new SqlCommand("doesMyThesisExists", conn);
                doesMyThesisExistPROC.CommandType = CommandType.StoredProcedure;

                doesMyThesisExistPROC.Parameters.Add(new SqlParameter("@serialNum", serialNo));
                doesMyThesisExistPROC.Parameters.Add(new SqlParameter("@superId", Session["user"]));

                SqlParameter doesMyThesisExists = doesMyThesisExistPROC.Parameters.Add("@success", SqlDbType.Int);
                doesMyThesisExists.Direction = ParameterDirection.Output;

                conn.Open();
                doesMyThesisExistPROC.ExecuteNonQuery();
                conn.Close();

                if (doesMyThesisExists.Value.ToString() == "0")
                {
                    int x = 680;
                    int y = 300;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You can't add a defence to this serial number!</div>");
                    SerialNumLabel.Visible = true;
                    SerialNumInput.Visible = true;
                    SerialNumInput.Text = "";
                    DefenceDateInput.Visible = true;
                    DefenceLocationLabel.Visible = true;
                    DefenceLocationInput.Visible = true;
                    AddDefenceButtonAction.Visible = true;
                }
                else
                {
                    int thesisSerialNumber = Int32.Parse(serialNo);
                    SqlCommand doesThesisHasDefencePROC = new SqlCommand("DoesThesisHasDefense", conn);
                    doesThesisHasDefencePROC.CommandType = CommandType.StoredProcedure;
                    doesThesisHasDefencePROC.Parameters.Add(new SqlParameter("@serialNo", thesisSerialNumber));

                    SqlParameter thesisHasDefense = doesThesisHasDefencePROC.Parameters.Add("@success", SqlDbType.Int);
                    thesisHasDefense.Direction = ParameterDirection.Output;

                    conn.Open();
                    doesThesisHasDefencePROC.ExecuteNonQuery();
                    conn.Close();

                    if (thesisHasDefense.Value.ToString() == "1")
                    {
                        int x = 680;
                        int y = 300;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>This thesis already have a defense!!</div>");
                        SerialNumLabel.Visible = true;
                        SerialNumInput.Visible = true;
                        SerialNumInput.Text = "";
                        DefenceDateInput.Visible = true;
                        DefenceLocationLabel.Visible = true;
                        DefenceLocationInput.Visible = true;
                        AddDefenceButtonAction.Visible = true;
                    }
                    else
                    {
                        SqlCommand isGucianThesisPROC = new SqlCommand("thesisBelongToGucian", conn);
                        isGucianThesisPROC.CommandType = CommandType.StoredProcedure;

                        isGucianThesisPROC.Parameters.Add(new SqlParameter("@serialNum", thesisSerialNumber));

                        SqlParameter isGucianThesis = isGucianThesisPROC.Parameters.Add("@success", SqlDbType.Int);
                        isGucianThesis.Direction = ParameterDirection.Output;

                        conn.Open();
                        isGucianThesisPROC.ExecuteNonQuery();
                        conn.Close();

                        if (isGucianThesis.Value.ToString() == "1")
                        {
                            SqlCommand AddDefenceProc = new SqlCommand("AddDefenseGucian", conn);
                            AddDefenceProc.CommandType = CommandType.StoredProcedure;
                            AddDefenceProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNumber));
                            AddDefenceProc.Parameters.Add(new SqlParameter("@DefenseDate", defenceDate));
                            AddDefenceProc.Parameters.Add(new SqlParameter("@DefenseLocation", location));

                            conn.Open();
                            try
                            {
                                AddDefenceProc.ExecuteNonQuery();
                                int x = 680;
                                int y = 300;
                                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>the defence has been added successfully!</div>");

                            }
                            catch (Exception e1)
                            {
                                int x = 680;
                                int y = 300;
                                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>An Error has occured!</div>");
                            }
                            conn.Close();

                        }
                        else
                        {
                            SqlCommand AddDefenceProc = new SqlCommand("AddDefenseNonGucian", conn);
                            AddDefenceProc.CommandType = CommandType.StoredProcedure;
                            AddDefenceProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNumber));
                            AddDefenceProc.Parameters.Add(new SqlParameter("@DefenseDate", defenceDate));
                            AddDefenceProc.Parameters.Add(new SqlParameter("@DefenseLocation", location));

                            conn.Open();
                            try
                            {
                                AddDefenceProc.ExecuteNonQuery();
                                conn.Close();
                                int x = 680;
                                int y = 300;
                                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>the defence has been added successfully!</div>");

                            }
                            catch (Exception e1)
                            {
                                int x = 680;
                                int y = 300;
                                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>An Error has occured!</div>");

                            }
                            conn.Close();
                        }
                        SerialNumLabel.Visible = true;
                        SerialNumInput.Visible = true;
                        DefenceDateInput.Visible = true;
                        DefenceLocationLabel.Visible = true;
                        DefenceLocationInput.Visible = true;
                        AddDefenceButtonAction.Visible = true;
                    }
                }
            }
        }


        protected void onAddExaminersClicked(object sender, EventArgs e)
        {
            SupervisorProfileTable.Visible = false;
            StudentThesisYearsTable.Visible = false;


            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;


            SerialNumLabel.Visible = false;
            SerialNumInput.Visible = false;
            DefenceDateInput.Visible = false;
            DefenceLocationLabel.Visible = false;
            DefenceLocationInput.Visible = false;
            AddDefenceButtonAction.Visible = false;



            ExaminerSerialNumLabel.Visible = true;
            ExaminerSerialNumInput.Visible = true;
            ExaminerIdLabel.Visible = true;
            ExaminerIdInput.Visible = true;
            AddExaminer.Visible = true;

            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;

        }
        protected void onAddExaminerActionClicked(object sender, EventArgs e)
        {
            string serialNumberString = ExaminerSerialNumInput.Text;
            string examinerIdString = ExaminerIdInput.Text;
            if (serialNumberString.Replace(" ", "") == "" || examinerIdString.Replace(" ", "") == "")
            {
                int x = 680;
                int y = 600;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>All the fields must be specified!! </div>");
                ExaminerSerialNumLabel.Visible = true;
                ExaminerSerialNumInput.Visible = true;
                ExaminerIdLabel.Visible = true;
                ExaminerIdInput.Visible = true;
                AddExaminer.Visible = true;
            }
            else if (!IsAllDigits(serialNumberString))
            {
                int x = 680;
                int y = 600;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Thesis serail number must be all digits! </div>");
                ExaminerSerialNumLabel.Visible = true;
                ExaminerSerialNumInput.Visible = true;
                ExaminerSerialNumInput.Text = "";
                ExaminerIdLabel.Visible = true;
                ExaminerIdInput.Visible = true;
                AddExaminer.Visible = true;

            }
            else if (!IsAllDigits(examinerIdString))
            {
                int x = 680;
                int y = 600;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Examiner ID must be all digits! </div>");
                ExaminerSerialNumLabel.Visible = true;
                ExaminerSerialNumInput.Visible = true;
                ExaminerIdLabel.Visible = true;
                ExaminerIdInput.Visible = true;
                ExaminerIdInput.Text = "";
                AddExaminer.Visible = true;
            }
            else
            {
                int serialNumber = Int32.Parse(serialNumberString);
                int examinerId = Int32.Parse(examinerIdString);


                string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand doesMyThesisExistPROC = new SqlCommand("doesMyThesisExists", conn);
                doesMyThesisExistPROC.CommandType = CommandType.StoredProcedure;

                doesMyThesisExistPROC.Parameters.Add(new SqlParameter("@serialNum", serialNumber));
                doesMyThesisExistPROC.Parameters.Add(new SqlParameter("@superId", Session["user"]));

                SqlParameter doesMyThesisExists = doesMyThesisExistPROC.Parameters.Add("@success", SqlDbType.Int);
                doesMyThesisExists.Direction = ParameterDirection.Output;

                conn.Open();
                doesMyThesisExistPROC.ExecuteNonQuery();
                conn.Close();
                if (doesMyThesisExists.Value.ToString() == "0")
                {
                    int x = 680;
                    int y = 600;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You can't add an examiner to this Thesis!</div>");
                    ExaminerSerialNumLabel.Visible = true;
                    ExaminerSerialNumInput.Visible = true;
                    ExaminerIdLabel.Visible = true;
                    ExaminerIdInput.Visible = true;
                    AddExaminer.Visible = true;

                }
                else
                {
                    SqlCommand doesExaminerExistPROC = new SqlCommand("ExaminerExists", conn);
                    doesExaminerExistPROC.CommandType = CommandType.StoredProcedure;
                    doesExaminerExistPROC.Parameters.Add(new SqlParameter("@id", examinerId));
                    SqlParameter doesExaminerExist = doesExaminerExistPROC.Parameters.Add("@success", SqlDbType.Int);
                    doesExaminerExist.Direction = ParameterDirection.Output;

                    conn.Open();
                    doesExaminerExistPROC.ExecuteNonQuery();
                    conn.Close();

                    if (doesExaminerExist.Value.ToString() == "0")
                    {
                        int x = 680;
                        int y = 600;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>This Examiner Doesn't Exist!</div>");
                        ExaminerSerialNumLabel.Visible = true;
                        ExaminerSerialNumInput.Visible = true;
                        ExaminerIdLabel.Visible = true;
                        ExaminerIdInput.Visible = true;
                        AddExaminer.Visible = true;
                    }
                    else
                    {
                        SqlCommand doesThesisHaveDefensePROC = new SqlCommand("DoesThesisHasDefense", conn);
                        doesThesisHaveDefensePROC.CommandType = CommandType.StoredProcedure;

                        doesThesisHaveDefensePROC.Parameters.Add(new SqlParameter("@serialNo", serialNumber));
                        SqlParameter thesisHaveDefense = doesThesisHaveDefensePROC.Parameters.Add("@success", SqlDbType.Int);
                        thesisHaveDefense.Direction = ParameterDirection.Output;

                        conn.Open();
                        doesThesisHaveDefensePROC.ExecuteNonQuery();
                        conn.Close();

                        if (thesisHaveDefense.Value.ToString() == "0")
                        {
                            int x = 680;
                            int y = 600;
                            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>This thesis doesn't have a defense, Add a Defense first!</div>");
                            ExaminerSerialNumLabel.Visible = true;
                            ExaminerSerialNumInput.Visible = true;
                            ExaminerIdLabel.Visible = true;
                            ExaminerIdInput.Visible = true;
                            AddExaminer.Visible = true;
                        }
                        else
                        {
                            SqlCommand getDefenceDatePROC = new SqlCommand("GetDefenceDate", conn);
                            getDefenceDatePROC.CommandType = CommandType.StoredProcedure;

                            getDefenceDatePROC.Parameters.Add(new SqlParameter("@serialNo", serialNumber));

                            SqlParameter defenceDate = getDefenceDatePROC.Parameters.Add("@date", SqlDbType.DateTime);
                            defenceDate.Direction = ParameterDirection.Output;

                            conn.Open();
                            getDefenceDatePROC.ExecuteNonQuery();
                            conn.Close();

                            SqlCommand addExaminerPROC = new SqlCommand("AddExaminerForaDefense", conn);
                            addExaminerPROC.CommandType = CommandType.StoredProcedure;
                            addExaminerPROC.Parameters.Add(new SqlParameter("@defenseDate", defenceDate.Value));
                            addExaminerPROC.Parameters.Add(new SqlParameter("@thesisSerialNumber", serialNumber));
                            addExaminerPROC.Parameters.Add(new SqlParameter("@examinerId", examinerId));

                            conn.Open();
                            addExaminerPROC.ExecuteNonQuery();
                            int x = 680;
                            int y = 600;
                            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Examiner added successfully!</div>");
                            ExaminerSerialNumLabel.Visible = true;
                            ExaminerSerialNumInput.Visible = true;
                            ExaminerIdLabel.Visible = true;
                            ExaminerIdInput.Visible = true;
                            AddExaminer.Visible = true;
                            conn.Close();

                        }
                    }
                }
            }
        }


        protected void onEvaluateProgressReportClicked(object sender, EventArgs e)
        {
            SupervisorProfileTable.Visible = false;
            StudentThesisYearsTable.Visible = false;


            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;


            SerialNumLabel.Visible = false;
            SerialNumInput.Visible = false;
            DefenceDateInput.Visible = false;
            DefenceLocationLabel.Visible = false;
            DefenceLocationInput.Visible = false;
            AddDefenceButtonAction.Visible = false;



            ExaminerSerialNumLabel.Visible = false;
            ExaminerSerialNumInput.Visible = false;
            ExaminerIdLabel.Visible = false;
            ExaminerIdInput.Visible = false;
            AddExaminer.Visible = false;


            PRthesisSerialNoLabel.Visible = true;
            PRserialNoInput.Visible = true;
            PRnumberLabel.Visible = true;
            PRnumberInput.Visible = true;
            PRevaluationLabel.Visible = true;
            PRevaluationInput.Visible = true;
            addEvaluationButton.Visible = true;

        }
        protected void onAddEvaluationButtonClicked(object sender, EventArgs e)
        {
            string serialNoString = PRserialNoInput.Text;
            string PRnumberString = PRnumberInput.Text;
            string evaluationString = PRevaluationInput.SelectedValue;
            if (serialNoString.Replace(" ", "") == "" || PRnumberString.Replace(" ", "") == "")
            {
                int x = 680;
                int y = 700;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>All the fields must be specified!</div>");
                PRthesisSerialNoLabel.Visible = true;
                PRserialNoInput.Visible = true;
                PRnumberLabel.Visible = true;
                PRnumberInput.Visible = true;
                PRevaluationLabel.Visible = true;
                PRevaluationInput.Visible = true;
                addEvaluationButton.Visible = true;
            }
            else if (!IsAllDigits(serialNoString))
            {
                int x = 680;
                int y = 700;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Thesis serial number must be all digits!</div>");
                PRthesisSerialNoLabel.Visible = true;
                PRserialNoInput.Text = "";
                PRserialNoInput.Visible = true;
                PRnumberLabel.Visible = true;
                PRnumberInput.Visible = true;
                PRevaluationLabel.Visible = true;
                PRevaluationInput.Visible = true;
                addEvaluationButton.Visible = true;
            }
            else if (!IsAllDigits(PRnumberString))
            {
                int x = 680;
                int y = 700;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Progress report number must be all digits!</div>");
                PRthesisSerialNoLabel.Visible = true;
                PRserialNoInput.Visible = true;
                PRnumberLabel.Visible = true;
                PRnumberInput.Visible = true;
                PRnumberInput.Text = "";
                PRevaluationLabel.Visible = true;
                PRevaluationInput.Visible = true;
                addEvaluationButton.Visible = true;
            }
            else
            {
                int serialNumber = Int32.Parse(serialNoString);
                int PRnumber = Int32.Parse(PRnumberString);
                int PRevaluation = Int32.Parse(evaluationString);

                string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand supervisorCanEvaluatePROC = new SqlCommand("SupervisorHasProgressReport", conn);
                supervisorCanEvaluatePROC.CommandType = CommandType.StoredProcedure;

                supervisorCanEvaluatePROC.Parameters.Add(new SqlParameter("@thesisSerialNumber", serialNumber));
                supervisorCanEvaluatePROC.Parameters.Add(new SqlParameter("@progressReportNumber", PRnumber));
                supervisorCanEvaluatePROC.Parameters.Add(new SqlParameter("@supervisorId", Session["user"]));

                SqlParameter supervisorCanEvaluate = supervisorCanEvaluatePROC.Parameters.Add("@success", SqlDbType.Int);
                supervisorCanEvaluate.Direction = ParameterDirection.Output;

                conn.Open();
                supervisorCanEvaluatePROC.ExecuteNonQuery();
                conn.Close();

                if (supervisorCanEvaluate.Value.ToString() == "0")
                {
                    int x = 680;
                    int y = 700;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You can not evaluate this progress report, enter a valid progress report number!</div>");
                    PRthesisSerialNoLabel.Visible = true;
                    PRserialNoInput.Visible = true;
                    PRnumberLabel.Visible = true;
                    PRnumberInput.Visible = true;
                    PRevaluationLabel.Visible = true;
                    PRevaluationInput.Visible = true;
                    addEvaluationButton.Visible = true;
                }
                else
                {
                    SqlCommand evaluateProgressReportPROC = new SqlCommand("EvaluateProgressReport", conn);
                    evaluateProgressReportPROC.CommandType = CommandType.StoredProcedure;

                    evaluateProgressReportPROC.Parameters.Add(new SqlParameter("@supervisorID", Session["user"]));
                    evaluateProgressReportPROC.Parameters.Add(new SqlParameter("@thesisSerialNo", serialNumber));
                    evaluateProgressReportPROC.Parameters.Add(new SqlParameter("@progressReportNo", PRnumber));
                    evaluateProgressReportPROC.Parameters.Add(new SqlParameter("@evaluation", PRevaluation));

                    conn.Open();
                    evaluateProgressReportPROC.ExecuteNonQuery();
                    conn.Close();
                    int x = 680;
                    int y = 700;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>The progress report is evaluated successfully!</div>");
                    PRthesisSerialNoLabel.Visible = true;
                    PRserialNoInput.Visible = true;
                    PRnumberLabel.Visible = true;
                    PRnumberInput.Visible = true;
                    PRevaluationLabel.Visible = true;
                    PRevaluationInput.Visible = true;
                    addEvaluationButton.Visible = true;
                }
            }

        }
        protected void onCancelThesisClicked(object sender, EventArgs e)
        {
            SupervisorProfileTable.Visible = false;
            StudentThesisYearsTable.Visible = false;


            studentPublicationsTable.Visible = false;
            StudentIdInputForPublication.Visible = false;
            GetStudentPublications.Visible = false;
            StudentIdLabel.Visible = false;


            SerialNumLabel.Visible = false;
            SerialNumInput.Visible = false;
            DefenceDateInput.Visible = false;
            DefenceLocationLabel.Visible = false;
            DefenceLocationInput.Visible = false;
            AddDefenceButtonAction.Visible = false;



            ExaminerSerialNumLabel.Visible = false;
            ExaminerSerialNumInput.Visible = false;
            ExaminerIdLabel.Visible = false;
            ExaminerIdInput.Visible = false;
            AddExaminer.Visible = false;


            PRthesisSerialNoLabel.Visible = false;
            PRserialNoInput.Visible = false;
            PRnumberLabel.Visible = false;
            PRnumberInput.Visible = false;
            PRevaluationLabel.Visible = false;
            PRevaluationInput.Visible = false;
            addEvaluationButton.Visible = false;


            CancelThesisSerialNumberLabel.Visible = true;
            CancelThesisSerialNumberInput.Visible = true;
            CancelThesisBtn.Visible = true;
        }
        protected void onCancelThesisBtnClicked(object sender, EventArgs e)
        {
            string serialNumberString = CancelThesisSerialNumberInput.Text;

            if (serialNumberString.Replace(" ", "") == "")
            {
                int x = 680;
                int y = 700;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You must enter a thesis serial number!</div>");
                CancelThesisSerialNumberLabel.Visible = true;
                CancelThesisSerialNumberInput.Visible = true;
                CancelThesisBtn.Visible = true;
            }
            else if (!IsAllDigits(serialNumberString))
            {
                int x = 680;
                int y = 700;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Serial numbers must be all digits!</div>");
                CancelThesisSerialNumberLabel.Visible = true;
                CancelThesisSerialNumberInput.Visible = true;
                CancelThesisSerialNumberInput.Text = "";
                CancelThesisBtn.Visible = true;
            }
            else
            {
                int serialNumber = Int32.Parse(serialNumberString);

                string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand canCancelPROC = new SqlCommand("doesMyThesisExists", conn);
                canCancelPROC.CommandType = CommandType.StoredProcedure;

                canCancelPROC.Parameters.Add(new SqlParameter("@serialNum", serialNumber));
                canCancelPROC.Parameters.Add(new SqlParameter("@superId", Session["user"]));

                SqlParameter canCancel = canCancelPROC.Parameters.Add("@success", SqlDbType.Int);
                canCancel.Direction = ParameterDirection.Output;

                conn.Open();
                canCancelPROC.ExecuteNonQuery();
                conn.Close();

                if (canCancel.Value.ToString() == "0")
                {
                    int x = 680;
                    int y = 700;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>You can not cancel a thesis with that serial number!</div>");
                    CancelThesisSerialNumberLabel.Visible = true;
                    CancelThesisSerialNumberInput.Visible = true;
                    CancelThesisSerialNumberInput.Text = "";
                    CancelThesisBtn.Visible = true;

                }
                else
                {
                    SqlCommand cancelThesisPROC = new SqlCommand("CancelThesis", conn);
                    cancelThesisPROC.CommandType = CommandType.StoredProcedure;

                    cancelThesisPROC.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNumber));

                    conn.Open();
                    cancelThesisPROC.ExecuteNonQuery();
                    conn.Close();

                    int x = 680;
                    int y = 700;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Operation done successfully!</div>");
                    CancelThesisSerialNumberLabel.Visible = true;
                    CancelThesisSerialNumberInput.Visible = true;
                    CancelThesisBtn.Visible = true;

                }
            }
        }


        protected void onAddPhoneNumberClicked(object sender, EventArgs e)
        {

        }

        protected void onLogoutClicked(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userType"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}