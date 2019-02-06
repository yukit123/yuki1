<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateInput.aspx.cs" Inherits="Webform2.ValidateInput" %>
<script>
    function Button_Click() {
        Label1.Text = Server.HtmlEncode(TextBox1.Text);
    }
</script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button onclick="Button_Click()" ID="Button1" runat="server" Text="Click_Me" />
        </div>
    </form>
    You enterd:<b><asp:Label ID="Label1" runat="server"></asp:Label>
</body>
</html>
