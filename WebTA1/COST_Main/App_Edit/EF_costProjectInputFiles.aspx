<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjectInputFiles.aspx.vb" Inherits="EF_costProjectInputFiles" title="Edit: Project Input Attachment" %>
<asp:Content ID="CPHcostProjectInputFiles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectInputFiles" runat="server" Text="&nbsp;Edit: Project Input Attachment"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectInputFiles" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectInputFiles"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costProjectInputFiles"
    runat = "server" />
<asp:FormView ID="FVcostProjectInputFiles"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,SerialNo"
  DataSourceID = "ODScostProjectInputFiles"
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
            Text='<%# Eval("COST_ProjectGroups2_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin Year :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear1_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("COST_ProjectsInput3_GroupOrderValueINR") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjectInputFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectInputFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="File Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:Label ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostProjectInputFiles"
  DataObjectTypeName = "SIS.COST.costProjectInputFiles"
  SelectMethod = "costProjectInputFilesGetByID"
  UpdateMethod="UZ_costProjectInputFilesUpdate"
  DeleteMethod="UZ_costProjectInputFilesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectInputFiles"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
