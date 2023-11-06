using AP.Entities.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AP.Common;
using AP.Models;
using AngularProject.Helper;
using System.Net;
using Newtonsoft.Json;

namespace AngularProject.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public AuthController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment) : base(hostEnvironment)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ApiResponseViewModel<Users> Login(UserLogin objModel)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username.ToLower() == objModel.UserName.ToLower());
                if (user != null)
                {
                    if (EncryptPassword.VerifyPass(objModel.Password, user.Password))
                    {
                        var jwtSettings = new JwtSetting
                        {
                            Issuer = ConfigHelper.GetConfig(nameof(JwtSetting) + ":" + nameof(JwtSetting.Issuer)),
                            Audience = ConfigHelper.GetConfig(nameof(JwtSetting) + ":" + nameof(JwtSetting.Audience)),
                            Key = ConfigHelper.GetConfig(nameof(JwtSetting) + ":" + nameof(JwtSetting.Key))
                        };
                        var token = JwtTokenHelper.GenerateToken(jwtSettings, user);

                        Users userModel = user;
                        userModel.Token = token;

                        return GenerateResponse.CreateResponse<Users>((int)HttpStatusCode.OK, "Login Successful", userModel, null);
                    }
                }

                return GenerateResponse.CreateResponse<Users>((int)HttpStatusCode.BadRequest, "Invalid credentials", null, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<Users>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
                //logic for logging
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ApiResponseViewModel<Users> Register(Users objUser)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username.ToLower() == objUser.Username.ToLower());
                if (user != null)
                {
                    return GenerateResponse.CreateResponse<Users>((int)HttpStatusCode.BadRequest, "User already exists", null, null);
                }
                var otp = GenerateOtp.GenerateRandomOtp();
                objUser.Otp = otp;
                var url = String.Concat(ConfigHelper.GetConfig("confirmPageUrl"), "/", EncryptParameter(JsonConvert.SerializeObject(objUser)));
                SendRegisterEmail(objUser.Username, otp, url, "Verification code", "RegisterEmail.html");
                return GenerateResponse.CreateResponse<Users>((int)HttpStatusCode.OK, "OTP sent on your email Id", objUser, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<Users>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }

        [AllowAnonymous]
        [HttpPost("addUser")]
        public ApiResponseViewModel<string> AddUser(Users objUser)
        {
            try
            {
                objUser.Password = EncryptPassword.EncryptPass(objUser.Password);
                objUser.CreatedAt = DateTime.Now;
                objUser.CreatedBy = 1;
                _context.Users.Add(objUser);
                _context.SaveChanges();
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.OK, "User added successfully", null, null);
            }
            catch (Exception ex)
            {
                return GenerateResponse.CreateResponse<string>((int)HttpStatusCode.InternalServerError, ex.Message, null, null);
            }
        }
    }
}
