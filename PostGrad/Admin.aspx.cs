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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            else if ((string)Session["userType"] != "admin")
            {
                if (((string)Session["userType"] == "gucianstudent" || (string)Session["userType"] == "nongucianstudent"))
                {
                    Response.Redirect("Student.aspx");
                }
                else if ((string)Session["userType"] == "examiner")
                {
                    Response.Redirect("Examiner.aspx");
                }
                else
                {
                    Response.Redirect("Supervisor.aspx");
                }
            } 
            

            superTable.Visible = false;
            adminListThesis.Visible = false;
            EnterThesis.Visible = false;
            ThesisSerialNumber.Visible = false;
            AddExt.Visible = false;
            serialNumberLabel.Visible = false;
            serialNumberInput.Visible = false;
            amountLabel.Visible = false;
            amountInput.Visible = false;
            noOfInstallLabel.Visible = false;
            noOfInstallInput.Visible = false;
            fundPercentageLabel.Visible = false;
            fundPercentageInput.Visible = false;
            AddPaymentbtn.Visible = false;
        }

        protected void listSupBtn(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand AdminListSupPROC = new SqlCommand("AdminListSup", conn);
            AdminListSupPROC.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataReader rdr = AdminListSupPROC.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Int32 supID = rdr.GetInt32(rdr.GetOrdinal("id"));

                string email = rdr.GetString(rdr.GetOrdinal("email"));

                string password = rdr.GetString(rdr.GetOrdinal("password"));

                string name = "";
                try
                {
                    name = rdr.GetString(rdr.GetOrdinal("name"));
                }
                catch (Exception e1)
                {

                }

                string faculty = "";
                try
                {
                    faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                }
                catch (Exception e1)
                {

                }

                HtmlTableRow tRow = new HtmlTableRow();

                HtmlTableCell tb = new HtmlTableCell();
                tb.InnerText = "" + supID;
                HtmlTableCell tb1 = new HtmlTableCell();
                tb1.InnerText = email;
                HtmlTableCell tb2 = new HtmlTableCell();
                tb2.InnerText = password;
                HtmlTableCell tb3 = new HtmlTableCell();
                tb3.InnerText = name;
                HtmlTableCell tb4 = new HtmlTableCell();
                tb4.InnerText = faculty;

                tRow.Controls.Add(tb);
                tRow.Controls.Add(tb1);
                tRow.Controls.Add(tb2);
                tRow.Controls.Add(tb3);
                tRow.Controls.Add(tb4);

                superTable.Rows.Add(tRow);
            }

            conn.Close();

            superTable.Visible = true;

        }

        protected void listThesBtn(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand AdminViewAllThesesPROC = new SqlCommand("AdminViewAllTheses", conn);
            AdminViewAllThesesPROC.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataReader rdr = AdminViewAllThesesPROC.ExecuteReader(CommandBehavior.CloseConnection);
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

                adminListThesis.Rows.Add(tRow);
            }

            conn.Close();

            adminListThesis.Visible = true;

            //AdminViewOnGoingTheses
            SqlCommand AdminViewOnGoingThesesPROC = new SqlCommand("AdminViewOnGoingTheses", conn);
            AdminViewOnGoingThesesPROC.CommandType = CommandType.StoredProcedure;

            SqlParameter thesisCnt = AdminViewOnGoingThesesPROC.Parameters.Add("@thesesCount", SqlDbType.Int);

            thesisCnt.Direction = ParameterDirection.Output;

            conn.Open();
            AdminViewOnGoingThesesPROC.ExecuteNonQuery();
            conn.Close();

            int x = 850;
            int y = 760;
            Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Count of ongoing thesis: " + thesisCnt.Value + "</div>");

        }


        protected void ExtensionButton(object sender, EventArgs e)
        {
            AddExt.Visible = true;
            EnterThesis.Visible = true;
            ThesisSerialNumber.Visible = true;
            superTable.Visible = false;
            adminListThesis.Visible = false;

        }
        protected void AddExtension(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand incrementExtensionPROC = new SqlCommand("incrementExtension", conn);
            incrementExtensionPROC.CommandType = CommandType.StoredProcedure;

            Int32 ThesisNum = 0;
            try
            {
                ThesisNum = Int32.Parse(ThesisSerialNumber.Text);
            }
            catch (Exception e1)
            {
            }



            conn.Open();
            if (!(ThesisNum > 0))
            {
                int x = 500;
                int y = 500;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Please Enter a Proper Thesis Serial Number!!!!!</div>");
            }
            else
            {
                incrementExtensionPROC.Parameters.Add(new SqlParameter("@serialNum", ThesisNum));
                incrementExtensionPROC.ExecuteNonQuery();
            }
            conn.Close();
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

        protected void onAddPaymentClicked(object sender, EventArgs e)
        {

            serialNumberLabel.Visible = true;
            serialNumberInput.Visible = true;
            amountLabel.Visible = true;
            amountInput.Visible = true;
            noOfInstallLabel.Visible = true;
            noOfInstallInput.Visible = true;
            fundPercentageLabel.Visible = true;
            fundPercentageInput.Visible = true;
            AddPaymentbtn.Visible = true;

        }
        protected void onAddPaymentBtnClicked(object sender, EventArgs e)
        {
            string serialNumberString = serialNumberInput.Text;
            double amount = -1;
            try
            {
                amount = double.Parse(amountInput.Text);
            }
            catch (Exception e1) { }
            string noOfInstallmentString = noOfInstallInput.Text;
            double fundPerc = -1;
            try
            {
                fundPerc = double.Parse(fundPercentageInput.Text);
            }
            catch (Exception e1) { }

            if (serialNumberString.Replace(" ", "") == "" || noOfInstallmentString.Replace(" ", "") == "")
            {
                int x = 500;
                int y = 500;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>All fields must be filled!</div>");
            }
            else if (!IsAllDigits(serialNumberString))
            {
                int x = 500;
                int y = 500;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>serial number must be all digits</div>");
            }
            else if (amount == -1)
            {
                int x = 500;
                int y = 500;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>amount must be specified</div>");
            }
            else if (!IsAllDigits(noOfInstallmentString))
            {
                int x = 500;
                int y = 500;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>number of installmennts must be all digits</div>");
            }
            else if (fundPerc == -1)
            {
                int x = 500;
                int y = 500;
                Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>fund percentage must be specified</div>");
            }
            else
            {
                int serialNumber = Int32.Parse(serialNumberString);
                int noOfInstallments = Int32.Parse(noOfInstallmentString);

                string connStr = WebConfigurationManager.ConnectionStrings["PostGrad"].ToString();

                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand addPaymentPROC = new SqlCommand("AdminIssueThesisPayment", conn);
                addPaymentPROC.CommandType = CommandType.StoredProcedure;

                addPaymentPROC.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNumber));
                addPaymentPROC.Parameters.Add(new SqlParameter("@amount", amount));
                addPaymentPROC.Parameters.Add(new SqlParameter("@noOfInstallments", noOfInstallments));
                addPaymentPROC.Parameters.Add(new SqlParameter("@fundPercentage", fundPerc));

                conn.Open();
                try
                {
                    addPaymentPROC.ExecuteNonQuery();
                    int x = 500;
                    int y = 500;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>Payment added successfully!</div>");

                }
                catch (Exception e1)
                {
                    int x = 500;
                    int y = 500;
                    Response.Write("<div style='position:absolute;top:" + y.ToString() + "px;left:" + x.ToString() + "px'>An Error has occured!</div>");

                }
                conn.Close();
            }
        }

        protected void logoutBtn(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userType"] = null;
            Response.Redirect("Login.aspx");
        }




    }
}



































