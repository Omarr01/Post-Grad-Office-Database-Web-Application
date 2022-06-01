<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner.aspx.cs" Inherits="PostGrad.Examiner" %>

<!DOCTYPE html>
<style>
    h1 {
        font-family: 'Candara', cursive;
        font-size: 50px;
        color: #406882;
    }
     .auto-style13 {
        position: absolute;
        top: 762px;
        left: 90px;
        z-index: 1;
        width: 186px;
        right: 801px;
    }

     .auto-style68 {
        position: absolute;
        top: 440px;
        left: 239px;
        z-index: 1;
        width: 186px;
        right: 820px;
    }

     .auto-style3 {
        position: absolute;
        top: 762px;
        left: 291px;
        z-index: 1;
        width: 177px;
        }
  
    .auto-style15 {
        position: absolute;
        top: 762px;
        left: 487px;
        z-index: 1;
        width: 164px;
        right: 426px;
    }
     
    .auto-style16 {
        position: absolute;
        top: 537px;
        left: 236px;
        z-index: 1;
        width: 164px;
        right: 845px;
    }
    .auto-style17 {
        position: absolute;
        top: 762px;
        left: 675px;
        z-index: 1;
        width: 164px;
        right: 238px;
    }
     .auto-style18 {
        position: absolute;
        top: 439px;
        left: 238px;
        z-index: 1;
        width: 164px;
        right: 843px;
    }
      .auto-style19 {
        position: absolute;
        top: 762px;
        left: 859px;
        z-index: 1;
        width: 164px;
        right: 54px;
    }
       .auto-style34 {
        position: absolute;
        top: 365px;
        left: 36px;
        z-index: 1;
        width: 164px;
        right: 1044px;
    }
      .auto-style20 {
        z-index: 1;
        left: 235px;
        top: 289px;
        position: absolute;
    }

    .auto-style21 {
        z-index: 1;
        left: 235px;
        top: 364px;
        position: absolute;
    }
     .auto-style25 {
        position: absolute;
        left: 235px;
        top: 313px;
        margin-top: 12px;
    }

       .auto-style27 {
        z-index: 1;
        left: 235px;
        top: 289px;
        position: absolute;
        margin-top: 0px;
    }
     .auto-style28 {
        position: absolute;
        left: 235px;
        top: 313px;
        margin-top: 12px;
    }

    .auto-style26 {
        position: absolute;
        left: 235px;
        top: 397px;
        margin-top: 0px;
    }

     .auto-style30 {
        position: absolute;
        left: 235px;
        top: 397px;
        height: 111px;
        width: 363px;
    }


      .auto-style31 {
        z-index: 1;
        left: 235px;
        top: 364px;
        position: absolute;
    }
       .auto-style32 {
        z-index: 1;
        left: 235px;
        top: 364px;
        position: absolute;
    }
        .auto-style33 {
        position: absolute;
        left: 235px;
        top: 397px;
        margin-top: 0px;
    }
             .auto-style35 {
        z-index: 1;
        left: 36px;
        top: 289px;
        position: absolute;
    }

 .auto-style36 {
        position: absolute;
        left: 36px;
        top: 325px;
        height: 14px;
        width: 160px;
    }
 .auto-style37 {
        position: absolute;
        top: 762px;
        left: 1043px;
        z-index: 1;
        width: 164px;
        right: 54px;
    }

    .table{
        font-family:Arial, sans-serif;
      display:block;
      position:absolute;

        overflow-y:scroll;
        height:200px;
        top: 174px;
        left: 215px;
    }
    .table2{
        font-family:Arial, sans-serif;
      display:block;
      position:absolute;

        overflow-y:scroll;
        height:200px;
        top: 174px;
        left: 569px;
    }
    td,th{
        border:1px solid #dddddd;
        text-align:left;
        padding:8px;
    }
    tr:nth-child(even){
        background-color:#dddddd;
    }
    #Text1 {
        width: 566px;
        margin-top: 0px;
        height: 124px;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Examiner</title>
