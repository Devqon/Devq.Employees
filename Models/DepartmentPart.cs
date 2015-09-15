using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Devq.Employees.Models
{
    public class DepartmentPart : ContentPart<DepartmentPartRecord> {
    }

    public class DepartmentPartRecord : ContentPartRecord { }
}