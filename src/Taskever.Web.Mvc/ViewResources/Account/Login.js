
// define(['durandal/app', 'session', 'service!taskever/userActivity'], function (app, session, userActivityService) {

define(["jquery", 'durandal/app', 'service!taskever/user'], function ($, app, userService) {
//    define(["jquery"], function ($) {

        $(function () {

            //Login form
        $("#LoginForm").validate({
            rules: {
                Password: {
                    minlength: 3
                }
            }
        });

        $("#LoginForm").abpAjaxForm({
            blockUI: '#LoginFormPanelBody',
            error: function (a, b, c, d, e, f, g, h, i, j, k) {
                // todo: pass correct error message to client from server
                $('#LoginErrorModal').modal('show');
                $('#LoginErrorMessage').text("Your email address or password is incorrect, please try again.");

                //abp.message.info("Invalid Email or Password.", "Login Failed!").done(
                //    function(){
                //        $("#LoginPassword").val("");
                //        $("#LoginEmailAddress").click();
                //    }
                //);
            },
            complete: function (a, b, c, d, e, f, g, h, i, j, k) {
                var _d;
                //debugger;
            }
        });

        //Add hash to return url
        $('#LoginReturnUrl').val($('#LoginReturnUrl').val() + location.hash);

        //Registration form
        $("#RegisterForm").validate({
            rules: {
                Password: {
                    minlength: 3
                },
                PasswordRepeat: {
                    equalTo: "#RegisterPassword"
                }
            }
        });

        $("#RegisterForm").abpAjaxForm({
            blockUI: '#RegisterFormPanelBody'
        });

        $('#ForgotPasswordLink').click(function () {
            $('#PasswordResetLinkModal').modal('show');
        });

        $('#PasswordResetLinkModalSubmitButton').click(function () {
            $("#PasswordResetErrorMessage").text("");

            userService.sendPasswordResetLink({
                emailAddress: $('#PasswordResetEmailAddress').val()
            }).done(function (data) {
                debugger;
                $('#PasswordResetLinkModal').modal('hide');
            }).fail(function (error) {
                // debugger;
                $("#PasswordResetErrorMessage").text(error.message);
                // abp.message.error(error.message, "Error");
            });

            //abp.ajax({
            //    url: abp.appPath + 'Account/SendPasswordResetLink',
            //    data: JSON.stringify({ emailAddress: $('#PasswordResetEmailAddress').val() })
            //}).done(function () {
            //    $('#PasswordResetLinkModal').modal('hide');
            //}).fail(function (args, title, message) {
            //    $("#PasswordResetErrorMessage").text(message);
            //    abp.message.error(message, title);
            //});
        });

        $('.taskever-screen-preview-image').fancybox();

        $('#LoginErrorModalSubmitButton').click(function () {
            $('#LoginErrorModal').modal('hide');

            $("#LoginPassword").val("");
            $("#LoginEmailAddress").click();
        });
    });

    return {

    };
});