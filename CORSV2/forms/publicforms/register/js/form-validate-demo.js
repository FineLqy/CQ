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


//手机号码验证  
jQuery.validator.addMethod("isMobile", function (value, element) {
    var length = value.length;
    //var isPhone = /^([0-9]{3,4}-)?[0-9]{7,8}$/;
    var mobile = /^((\+?86)|(\(\+86\)))?(13[0-9]{9}|14[0-9]{9}|17[0-9]{9}|15[0-9]{9}|18[0-9]{9})$/;
    return this.optional(element) || (length == 11 && mobile.test(value));/* || isPhone.test(value));*/
}, "请正确填写手机号码");

// 字母和数字的验证
jQuery.validator.addMethod("isCharNum", function (value, element) {
    var chrnum = /^([a-zA-Z0-9]+)$/;
    return this.optional(element) || (chrnum.test(value));
}, "只能输入数字和字母(字符A-Z, a-z, 0-9)");
jQuery.validator.addMethod("isCharNum1", function (value, element) {
    var chrnum = /^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{8,15}$/;
    return this.optional(element) || (chrnum.test(value));
}, "密码包含 数字,英文,字符中的两种以上，长度不少于8位");
//$.validator.setDefaults({
//    submitHandler: function () {
//        alert("提交事件!");
//    }
//});
//以下为官方示例
$().ready(function () {
    // validate the comment form when it is submitted
    // $("#signupForm").validate();

    // validate signup form on keyup and submit
    var icon = "<i class='fa fa-times-circle'></i> ";
    $("#signupForm").validate({
        onsubmit: true,// 是否在提交是验证
        rules: {
            firstname: "required",
            lastname: "required",
            username: {
                required: true,
                minlength: 3,
                maxlength: 15,
                isCharNum: true,

                remote: {
                    url: "?action=check_username",     //后台处理程序
                    dataType: "text",           //接受数据格式   
                    data: {                     //要传递的数据
                        username: function () {
                            return $("#username").val();
                        }
                    }
                }
            },
            password: {
                required: true,
                //minlength: 6,
                isCharNum: true,
                isCharNum1: true,
                maxlength: 15
            },
            confirm_password: {
                required: true,
                isCharNum: true,
                isCharNum1: true,
                minlength: 8,
                maxlength: 15,
                equalTo: "#password"
            },
            email: {
                required: true,
                email: true
            },
            tel: {
                required: true,
                tel: true
            },
            phone: {
                required: true,
                isMobile: true,
                remote: {
                    url: "?action=check_phone",     //后台处理程序
                    dataType: "text",           //接受数据格式   
                    data: {                     //要传递的数据
                        phone: function () {
                            return $("#phone").val();
                        }
                    }
                }
            },
            topic: {
                required: "#newsletter:checked",
                minlength: 2
            },
            agree: "required"
        },
        messages: {
            firstname: icon + "请输入你的姓",
            lastname: icon + "请输入您的名字",
            username: {
                required: icon + "请输入您的用户名",
                isCharNum: icon + "只能输入数字和字母(字符A-Z, a-z, 0-9)",
                minlength: icon + "用户名必须3个字符以上",
                maxlength: icon + "用户名必须15个字符以下",
                remote: icon + "用户名已存在",
            },
            password: {
                required: icon + "请输入您的密码",
                isCharNum: icon + "只能输入数字和字母(字符A-Z, a-z, 0-9)",

                maxlength: icon + "用户名必须15个字符以下",
                isCharNum1: icon + "密码包含 数字,英文,字符中的两种以上，长度不少于8位",
            },
            confirm_password: {
                required: icon + "请再次输入密码",
                isCharNum: icon + "只能输入数字和字母(字符A-Z, a-z, 0-9)",

                maxlength: icon + "用户名必须15个字符以下",
                equalTo: icon + "两次输入的密码不一致",
                isCharNum1: icon + "密码包含 数字,英文,字符中的两种以上，长度不少于8位",
            },
            email: icon + "请输入您的E-mail",
            tel: icon + "请输入您的电话号码",
            phone: {
                required: "请输入您的电话号码",
                isMobile: "请正确填写手机号码",
                remote: icon + "手机号已存在",
            },
            agree: {
                required: icon + "必须同意协议后才能注册",
                element: '#agree-error'
            }
        },
        submitHandler: function (form) {
            if ($("#getCode").attr("data-value") == "2") {
                // alert("gg");
            }
            else {  //此处为表单验证通过后   才出发表单提交事件
                edit_info()
            }


        }
        //submitHandler: function(form) { //通过之后回调
        //    //进行ajax传值
        //$.ajax({
        //    url : "{:U('user/index')}",
        //    type : "post",
        //    dataType : "json",
        //    data: {
        //        user: $("#user").val(),
        //        password: $("#password").val() 
        //    },
        //    success : function(msg) {
        //        //要执行的代码
        //    }
        //});
        //}
    });

    // propose username by combining first- and lastname
    //$("#username").focus(function () {
    //    var firstname = $("#firstname").val();
    //    var lastname = $("#lastname").val();
    //    if (firstname && lastname && !this.value) {
    //        this.value = firstname  + lastname;
    //    }
    //});
});
