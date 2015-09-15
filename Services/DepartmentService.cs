using Orchard.ContentManagement;

namespace Devq.Employees.Services
{
    public class DepartmentService : IDepartmentService {
        private readonly IContentManager _contentManager;

        public DepartmentService(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        public IContentQuery<ContentItem> GetDepartmentsQuery() {
            return _contentManager
                .Query(VersionOptions.Published)
                .ForType("Department");
        } 
    }
}