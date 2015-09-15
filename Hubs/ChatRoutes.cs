using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Routes;

namespace Devq.Employees.Hubs
{
    [OrchardFeature("Devq.EmployeeChat")]
    public class ChatRoutes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 12,
                    Route = new Route(
                        "Chat/{action}",
                        new RouteValueDictionary {
                            {"area", "Devq.Employees"},
                            {"controller", "Chat"},
                            {"action", "Index"},
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Devq.Employees"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}