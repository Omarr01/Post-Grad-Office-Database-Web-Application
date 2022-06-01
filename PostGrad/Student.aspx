<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="PostGrad.Student" %>

<!DOCTYPE html>
<style>
    h1 {
        font-family: 'Candara', cursive;
        font-size: 50px;
        color: #406882;
    }

    div {
        border-width: 4px;
    }

    p.double {
        border-style: double;
    }

    .auto-style5 {
        position: absolute;
        top: 857px;
        left: 350px;
        z-index: 1;
        width: 164px;
        right: 1048px;
    }

    .auto-style6 {
        position: absolute;
        top: 857px;
        left: 558px;
        z-index: 1;
        width: 164px;
        right: 845px;
    }

    .auto-style7 {
        position: absolute;
        top: 857px;
        left: 757px;
        z-index: 1;
        width: 164px;
        right: 650px;
    }

    .auto-style8 {
        position: absolute;
        top: 857px;
        left: 970px;
        z-index: 1;
        width: 164px;
        right: 455px;
    }

    .auto-style9 {
        position: absolute;
        top: 857px;
        left: 1175px;
        z-index: 1;
        width: 164px;
        right: 257px;
    }

    .auto-style10 {
        position: absolute;
        top: 857px;
        left: 1380px;
        z-index: 1;
        width: 164px;
        right: 63px;
    }

    table {
        font-family: arial, sans-serif;
    }

    .tableReports {
        font-family: arial, sans-serif;
        height: 300px;
        overflow-y: scroll;
        display: block;
        width: 50%;
        position: absolute;
        left: 120px;
        top: 370px;
    }

    .tablePublication{
        font-family: arial, sans-serif;
        height: 150px;
        overflow-y: scroll;
        display: block;
        width: 50%;
        position: absolute;
        left: 120px;
        top: 530px;
    }

    .tableOngoingThesis{
        font-family: arial, sans-serif;
        height: 150px;
        overflow-y: scroll;
        display: block;
        width: 50%;
        position: absolute;
        left: 120px;
        top: 370px;
    }

    .tableThesis {
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 55%;
    }

    .tableCourses {
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 23%;
    }

    .tableNumbers {
        font-family: arial, sans-serif;
        height: 100px;
        overflow-y: scroll;
        display: block;
        position: absolute;
    }

    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #dddddd;
    }

    .auto-style11 {
        position: absolute;
        top: 818px;
        left: 757px;
        z-index: 1;
        width: 164px;
        right: 808px;
    }

    .auto-style12 {
        position: absolute;
        top: 818px;
        left: 970px;
        z-index: 1;
        width: 164px;
        right: 595px;
    }

    .auto-style20 {
        z-index: 1;
        left: 500px;
        top: 337px;
        position: absolute;
    }

    .auto-style21 {
        z-index: 1;
        left: 500px;
        top: 410px;
        position: absolute;
    }

    .auto-style22 {
        z-index: 1;
        left: 500px;
        top: 690px;
        position: absolute;
    }

    .auto-style25 {
        position: absolute;
        left: 1400px;
        top: 380px;
    }

    .auto-style26 {
        position: absolute;
        left: 1400px;
        top: 436px;
    }

    .auto-style27 {
        position: absolute;
        left: 1400px;
        top: 490px;
    }

    .auto-style28 {
        position: absolute;
        left: 1400px;
        top: 545px;
    }

    .auto-style29 {
        z-index: 1;
        left: 1225px;
        top: 492px;
        position: absolute;
    }

    .auto-style30 {
        z-index: 1;
        left: 1225px;
        top: 382px;
        position: absolute;
    }

    .auto-style31 {
        z-index: 1;
        left: 1225px;
        top: 437px;
        position: absolute;
    }

    .auto-style32 {
        z-index: 1;
        left: 1225px;
        top: 547px;
        position: absolute;
    }



    .auto-style34 {
        position: absolute;
        top: 680px;
        left: 1400px;
        z-index: 1;
        width: 74px;
    }
    .auto-style35 {
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        position: absolute;
        left: 880px;
        top: 300px;
    }
    .auto-style36 {
        z-index: 1;
        position: absolute;
        left: 938px;
        top: 639px;
    }
    .auto-style37 {
        position: absolute;
        top: 570px;
        left: 873px;
        z-index: 1;
    }
    .auto-style38 {
        position: absolute;
        top: 282px;
        left: 745px;
        z-index: 1;
        width: 419px;
    }
    .auto-style39 {
        position: absolute;
        top: 321px;
        left: 745px;
        z-index: 1;
        width: 419px;
    }
    .auto-style40 {
        position: absolute;
        top: 241px;
        left: 745px;
        z-index: 1;
        width: 419px;
    }
    .auto-style51 {
        position: absolute;
        top: 665px;
        left: 900px;
    }
    .auto-style52 {
        position: absolute;
        top: 321px;
        left: 622px;
        z-index: 1;
    }
    .auto-style53 {
        position: absolute;
        top: 380px;
        left: 622px;
        z-index: 1;
    }
    .auto-style55 {
        position: absolute;
        top: 241px;
        left: 622px;
        z-index: 1;
    }
    .auto-style56 {
        position: absolute;
        top: 282px;
        left: 622px;
        z-index: 1;
    }
    .auto-style57 {
        position: absolute;
        top: 700px;
        left: 905px;
        z-index: 1;
        width: 74px;
    }
    .auto-style58 {
        position: absolute;
        left: 1400px;
        top: 450px;
    }
    .auto-style59 {
        z-index: 1;
        left: 1225px;
        top: 450px;
        position: absolute;
    }
    .auto-style60 {
        position: absolute;
        left: 1400px;
        top: 500px;
    }
    .auto-style61 {
        z-index: 1;
        left: 1225px;
        top: 500px;
        position: absolute;
    }
    .auto-style62 {
        position: absolute;
        top: 550px;
        left: 1350px;
        z-index: 1;
        width: 74px;
    }
    .auto-style63 {
        position: absolute;
        top: 938px;
        left: 1700px;
        z-index: 1;
        width: 164px;
        right: 11px;
    }
    .auto-style64 {
        width: 50%;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <center>
            <h1>Student Homepage</h1>
        </center>
        <br />




        <div style="height: 700px; border-style: double">


            <br />
            <br />
            <br />
            <br />
            
            <br />
            <br />
            <br />
            <br />
            <center>
                <table runat="server" id="gucianProfileTable" class="auto-style64">
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Type</th>
                        <th>Faculty</th>
                        <th>Address</th>
                        <th>GPA</th>
                        <th>undergrad ID</th>
                    </tr>
                </table>


            </center>
            <center>
                <table class="tableThesis" runat="server" id="stdListThesis">
                    <tr>
                        <th>Serial Number</th>
                        <th>Field</th>
                        <th>Type</th>
                        <th>Title</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Defense Date</th>
                        <th>Years</th>
                        <th>Grade</th>
                        <th>Payment ID
                        </th>
                        <th>num Of Extensions</th>
                    </tr>
                </table>
            </center>

            <center>
                <table class="tableCourses" runat="server" id="coursesTable">
                    <tr>
                        <th>Course ID</th>
                        <th>Fees</th>
                        <th>Credit Hours</th>
                        <th>Code
                        </th>
                        <th>Grade</th>
                    </tr>
                </table>
            </center>



            
                <table class="auto-style35" visible:false runat="server" id="TablePhoneNumbers">
                    <tr>
                        <th>Phone Numbers

                        </th>
                    </tr>
                </table>
                
            <table class="tableOngoingThesis" runat="server" id="TableOnGoingTh">
                    <tr>
                        <th>Serial Number</th>
                        <th>Field</th>
                        <th>Type</th>
                        <th>Title</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Defense Date</th>
                        <th>Years</th>
                        <th>Grade</th>
                        <th>Payment ID
                        </th>
                        <th>num Of Extensions</th>
                    </tr>
                </table>
           


            <table class="tableReports" visible:false runat="server" id="TablePrgReports">
                <tr>
                    <th>Report Number</th>
                    <th>Report Date</th>
                    <th>Evaluation</th>
                    <th>State</th>
                    <th>Description</th>
                    <th>Serial Number
                    </th>
                    <th>Supervisor ID
                    </th>
                </tr>
            </table>

            <table class="tablePublication" visible:false runat="server" id="TablePubs">
                <tr>
                    <th>ID</th>
                    <th>Title</th>
                    <th>Date of Publication</th>
                    <th>Place</th>
                    <th>Accepted</th>
                    <th>Host</th>
                </tr>
            </table>


            <asp:Label Visible="false" ID="Label8" runat="server" CssClass="auto-style55" Text="Title:"></asp:Label>
            <asp:Label Visible="false" ID="Label9" runat="server" CssClass="auto-style56" Text="Place:"></asp:Label>
            <asp:Label Visible="false" ID="Label10" runat="server" CssClass="auto-style52" Text="Host:"></asp:Label>
            <asp:Label Visible="false" ID="Label11" runat="server" CssClass="auto-style53" Text="Date of Publication:"></asp:Label>

            <asp:Label ID="Label1" Visible="false" runat="server" Text="Thesis number:" CssClass="auto-style20"></asp:Label>

            <asp:Label ID="Label2" Visible="false" runat="server" Text="Progress Report Date:" CssClass="auto-style21"></asp:Label>
            <asp:Label ID="Label3" Visible="false" runat="server" Text="Progress Report Number:" CssClass="auto-style22"></asp:Label>

            <center>
                <asp:TextBox Visible="false" ID="thesisNum" runat="server"></asp:TextBox>
            </center>

            

            <br />
            <center>
                <asp:Calendar Visible="false" ID="progDate" runat="server"></asp:Calendar>
            </center>
            <br />
            <center>
                <asp:TextBox Visible="false" ID="progNumber" runat="server"></asp:TextBox>

            </center>

            

            <br />
            <center>
                <asp:Button Visible="false" ID="AddRep" OnClick="addProgress" runat="server" Style="z-index: 1" Text="Add" />
            </center>

            <asp:Label ID="Label4" runat="server" Text="Thesis number:" CssClass="auto-style30" Visible:false></asp:Label>

            <asp:Label ID="Label12" runat="server" Text="Thesis number:" CssClass="auto-style59"></asp:Label>


            <asp:Label ID="Label5" runat="server" Text="Progress Report Number:" CssClass="auto-style31" Visible:false></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="State:" CssClass="auto-style29" Visible:false></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="Description:" CssClass="auto-style32" Visible:false></asp:Label>

            <asp:Label ID="Label13" runat="server" Text="Publication ID:" CssClass="auto-style61"></asp:Label>

            <asp:TextBox ID="thesNumFillPrg" runat="server" CssClass="auto-style25" Visible:false></asp:TextBox>

            <asp:TextBox ID="thesisNumLinkPub" runat="server" CssClass="auto-style58" ></asp:TextBox>

            <asp:TextBox ID="prgNumFillPrg" runat="server" CssClass="auto-style26" Visible:false></asp:TextBox>

            <asp:TextBox ID="PubIDLinkPub" runat="server" CssClass="auto-style60"></asp:TextBox>

            <asp:TextBox ID="state" runat="server" CssClass="auto-style27" Visible:false></asp:TextBox>

            <asp:TextBox ID="phoneNum" runat="server" CssClass="auto-style37"></asp:TextBox>
            
            <asp:TextBox Visible="false" MaxLength="50" ID="PubTitle" runat="server" CssClass="auto-style40"></asp:TextBox>
            <asp:TextBox Visible="false" MaxLength="50" ID="PubHost" runat="server" CssClass="auto-style39"></asp:TextBox>
            <asp:TextBox Visible="false" MaxLength="50" ID="PubPlace" runat="server" CssClass="auto-style38"></asp:TextBox>
            
            <asp:CheckBox Visible="false" Text="Accepted" ID="checkAccepted" runat="server" CssClass="auto-style51" style="z-index: 1" />

            <textarea visible:false
                runat="server" maxlength="200" rows="5"
                cols="40"
                name="txt"
                id="descTextArea" class="auto-style28">
             </textarea>

            <asp:Button ID="FillPR" OnClick="fill" runat="server" CssClass="auto-style34" Text="Fill" />

            <asp:Button ID="LinkPubThesis" OnClick="linkPubThesis" runat="server" CssClass="auto-style62" Text="Link" />

            <asp:Button Visible="false" ID="submitPub" OnClick="subPub" runat="server" CssClass="auto-style57" Text="Add" />

            <asp:Button ID="logout" OnClick="logoutBtn" runat="server" CssClass="auto-style63" Text="Logout" />

        </div>

                    



        <div>

            <asp:Button ID="ViewProfile" OnClick="viewPrfBtn" runat="server" CssClass="auto-style11" Text="View your profile" />
            <asp:Button ID="ListThesis" OnClick="listThesBtn" runat="server" CssClass="auto-style5" Text="List your thesis" />
            <asp:Button ID="AddProgress" OnClick="addPrg" runat="server" CssClass="auto-style6" Text="Add a progress report" />
            <asp:Button ID="FillProgress" OnClick="fillProgress" runat="server" CssClass="auto-style7" Text="Fill a progress report" />
            <asp:Button ID="AddPub" OnClick="addPub" runat="server" CssClass="auto-style8" Text="Add a publication" />
            <asp:Button ID="LinkPub" OnClick="linkPub" runat="server" CssClass="auto-style9" Text="Link publication" />

            <asp:Button ID="ViewCoursesNon" OnClick="ViewCrsBtn" runat="server" CssClass="auto-style10" Text="View your courses" />
            <asp:Button ID="AddNumber" OnClick="addNumberBtn" runat="server" CssClass="auto-style12" Text="Add a phone number" />

            <asp:Button Visible="false" ID="AddNum" OnClick="addPhoneInTable" runat="server" Text="Add" CssClass="auto-style36" />
        </div>
    </form>
</body>
</html>
