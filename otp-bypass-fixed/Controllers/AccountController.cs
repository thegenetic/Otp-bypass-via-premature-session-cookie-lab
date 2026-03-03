using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

public class AccountController : Controller
{
    private const string ValidUsername = "thegenetic";
    private const string ValidPassword = "password123";
    private const string ValidOtp = "123456";

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (username == ValidUsername && password == ValidPassword)
        {
            // Store username in session
            HttpContext.Session.SetString("preauthuser", username);
            return RedirectToAction(nameof(OTP));
        }

        ModelState.AddModelError("", "Invalid username or password.");
        return View();
    }

    [HttpGet]
    public IActionResult OTP()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> OTP(string otp)
    {
        var preauthuser = HttpContext.Session.GetString("preauthuser");
        if (string.IsNullOrEmpty(preauthuser))
        {
            return RedirectToAction(nameof(Login)); 
        }

        if (otp == ValidOtp)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, preauthuser)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            HttpContext.Session.Remove("preauthuser"); // Clear session after successful login

            return RedirectToAction("Dashboard", "Home");
        }

        ModelState.AddModelError("", "Invalid OTP.");
        return View();
    }


}


