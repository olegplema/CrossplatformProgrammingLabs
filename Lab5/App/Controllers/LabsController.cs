using ClassLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class LabsController : Controller
{
    [HttpGet]
    public IActionResult First()
    {
        return View();
    }

    [HttpPost]
    public IActionResult First(string inputText)
    {
        var result = Lab1.Execute(inputText);
        ViewBag.OutputResult = result;
        return View();
    }

    [HttpGet]
    public IActionResult Second()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Second(string inputText)
    {
        var result = Lab2.Execute(inputText);
        ViewBag.OutputResult = result;
        return View();
    }

    [HttpGet]
    public IActionResult Third()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Third(string inputText)
    {
        var result = Lab3.Execute(inputText);
        ViewBag.OutputResult = result;
        return View();
    }
}
