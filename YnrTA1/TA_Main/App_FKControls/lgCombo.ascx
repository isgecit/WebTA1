<%@ Control Language="VB" AutoEventWireup="false" CodeFile="lgCombo.ascx.vb" Inherits="lgCombo" %>
<script type="text/javascript">
  var script_lgCombo = {
    interval: 100,
    ddtxt: '',
    ddpnl: '',
    ddpgm: '',
    downloading: false,
    timerON: false,
    rendering: false,
    start: function (o, p, q) {
      this.ddtxt = $get(o);
      this.ddpnl = $get(p);
      this.ddpgm = q;
      this.ddpnl.top = this.element.top + this.element.offsetHeight;
      this.ddpnl.left = this.element.left;
      this.ddpnl.style.display = 'none';
      //this.element.onkeydown = function () { this.download; }
      this.attach(this.ddtxt, 'keydown', this.download);
    },
    attach: function (elm, evnt, hndlr) {
      if (elm.addEventListener)
        elm.addEventListener(evnt, hndlr, false);
      else if (elm.attachEvent)
        elm.attachEvent('on' + evnt, hndlr);
    },
    download: function () {
      if (!script_lgCombo.downloading) {
        script_lgCombo.downloading = true;
        if (!script_lgCombo.timerON) {
          script_lgCombo.timerON = true;
          setTimeout(script_lgCombo.doDownLoad, script_lgCombo.interval);
        }
      }
    },
    doDownLoad: function () {
      script_lgCombo.timerON = false;
      PageMethods.doDownLoad(script_lgCombo.ddtxt.value, script_lgCombo.downloaded, script_lgCombo.errorDownload);
    },
    downloaded: function (r) {
      script_lgCombo.downloading = false;
      script_lgCombo.ddpnl.style.margin = '2px';
      script_lgCombo.ddpnl.innerHTML = r;
      script_lgCombo.ddpnl.style.display = 'block';
    },
    errorDownload: function () {

    }
  };
</script>
<asp:Panel ID="LG_panel" runat="server"></asp:Panel>
