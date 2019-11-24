using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
  public class HomeController : Controller
  {

    private readonly IHubContext<JobProgressHub> _hubContext;
    public HomeController(IHubContext<JobProgressHub> hubContext)
    {
      _hubContext = hubContext;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult StartProgress()
    {
      string jobId = Guid.NewGuid().ToString("N");
      PerformBackgroundJob(jobId);
      return RedirectToAction("Progress", new { jobId });
    }

    public IActionResult Progress(string jobId)
    {
      ViewBag.JobId = jobId;

      return View();
    }

    private async Task PerformBackgroundJob(string jobId)
    {
      for (int i = 0; i <= 100; i += 5)
      {
        await _hubContext.Clients.Group(jobId).SendAsync("progress", i);

        await Task.Delay(100);
      }
    }
  }
}
