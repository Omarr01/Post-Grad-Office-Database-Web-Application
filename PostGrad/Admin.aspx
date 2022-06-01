<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PostGrad.Admin" %>

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

    .auto-style5 {
        position: absolute;
        top: 857px;
        left: 450px;
        z-index: 1;
        width: 164px;
        right: 1048px;
    }

    .auto-style6 {
        position: absolute;
        top: 857px;
        left: 660px;
        z-index: 1;
        width: 164px;
        right: 845px;
    }

    .auto-style7 {
        position: absolute;
        top: 857px;
        left: 860px;
        z-index: 1;
        width: 164px;
        right: 650px;
    }

    .auto-style8 {
        position: absolute;
        top: 857px;
        left: 1070px;
        z-index: 1;
        width: 164px;
        right: 455px;
    }

    .auto-style9 {
        position: absolute;
        top: 857px;
        left: 1275px;
        z-index: 1;
        width: 182px;
        right: 101px;
    }
    table {
        font-family: arial, sans-serif;
    }
    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #dddddd;
    }
    .tableSup {
        font-family: arial, sans-serif;
        height: 200px;
        overflow-y: scroll;
        display: block;
        width: 32%;
    }
    .tableThesis {
        font-family: arial, sans-serif;
        height: 300px;
        overflow-y: scroll;
        display: block;
        width: 55%;
    }
    .auto-style63 {
        position: absolute;
        top: 938px;
        left: 1700px;
        z-index: 1;
        width: 164px;
        right: 11px;
    }
    .auto-style2 {
        z-index: 1;
        left: 216px;
        top: 293px;
        position: absolute;
    }
     .auto-style3 {
        position: absolute;
        left: 215px;
        top: 314px;
        margin-top: 12px;
    }
     .auto-style4 {
        position: absolute;
        top: 326px;
        left: 404px;
        z-index: 1;
        width: 186px;
        right: 968px;
    }
    </style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <center>
            <h1>Admin Homepage</h1>
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
                <table runat="server" id="superTable" class="tableSup">
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
                <table class="tableThesis" runat="server" id="adminListThesis">
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
                        <th>Payment ID</th>
                        <th>num Of Extensions</th>
                    </tr>
                </table>
            </center>

             <center>
                <asp:Label ID="serialNumberLabel" runat="server" Visible="false" style="position:absolute; top: 301px; left: 612px;" Text="Enter Thesis Serial Number: "></asp:Label>

                <asp:TextBox ID="serialNumberInput" runat="server" Visible="false" style="position:absolute; top: 303px; left: 847px;" MaxLength="20" ></asp:TextBox>
                <asp:Label ID="amountLabel"  runat="server" Visible="false" style="position:absolute; top: 333px; left: 628px;" Text="Enter payment amount: "></asp:Label>

                <asp:TextBox ID="amountInput" runat="server" Visible="false" style="position:absolute; top: 336px; left: 822px;"  MaxLength="20" ></asp:TextBox>
         
                <asp:Label ID="noOfInstallLabel" Visible="false" runat="server" style="position:absolute; top: 387px; left: 606px;"  Text="Enter number of installments: "></asp:Label>
                <asp:TextBox ID="noOfInstallInput" Visible="false" runat="server" style="position:absolute; top: 389px; left: 852px;" MaxLength="20" ></asp:TextBox>
           
                <asp:Label ID="fundPercentageLabel" Visible="false" runat="server" style="position:absolute; top: 435px; left: 624px;"  Text="Enter fund percentage: "></asp:Label>
                <asp:TextBox ID="fundPercentageInput" Visible="false" type="number" step="0.01" runat="server"  style="position:absolute; top: 443px; left: 817px;" MaxLength="20" ></asp:TextBox>
                <asp:Button ID="AddPaymentbtn" Visible="false" OnClick="onAddPaymentBtnClicked" runat="server" style="position:absolute; top: 499px; left: 742px;" Text="Add Payment" />
            </center>


             <asp:Button ID="logout" OnClick="logoutBtn" runat="server" CssClass="auto-style63" Text="Logout" />
        </div>

        <div>

            <asp:Button ID="ListSup" OnClick="listSupBtn" runat="server" CssClass="auto-style5" Text="List all supervisors" />
            <asp:Button ID="ListThesis" OnClick="listThesBtn"  runat="server" CssClass="auto-style6" Text="List all Thesis" />
             <asp:Button ID="AddPayment"  runat="server" CssClass="auto-style7" OnClick="onAddPaymentClicked" Text="Add Payment" />
            <asp:Button ID="hanafyawhoka2"  runat="server" CssClass="auto-style8" Text="" />
            <asp:Button ID="ExtensionBtn" OnClick="ExtensionButton" runat="server" CssClass="auto-style9" Text="Add an Extension to a Thesis" />
            <asp:Button ID="AddExt" OnClick="AddExtension" runat="server" CssClass="auto-style4" Text="Add"/>
            
            <asp:Label ID="EnterThesis"  runat="server" Text="Enter Thesis Serial Number:" CssClass="auto-style2"></asp:Label>

            <asp:TextBox ID="ThesisSerialNumber" runat="server" CssClass="auto-style3" MaxLength="20" ></asp:TextBox>

        </div>
    </form>
</body>
</html>
