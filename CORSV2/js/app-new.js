require( [ "Validate" , "ModalView" ] , function( Validate , ModalView ){
    var self    = new ModalView( "regApp" , $( document.body ) , function(){
        this.initViewPort()
            .initHandlerbarsHelper()
            .initValidate()
            .handlePreAjax();
    } , {
        phoneSendNum    : 60
    } );
    self.addModalEvent( {
        handlePreAjax   : function(){
            var _self   = new ModalView();
            _self.setAjaxConfig( {
                successList     : function( rtn ){
                    return !rtn.hasError && $.extend( rtn , rtn.content );
                }
            } , true );
            return this;
        } ,
        initValidate: function(){
            var _validate   = new Validate();
            _validate.addRules( {
                isPwd           : function( str ){
                    return !/\d/.test( str ) ? false :
                                /[a-z|A-Z]/.test( str );
                } ,
                phone    : function( str ){
                    //if ( _validate.checkRule( "email" , str ) ) {
                    //    return true;
                    //} else 
						
					if( _validate.checkRule( "isPhone" , str ) ){
                        return true;
                    }
                    return false;
                }
            } , true );
            return this;
        } ,
        initViewPort: function(){
            var _sw     = window.screen.width ,
                _iw     = window.innerWidth ,
                _w      = _sw > _iw ? _iw : _sw ,
                _scale,
                _$meta;
            if( _w < 1240 ){
                _scale  = _w / 1240;
                _$meta  = $( "<meta>" , {
                    name    : "viewport" ,
                    content : [
                        "width=device-width" ,
                        "initial-scale=" + _scale,
                        "maximum-scale=" + _scale,
                        "minimum-scale=" + _scale,
                        "user-scalable=yes"
                    ].join( "," )
                } );
                $( "head" ).append( _$meta );
            }
            return this;
        } ,
        initHandlerbarsHelper : function(){
            Handlebars.registerHelper( "stateStr" , function( state ){
                return {
                        "0"     : "未激活" ,
                        "2"     : "在线" ,
                        "3"     : "离线"
                    }[ state ];
            } );
            Handlebars.registerHelper( "stateClass" , function( state ){
                return state == 2 ? "success" : 
                            state == 3 ? "default" : "error";
            } );
            return this;
        } ,
        sendPhoneCode   : function( btn , opt ){
            var _$btn   = $( btn ) ,
                _timer ,
                _num ;
            if( !_$btn.data( "is-sending" ) ) {
                _num    = self.prop.phoneSendNum;
                _timer  = function(){
                    if ( --_num ) {
                        _$btn.text( _num + "秒后重发" );
                        window.setTimeout( _timer , 1e3 );
                    } else {
                        _$btn.data( "is-sending" , false );
                        _$btn.text( "获取验证码" );
                        typeof opt.refreshCode === "function" && opt.refreshCode(  );
                    }
                }
                 self.pipe( opt.url || "/index.php?s=/Home/Member/sendRegPhoneSms.html" , { receiver : opt.phone , code : opt.imgCode } , "post" )
                    .then( function( rtn ){
                        if ( rtn.code == 200 ) {
                            _timer();
                            _$btn.data( "is-sending" , true );    
                        } else if( rtn.code == 109 ) {
                            _$btn.parents( ".p-row" ).addClass( "has-error" )
                                .find( ".error-msg" ).text( rtn.msg );
                        } else if( rtn.code == 110){
                            _$btn.parents( ".p-row" ).siblings(".img-code").addClass( "has-error" )
                                .find( ".error-msg" ).text( rtn.msg );
                        } else {
                            typeof opt.error === "function" && opt.error( rtn );
                        }
                    } );
            }
            return this;
        }
    } ).addViewEvent( {
        
    } ).init();
    window.$app     = self;
} );