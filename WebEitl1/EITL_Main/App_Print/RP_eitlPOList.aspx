<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RP_eitlPOList.aspx.vb" Inherits="RP_eitlPOList" title="Print: PO List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<style>
  body{margin: 10px auto auto 60px;}
  td{padding-left: 4px;}
  .tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}
</style>
</head>
<body>
<form id="form1" runat="server">
<asp:Table ID="tblMain" runat="server">
</asp:Table>
</form>
</body>
</html>
