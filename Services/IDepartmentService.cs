using Orchard;
using Orchard.ContentManagement;

namespace Devq.Employees.Services {
    public interface IDepartmentService : IDependency {
        IContentQuery<ContentItem> GetDepartmentsQuery();
    }
}