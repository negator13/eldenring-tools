using CsvHelper.Configuration;
using EldenRingBlazor.Services.Equipment;

namespace EldenRingBlazor.CsvMappings
{
    public class AttackElementMap : ClassMap<AttackElement>
    {
        // AttackElementCorrectParam
        public AttackElementMap()
        {
            Map(m => m.Id).Name("Row ID");

            Map(m => m.PhysicalStr).Name("Physical Scaling: STR");
            Map(m => m.PhysicalDex).Name("Physical Scaling: DEX");
            Map(m => m.PhysicalInt).Name("Physical Scaling: INT");
            Map(m => m.PhysicalFth).Name("Physical Scaling: FAI");
            Map(m => m.PhysicalArc).Name("Physical Scaling: ARC");

            Map(m => m.MagicStr).Name("Magic Scaling: STR");
            Map(m => m.MagicDex).Name("Magic Scaling: DEX");
            Map(m => m.MagicInt).Name("Magic Scaling: INT");
            Map(m => m.MagicFth).Name("Magic Scaling: FAI");
            Map(m => m.MagicArc).Name("Magic Scaling: ARC");

            Map(m => m.FireStr).Name("Fire Scaling: STR");
            Map(m => m.FireDex).Name("Fire Scaling: DEX");
            Map(m => m.FireInt).Name("Fire Scaling: INT");
            Map(m => m.FireFth).Name("Fire Scaling: FAI");
            Map(m => m.FireArc).Name("Fire Scaling: ARC");

            Map(m => m.LightningStr).Name("Lightning Scaling: STR");
            Map(m => m.LightningDex).Name("Lightning Scaling: DEX");
            Map(m => m.LightningInt).Name("Lightning Scaling: INT");
            Map(m => m.LightningFth).Name("Lightning Scaling: FAI");
            Map(m => m.LightningArc).Name("Lightning Scaling: ARC");

            Map(m => m.HolyStr).Name("Holy Scaling: STR");
            Map(m => m.HolyDex).Name("Holy Scaling: DEX");
            Map(m => m.HolyInt).Name("Holy Scaling: INT");
            Map(m => m.HolyFth).Name("Holy Scaling: FAI");
            Map(m => m.HolyArc).Name("Holy Scaling: ARC");
        }
    }
}
