using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Modules.Core.Mvc.Models;
using Abp.UI;
using Abp.Users.Dto;
using Abp.Web.Models;
using Abp.Web.Mvc.Models;

using Recaptcha.Web;
using Recaptcha.Web.Mvc;

using Taskever.Security.Users;
using Taskever.Users;
using Taskever.Web.Mvc.Models.Account;


namespace Taskever.Web.Mvc.Controllers
{
    public class AccountController : TaskeverController
    {
        private readonly ITaskeverUserAppService _userAppService;

        private readonly UserManager _userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(ITaskeverUserAppService userAppService, UserManager userManager)
        {
            _userAppService = userAppService;
            _userManager = userManager;
        }

        public virtual ActionResult Login(string returnUrl = "", string loginMessage = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginMessage = loginMessage;
            return View();
        }

        [HttpPost]
        public virtual async Task<JsonResult> Login(LoginModel loginModel, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Your form is invalid!");
            }

            var result = await _userManager.LoginAsync(loginModel.EmailAddress, loginModel.Password);

            if (result.Result != AbpLoginResultType.Success)
            {
                // ErrorInfo error = CreateErrorInfoForFailedLoginAttempt(result.Result, loginModel.EmailAddress);
                throw CreateExceptionForFailedLoginAttempt(result.Result, loginModel.EmailAddress);

                // throw new UserFriendlyException("Invalid user name or password!");
                // return Json(new MvcAjaxResponse { Error = error });
            }

            await SignInAsync(result.User, loginModel.RememberMe);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            return Json(new MvcAjaxResponse { TargetUrl = returnUrl });
        }

        private ErrorInfo CreateErrorInfoForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress)
        {
            ErrorInfo info = new ErrorInfo(500);
            
            switch (result)
            {
                case AbpLoginResultType.Success:
                    throw new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    info.Message = L("LoginFailed");
                    info.Details = L("InvalidUserNameOrPassword");
                    break;

                case AbpLoginResultType.UserIsNotActive:
                    info.Message = L("LoginFailed");
                    info.Details = L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress);
                    break;

                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    info.Message = L("LoginFailed");
                    info.Details = "Your email address is not confirmed. You can not login";
                    break;
                    
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    
                    info.Message = L("LoginFailed");
                    info.Details = "Unhandled login fail reason: " + result;
                    break;
            }

            return info;
        }

        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));

                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            }
        }


        private async Task SignInAsync(TaskeverUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }

        public ActionResult ConfirmEmail(ConfirmEmailInput input)
        {
            _userAppService.ConfirmEmail(input);
            return RedirectToAction("Login", new { loginMessage = "Congratulations! Your account is activated. Enter your email address and password to login" });
        }

        [AbpAuthorize]
        public virtual ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult ActivationInfo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(RegisterUserInput input)
        {
            //TODO: Return better exception messages!
            //TODO: Show captcha after filling register form, not on startup!

            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Your form is invalid!");
            }

            //TODO: Remove Recapthcha for testing??
            var recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                throw new UserFriendlyException("Captcha answer cannot be empty.");
            }

            var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                throw new UserFriendlyException("Incorrect captcha answer.");
            }

            input.ProfileImage = ProfileImageHelper.GenerateRandomProfileImage();

            _userAppService.RegisterUser(input);

            return Json(new MvcAjaxResponse { TargetUrl = Url.Action("ActivationInfo") });
        }

        public JsonResult SendPasswordResetLink(SendPasswordResetLinkInput input)
        {
            _userAppService.SendPasswordResetLink(input);

            return Json(new MvcAjaxResponse());
        }

        [HttpGet]
        public ActionResult ResetPassword(int userId, string resetCode)
        {
            return View(new ResetPasswordViewModel { UserId = userId, ResetCode = resetCode });
        }

        [HttpPost]
        public JsonResult ResetPassword(ResetPasswordInput input)
        {
            var recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                throw new UserFriendlyException("Captcha answer cannot be empty.");
            }

            var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                throw new UserFriendlyException("Incorrect captcha answer.");
            }

            _userAppService.ResetPassword(input);

            return Json(new MvcAjaxResponse { TargetUrl = Url.Action("Login") });
        }

        [Authorize, DisableAuditing]
        public JsonResult KeepSessionOpen()
        {
            return Json(new MvcAjaxResponse());
        }
    }
}
