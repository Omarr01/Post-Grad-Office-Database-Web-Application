<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterSupervisor.aspx.cs" Inherits="PostGrad.RegisterSupervisor" %>

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
        right: 740px;
        position: absolute;
        top: 664px;
        left: 776px;
    }
    .auto-style2 {
        z-index: 1;
        left: 738px;
        top: 370px;
        position: absolute;
        width: 186px;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 384px; width: 1951px;">
    <form id="form1" runat="server">
        <p class="double" style="position: absolute; top: 113px; left: 477px; height: 522px; width: 670px;"></p>
        <div style="height: 567px;">
            <h1>
               <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 604px; top: 190px; position: absolute" Text="Supervisor Register"></asp:Label>
            </h1>
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 630px; top: 282px; position: absolute" Text="First Name:"></asp:Label>
            <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 630px; top: 327px; position: absolute" Text="Last Name:"></asp:Label>
            <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 630px; top: 372px; position: absolute" Text="Email:"></asp:Label>
            <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 630px; top: 417px; position: absolute" Text="Password:"></asp:Label>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 630px; top: 462px; position: absolute" Text="Faculty:"></asp:Label>

            <asp:TextBox ID="firstName" runat="server" style="z-index: 1; left: 738px; top: 280px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="lastName" runat="server" style="z-index: 1; left: 738px; top: 325px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="emailSup" TextMode="Email" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:TextBox TextMode="Password" ID="passwordSup" runat="server" style="z-index: 1; left: 738px; top: 415px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="facultySup" runat="server" style="z-index: 1; left: 738px; top: 460px; position: absolute; width: 186px;"></asp:TextBox>
    
            <asp:Button ID="regbtn" runat="server" style="z-index: 1; left: 755px; top: 517px; position: absolute; width: 150px;" 
               OnClick ="regBtn" Text="Register" />

            <asp:HyperLink ID="HyperLinkLogIn" NavigateUrl ="~/Login.aspx" runat="server" CssClass="auto-style1">Procced to login</asp:HyperLink>


        </div>
    </form>
</body>
</html>
