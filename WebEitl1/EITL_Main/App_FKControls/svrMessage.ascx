<%@ Control Language="VB" AutoEventWireup="false" CodeFile="svrMessage.ascx.vb" Inherits="svrMessage" %>
    <asp:Label ID="dummy" runat="server" Text="dummy" style="display:none" ></asp:Label>
    <asp:Panel ID="svrMsg" runat="server" Style="display:none; width: 1080px" CssClass="modalPopup">
      <table style="width: 100%">
        <tr>
          <td style="background-color: Navy">
            <asp:Image ID="Image2" runat="server" AlternateText="Task" ToolTip="Task" ImageUrl="~/App_Themes/Default/Images/application.png" />
          </td>
          <td id="dragOTPLinkCLP" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White; height: 24px">
            Link Task with CLP
          </td>
          <td style="background-color: Navy; text-align: right">
            <asp:ImageButton ID="closeOTPLinkCLP" runat="server" Height="20px" Width="20px" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
          </td>
        </tr>
      </table>
    <asp:Label ID="F_ErrMsg" ForeColor="Red" Font-Size="10px" style="display:block" runat="server" Text="" />
    <div id="divHdr" style="width:100%">&nbsp;</div>
    <div id="divCLP" style="width:100%;height:400px;overflow:scroll">&nbsp;</div>
    <table width="100%">
      <tr>
      <td style="text-align:center">
        <input type="button" value="Cancel" onclick="lc_OTPLinkCLP.hidePop();" style="background-color: silver;color: Red" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:ModalPopupExtender BehaviorID="mpeOTPLinkCLP" PopupControlID="svrMsg" OkControlID="closeOTPLinkCLP" CancelControlID="closeOTPLinkCLP" PopupDragHandleControlID="dragOTPLinkCLP" ID="ModalPopupExtender2" runat="server" TargetControlID="dummy" BackgroundCssClass="modalBackground" DropShadow="true" />
