<script type="text/javascript"> 
  var script_lgDDL = {
    interval: 100,
    element: '',
    ddpnl: '',
    downloading: false,
    timerON: false,
    rendering: false,
    attch: function (o, p) {
      alert('atch');
      this.element = o;
      this.ddpnl = p;
      this.ddpnl.top = this.element.top + this.element.offsetHeight;
      this.ddpnl.left = this.element.left;
      this.ddpnl.style.display = 'none';
      //this.element.onkeydown = function () { this.download; }
      this.handlr(this.element, 'keydown', this.download);
    },
    handlr: function (elm, evnt, hndlr) {
      if (elm.addEventListener)
        elm.addEventListener(evnt, hndlr, false);
      else if (elm.attachEvent)
        elm.attachEvent('on' + evnt, hndlr);
    },
    download: function () {
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
    doDownLoad: function () {
      this = script_lgDDL;
      this.timerON = false;
      PageMethods.doDownLoad(this.element.value, this.downloaded, this.errorDownload);
    },
    downloaded: function (r) {
      $get('ddtxt').value = r;

      this = script_lgDDL;
      this.downloading = false;
      this.ddpnl.style.margin = '2px';
      this.ddpnl.innerHTML = r;
      this.ddpnl.style.display = 'block';
    },
    errorDownload: function () {

    }
  }
  
</script>