</head>
<body>
    <form id="form1" runat="server">
         <br />
        <center>
            <h1>Examiner Homepage</h1>
        </center>
        <br />
        <div style="height: 700px; border-style: double">
        <center>
                <table   style="width: 50%" runat="server" id="ExaminerProfileTable" >
                    <tr>
                        <th>Name</th>
                        <th>Field Of Work</th>
                       
                    </tr>
                    
                </table>

           
            </center>
             <center>

                <table   Class="table2" runat="server" id="Table1" visible="false">
                    <tr>
                        <th>Thesis Title</th>
                        <th>Supervisor</th>
                        <th>Student First Name</th>
                        <th>Student Last Name</th>
                       
                    </tr>
                    
                </table>

           
            </center>
             <center>

                <table   Class="table" runat="server" id="Table2" visible="false">
                    <tr>
                         <th>Serial No.:</th>
                         <th>Field:</th>
                         <th>Type:</th>
                        <th>Thesis Title:</th>
                        <th>Start Date:</th>
                         <th>End Date:</th>
                         <th>Defense Date:</th>
                        <th>Years:</th>
                         <th>Grade:</th>
                         <th>Payment ID:</th>
                        <th>No. of Extensions:</th>
                      
                       
                    </tr>
                    
                </table>

           
            </center>
            </div>
        
              <br />
            <br />

            
            <br />
       
           
        <div>
          
            
                      
        <asp:Button ID="EditProfile" OnClick="editPrfBtn" runat="server" CssClass="auto-style13" Text="Edit your personal information" />
        <asp:Button ID="UpdateProfile" OnClick="updatePrfBtn" runat="server" CssClass="auto-style68" Text="update personal information" Visible="false"/>   
        <asp:Button ID="ViewDefenseInfo" OnClick="dfnsInfBtn" runat="server" CssClass="auto-style3" Text="View Defense(s) Information" />
        <asp:Button ID="AddComments" OnClick="addCmntsBtn" runat="server" CssClass="auto-style15" Text="Comment on a Defense" />
            <asp:Button ID="AddComments2" OnClick="addCmntsBtn2" runat="server" CssClass="auto-style16" Text="Add your Comments" Visible="false"/>
            <asp:Button ID="AddGrade" OnClick="addGrdBtn" runat="server" CssClass="auto-style17" Text="Add Grade for a Defense" />
            <asp:Button ID="AddGrade2" OnClick="addGrdBtn2" runat="server" CssClass="auto-style18" Text="Add Grade" Visible="false"/>
            <asp:Button ID="SelectThesis" OnClick="slctThsBtn" runat="server" CssClass="auto-style19" Text="Find Thesis" />
            <asp:Button ID="SelectThesis2" OnClick="slctThsBtn2" runat="server" CssClass="auto-style34" Text="Search for Thesis" Visible="false"/>
            <asp:Button ID="LogOut" OnClick="logOutBtn" runat="server" CssClass="auto-style37" Text="Log Out"/>

            <asp:Label ID="upname" Visible="false" runat="server" Text="update name:" CssClass="auto-style20"></asp:Label>

            <asp:Label ID="upfield" Visible="false" runat="server" Text="update field:" CssClass="auto-style21"></asp:Label>

            <asp:TextBox ID="newname" runat="server" CssClass="auto-style25" Visible="false" MaxLength="20" ></asp:TextBox>

            <asp:TextBox ID="newfield" runat="server" CssClass="auto-style26" Visible="false" MaxLength="100" ></asp:TextBox>

            <asp:Label ID="thesserno" Visible="false" runat="server" Text="Enter The Thesis Serial No.:" CssClass="auto-style27"></asp:Label>

            <asp:TextBox ID="enterthesserno" runat="server" CssClass="auto-style28" Visible="false" type="number"></asp:TextBox>

            <asp:Label ID="cmntslabel" Visible="false" runat="server" Text="Add Comments:" CssClass="auto-style31"></asp:Label>

             <asp:TextBox id="cmtstext" type="text" Visible="false" runat="server" maxlength="300" class="auto-style30"/></asp:TextBox>
             
            <asp:Label ID="GradeLabel" Visible="false" runat="server" Text="Add Grade:" CssClass="auto-style32"></asp:Label>

             <asp:TextBox id="GradeText" type="number" step="0.01" Visible="false" runat="server" maxlength="4" class="auto-style33" /></asp:TextBox>

              <asp:Label ID="Thesissearch" Visible="false" runat="server" Text="Enter Thesis Keyword(s):" CssClass="auto-style35"></asp:Label>

             <asp:TextBox id="ThesisText" type="text" Visible="false" runat="server" maxlength="100" class="auto-style36"/></asp:TextBox>
        </div>
    </form>
</body>
</html>
