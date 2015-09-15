using System;
using System.Linq;
using System.Web.Mvc;
using Devq.Employees.Helpers;
using Devq.Employees.Models;
using Devq.Employees.Services;
using Devq.Employees.ViewModels;
using Orchard;
using Orchard.ContentManagement;

namespace Devq.Employees.Controllers
{
    public class ScheduleController : Controller {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IOrchardServices services, IScheduleService scheduleService) {
            _scheduleService = scheduleService;

            Services = services;
        }

        public IOrchardServices Services { get; set; }

        [HttpGet]
        public ActionResult Index(ScheduleIndexViewModel model) {

            IContentQuery<WorkDayPart> query;
            if (model.DepartmentId > 0) {
                query = _scheduleService.GetWorkDaysByDepartment(model.DepartmentId);
            }
            else if (model.EmployeeId > 0) {
                query = _scheduleService.GetWorkDaysByEmployee(model.EmployeeId);
            }
            else {
                query = _scheduleService.GetWorkDayQuery();
            }

            var now = DateTime.UtcNow;
            if (model.Week == 0) {
                model.Week = now.GetIso8601WeekOfYear();
            }
            if (model.Year == 0) {
                model.Year = now.Year;
            }

            var monday = DateHelpers.FirstDateOfWeekISO8601(model.Year, model.Week);
            // TODO: site setting which day is last day
            var saturday = monday.AddDays(5);

            var schedules = query
                .Where<WorkDayPartRecord>(w => w.Date >= monday.Date && w.Date < saturday.AddDays(1))
                .List();

            model.WorkDays = schedules.ToList();
            model.Start = monday;
            model.End = saturday;

            return View(model);
        }
    }
}