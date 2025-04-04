using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FreelancerJerry.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FreelancerJerry.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FreelancerjerrydbContext _context;

    public HomeController(ILogger<HomeController> logger, FreelancerjerrydbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        bool work = IsServerConnected();
        if(work){
            System.Console.WriteLine("Server working");
        }
        else {
            System.Console.WriteLine("Server not connected!");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private bool IsServerConnected()
    {
        using (var l_oConnection = new SqlConnection(Environment.GetEnvironmentVariable("freelancerjerrydbconnectionstring")))
        {
            try
            {
                l_oConnection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}