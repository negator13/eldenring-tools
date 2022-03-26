using CsvHelper.Configuration;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.DataAccess
{
    public class PassiveEffectMap: ClassMap<PassiveEffect>
    {
        // SpEffectParam
        public PassiveEffectMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Value).Name("Value");
            Map(m => m.Type).Name("Type");
        }
    }
}
