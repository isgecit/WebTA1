<%@ Page Language="VB" AutoEventWireup="false" CodeFile="temp-D.aspx.vb" Inherits="TA_Main_App_Create_temp_D" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="SHORTCUT ICON" type="image/x-icon" runat="server" href="~/isgec.ico" />
  <link rel="stylesheet" href="/../UserRights/Menu/Menu.css" />
  <script type="text/javascript" src="/../UserRights/jquery/jquery.js"></script>
  <link rel="stylesheet" href="/../UserRights/jquery/themes/smoothness/jquery-ui.css" />
  <script type="text/javascript" src="/../UserRights/jquery/jquery-ui.js"></script>
  <script type="text/javascript">
    $(function () {
      $(".page").resizable();
    });
  </script>

</head>
<body>
    <form id="form1" runat="server">
  <ASP:ScriptManager ID="ToolkitScriptManager1" EnableScriptGlobalization="true" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="3600" EnableScriptLocalization="True" ScriptMode="Auto">
    <Scripts>
        <asp:ScriptReference Path="/../UserRights/jquery/webkit.js" />
    </Scripts>
  </ASP:ScriptManager>
    <div>
        <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td>
          <b><asp:Label ID="L_TABillNo" ForeColor="#CC6633" runat="server" Text="TA Bill No" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="88px"
            Runat="Server" />
        </td>
      </tr>
      </table>
      <table>
        <tr>
        <td>
          <asp:Label ID="L_City1Text" runat="server" Text="From Place" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_City2Text" runat="server" Text="To Place" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_Date1Time" runat="server" Text="Date" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:Label ID="L_ModeLCID" runat="server" Text="Mode" />
        </td>
        <td>
          <asp:Label ID="L_ModeText" runat="server" Text="Other Mode" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_AirportToHotel" runat="server" Text="Airport To Hotel" />
        </td>
        <td>
          <asp:Label ID="L_AmountRateOU" runat="server" Text="Claimed Amount" />&nbsp;
        </td>
        <td>
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks" />&nbsp;
        </td>

        </tr>
        <tr>
        <td>
          <asp:TextBox ID="F_City1Text"
            ClientIDMode="Static"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBDLC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for From Place."
            MaxLength="100"
            Width="50px" 
            runat="server" />
        </td>
        <td>
          <asp:TextBox ID="F_City2Text"
            ClientIDMode="Static"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBDLC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for To Place."
            MaxLength="100"
            Width="50px" 
            runat="server" />
        </td>
        <td>
          <asp:TextBox ID="F_Date1Time"
            ClientIDMode="Static"
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="taBDLC"
            onfocus = "return this.select();"
            runat="server" />
        </td>
        <td>
          <LGM:LC_taLCModes
            ID="F_ModeLCID"
            ClientIDMode="Static"
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="50px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td>
          <asp:TextBox ID="F_ModeText"
            ClientIDMode="Static"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Conveyance Mode [ If not found in List ]."
            MaxLength="100"
            Width="50px" 
            runat="server" />
        </td>
        <td>
          <asp:CheckBox ID="F_AirportToHotel"
           ClientIDMode="Static"
           CssClass = "mychk"
           runat="server" />
        </td>
        <td>
          <asp:TextBox ID="F_AmountRateOU"
            ClientIDMode="Static"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            ClientIDMode="Static"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="50px" 
            runat="server" />
        </td>

        </tr>
      </table>

    </div>
    </form>
</body>
</html>
