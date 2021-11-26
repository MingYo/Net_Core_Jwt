using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthDemo.Helpers;
using Microsoft.AspNetCore.Authorization;
using JwtAuthDemo.Models;

namespace JwtAuthDemo.Controllers
{
    [Authorize]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtHelpers jwt;

        public TokenController(JwtHelpers jwt)
        {
            this.jwt = jwt;
        }

        [AllowAnonymous]
        [Route("SignIn/{aa}")]
        [HttpPost]
        public ActionResult<string> SignIn(LoginViewModel login,int? aa )
        {

            if (ValidateUser(login))
            {
                return jwt.GenerateToken(login.Username);
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ValidateUser(LoginViewModel login)
        {
            return true; // TODO
        }

    }
}
