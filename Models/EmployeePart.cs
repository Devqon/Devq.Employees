using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement.Utilities;
using Orchard.Data.Conventions;

namespace Devq.Employees.Models
{
    public class EmployeePart : ContentPart<EmployeePartRecord> {

        internal LazyField<IEnumerable<IContent>> _workDaysField = new LazyField<IEnumerable<IContent>>();

        public IEnumerable<IContent> WorkDays {
            get { return _workDaysField.Value; }
            set { _workDaysField.Value = value; }
        }

        public bool FullTimer {
            get { return Retrieve(x => x.FullTimer); }
            set { Store(x => x.FullTimer, value); }
        }
    }

    public class EmployeePartRecord : ContentPartRecord {

        public virtual bool FullTimer { get; set; }

        [CascadeAllDeleteOrphan]
        public virtual IList<WorkDayPartRecord> WorkDays { get; set; }
    }
}