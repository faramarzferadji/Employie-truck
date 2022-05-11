<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ASP.Eploie.sql.Index" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Emploie Search Form</title>
    
    <style type="text/css">
.auto-style1 {
text-align: center;
color: saddlebrown;
}
.auto-style2 {
width: 417px;
}
.auto-style3 {
width: 400px;
}
.auto-style4 {
height: 55px;
width: 97px;
}
.auto-style5 {
margin-left: 0px;
margin-top: 0px;
}
.auto-style6 {
width: 273px;

}
.auto-style7 {
height: 55px;
width: 273px;
}
.auto-style8 {
margin-top: 0px;
border-radius:50px;
}
.auto-style9 {
width: 733px;
height: 581px;
}
.auto-style10 {
width: 97px;
}
.auto-style11 {
width: 500px;
}
.auto-style12 {
height: 116px;
}
.stylePanel {
border-radius:50px;
}
.tecboc {
border-radius:10px;
}
.auto-style14 {
text-align: center;
}
.auto-style15 {
margin-top: 0px;
border-radius:50px;

}
        #TextArea1 {
            width: 448px;
            height: 71px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style9">
        <div>
            <h1 class="auto-style2">  Emploie Search APP by SQL & Asp.NET</h1>
            <hr class="auto-style2" />
            <hr class="auto-style2"/>
            <table class="auto-style12">
                <td class="auto-style12">
                    <asp:Panel ID="PanelInfo" runat="server" CssClass="stylePanel" BackColor="#CC9900" GroupingText="Emoloie Info" Height="100%" Width="45%">
                        <table class="auto-style12">
                            <tr>
                                <td>
                                    <asp:Label ID="Labelcompany" runat="server" Text="name of company"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxcompany" runat="server"  CssClass="tecboc" Width="200px" OnTextChanged="TextBoxcompany_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="Labeposition" runat="server" Text="Which Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListPosition" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="Labelengine" runat="server" Text="Search Engine"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListengime" runat="server"></asp:DropDownList>

                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="Labeldate" runat="server" Text="Date of Request"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxdate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>

                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="Labelresult" runat="server" Text="Result"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxresult" runat="server" CssClass="tecboc" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                           

                        </table>

                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" CssClass="auto-style1" Height="100%" Width="700px">
                        <asp:Button ID="Buttonsave" runat="server" Text="Save" OnClick="Buttonsave_Click1" />
                         <asp:Button ID="Buttonshow" runat="server" Text="Show" OnClick="Buttonshow_Click" />
                         <asp:Button ID="Buttonuodate" runat="server" Text="Update" OnClick="Buttonuodate_Click" />
                         <asp:Button ID="Buttondelet" runat="server" Text="Delete" OnClick="Buttondelet_Click" />
                         <asp:Button ID="Buttonsearch" runat="server" Text="Search" OnClick="Buttonsearch_Click" />
                         <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click1" />
                    </asp:Panel>
                   <asp:GridView ID="GridV" runat="server" ShowFooter="true" FooterStyle-BackColor="Yellow" AutoGenerateColumns="false" OnRowDataBound="GridV_RowDataBound" OnSelectedIndexChanged="GridV_SelectedIndexChanged" >
                        <Columns>                         
                            <asp:BoundField DataField="id" HeaderText="ID"/>
                              <asp:BoundField  DataField="companie" HeaderText="company"/>
                            <asp:BoundField DataField="post" HeaderText="Position"/>
                            <asp:BoundField DataField="engine" HeaderText="Search Engine"/>
                            <asp:BoundField DataField="date" HeaderText="Search Date"/>
                            <asp:BoundField DataField="result" HeaderText="Result"/>            
                        </Columns>
                    </asp:GridView>
                </td>
                
            </table>
        </div>
    </form>
</body>
</html>
