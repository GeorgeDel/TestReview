using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsSystem.Interfaces;

namespace NewsSystem.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [RouteAttribute("Api/login/GetUser/{username=username}/{password=password}")]
        [HttpGet]
        public HttpResponseMessage GetUser(string username, string password)
        {
            try
            {
                var result = _userRepository.GetUser(username, password);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
              const string error = "password not ok";
             return   Request.CreateResponse(HttpStatusCode.NotAcceptable,error);

            }
        }
    }
}
