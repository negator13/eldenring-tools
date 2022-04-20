using CsvHelper.Configuration;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.CsvMappings
{
    public class ArmorMap : ClassMap<Armor>
    {
        public ArmorMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            //Map(m => m.ArmorId).Name("Armor ID");
            //Map(m => m.ArmorSetId).Name("Armor Set ID");
            //Map(m => m.Category).Name("Armor Category");
            Map(m => m.EquipSlot).Name("Equip Slot");
            Map(m => m.PhysicalNegation).Name("Damage Negation (Physical)");
            Map(m => m.StrikeNegation).Name("Damage Negation (VS Strike)");
            Map(m => m.SlashNegation).Name("Damage Negation (VS Slash)");
            Map(m => m.PierceNegation).Name("Damage Negation (VS Pierce)");
            Map(m => m.MagicNegation).Name("Damage Negation (Magic)");
            Map(m => m.FireNegation).Name("Damage Negation (Fire)");
            Map(m => m.LightningNegation).Name("Damage Negation (Lightning)");
            Map(m => m.HolyNegation).Name("Damage Negation (Holy)");
            Map(m => m.Immunity).Name("Immunity (Poison and Rot)");
            Map(m => m.Robustness).Name("Robustness (Blood)");
            //Map(m => m.Frost).Name("Frost");
            Map(m => m.Focus).Name("Focus (Madness)");
            //Map(m => m.Sleep).Name("Sleep");
            Map(m => m.Vitality).Name("Vitality (Death Blight)");
            Map(m => m.Poise).Name("Poise");
            Map(m => m.Weight).Name("Weight");
        }
    }
}
