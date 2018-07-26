<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Close.aspx.cs" Inherits="WebApplication2.Close" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    function NewWindow() {
        //document.forms[0].target = "_blank";
    
       // parent.location.href = "http://translate.google.com/translate?js=n&sl=auto&tl=it&u=http://michelangelo.nu/eventkalender3.aspx";
        window.open('http://translate.google.com/translate?js=n&sl=auto&tl=it&u=http://michelangelo.nu/eventkalender3.aspx');
        window.close();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/test.jpg" Height="19px" Width="19px" OnClientClick="NewWindow();" PostBackUrl="http://translate.google.com/translate?js=n&sl=auto&tl=it&u=http://michelangelo.nu/eventkalender3.aspx"></asp:ImageButton>
        </div>
    </form>
</body>
</html>
