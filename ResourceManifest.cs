using Orchard.UI.Resources;

namespace Devq.Employees
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest
                .DefineScript("Angular_SignalR")
                .SetUrl("angular-signalr-hub.min.js", "angular-signalr-hub.js")
                .SetDependencies("AngularJS");
        }
    }
}