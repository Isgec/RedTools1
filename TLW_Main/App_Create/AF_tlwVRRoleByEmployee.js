<script type="text/javascript"> 
var script_tlwVRRoleByEmployee = {
    ACEUserName_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UserName','');
      var F_UserName = $get(sender._element.id);
      var F_UserName_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UserName.value = p[0];
      F_UserName_Display.innerHTML = e.get_text();
    },
    ACEUserName_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UserName','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUserName_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_UserName: function(sender) {
      var Prefix = sender.id.replace('UserName','');
      this.validated_FK_SYS_VRRoleByEmployee_UserName_main = true;
      this.validate_FK_SYS_VRRoleByEmployee_UserName(sender,Prefix);
      },
    validate_FK_SYS_VRRoleByEmployee_UserName: function(o,Prefix) {
      var value = o.id;
      var UserName = $get(Prefix + 'UserName');
      if(UserName.value==''){
        if(this.validated_FK_SYS_VRRoleByEmployee_UserName_main){
          var o_d = $get(Prefix + 'UserName' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UserName.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_SYS_VRRoleByEmployee_UserName(value, this.validated_FK_SYS_VRRoleByEmployee_UserName);
      },
    validated_FK_SYS_VRRoleByEmployee_UserName_main: false,
    validated_FK_SYS_VRRoleByEmployee_UserName: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_tlwVRRoleByEmployee.validated_FK_SYS_VRRoleByEmployee_UserName_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
