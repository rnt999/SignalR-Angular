using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
  public class JobProgressHub : Hub
  {
    public async Task AssociateJob(string jobId)
    {
      await Groups.AddToGroupAsync(Context.ConnectionId, jobId);
    }
  }
}
