
//以下为修改jQuery Validation插件兼容Bootstrap的方法，没有直接写在插件中是为了便于插件升级
$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
    },
    success: function (element) {
        element.closest('.form-group').removeClass('has-error').addClass('has-success');
    },
    errorElement: "span",
    errorPlacement: function (error, element) {
        if (element.is(":radio") || element.is(":checkbox")) {
            error.appendTo(element.parent().parent().parent());
        } else {
            error.appendTo(element.parent());
        }
    },
    errorClass: "help-block m-b-none",
    validClass: "help-block m-b-none"


});


/* 增加自定义规则, 不等于某个字段*/
$.validator.addMethod("notEqualTo", function (value, element, param)
{
    var target = $(param);
    if (value) return value != target.val();
    else return this.optional(element);
}, "Does not match");

/* 增加自定义规则, 不等于某个字段*/
$.validator.addMethod("isPwd", function (value, element, param)
{
    var result= !/\d/.test( value ) ? false :
        /[a-z|A-Z]/.test( value );

    return this.optional(element) || result;

}, "Does not match");

var PasswordValidation = function () {

    var handleValidation1 = function() {
        // for more info visit the official plugin documentation: 
            // http://docs.jquery.com/Plugins/Validation

            var form1 = $('#change_password_form');
            form1.validate({
                onsubmit: true,// 是否在提交是验证
                rules: {
                    old_password: {
                        required: true,
                        remote:{//验证原始密码是否存在
                            type:"POST",
                            dataType: "text",
                            url:"/forms/publicforms/login/changepassword.aspx?action=checkPassword",             //servlet
                            data:{
                                old_password:function(){
                                    return $("#old_password").val();
                                }
                            }
                        }
                    },
                    new_password: {
                        required: true,
                        rangelength:[5,15],
                        notEqualTo:"#old_password",
                        isPwd:true
                    },
                    confirm_password: {
                        required: true,
                        equalTo: "#new_password",
                        notEqualTo:"#old_password"
                    }
                },
                messages: {
                    old_password: {
                        required:"请输入原始密码",
                        remote:"原始密码有误!"
                    },
                    new_password: {
                        required: "请输入新密码",
                        rangelength: "密码长度必须在5-15个字符",
                        isPwd:"必须同时包含数字和字母",
                        notEqualTo: "不能与旧密码一致",
                    },
                    confirm_password: {
                        required: "请输入密码",
                        minlength: "密码长度不能小于5 个字符",
                        equalTo: "两次密码输入不一致",
                        notEqualTo: "不能与旧密码一致",
                    }
                },

                submitHandler: function (form) {
                    //var sms_code=$("#sms_code").val();
                    //if(!sms_code || sms_code.length<6){
                    //    layer.msg('短信验证码格式不对!');
                    //    $("#sms_code").focus();
                    //    return false;
                    //}
                    var old_password=$("#old_password").val();
                    var new_password=$("#new_password").val();
                    var confirm_password=$("#confirm_password").val();

                    //异步修改密码
                    $.ajax({
                        type: 'POST',
                        url: "/forms/publicforms/login/changepassword.aspx?action=changePassword",
                        data: {
                            "old_password":old_password,
                            "new_password":new_password,
                            "confirm_password":confirm_password,
                            //"sms_code":sms_code
                        },
                        success: function(data){
                            if(data.code==200){
                                layer.msg('密码修改成功,将重新登陆...');
                                window.setTimeout("window.parent.location='/forms/publicforms/login/login.aspx';", 500);
                                //window.setTimeout(function () { $("#login").click(); }, 2000);
                            }else{
                                layer.msg("密码修改失败");
                                return false;
                            }
                        },
                        dataType: "json"
                    });

                }
            });

    }

    return {
        //main function to initiate the module
        init: function () {
            handleValidation1();
        }

    };

}();