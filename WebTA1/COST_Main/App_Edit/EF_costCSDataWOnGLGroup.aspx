<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costCSDataWOnGLGroup.aspx.vb" Inherits="EF_costCSDataWOnGLGroup" title="Edit: CS Data WO and GL Group wise" %>
<asp:Content ID="CPHcostCSDataWOnGLGroup" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostCSDataWOnGLGroup" runat="server" Text="&nbsp;Edit: CS Data WO and GL Group wise"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostCSDataWOnGLGroup" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostCSDataWOnGLGroup"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_costCSDataWOnGLGroup.aspx?pk="
    ValidationGroup = "costCSDataWOnGLGroup"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVcostCSDataWOnGLGroup"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision,WorkOrderTypeID,GLGroupID"
  DataSourceID = "ODScostCSDataWOnGLGroup"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin.Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin.Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear2_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Quarter."
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" runat="server" ForeColor="#CC6633" Text="Revision :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            ToolTip="Value of Revision."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WorkOrderTypeID" runat="server" ForeColor="#CC6633" Text="Work Order Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_WorkOrderTypeID"
            Width="88px"
            Text='<%# Bind("WorkOrderTypeID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Work Order Type."
            Runat="Server" />
          <asp:Label
            ID = "F_WorkOrderTypeID_Display"
            Text='<%# Eval("COST_WorkOrderTypes6_WorkOrderTypeDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" runat="server" ForeColor="#CC6633" Text="GL Group :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GLGroupID"
            Width="88px"
            Text='<%# Bind("GLGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of GL Group."
            Runat="Server" />
          <asp:Label
            ID = "F_GLGroupID_Display"
            Text='<%# Eval("COST_GLGroups3_GLGroupDescriptions") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CrAmount" runat="server" Text="CrAmount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CrAmount"
            Text='<%# Bind("CrAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costCSDataWOnGLGroup"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECrAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CrAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVCrAmount"
            runat = "server"
            ControlToValidate = "F_CrAmount"
            ControlExtender = "MEECrAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrAmount" runat="server" Text="DrAmount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DrAmount"
            Text='<%# Bind("DrAmount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costCSDataWOnGLGroup"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEDrAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_DrAmount" />
          <AJX:MaskedEditValidator 
            ID = "MEVDrAmount"
            runat = "server"
            ControlToValidate = "F_DrAmount"
            ControlExtender = "MEEDrAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            style="text-align: right"
            Width="136px"
            CssClass = "mytxt"
            ValidationGroup= "costCSDataWOnGLGroup"
            MaxLength="16"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmount"
            runat = "server"
            mask = "99999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmount"
            runat = "server"
            ControlToValidate = "F_Amount"
            ControlExtender = "MEEAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costCSDataWOnGLGroup"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostCSDataWOnGLGroup"
  DataObjectTypeName = "SIS.COST.costCSDataWOnGLGroup"
  SelectMethod = "costCSDataWOnGLGroupGetByID"
  UpdateMethod="UZ_costCSDataWOnGLGroupUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costCSDataWOnGLGroup"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Revision" Name="Revision" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="WorkOrderTypeID" Name="WorkOrderTypeID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLGroupID" Name="GLGroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
