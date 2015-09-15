using Devq.Employees.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Devq.Utilities.Extensions;

namespace Devq.Employees.Migrations
{
    public class Migrations : DataMigrationImpl
    {
        public int Create() {

            SchemaBuilder.CreateTable(typeof (EmployeePartRecord).Name,
                table => table

                    .ContentPartRecord()

                    .Column<bool>("FullTimer"));

            ContentDefinitionManager.AlterTypeDefinition("User",
                type => type

                    .WithPart("ProfilePart")

                    .WithPart<EmployeePart>());

            return 1;
        }

        public int UpdateFrom1() {
            
            ContentDefinitionManager.AlterPartDefinition<DepartmentPart>(part => part
                .WithField("Employees", field => field
                    .OfType("ContentPickerField")
                    .WithSetting("ContentPickerFieldSettings.Multiple", "true")
                    .WithSetting("ContentPickerFieldSettings.DisplayedContentTypes", "User")));

            ContentDefinitionManager.AlterTypeDefinition("Department",
                type => type
                
                    .Default() // common, title, body
                    .WithPart<DepartmentPart>());

            return 2;
        }

        public int UpdateFrom2() {
            SchemaBuilder.CreateTable(typeof (DepartmentPartRecord).Name,
                table => table
                    .ContentPartRecord());

            return 3;
        }
    }
}