using CsvHelper.Configuration;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.CsvMappings
{
    public class TalismanMap : ClassMap<Talisman>
    {
        public TalismanMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.TalismanName).Name("Talisman Name");
            Map(m => m.Weight).Name("Weight");
        }
    }
}
