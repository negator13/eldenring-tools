using CsvHelper.Configuration;
using EldenRingBlazor.Services.BuildPlanner;
using EldenRingBlazor.Services.Equipment;

namespace EldenRingBlazor.CsvMappings
{
    public class StartingClassMap : ClassMap<StartingClass>
    {
        public StartingClassMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.Vigor).Name("Vigor");
            Map(m => m.Mind).Name("Mind");
            Map(m => m.Endurance).Name("Endurance");
            Map(m => m.Strength).Name("Strength");
            Map(m => m.Dexterity).Name("Dexterity");
            Map(m => m.Intelligence).Name("Intelligence");
            Map(m => m.Faith).Name("Faith");
            Map(m => m.Arcane).Name("Arcane");
        }
    }
}
