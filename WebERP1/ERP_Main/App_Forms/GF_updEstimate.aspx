<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_updEstimate.aspx.vb" Inherits="GF_updEstimate" title="Update Estimate" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;UPDATE Estimate" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <asp:UpdateProgress ID="UPGSlgDMisg" runat="server" AssociatedUpdatePanelID="UPNLlgDMisg" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
    <br />
    <table>
			<tr>
				<td class="alignright">
          <div id="F_Upload" runat="server" style="margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" >
            <table>
              <tr>
                <td colspan="4">
                  <asp:Label ID="errMsg" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
                </td>
              </tr>
              <tr>
                <td><b>Upload Estimate</b></td>
                <td>
                </td>
                <td>
                    <asp:FileUpload ID="F_FileUpload" runat="server" />
                </td>
                <td>
                  <asp:Button ID="cmdFileUpload" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                </td>
              </tr>
            </table>
          </div>
				</td>
			</tr>
    </table>
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
		<asp:PostBackTrigger ControlID="cmdFileUpload" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
