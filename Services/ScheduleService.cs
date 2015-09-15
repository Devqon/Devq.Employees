using System.Collections.Generic;
using System.Linq;
using Devq.Employees.Models;
using Orchard.ContentManagement;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;

namespace Devq.Employees.Services {
    public class ScheduleService : IScheduleService {

        private readonly IContentManager _contentManager;
        private readonly ITaxonomyService _taxonomyService;

        public ScheduleService(IContentManager contentManager, ITaxonomyService taxonomyService) {
            _contentManager = contentManager;
            _taxonomyService = taxonomyService;
        }

        public IContentQuery<WorkDayPart> GetWorkDayQuery() {

            return _contentManager
                .Query<WorkDayPart, WorkDayPartRecord>();
        }

        public IContentQuery<WorkDayPart> GetWorkDaysByEmployee(int employeeId)
        {
            return GetWorkDayQuery()
                .Where<WorkDayPartRecord>(w => w.User.Id == employeeId);
        }

        public IContentQuery<WorkDayPart> GetWorkDaysByDepartment(int departmentId) {

            var departmentType = _taxonomyService
                .GetTermsForContentItem(departmentId, "Department", VersionOptions.Published)
                .FirstOrDefault();

            if (departmentType == null) {
                return null;
            }

            return GetWorkDayQuery()
                .Join<TermsPartRecord>()
                .Where<TermsPartRecord>(
                    partRecord => partRecord
                        .Terms
                        .Any(t => t.TermRecord.Id == departmentType.Id));
        } 
    }
}