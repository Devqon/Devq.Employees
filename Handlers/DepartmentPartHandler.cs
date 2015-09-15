using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Devq.Employees.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Devq.Employees.Handlers
{
    public class DepartmentPartHandler : ContentHandler
    {
        public DepartmentPartHandler(IRepository<DepartmentPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}