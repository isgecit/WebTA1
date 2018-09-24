<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costCostSheet.aspx.vb" Inherits="EF_costCostSheet" title="Edit: Cost Sheet" %>
<asp:Content ID="CPHcostCostSheet" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostCostSheet" runat="server" Text="&nbsp;Edit: Cost Sheet"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostCostSheet" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostCostSheet"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_costCostSheet.aspx?pk="
    ValidationGroup = "costCostSheet"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=150,height=100,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVcostCostSheet"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision"
  DataSourceID = "ODScostCostSheet"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("COST_ProjectGroups5_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin. Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin. Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear4_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
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
            Text='<%# Eval("COST_Quarters6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
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
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("COST_CostSheetStates3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LockERPData" runat="server" Text="Cost Sheet Checked :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_LockERPData"
            Checked='<%# Bind("LockERPData") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Remarks" runat="server" Text="Provision to be Adjusted :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            MaxLength="250"
            Enabled="false"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemarks" runat="server" Text="Approver Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemarks"
            Text='<%# Bind("ApproverRemarks") %>'
            ToolTip="Value of Approver Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostProjectsInputAC" runat="server" Text="&nbsp;List: Projects Input Data"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectsInputAC" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectsInputAC"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectsInputAC.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "costProjectsInputAC"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectsInputAC" runat="server" AssociatedUpdatePanelID="UPNLcostProjectsInputAC" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostProjectsInputAC" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectsInputAC" DataKeyNames="ProjectGroupID,FinYear,Quarter">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Order Value [INR]" SortExpression="GroupOrderValueINR">
          <ItemTemplate>
            <asp:Label ID="LabelGroupOrderValueINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GroupOrderValueINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Revenue By AC [INR]" SortExpression="ProjectRevenueByACINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectRevenueByACINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectRevenueByACINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Margin By AC [INR]" SortExpression="ProjectMarginByACINR">
          <ItemTemplate>
            <asp:Label ID="LabelProjectMarginByACINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectMarginByACINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Export Incentive By AC [INR]" SortExpression="ExportIncentiveByACINR">
          <ItemTemplate>
            <asp:Label ID="LabelExportIncentiveByACINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExportIncentiveByACINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Approved By" SortExpression="aspnet_users2_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ApprovedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ApprovedBy") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostProjectsInputAC"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectsInputAC"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costProjectsInputACSelectList"
      TypeName = "SIS.COST.costProjectsInputAC"
      SelectCountMethod = "costProjectsInputACSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectsInputAC" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostAdjustmentEntry" runat="server" Text="&nbsp;List: Adjustment Entry"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostAdjustmentEntry" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostAdjustmentEntry"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costAdjustmentEntry.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costAdjustmentEntry.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "costAdjustmentEntry"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostAdjustmentEntry" runat="server" AssociatedUpdatePanelID="UPNLcostAdjustmentEntry" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostAdjustmentEntry" SkinID="gv_silver" runat="server" DataSourceID="ODScostAdjustmentEntry" DataKeyNames="ProjectGroupID,FinYear,Quarter,Revision,AdjustmentSerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Adjustment Serial No" SortExpression="AdjustmentSerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelAdjustmentSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AdjustmentSerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects8_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cr. GL Code" SortExpression="COST_ERPGLCodes3_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_CrGLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CrGLCode") %>' Text='<%# Eval("COST_ERPGLCodes3_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dr. GL Code" SortExpression="COST_ERPGLCodes4_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_DrGLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DrGLCode") %>' Text='<%# Eval("COST_ERPGLCodes4_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostAdjustmentEntry"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costAdjustmentEntry"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costAdjustmentEntrySelectList"
      TypeName = "SIS.COST.costAdjustmentEntry"
      SelectCountMethod = "costAdjustmentEntrySelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Revision" PropertyName="Text" Name="Revision" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostAdjustmentEntry" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostCSDWOnGLGr" runat="server" Text="&nbsp;List: Work Order and GL Group wise"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostCSDWOnGLGr" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostCSDWOnGLGr"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costCSDWOnGLGr.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costCSDWOnGLGr.aspx"
      EnableExit = "false"
      ValidationGroup = "costCSDWOnGLGr"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostCSDWOnGLGr" runat="server" AssociatedUpdatePanelID="UPNLcostCSDWOnGLGr" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostCSDWOnGLGr" SkinID="gv_silver" runat="server" DataSourceID="ODScostCSDWOnGLGr" DataKeyNames="ProjectGroupID,FinYear,Quarter,Revision,WorkOrderTypeID,GLGroupID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Work Order Type" SortExpression="COST_WorkOrderTypes6_WorkOrderTypeDescription">
          <ItemTemplate>
             <asp:Label ID="L_WorkOrderTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("WorkOrderTypeID") %>' Text='<%# Eval("COST_WorkOrderTypes6_WorkOrderTypeDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Group" SortExpression="COST_GLGroups3_GLGroupDescriptions">
          <ItemTemplate>
             <asp:Label ID="L_GLGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLGroupID") %>' Text='<%# Eval("COST_GLGroups3_GLGroupDescriptions") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CrAmount" SortExpression="CrAmount">
          <ItemTemplate>
            <asp:Label ID="LabelCrAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CrAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DrAmount" SortExpression="DrAmount">
          <ItemTemplate>
            <asp:Label ID="LabelDrAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DrAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostCSDWOnGLGr"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costCSDWOnGLGr"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costCSDWOnGLGrSelectList"
      TypeName = "SIS.COST.costCSDWOnGLGr"
      SelectCountMethod = "costCSDWOnGLGrSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Revision" PropertyName="Text" Name="Revision" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostCSDWOnGLGr" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostCostSheetData" runat="server" Text="&nbsp;List: Cost Sheet Data"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostCostSheetData" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostCostSheetData"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costCostSheetData.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "costCostSheetData"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostCostSheetData" runat="server" AssociatedUpdatePanelID="UPNLcostCostSheetData" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostCostSheetData" SkinID="gv_silver" runat="server" DataSourceID="ODScostCostSheetData" DataKeyNames="ProjectGroupID,FinYear,Quarter,Revision,ProjectID,GLCode,AdjustmentSerialNo,AdjustmentCredit">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects6_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Code" SortExpression="COST_ERPGLCodes2_GLDescription">
          <ItemTemplate>
             <asp:Label ID="L_GLCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLCode") %>' Text='<%# Eval("COST_ERPGLCodes2_GLDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Adjustment Serial No" SortExpression="AdjustmentSerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelAdjustmentSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AdjustmentSerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cr. Amount" SortExpression="CrAmount">
          <ItemTemplate>
            <asp:Label ID="LabelCrAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CrAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dr. Amount" SortExpression="DrAmount">
          <ItemTemplate>
            <asp:Label ID="LabelDrAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DrAmount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostCostSheetData"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costCostSheetData"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costCostSheetDataSelectList"
      TypeName = "SIS.COST.costCostSheetData"
      SelectCountMethod = "costCostSheetDataSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Revision" PropertyName="Text" Name="Revision" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostCostSheetData" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostCostSheet"
  DataObjectTypeName = "SIS.COST.costCostSheet"
  SelectMethod = "costCostSheetGetByID"
  UpdateMethod="UZ_costCostSheetUpdate"
  DeleteMethod="UZ_costCostSheetDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costCostSheet"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Revision" Name="Revision" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
