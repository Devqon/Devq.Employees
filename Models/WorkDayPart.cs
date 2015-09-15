using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Users.Models;

namespace Devq.Employees.Models
{
    public class WorkDayPart : ContentPart<WorkDayPartRecord>
    {
        public DateTime? Date {
            get { return Retrieve(x => x.Date); }
            set { Store(x => x.Date, value); }
        }

        public DateTime? Start
        {
            get { return Retrieve(x => x.Start); }
            set { Store(x => x.Start, value); }
        }

        public DateTime? End
        {
            get { return Retrieve(x => x.End); }
            set { Store(x => x.End, value); }
        }

        public string Notes
        {
            get { return Retrieve(x => x.Notes); }
            set { Store(x => x.Notes, value); }
        }
    }

    public class WorkDayPartRecord : ContentPartRecord {

        public virtual UserPartRecord User { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual DateTime? Start { get; set; }
        public virtual DateTime? End { get; set; }
        public virtual string Notes { get; set; }
    }

    public enum WorkDayType {
        Normal,
        Sick,
        NotShowed
    }
}