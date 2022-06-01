<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supervisor.aspx.cs" Inherits="PostGrad.Supervisor" %>

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
        top: 862px;
        left: 47px;
        z-index: 1;
        width: 164px;
        right: 1247px;
    }

    .auto-style6 {
        position: absolute;
        top: 861px;
        left: 269px;
        z-index: 1;
        width: 199px;
        right: 990px;
    }

    .auto-style7 {
        position: absolute;
        top: 862px;
        left: 502px;
        z-index: 1;
        width: 164px;
        right: 792px;
    }

    .auto-style8 {
        position: absolute;
        top: 861px;
        left: 697px;
        z-index: 1;
        width: 164px;
        right: 597px;
    }

    .auto-style9 {
        position: absolute;
        top: 860px;
        left: 914px;
        z-index: 1;
        width: 213px;
        right: 331px;
    }

    .auto-style10 {
        position: absolute;
        top: 861px;
        left: 1184px;
        z-index: 1;
        width: 164px;
        right: 110px;
    }

    table {
        font-family: arial, sans-serif;
        
    }
    .tableReports{
        font-family: arial, sans-serif;
        height: 300px;
        overflow-y: scroll;
        display: block;
        width: 50%;
        position: absolute;
        left: 120px;
        top: 370px;
    }
    
    .tableThesis{
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 50%;
    }

    .tableCourses{
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 50%;
    }
    .tableStudentThesis{
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 100%;
    }
    .tableStudentPublications{
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 50%;
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
        top: 827px;
        left: 504px;
        z-index: 1;
        width: 162px;
        right: 853px;
    }

    .auto-style12 {
        position: absolute;
        top: 827px;
        left: 698px;
        z-index: 1;
        width: 164px;
        right: 657px;
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
        top: 435px;
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
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supervisor</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <center>
            <h1>Supervisor Homepage</h1>
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
                <table style="width: 50%" runat="server" id="SupervisorProfileTable">
                    <tr>
                        <th>ID</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Name</th>
                        <th>Faculty</th>
                    </tr>
                </table>
            </center>
             <center>
                <table class="tableStudentThesis" style="width: 50%" runat="server" id="StudentThesisYearsTable">
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Years Spent</th>
                    </tr>
                </table>
            </center>
            <center>
                <div>
                    <table class="tableStudentPublications" style="width: 50%" runat="server" id="studentPublicationsTable">
                    <tr>
                        <th>ID</th>
                        <th>Title</th>
                        <th>Date Of Publication</th>
                        <th>Place</th>
                        <th>Accepted</th>
                        <th>Host</th>
                    </tr>
                    </table>
                    <br />
                    <center>
                        <asp:Label ID="StudentIdLabel" runat="server"  Text="Enter a Student ID: "></asp:Label>
                        <asp:TextBox Visible="true"  ID="StudentIdInputForPublication" runat="server"></asp:TextBox>
                    </center>
                    <br />
                    <center>
                         <asp:Button ID="GetStudentPublications" OnClick="onGetPublicationClicked" runat="server" Style="z-index: 1" Text="Get Publications" />
                    </center>
                </div>
            </center>
            <center>
                <div>
                    <center>
                        <asp:Label Visible="false" ID="SerialNumLabel" runat="server"  Text="Enter thesis serial number: "></asp:Label>
                        <asp:TextBox Visible="false" ID="SerialNumInput" runat="server"></asp:TextBox>
                    </center>
                    <br />
                    <center>
                        <asp:Calendar Visible="false" ID="DefenceDateInput" runat="server"></asp:Calendar>
                    </center>
                    <br />
                    <center>
                        <asp:Label Visible="false" ID="DefenceLocationLabel" runat="server"  Text="Enter defence Location: "></asp:Label>
                        <asp:TextBox maxLength="15" Visible="false" ID="DefenceLocationInput" runat="server"></asp:TextBox>
                    </center>
                    <br />
                    <center>
                         <asp:Button Visible="false" ID="AddDefenceButtonAction" OnClick="onAddDefenceActionClicked" runat="server" Style="z-index: 1" Text="Add Defence" />
                    </center>
                    <br />
                </div>
            </center>
        
            <center>
                    <div>
                        <center>
                            <asp:Label Visible="false" ID="ExaminerSerialNumLabel" runat="server"  Text="Enter thesis serial number: "></asp:Label>
                            <asp:TextBox Visible="false" ID="ExaminerSerialNumInput" runat="server"></asp:TextBox>
                        </center>
                        <br/>
                        <br/>
                        <center>
                            <asp:Label Visible="false" ID="ExaminerIdLabel" runat="server"  Text="Enter Examiner ID: "></asp:Label>
                            <asp:TextBox Visible="false" ID="ExaminerIdInput" runat="server"></asp:TextBox>
                        </center>
                        <br/>
                        <br/>
                        <center>
                            <asp:Button Visible="false" ID="AddExaminer" OnClick="onAddExaminerActionClicked" runat="server" Style="z-index: 1" Text="Add Examiner" />
                        </center>

                    </div>
            </center>
            <center>
                <div>
                    <center>
                        <asp:Label ID="PRthesisSerialNoLabel" runat="server"  Text="Enter thesis serial number: "></asp:Label>
                        <asp:TextBox ID="PRserialNoInput" runat="server"></asp:TextBox>
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="PRnumberLabel" runat="server"  Text="Enter the progress report number: "></asp:Label>
                        <asp:TextBox ID="PRnumberInput" runat="server"></asp:TextBox>
                    </center>
                    <br />
                    <center>
                        <asp:Label ID="PRevaluationLabel" runat="server"  Text="Choose the report Evaluation: "></asp:Label>
                        <asp:DropDownList ID="PRevaluationInput" runat="server">
                            <asp:ListItem Value=0>0</asp:ListItem>
                            <asp:ListItem Value=1>1</asp:ListItem>
                            <asp:ListItem Value=2>2</asp:ListItem>
                            <asp:ListItem Value=3>3</asp:ListItem>
                        </asp:DropDownList>
                    </center>
                    <br />
                    <center>
                            <asp:Button ID="addEvaluationButton" OnClick="onAddEvaluationButtonClicked" runat="server" Style="z-index: 1" Text="Add Evaluation" />
                    </center>

                </div>
            </center>
            <center>
                <div>
                    <center>
                        <asp:Label ID="CancelThesisSerialNumberLabel" runat="server"  Text="Enter thesis serial number: "></asp:Label>
                        <asp:TextBox ID="CancelThesisSerialNumberInput" runat="server"></asp:TextBox>
                    </center>
                    <br />
                    <br />
                    <center>
                            <asp:Button ID="CancelThesisBtn" OnClick="onCancelThesisBtnClicked" runat="server" Style="z-index: 1" Text="Cancel Thesis" />
                    </center>
                </div>
            </center>
        </div>

        <div>
            <asp:Button ID="ViewProfileButton" OnClick="onViewProfileClicked" runat="server" CssClass="auto-style11" Text="View your profile" />
            <asp:Button ID="ViewStudentsButton" OnClick="onViewStudentsClicked" runat="server" CssClass="auto-style5" Text="List your Students" />
            <asp:Button ID="ViewStudentPublicationButton" OnClick="onViewPublicationClicked" runat="server" CssClass="auto-style6" Text="View Student Publication" />
            <asp:Button ID="AddDefenceButton" OnClick="onAddDefenceClicked" runat="server" CssClass="auto-style7" Text="Add a Defence" />
            <asp:Button ID="AddExaminersButton" OnClick="onAddExaminersClicked" runat="server" CssClass="auto-style8" Text="Add Examiner(s)" />
            <asp:Button ID="EvaluateProgressReportButton" OnClick="onEvaluateProgressReportClicked" runat="server" CssClass="auto-style9" Text="Evaluate Progress Report" />
            <asp:Button ID="CancelThesisButton" OnClick="onCancelThesisClicked" runat="server" CssClass="auto-style10" Text="Cancel Thesis" />
            <asp:Button ID="AddNumberButton" OnClick="onAddPhoneNumberClicked" runat="server" CssClass="auto-style12" Text="Add a phone number" />
            <asp:Button ID="LogoutBtn" OnClick="onLogoutClicked" runat="server" style="position:absolute; top: 862px; left: 1379px;" Text="Log Out" />
        </div>
    </form>
</body>
</html>