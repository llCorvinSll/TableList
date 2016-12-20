﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Authentication;

namespace TableList.Auth.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
		//[HttpGet("~/signin")]
		//public IActionResult SignIn() => View("SignIn", HttpContext.GetExternalProviders());

		[HttpGet("~/signin")]
		public IActionResult SignIn([FromForm] string provider)
		{
			// Note: the "provider" parameter corresponds to the external
			// authentication provider choosen by the user agent.
			if (string.IsNullOrWhiteSpace(provider))
			{
				return BadRequest();
			}

			// Instruct the middleware corresponding to the requested external identity
			// provider to redirect the user agent to its own authorization endpoint.
			// Note: the authenticationScheme parameter must match the value configured in Startup.cs
			return Challenge(new AuthenticationProperties { RedirectUri = "/" }, provider);
		}

		//[HttpGet("~/signout"), HttpPost("~/signout")]
		//public IActionResult SignOut()
		//{
		//	// Instruct the cookies middleware to delete the local cookie created
		//	// when the user agent is redirected from the external identity provider
		//	// after a successful authentication flow (e.g Google or Facebook).
		//	return SignOut(new AuthenticationProperties { RedirectUri = "/" },
		//		CookieAuthenticationDefaults.AuthenticationScheme);
		//}
	}
}
