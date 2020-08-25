require( [ "ModalView" , "Validate" ], function( ModalView , Validate ){
    var self;
    self    = new ModalView( "app" , $( document.body ) , function(){
        this.initValidate();
    } , {
        validate    : false ,
        $submitInput: $( "input[type='submit']" )
    } );
    self.addModalEvent( {
        submit  : function(){
            self.$container.find( "form" ).submit();
            return this;
        } ,
        checkSubmitBtn  : function(){
            if( !self.prop.validate.validateStatus( "login" , { handleCallback : false , ignoreNone : true } ) || 
                self.$container.find( ".p-row.has-error" ).length || 
                self.$container.find( "input[name='agreeProtocol']" )[ 0 ].checked === false ){
                self.prop.$submitInput.addClass( "btn-disabled" )[ 0 ].disabled     = true;
            } else {
                self.prop.$submitInput.removeClass( "btn-disabled" )[ 0 ].disabled  = false;
            }
            return this;
        } ,
        ajaxCheckInput  : function( $input ){
            var _role   = $input.attr( "role" ) ,
                _params;
            if ( {
                    "username"  : 1 ,
                    "pwd"       : 1 ,
                    "imgCode"   : 1 ,
                    "phone"     : 1 ,
                    "email"     : 1
                }[ _role ] ) {
                _params     = {};
                _params[ _role ]    = $input.val()
                self.pipe( "/index.php?s=/Home/Member/doVerifyRegister.html" , _params , "post" )
                    .then( function( rtn ){
                        if ( rtn.code !== 200 ) {
                            $input.parents( ".p-row" ).addClass( "has-error" );
                            $input.siblings( ".error-msg" ).html( rtn.msg );
                        }
                    } );
            }
            return this;
        } ,
        initValidate    : function(){
            var _validate   = new Validate();
            _validate.addVerifyItem( "login" , this.$container.find( ".content-container" ) , {
                username    : "length[4,14]" ,
                pwd         : "length[8,16] isPwd" ,
                checkpwd    : "length[8,16] isPwd" ,
                //phone       : "emailOrPhone" ,
				phone       : "phone" ,
                email       : "email" ,
                imgCode     : "length[3,6]" ,
                verifyCode  : "length[6,6]" ,
                options     : {
                    checkName   : "role"
                }
            } , function( $input , isPass ){
                var _content;
                if ( isPass ) {
                    $input.parents( ".p-row" ).removeClass( "has-error" );
                    if ( $input.attr( "role" ) === "checkpwd" ) {
                        if ( $input.val() !== self.$container.find( "input[role='pwd']" ).val() ) {
                            $input.parents( ".p-row" ).addClass( "has-error" );
                             $input.siblings( ".error-msg" ).html( "两次输入的密码不一致" );
                        }
                    }
                    self.ajaxCheckInput( $input );
                } else {
                    _content    = $input.data( "content" );
                    $input.parents( ".p-row" ).addClass( "has-error" );
                    $input.siblings( ".error-msg" ).html( _content );
                }
                self.checkSubmitBtn();
            } );
            self.prop.validate  = _validate;
            return this;
        },
        refreshCode     : function(){
            $( ".pic-code" ).attr( "src" , "/index.php?s=/Home/Member/verify.html&x=" + ( +new Date() ) );
            return this;
        } 
    } ).addViewEvent( {
        "#getCode::click"   : function(){
            var _$input = self.$container.find( "input[role='phone']" ) ,
                _phone  = _$input.val();
            var _$code  = self.$container.find("input[role='imgCode']") ,
                _code   = _$code.val();
            // if ( self.prop.validate.checkRule( "isPhone" , _phone ) ||
            //      self.prop.validate.checkRule( "email" , _phone ) ) {
            //     $app.sendPhoneCode( this , { phone : _phone } );
            // } else {
            //     _$input.blur();
            // }
            if ( self.prop.validate.checkRule( "isPhone" , _phone ) ){
                if( _code != "" ){
                    $app.sendPhoneCode( this , {
                         phone : _phone,
                         imgCode  : _code,
                         refreshCode : function(rtn){
                            $( ".pic-code" ).attr( "src" , "/index.php?s=/Home/Member/verify.html&x=" + ( +new Date() ) );
                            return this;
                        }
                     } );
                }else{
                    _$code.blur();
                }
            }else{
               _$input.blur(); 
            }
            if ( self.prop.validate.checkRule( "email" , _phone ) ){
                $app.sendPhoneCode( this , { 
                     phone : _phone ,
                     imgCode  : _code
                 } );
            }else{
               _$input.blur(); 
            }
        } ,
        "input[role='phone']::keyup"    : function(){
            var _phone  = $(this).val();
            if ( self.prop.validate.checkRule( "isPhone" , _phone ) ) {
                //$(".img-code").show();
            }else{
                //$(".img-code").hide();
            }
        } ,
        "input[name='agreeProtocol']::click"    : function(){
            self.checkSubmitBtn();
        } ,
        ".btn[func='submit']::click"   : function(){
            if ( this.className.indexOf( "btn-disabled" ) === -1 ) {
                self.submit();
            }
        } ,
        "img[func='refreshCode']::click"  : function(){
            $( "img[func='verifyCode']" ).attr( "src" , "" );
            self.refreshCode();
        }
    } ).init();
} );