using System.Net;

namespace Devq.Employees.Hubs.Chat.ContentProviders
{
    public interface IContentProvider
    {
        string GetContent(HttpWebResponse response);
    }
}