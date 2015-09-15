using Orchard.ContentManagement;

namespace Devq.Employees.Services
{
    public class EmployeeService : IEmployeeService {
        private readonly IContentManager _contentManager;
        public EmployeeService(IContentManager contentManager) {
            _contentManager = contentManager;
        }
    }
}