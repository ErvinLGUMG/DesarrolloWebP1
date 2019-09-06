using RestApiLibrary.Models.Objects;
using RestApiLibrary.Models.Responses;
using RestApiLibrary.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApiLibrary.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        public static string base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        [HttpPost]
        public ResponseToken Authenticate(User user)
        {
            ResponseToken result = new ResponseToken();
            
            try
            {
                if (user == null)
                {
                    result.status = "No information provided";
                }
                user.password = base64Decode(user.password);
                bool isCredentialValid = (user.password == "ProjectLibrary2019");
                if (isCredentialValid)
                {
                    result.token = TokenGenerator.GenerateJwt(user);
                    result.status = "OK";
                    result.message = "Token Generado";
                }
                else
                {
                    result.status = "error";
                    result.message = "Invalid credentials";
                }
            }
            catch (Exception e)
            {
                result.status = "error";
                result.message = e.Message;
            }
            return result;
        }
    }
}
