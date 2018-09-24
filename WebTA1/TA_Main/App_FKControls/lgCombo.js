<script type="text/javascript">
  var script_lgDDL = {
    interval: 100,
    ddtxt: '',
    ddpnl: '',
    downloading: false,
    timerON: false,
    rendering: false,
    attach: function(o, p) {
      this.element = o;
      this.ddpnl = p;
      this.ddpnl.top = this.element.top + this.element.offsetHeight;
      this.ddpnl.left = this.element.left;
      this.ddpnl.style.display = 'none';
      //this.element.onkeydown = function () { this.download; }
      this.handlr(this.element, 'keydown', 'this.download');
    },
    handlr: function(elm, evnt, hndlr) {
      if (elm.addEventListener)
        elm.addEventListener(evnt, hndlr, false);
      else if (elm.attachEvent)
        elm.attachEvent('on' + evnt, hndlr);
    },
    download: function() {
      alert('hi');
      this = script_lgDDL;
      if (!this.downloading) {
        this.downloading = true;
        if (!this.timerON) {
          this.timerON = true;
          setTimeout(this.doDownLoad, this.interval);
        }
      }

    },
    doDownLoad: function() {
      this = script_lgDDL;
      this.timerON = false;
      PageMethods.doDownLoad(this.element.value, this.downloaded, this.errorDownload);
    },
    downloaded: function(r) {
      this = script_lgDDL;
      this.downloading = false;
      this.ddpnl.style.margin = '2px';
      this.ddpnl.innerHTML = r;
      this.ddpnl.style.display = 'block';
    },
    errorDownload: function() {

    }
  };
</script>


<script type="text/javascript">
  var script_lgCombo = {
    ddtxt: '',
    ddpnl: '',
    start: function (o, p) {
      alert('atch');
      this.ddtxt = o;
      this.ddpnl = p;
      this.attach($get(this.ddtxt), 'dblclick', this.getData);
      alert(this.ddpnl);
    },
    attach: function (elm, evnt, hndlr) {
      if (elm.addEventListener)
        elm.addEventListener(evnt, hndlr, false);
      else if (elm.attachEvent)
        elm.attachEvent('on' + evnt, hndlr);
    },
    getData: function (o) {
      alert('called');
      try {
        PageMethods.getData(script_lgCombo.ddpnl + "|" + $get(script_lgCombo.ddtxt).value, script_lgCombo.downloaded);
      } catch (e) { alert(e); }
    },
    downloaded: function (r) {
      var p = r.split('|');
      alert(r);
      $get(p[0]).innerHTML = p[1];
    }
  }
  
</script>
