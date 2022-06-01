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
    public partial class Student : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
               Response.Redirect("Login.aspx");
            else if (((string)Session["userType"] != "gucianstudent" && (string)Session["userType"] != "nongucianstudent"))
            {
                if((string)Session["userType"] == "supervisor")
                {
                    Response.Redirect("Supervisor.aspx");
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

            if ((string)Session["userType"] == "gucianstudent")
            {
                ViewCoursesNon.Enabled = false;
            }
            gucianProfileTable.Visible = false;
            stdListThesis.Visible = false;
            coursesTable.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            thesNumFillPrg.Visible = false;
            prgNumFillPrg.Visible = false;
            state.Visible = false;
            descTextArea.Visible = false;
            TablePrgReports.Visible = false;
            FillPR.Visible = false;
            TablePhoneNumbers.Visible = false;
            AddNum.Visible = false;
            phoneNum.Visible = false;
            TableOnGoingTh.Visible = false;
            TablePubs.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            thesisNumLinkPub.Visible = false;
            PubIDLinkPub.Visible = false;
            LinkPubThesis.Visible = false;

        }

        protected void viewPrfBtn(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewMyProfilePROC = new SqlCommand("viewMyProfile", conn);
            viewMyProfilePROC.CommandType = CommandType.StoredProcedure;

            viewMyProfilePROC.Parameters.Add(new SqlParameter("@studentId", Session["user"]));


            conn.Open();

            SqlDataReader rdr = viewMyProfilePROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 stdID = rdr.GetInt32(rdr.GetOrdinal("id"));
                String stdFirstName = "";
                try
                {
                    stdFirstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                }
                catch (Exception e1)
                {

                }
                String stdLastName = "";
                try
                {
                    stdLastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                }
                catch (Exception e1)
                {

                }
                String stdType = "";
                try
                {
                    stdType = rdr.GetString(rdr.GetOrdinal("type"));
                }
                catch (Exception e1)
                {
                }
                String stdFaculty = "";
                try
                {
                    stdFaculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                }
                catch (Exception e1)
                {

                }
                String stdAddress = "";
                try
                {
                    stdAddress = rdr.GetString(rdr.GetOrdinal("address"));
                }
                catch (Exception e1)
                {

                }
                Decimal stdGPA = 0;
                HtmlTableCell tb6 = new HtmlTableCell();
                try
                {
                    stdGPA = rdr.GetDecimal(rdr.GetOrdinal("GPA"));
                    tb6.InnerText = "" + stdGPA;
                }
                catch (Exception e1)
                {
                    tb6.InnerText = "";
                }
                HtmlTableCell tb7 = new HtmlTableCell();
                if ((string)Session["userType"] == "gucianstudent")
                {
                    Int32 stdUnderID = 0;
                    
                    try
                    {
                        stdUnderID = rdr.GetInt32(rdr.GetOrdinal("undergradID"));
                        tb7.InnerText = "" + stdUnderID;
                    }
                    catch (Exception e1)
                    {
                        tb7.InnerText = "";
                    }
                }
                else
                {
                    tb7.InnerText = "------------------------";
                }
                

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + stdID;
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = stdFirstName;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = stdLastName;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = stdType;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = stdFaculty;
                HtmlTableCell tb5 = new HtmlTableCell();
                tb5.InnerText = stdAddress;



                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);
                tRow.Controls.Add(tb5);
                tRow.Controls.Add(tb6);

                tRow.Controls.Add(tb7);

                gucianProfileTable.Rows.Add(tRow);
            }

            conn.Close();


            gucianProfileTable.Visible = true;
        }


        protected void listThesBtn(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listMyThesisPROC = new SqlCommand("listMyThesis", conn);
            listMyThesisPROC.CommandType = CommandType.StoredProcedure;

            listMyThesisPROC.Parameters.Add(new SqlParameter("@studentId", Session["user"]));

            conn.Open();

            SqlDataReader rdr = listMyThesisPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 ThesisSer = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));

                String field = "";
                try
                {
                    field = rdr.GetString(rdr.GetOrdinal("field"));
                }
                catch (Exception e1)
                {

                }

                String type = rdr.GetString(rdr.GetOrdinal("type"));
                String title = rdr.GetString(rdr.GetOrdinal("title"));
                DateTime startDate = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("endDate"));

                DateTime defenseDate = new DateTime();
                HtmlTableCell tb5 = new HtmlTableCell();

                try
                {
                    defenseDate = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                    tb5.InnerText = "" + defenseDate;
                }
                catch (Exception e1)
                {
                    tb5.InnerText = "";
                }

                Int32 years = 0;
                HtmlTableCell tb6 = new HtmlTableCell();

                try
                {
                    years = rdr.GetInt32(rdr.GetOrdinal("years"));
                    tb6.InnerText = "" + years;
                }
                catch (Exception e1)
                {
                    tb6.InnerText = "";
                }

                Decimal grade = 0;
                HtmlTableCell tb7 = new HtmlTableCell();

                try
                {
                    grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    tb7.InnerText = "" + grade;
                }
                catch (Exception e1)
                {
                    tb7.InnerText = "";
                }

                Int32 paymentID = 0;
                HtmlTableCell tb8 = new HtmlTableCell();

                try
                {
                    paymentID = rdr.GetInt32(rdr.GetOrdinal("payment_id"));
                    tb8.InnerText = "" + paymentID;
                }
                catch (Exception e1)
                {
                    tb8.InnerText = "";
                }

                Int32 numOfExt = 0;
                HtmlTableCell tb9 = new HtmlTableCell();

                try
                {
                    numOfExt = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                    tb9.InnerText = "" + numOfExt;
                }
                catch (Exception e1)
                {
                    tb9.InnerText = "";
                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + ThesisSer;
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = field;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = type;
                HtmlTableCell tb10 = new HtmlTableCell();
                tb10.InnerText = title;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = "" + startDate;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = "" + endDate;


                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb10);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);
                tRow.Controls.Add(tb5);
                tRow.Controls.Add(tb6);
                tRow.Controls.Add(tb7);
                tRow.Controls.Add(tb8);
                tRow.Controls.Add(tb9);

                stdListThesis.Rows.Add(tRow);
            }

            conn.Close();
            stdListThesis.Visible = true;
        }


        protected void ViewCrsBtn(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand ListCoursesAndGradePROC = new SqlCommand("ListCoursesAndGrade", conn);
            ListCoursesAndGradePROC.CommandType = CommandType.StoredProcedure;

            ListCoursesAndGradePROC.Parameters.Add(new SqlParameter("@studentId", Session["user"]));

            conn.Open();

            SqlDataReader rdr = ListCoursesAndGradePROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 cid = rdr.GetInt32(rdr.GetOrdinal("id"));

                Int32 fees = 0;
                HtmlTableCell tb1 = new HtmlTableCell();

                try
                {
                    fees = rdr.GetInt32(rdr.GetOrdinal("fees"));
                    tb1.InnerText = "" + fees;
                }
                catch (Exception e1)
                {
                    tb1.InnerText = "";
                }

                Int32 crdtHrs = 0;
                HtmlTableCell tb2 = new HtmlTableCell();

                try
                {
                    crdtHrs = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    tb2.InnerText = "" + crdtHrs;
                }
                catch (Exception e1)
                {
                    tb2.InnerText = "";
                }

                String code = "";
                try
                {
                    code = rdr.GetString(rdr.GetOrdinal("code"));
                }
                catch (Exception e1)
                {

                }

                decimal grade = 0;
                HtmlTableCell tb4 = new HtmlTableCell();

                try
                {
                    grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    tb4.InnerText = "" + grade;
                }
                catch (Exception e1)
                {
                    tb4.InnerText = "";
                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + cid;


                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = code;


                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);

                coursesTable.Rows.Add(tRow);
            }

            conn.Close();
            coursesTable.Visible = true;

        }

        protected void addPrg(object sender, EventArgs e)
        {

            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            thesisNum.Visible = true;
            progDate.Visible = true;
            progNumber.Visible = true;
            AddRep.Visible = true;
            thesisNum.Enabled = true;
            progDate.Enabled = true;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

        }
        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        protected void addProgress(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            string thesisNumber = thesisNum.Text;
            DateTime progCalender = progDate.SelectedDate;
            string prgNum = progNumber.Text;

            if (thesisNumber.Replace(" ", "") == "" || prgNum.Replace(" ", "") == "")
            {
                int x = 800;
                int y = 760;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill all the fields!</div>");
            }
            else
            {
                if (!IsAllDigits(thesisNumber))
                {
                    int x = 820;
                    int y = 760;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Thesis number has to be all digit numbers!</div>");
                }
                else if (!IsAllDigits(prgNum))
                {
                    int x = 820;
                    int y = 760;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Progress number has to be all digit numbers!</div>");
                }
                else
                {
                    
                    int thesNumInt = Int16.Parse(thesisNumber);

                    SqlCommand thesisBelongsToMeOngoingPROC = new SqlCommand("thesisBelongsToMeOngoing", conn);
                    thesisBelongsToMeOngoingPROC.CommandType = CommandType.StoredProcedure;

                    thesisBelongsToMeOngoingPROC.Parameters.Add(new SqlParameter("@stdID", Session["user"]));
                    thesisBelongsToMeOngoingPROC.Parameters.Add(new SqlParameter("@thesisSerial", thesNumInt));

                    SqlParameter success = thesisBelongsToMeOngoingPROC.Parameters.Add("@success", SqlDbType.Int);

                    success.Direction = ParameterDirection.Output;

                    conn.Open();
                    thesisBelongsToMeOngoingPROC.ExecuteNonQuery();
                    conn.Close();

                    int progNumInt = Int16.Parse(prgNum);

                    SqlCommand progressNumUsedPROC = new SqlCommand("progressNumUsed", conn);
                    progressNumUsedPROC.CommandType = CommandType.StoredProcedure;

                    progressNumUsedPROC.Parameters.Add(new SqlParameter("@stdID", Session["user"]));
                    progressNumUsedPROC.Parameters.Add(new SqlParameter("@progressNum", progNumInt));

                    SqlParameter success2 = progressNumUsedPROC.Parameters.Add("@success", SqlDbType.Int);

                    success2.Direction = ParameterDirection.Output;

                    conn.Open();
                    progressNumUsedPROC.ExecuteNonQuery();
                    conn.Close();

                    if (success.Value.ToString() == "0")
                    {
                        int x = 820;
                        int y = 760;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please choose an " + "<b><b>ongoing</b></b>" + " thesis you registered!</div>");
                    }
                    else if (success2.Value.ToString() == "1")
                    {
                        int x = 780;
                        int y = 760;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Report number already used, please choose another one.</div>");
                    }
                    else
                    {

                        SqlCommand AddProgressReportPROC = new SqlCommand("AddProgressReport", conn);
                        AddProgressReportPROC.CommandType = CommandType.StoredProcedure;

                        AddProgressReportPROC.Parameters.Add(new SqlParameter("@thesisSerialNo", thesNumInt));
                        AddProgressReportPROC.Parameters.Add(new SqlParameter("@progressReportDate", progCalender));
                        AddProgressReportPROC.Parameters.Add(new SqlParameter("@studentID", Session["user"]));
                        AddProgressReportPROC.Parameters.Add(new SqlParameter("@progressReportNo", progNumInt));


                        conn.Open();
                        AddProgressReportPROC.ExecuteNonQuery();
                        conn.Close();

                        int x = 840;
                        int y = 760;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Progress Report added successfully.</div>");


                    }

                }


            }


        }

        protected void fillProgress(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            thesNumFillPrg.Visible = true;
            prgNumFillPrg.Visible = true;
            state.Visible = true;
            descTextArea.Visible = true;
            TablePrgReports.Visible = true;
            FillPR.Visible = true;




            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand showProgressReportsPROC = new SqlCommand("showProgressReports", conn);
            showProgressReportsPROC.CommandType = CommandType.StoredProcedure;

            showProgressReportsPROC.Parameters.Add(new SqlParameter("@stdID", Session["user"]));


            conn.Open();

            SqlDataReader rdr = showProgressReportsPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 progNum = rdr.GetInt32(rdr.GetOrdinal("no"));

                DateTime progDate = new DateTime();
                HtmlTableCell tb1 = new HtmlTableCell();

                try
                {
                    progDate = rdr.GetDateTime(rdr.GetOrdinal("date"));
                    tb1.InnerText = "" + progDate;
                }
                catch (Exception e1)
                {
                    tb1.InnerText = "";
                }

                Int32 eval = 0;
                HtmlTableCell tb2 = new HtmlTableCell();

                try
                {
                    eval = rdr.GetInt32(rdr.GetOrdinal("eval"));
                    tb2.InnerText = "" + eval;
                }
                catch (Exception e1)
                {
                    tb2.InnerText = "";
                }

                Int32 stateCell = 0;
                HtmlTableCell tb10 = new HtmlTableCell();

                try
                {
                    stateCell = rdr.GetInt32(rdr.GetOrdinal("state"));
                    tb10.InnerText = "" + stateCell;
                }
                catch (Exception e1)
                {
                    tb10.InnerText = "";
                }

                string desc = "";
                try
                {
                    desc = rdr.GetString(rdr.GetOrdinal("description"));
                }
                catch (Exception e1)
                {

                }

                Int32 thesisCell = 0;
                HtmlTableCell tb4 = new HtmlTableCell();

                try
                {
                    thesisCell = rdr.GetInt32(rdr.GetOrdinal("thesisSerialNumber"));
                    tb4.InnerText = "" + thesisCell;
                }
                catch
                {
                    tb4.InnerText = "";
                }

                Int32 superID = 0;
                HtmlTableCell tb5 = new HtmlTableCell();

                try
                {
                    superID = rdr.GetInt32(rdr.GetOrdinal("supid"));
                    tb5.InnerText = "" + superID;
                }
                catch (Exception e1)
                {
                    tb5.InnerText = "";
                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + progNum;



                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = desc;



                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb10);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);
                tRow.Controls.Add(tb5);


                TablePrgReports.Rows.Add(tRow);


            }

            conn.Close();


            TablePrgReports.Visible = true;
        }

        protected void fill(object sender, EventArgs e)
        {


            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            thesNumFillPrg.Visible = true;
            prgNumFillPrg.Visible = true;
            state.Visible = true;
            descTextArea.Visible = true;
            TablePrgReports.Visible = true;
            FillPR.Visible = true;

            string thesisNF = thesNumFillPrg.Text;
            string prgNumF = prgNumFillPrg.Text;
            string stateF = state.Text;
            string descripF = descTextArea.InnerText;

            if (thesisNF.Replace(" ", "") == "" || prgNumF.Replace(" ", "") == "")
            {
                int x = 1410;
                int y = 740;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please enter thesis and report numbers!</div>");
            }
            else
            {
                if (!IsAllDigits(thesisNF))
                {
                    int x = 1410;
                    int y = 740;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Thesis number has to be all digit numbers!</div>");
                }
                else if (!IsAllDigits(prgNumF))
                {
                    int x = 1410;
                    int y = 740;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Report number has to be all digit numbers!</div>");
                }
                else
                {
                    int thesNumInt = Int16.Parse(thesisNF);
                    int prgNumInt = Int16.Parse(prgNumF);

                    SqlCommand validProgressUpdatePROC = new SqlCommand("validProgressUpdate", conn);
                    validProgressUpdatePROC.CommandType = CommandType.StoredProcedure;

                    validProgressUpdatePROC.Parameters.Add(new SqlParameter("@stdID", Session["user"]));
                    validProgressUpdatePROC.Parameters.Add(new SqlParameter("@thesisSer", thesNumInt));
                    validProgressUpdatePROC.Parameters.Add(new SqlParameter("@prgNum", prgNumInt));

                    SqlParameter success = validProgressUpdatePROC.Parameters.Add("@success", SqlDbType.Int);

                    success.Direction = ParameterDirection.Output;

                    conn.Open();
                    validProgressUpdatePROC.ExecuteNonQuery();
                    conn.Close();

                    if (success.Value.ToString() == "0")
                    {
                        int x = 1380;
                        int y = 710;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please enter a valid thesis and report numbers from the table!</div>");
                    }
                    else
                    {
                        SqlCommand FillProgressReportPROC = new SqlCommand("FillProgressReport", conn);
                        FillProgressReportPROC.CommandType = CommandType.StoredProcedure;

                        FillProgressReportPROC.Parameters.Add(new SqlParameter("@thesisSerialNo", thesNumInt));
                        FillProgressReportPROC.Parameters.Add(new SqlParameter("@progressReportNo", prgNumInt));
                        FillProgressReportPROC.Parameters.Add(new SqlParameter("@state", stateF));
                        FillProgressReportPROC.Parameters.Add(new SqlParameter("@description", descripF));
                        FillProgressReportPROC.Parameters.Add(new SqlParameter("@studentID", Session["user"]));

                        conn.Open();
                        FillProgressReportPROC.ExecuteNonQuery();
                        conn.Close();

                        int x = 1410;
                        int y = 700;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Added successfully!</div>");

                        fillProgress(null, EventArgs.Empty);


                    }





                }
            }

            SqlCommand showProgressReportsPROC = new SqlCommand("showProgressReports", conn);
            showProgressReportsPROC.CommandType = CommandType.StoredProcedure;

            showProgressReportsPROC.Parameters.Add(new SqlParameter("@stdID", Session["user"]));


            conn.Open();

            SqlDataReader rdr = showProgressReportsPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 progNum = rdr.GetInt32(rdr.GetOrdinal("no"));

                DateTime progDate = new DateTime();
                HtmlTableCell tb1 = new HtmlTableCell();

                try
                {
                    progDate = rdr.GetDateTime(rdr.GetOrdinal("date"));
                    tb1.InnerText = "" + progDate;
                }
                catch (Exception e1)
                {
                    tb1.InnerText = "";
                }

                Int32 eval = 0;
                HtmlTableCell tb2 = new HtmlTableCell();

                try
                {
                    eval = rdr.GetInt32(rdr.GetOrdinal("eval"));
                    tb2.InnerText = "" + eval;
                }
                catch (Exception e1)
                {
                    tb2.InnerText = "";
                }

                Int32 stateCell = 0;
                HtmlTableCell tb10 = new HtmlTableCell();

                try
                {
                    stateCell = rdr.GetInt32(rdr.GetOrdinal("state"));
                    tb10.InnerText = "" + stateCell;
                }
                catch (Exception e1)
                {
                    tb10.InnerText = "";
                }

                string desc = "";
                try
                {
                    desc = rdr.GetString(rdr.GetOrdinal("description"));
                }
                catch (Exception e1)
                {

                }

                Int32 thesisCell = 0;
                HtmlTableCell tb4 = new HtmlTableCell();

                try
                {
                    thesisCell = rdr.GetInt32(rdr.GetOrdinal("thesisSerialNumber"));
                    tb4.InnerText = "" + thesisCell;
                }
                catch
                {
                    tb4.InnerText = "";
                }

                Int32 superID = 0;
                HtmlTableCell tb5 = new HtmlTableCell();

                try
                {
                    superID = rdr.GetInt32(rdr.GetOrdinal("supid"));
                    tb5.InnerText = "" + superID;
                }
                catch (Exception e1)
                {
                    tb5.InnerText = "";
                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + progNum;



                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = desc;



                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb10);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);
                tRow.Controls.Add(tb5);


                TablePrgReports.Rows.Add(tRow);


            }

            conn.Close();


            TablePrgReports.Visible = true;
        }


        protected void addNumberBtn(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand showMobilePROC = new SqlCommand("showMobile", conn);
            showMobilePROC.CommandType = CommandType.StoredProcedure;

            showMobilePROC.Parameters.Add(new SqlParameter("@ID", Session["user"]));

            conn.Open();

            SqlDataReader rdr = showMobilePROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 num = 0;
                string numStr = "";
                try
                {
                    num = rdr.GetInt32(rdr.GetOrdinal("phone"));
                    numStr = "0" + num;
                }
                catch
                {

                }


                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = numStr;

                tRow.Controls.Add(tb);

                TablePhoneNumbers.Rows.Add(tRow);
            }
            conn.Close();
            TablePhoneNumbers.Visible = true;
            AddNum.Visible = true;
            phoneNum.Visible = true;
        }

        protected void addPhoneInTable(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            AddNum.Visible = true;
            phoneNum.Visible = true;

            string number = phoneNum.Text;
            if (number.Replace(" ", "") == "")
            {
                int x = 890;
                int y = 700;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please enter a number!</div>");
            }
            else
            {
                if (!IsAllDigits(number))
                {
                    int x = 850;
                    int y = 700;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Phone number must be all digit numbers!</div>");
                }
                else
                {
                    if ((number.Substring(0, 3) == "010" || number.Substring(0, 3) == "011" || number.Substring(0, 3) == "012" || number.Substring(0, 3) == "010") && (number.Length == 11))
                    {
                        SqlCommand addMobilePROC = new SqlCommand("addMobile", conn);
                        addMobilePROC.CommandType = CommandType.StoredProcedure;

                        addMobilePROC.Parameters.Add(new SqlParameter("@ID", Session["user"]));
                        addMobilePROC.Parameters.Add(new SqlParameter("@mobile_number", number));

                        conn.Open();
                        try
                        {
                            addMobilePROC.ExecuteNonQuery();
                            int x = 890;
                            int y = 700;
                            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Added successfully!</div>");
                        }
                        catch (Exception e1)
                        {
                            int x = 890;
                            int y = 700;
                            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Phone already added!</div>");
                        }
                        conn.Close();

                    }
                    else
                    {

                        int x = 800;
                        int y = 700;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Valid phone number must start with 010,011,012 or 015</div>");
                        int x2 = 900;
                        int y2 = 720;
                        Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>and of length 11 digits!</div>");
                    }

                }


            }

            SqlCommand showMobilePROC = new SqlCommand("showMobile", conn);
            showMobilePROC.CommandType = CommandType.StoredProcedure;

            showMobilePROC.Parameters.Add(new SqlParameter("@ID", Session["user"]));

            conn.Open();

            SqlDataReader rdr = showMobilePROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 num = 0;
                string numStr = "";
                try
                {
                    num = rdr.GetInt32(rdr.GetOrdinal("phone"));
                    numStr = "0" + num;
                }
                catch
                {

                }


                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = numStr;

                tRow.Controls.Add(tb);

                TablePhoneNumbers.Rows.Add(tRow);
            }
            conn.Close();


            TablePhoneNumbers.Visible = true;
        }


        protected void addPub(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;

            PubTitle.Visible = true;
            PubHost.Visible = true;
            PubPlace.Visible = true;

            checkAccepted.Visible = true;
            progDate.Visible = true;
            submitPub.Visible = true;

        }

        protected void subPub(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            Label11.Visible = true;

            PubTitle.Visible = true;
            PubHost.Visible = true;
            PubPlace.Visible = true;

            checkAccepted.Visible = true;
            progDate.Visible = true;
            submitPub.Visible = true;

            string PTitle = PubTitle.Text;
            string PHost = PubHost.Text;
            string PPlace = PubPlace.Text;
            DateTime PDate = progDate.SelectedDate;
            Boolean accepted = checkAccepted.Checked;

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            if (PTitle.Replace(" ", "") == "" || PHost.Replace(" ", "") == "" || PPlace.Replace(" ", "") == "")
            {
                int x = 870;
                int y = 730;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill all the fields!</div>");
            }
            else
            {
                SqlCommand addPublicationPROC = new SqlCommand("addPublication", conn);
                addPublicationPROC.CommandType = CommandType.StoredProcedure;

                addPublicationPROC.Parameters.Add(new SqlParameter("@title", PTitle));
                addPublicationPROC.Parameters.Add(new SqlParameter("@pubDate", PDate));
                addPublicationPROC.Parameters.Add(new SqlParameter("@host", PHost));
                addPublicationPROC.Parameters.Add(new SqlParameter("@place", PPlace));

                Int32 accPar = 0;
                if (accepted)
                {
                    accPar = 1;
                }

                addPublicationPROC.Parameters.Add(new SqlParameter("@accepted", accPar));

                conn.Open();
                addPublicationPROC.ExecuteNonQuery();
                conn.Close();

                int x = 850;
                int y = 730;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Publication added successfully.</div>");

                SqlCommand showPubIdPROC = new SqlCommand("showPubId", conn);
                showPubIdPROC.CommandType = CommandType.StoredProcedure;

                SqlParameter pubID = showPubIdPROC.Parameters.Add("@pubID", SqlDbType.Int);

                pubID.Direction = ParameterDirection.Output;

                conn.Open();
                showPubIdPROC.ExecuteNonQuery();
                conn.Close();

                int x2 = 880;
                int y2 = 750;
                Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>Publication ID: " + pubID.Value + "</div>");

            }

        }


        protected void linkPub(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            thesisNum.Visible = false;
            progDate.Visible = false;
            progNumber.Visible = false;
            AddRep.Visible = false;

            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            Label11.Visible = false;
            PubTitle.Visible = false;
            PubHost.Visible = false;
            PubPlace.Visible = false;
            checkAccepted.Visible = false;
            submitPub.Visible = false;

            TableOnGoingTh.Visible = true;
            TablePubs.Visible = true;
            Label12.Visible = true;
            Label13.Visible = true;
            thesisNumLinkPub.Visible = true;
            PubIDLinkPub.Visible = true;
            LinkPubThesis.Visible = true;

            //listMyOngoingThesis
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand listMyOngoingThesisPROC = new SqlCommand("listMyOngoingThesis", conn);
            listMyOngoingThesisPROC.CommandType = CommandType.StoredProcedure;

            listMyOngoingThesisPROC.Parameters.Add(new SqlParameter("@studentId", Session["user"]));

            conn.Open();

            SqlDataReader rdr = listMyOngoingThesisPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 ThesisSer = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));

                String field = "";
                try
                {
                    field = rdr.GetString(rdr.GetOrdinal("field"));
                }
                catch (Exception e1)
                {

                }

                String type = rdr.GetString(rdr.GetOrdinal("type"));
                String title = rdr.GetString(rdr.GetOrdinal("title"));
                DateTime startDate = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("endDate"));

                DateTime defenseDate = new DateTime();
                HtmlTableCell tb5 = new HtmlTableCell();

                try
                {
                    defenseDate = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                    tb5.InnerText = "" + defenseDate;
                }
                catch (Exception e1)
                {
                    tb5.InnerText = "";
                }

                Int32 years = 0;
                HtmlTableCell tb6 = new HtmlTableCell();

                try
                {
                    years = rdr.GetInt32(rdr.GetOrdinal("years"));
                    tb6.InnerText = "" + years;
                }
                catch (Exception e1)
                {
                    tb6.InnerText = "";
                }

                Decimal grade = 0;
                HtmlTableCell tb7 = new HtmlTableCell();

                try
                {
                    grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    tb7.InnerText = "" + grade;
                }
                catch (Exception e1)
                {
                    tb7.InnerText = "";
                }

                Int32 paymentID = 0;
                HtmlTableCell tb8 = new HtmlTableCell();

                try
                {
                    paymentID = rdr.GetInt32(rdr.GetOrdinal("payment_id"));
                    tb8.InnerText = "" + paymentID;
                }
                catch (Exception e1)
                {
                    tb8.InnerText = "";
                }

                Int32 numOfExt = 0;
                HtmlTableCell tb9 = new HtmlTableCell();

                try
                {
                    numOfExt = rdr.GetInt32(rdr.GetOrdinal("noOfExtensions"));
                    tb9.InnerText = "" + numOfExt;
                }
                catch (Exception e1)
                {
                    tb9.InnerText = "";
                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + ThesisSer;
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = field;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = type;
                HtmlTableCell tb10 = new HtmlTableCell();
                tb10.InnerText = title;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = "" + startDate;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = "" + endDate;


                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb10);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);
                tRow.Controls.Add(tb5);
                tRow.Controls.Add(tb6);
                tRow.Controls.Add(tb7);
                tRow.Controls.Add(tb8);
                tRow.Controls.Add(tb9);

                TableOnGoingTh.Rows.Add(tRow);
            }

            conn.Close();
            TableOnGoingTh.Visible = true;

            //pubTable

            SqlCommand pubTablePROC = new SqlCommand("pubTable", conn);
            pubTablePROC.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataReader rdr2 = pubTablePROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr2.Read())
            {
                Int32 pubID = rdr2.GetInt32(rdr2.GetOrdinal("id"));

                string pubTitle = rdr2.GetString(rdr2.GetOrdinal("title"));

                DateTime dateOfPub = new DateTime();
                HtmlTableCell tb = new HtmlTableCell();
                try
                {
                    dateOfPub = rdr2.GetDateTime(rdr2.GetOrdinal("dateOfPublication"));
                    tb.InnerText = "" + dateOfPub;
                }
                catch (Exception e1)
                {
                    tb.InnerText = "";
                }

                string place = "";
                try
                {
                    place = rdr2.GetString(rdr2.GetOrdinal("place"));
                }
                catch (Exception e1)
                {

                }

                Boolean acc = false;
                Int32 accInt = 0;
                HtmlTableCell tb1 = new HtmlTableCell();
                try
                {
                    acc = rdr2.GetBoolean(rdr2.GetOrdinal("accepted"));
                    if (acc == true)
                    {
                        accInt = 1;
                    }
                    tb1.InnerText = "" + accInt;
                }
                catch (Exception e1)
                {
                    tb1.InnerText = "";
                }

                string host = "";
                try
                {
                    host = rdr2.GetString(rdr2.GetOrdinal("host"));
                }
                catch (Exception e1)
                {

                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = "" + pubID;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = pubTitle;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = place;
                HtmlTableCell tb5 = new HtmlTableCell();
                tb5.InnerText = host;

                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb4);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb5);

                TablePubs.Rows.Add(tRow);
            }

            conn.Close();

            TablePubs.Visible = true;
        }


        protected void linkPubThesis(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            TableOnGoingTh.Visible = true;
            TablePubs.Visible = true;
            Label12.Visible = true;
            Label13.Visible = true;
            thesisNumLinkPub.Visible = true;
            PubIDLinkPub.Visible = true;
            LinkPubThesis.Visible = true;

            string thesisStr = thesisNumLinkPub.Text;
            string pubStr = PubIDLinkPub.Text;

            if (thesisStr.Replace(" ", "") == "" || pubStr.Replace(" ", "") == "")
            {
                int x = 1315;
                int y = 600;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please fill all the fields!</div>");
            }
            else
            {
                if (!IsAllDigits(thesisStr))
                {
                    int x = 1250;
                    int y = 600;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Thesis number has to be all digit numbers!</div>");
                }
                else if (!IsAllDigits(pubStr))
                {
                    int x = 1250;
                    int y = 600;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Publication ID has to be all digit numbers!</div>");
                }
                else
                {
                    Int32 thesisPubInt = Int32.Parse(thesisStr);

                    SqlCommand thesisBelongsToMeOngoingPROC = new SqlCommand("thesisBelongsToMeOngoing", conn);
                    thesisBelongsToMeOngoingPROC.CommandType = CommandType.StoredProcedure;

                    thesisBelongsToMeOngoingPROC.Parameters.Add(new SqlParameter("@stdID", Session["user"]));
                    thesisBelongsToMeOngoingPROC.Parameters.Add(new SqlParameter("@thesisSerial", thesisPubInt));

                    SqlParameter success = thesisBelongsToMeOngoingPROC.Parameters.Add("@success", SqlDbType.Int);

                    success.Direction = ParameterDirection.Output;

                    conn.Open();
                    thesisBelongsToMeOngoingPROC.ExecuteNonQuery();
                    conn.Close();

                    if (success.Value.ToString() == "0")
                    {
                        int x = 1250;
                        int y = 600;
                        Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please choose an " + "<b><b>ongoing</b></b>" + " thesis you registered!</div>");
                    }
                    else {
                        try
                        {
                            Int32 PubInt = Int32.Parse(pubStr);
                            
                            SqlCommand linkPubThesisPROC = new SqlCommand("linkPubThesis", conn);
                            linkPubThesisPROC.CommandType = CommandType.StoredProcedure;

                            linkPubThesisPROC.Parameters.Add(new SqlParameter("@PubID", PubInt));
                            linkPubThesisPROC.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisPubInt));

                            conn.Open();
                            linkPubThesisPROC.ExecuteNonQuery();
                            conn.Close();

                            int x = 1335;
                            int y = 600;
                            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Added Successfully!</div>");
                        }
                        catch (Exception e1)
                        {
                            int x = 1335;
                            int y = 600;
                            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Invalid publication ID</div>");
                            int x2 = 1250;
                            int y2 = 650;
                            Response.Write("<div style='position:absolute;top:" + y2.ToString() + "px;left:" + x2.ToString() + "px'>or Publication already linked to this Thesis</div>");
                        }
                    }


                }


            }

            linkPub(null, EventArgs.Empty);
        }


        protected void logoutBtn(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userType"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}