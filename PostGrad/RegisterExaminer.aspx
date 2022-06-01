<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterExaminer.aspx.cs" Inherits="PostGrad.RegisterExaminer" %>

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
    .auto-style1 {
        position: absolute;
        top: 672px;
        left: 774px;
        z-index: 1;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p class="double" style="position: absolute; top: 113px; left: 477px; height: 522px; width: 670px;"></p>
        <div style="height: 567px;">
            <h1>
               <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 612px; top: 190px; position: absolute" Text="Examiner Register"></asp:Label>
            </h1>
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 630px; top: 282px; position: absolute" Text="Name:"></asp:Label>
            <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 630px; top: 327px; position: absolute" Text="Email:"></asp:Label>
            <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 630px; top: 372px; position: absolute" Text="Password:"></asp:Label>
            <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 630px; top: 417px; position: absolute" Text="Field of work:"></asp:Label>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 630px; top: 462px; position: absolute" Text="Nationallity:"></asp:Label>

            <asp:TextBox ID="Name" runat="server" style="z-index: 1; left: 738px; top: 280px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="emailExam" TextMode="Email" runat="server" style="z-index: 1; left: 738px; top: 325px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox TextMode="Password" ID="Password" runat="server" style="z-index: 1; left: 738px; top: 370px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="fieldExam" runat="server" style="z-index: 1; left: 738px; top: 415px; position: absolute; width: 186px;"></asp:TextBox>
            
    
            <asp:Button ID="regbtn" runat="server" style="z-index: 1; left: 755px; top: 517px; position: absolute; width: 150px;" 
               OnClick ="regBtn" Text="Register" />
            
            <asp:DropDownList ID="DropDownList" runat="server" style="z-index: 1; left: 738px; top:462px; position: absolute; width: 186px;">
                <asp:ListItem Value="egyptian">Egyptian</asp:ListItem>
                <asp:ListItem Value="nonEgyptian">Foreigner</asp:ListItem>
            </asp:DropDownList>

            <asp:HyperLink ID="HyperLinkLogIn" NavigateUrl ="~/Login.aspx" runat="server" CssClass="auto-style1">Procced to login</asp:HyperLink>


        </div>
    </form>
</body>
</html>
