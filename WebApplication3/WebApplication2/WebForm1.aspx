<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
function CloseWebPage(){
  if (navigator.userAgent.indexOf("MSIE") > 0) {
   if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
    window.opener = null;
    window.close();
   } else {
    window.open('', '_top');
    window.top.close();
   }
  }
  else if (navigator.userAgent.indexOf("Firefox") > 0) {
   window.location.href = 'about:blank ';
  } else {
   window.opener = null;
   window.open('', '_self', '');
   window.close();
  }
 } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button onclick="CloseWebPage()">点我关闭窗口</button>
  
        </div>
    </form>
</body>
</html>
