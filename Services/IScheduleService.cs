using System.Collections.Generic;
using Devq.Employees.Models;
using Orchard.ContentManagement;

namespace Devq.Employees.Services
{
    public interface IScheduleService
    {
        IContentQuery<WorkDayPart> GetWorkDayQuery();
        IContentQuery<WorkDayPart> GetWorkDaysByEmployee(int employeeId);
        IContentQuery<WorkDayPart> GetWorkDaysByDepartment(int departmentId);
    }
}