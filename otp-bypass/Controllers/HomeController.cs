using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using otp_bypass.Models;

namespace otp_bypass.Controllers;

public class HomeController : Controller
{
    [Authorize]
    public IActionResult Dashboard()
    {
        return View();
    }
}
