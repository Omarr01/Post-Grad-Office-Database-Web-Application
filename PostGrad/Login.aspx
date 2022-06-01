<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PostGrad.Login" %>

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
        top: 467px;
        left: 592px;
        z-index: 1;
    }

    .auto-style4 {
        position: absolute;
        top: 467px;
        left: 764px;
        z-index: 1;
        right: 667px;
    }

    .auto-style5 {
        position: absolute;
        top: 467px;
        left: 916px;
        z-index: 1;
    }
    .auto-style6 {
        z-index: 1;
        left: 630px;
        top: 282px;
        position: absolute;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body style="height: 384px; width: 1951px;">
    <form id="form1" runat="server">
        <p class="double" style="position: absolute; top: 116px; left: 477px; height: 324px; width: 670px;">
        </p>
        <div style="height: 567px;">

            <asp:Label ID="Label1" runat="server" Text="Email:" CssClass="auto-style6"></asp:Label>
            <asp:Button  ID="loginbtn" runat="server" Style="z-index: 1; left: 755px; top: 367px; position: absolute; width: 150px;"
                OnClick="LoginBtn" Text="Log in" />
            <h1>
                <asp:Label ID="Label3" runat="server" Style="z-index: 1; left: 604px; top: 190px; position: absolute" Text="Hello, Please Log In"></asp:Label>
            </h1>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 630px; top: 327px; position: absolute" Text="Password:"></asp:Label>
            <asp:TextBox TextMode="Email" MaxLength="50" ID="userEmail" runat="server" Style="z-index: 1; left: 738px; top: 280px; position: absolute; width: 186px;"></asp:TextBox>
            <asp:TextBox TextMode="Password" MaxLength="30" ID="password" runat="server" Style="z-index: 1; left: 738px; top: 325px; position: absolute; width: 186px;"></asp:TextBox>

            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RegisterSupervisor.aspx" CssClass="auto-style1">Register as a Supervisor</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/StudentRegisterForm.aspx" CssClass="auto-style4">Register as a Student</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/RegisterExaminer.aspx" CssClass="auto-style5">Register as an Examiner</asp:HyperLink>

        </div>
    </form>
</body>
</html>
