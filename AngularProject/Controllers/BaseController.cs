using AngularProject.Helper;
using AP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AngularProject.Controllers
{
    [Route("api/base")]
    [ApiController]
    public class BaseController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public BaseController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [NonAction]
        [HttpGet]
        public void SendRegisterEmail(string sToUser, string sOtp, string sConfirmUrl, string sSubject, string sTemplateName)
        {
            var fromAddress = new MailAddress(ConfigHelper.GetConfig("EmailCredentials:EmailId"), ConfigHelper.GetConfig("EmailCredentials:FromUser"));
            var toAddress = new MailAddress(sToUser);
            List<ParamModel> paramList = new List<ParamModel>()
            {
                new ParamModel()
                {
                    ParamName = "[Param_Otp]",
                    ParamValue = sOtp
                },
                new ParamModel()
                {
                    ParamName = "[Param_url]",
                    ParamValue = sConfirmUrl
                }
            };
            var emailBody = GetRegisterTemplate(paramList, sTemplateName);
            using (var smtp = new SmtpClient())
            {
                var credentials = new NetworkCredential(ConfigHelper.GetConfig("EmailCredentials:EmailId"), ConfigHelper.GetConfig("EmailCredentials:Password"));
                smtp.Host = ConfigHelper.GetConfig("SmtpSettings:Host");
                smtp.Port = Convert.ToInt32(ConfigHelper.GetConfig("SmtpSettings:Port"));
                smtp.EnableSsl = Convert.ToBoolean(ConfigHelper.GetConfig("SmtpSettings:EnableSsl"));
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigHelper.GetConfig("SmtpSettings:UseDefaultCredentials"));
                smtp.Credentials = credentials;
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = sSubject,
                    Body = emailBody,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
            }

        }

        [NonAction]
        [HttpGet]
        public string GetRegisterTemplate(List<ParamModel> lstParams, string sTemplateName)
        {
            var pathToFile = Path.Combine(_hostEnvironment.WebRootPath, "EmailTemplates", sTemplateName);
            string htmlBody = String.Empty;
            using (StreamReader streamReader = System.IO.File.OpenText(pathToFile))
            {
                htmlBody = streamReader.ReadToEnd();
            }

            foreach (var param in lstParams)
            {
                htmlBody = htmlBody.Replace(param.ParamName, param.ParamValue);
            }

            return htmlBody;
        }

        [HttpGet]
        [NonAction]
        public string EncryptParameter(string sParameterValue)
        {
            var paramToByte = Encoding.UTF8.GetBytes(sParameterValue);
            return Convert.ToBase64String(paramToByte);
            //var paramToByte = Encoding.ASCII.GetBytes(sParameterValue);
            //var encryptedParam = Convert.ToBase64String(paramToByte);
            //return encryptedParam;
        }
    }
}
