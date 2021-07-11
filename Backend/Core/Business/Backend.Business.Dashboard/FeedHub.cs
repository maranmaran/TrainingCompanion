using Backend.Business.Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard
{
    public interface IFeedHub
    {
        Task PushFeedActivity(Activity activity);
    }

    [Authorize]
    public class FeedHub : Hub<IFeedHub>
    {
        public FeedHub()
        {
        }
    }
}