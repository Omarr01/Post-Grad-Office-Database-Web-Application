<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegisterForm.aspx.cs" Inherits="PostGrad.StudentRegisterForm" %>

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
        top: 737px;
        left: 774px;
        z-index: 1;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 384px; width: 1951px;">
    <form id="form1" runat="server">
        <p class="double" style="position: absolute; top: 113px; left: 477px; height: 600px; width: 670px;">
        </p>
        <div style="height: 720px">
            
        <h1><asp:Label ID="Label3" runat="server" style="z-index: 1; left: 604px; top: 190px; position: absolute"  Text="Student Register"></asp:Label></h1>            

            <asp:Label ID="FirstNameLabel" runat="server"  Text="First Name:" style="z-index: 1; left: 630px; top: 282px; position: absolute"></asp:Label>
            <asp:Label ID="LastNameLabel" runat="server" Text="Last Name:" style="z-index: 1; left: 630px; top: 327px; position: absolute"></asp:Label>
            <asp:Label ID="EmailLabel" runat="server" Text="Email:" style="z-index: 1; left: 630px; top: 372px; position: absolute"></asp:Label>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password:" style="z-index: 1; left: 630px; top: 417px; position: absolute"></asp:Label> 
            <asp:Label ID="FacultyLabel" runat="server" Text="Faculty:" style="z-index: 1; left: 630px; top: 462px; position: absolute"></asp:Label>
            <asp:Label ID="AddressLabel" runat="server" Text="Address:" style="z-index: 1; left: 630px; top: 507px; position: absolute"></asp:Label>
            <asp:Label ID="GucianFlag" runat="server" Text="You are :" style="z-index: 1; left: 630px; top: 552px; position: absolute"></asp:Label>
  
             


            <asp:TextBox ID="FirstName" runat="server" style="z-index: 1; left: 738px; top: 280px; position: absolute; width: 186px;" ></asp:TextBox>
            <asp:TextBox ID="LastName" runat="server" style="z-index: 1; left: 738px; top: 325px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="Email" TextMode="Email" runat="server" style="z-index: 1; left: 738px; top: 370px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox TextMode="Password" ID="Password" runat="server" style="z-index: 1; left: 738px; top: 415px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="Faculty" runat="server" style="z-index: 1; left: 738px; top: 460px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox ID="Address" runat="server" style="z-index: 1; left: 738px; top: 505px; position: absolute; width: 186px;"></asp:TextBox>
             
            <asp:DropDownList ID="DropDownList" runat="server" style="z-index: 1; left: 738px; top: 550px; position: absolute; width: 186px;">
                <asp:ListItem Value="gucian">GUCian</asp:ListItem>
                <asp:ListItem Value="nonGucian">Non GUCian</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="RegisterButton" runat="server" style="z-index: 1; left: 755px; top:600px; position: absolute; width: 150px;" Text="Register" OnClick="onRegisterClicked"  />
                 
            
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" CssClass="auto-style1">Procced to login</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>