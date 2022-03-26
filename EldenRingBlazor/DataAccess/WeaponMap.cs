using CsvHelper.Configuration;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.DataAccess
{
    public class WeaponMap: ClassMap<Weapon>
    {
        // Raw_Data
        public WeaponMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.ReinforceTypeId).Name("Reinforce Type ID");
            Map(m => m.AttackElementCorrectId).Name("Attack Element Correct ID");

            Map(m => m.PhysicalAttack).Name("Physical Attack");
            Map(m => m.MagicAttack).Name("Magic Attack");
            Map(m => m.FireAttack).Name("Fire Attack");
            Map(m => m.LightningAttack).Name("Lightning Attack");
            Map(m => m.HolyAttack).Name("Holy Attack");

            Map(m => m.StrScaling).Name("Str Scaling");
            Map(m => m.DexScaling).Name("Dex Scaling");
            Map(m => m.IntScaling).Name("Int Scaling");
            Map(m => m.FthScaling).Name("Fai Scaling");
            Map(m => m.ArcScaling).Name("Arc Scaling");
            Map(m => m.MaxUpgrade).Name("Max Upgrade");

            Map(m => m.StrRequirement).Name("Required (Str)");
            Map(m => m.DexRequirement).Name("Required (Dex)");
            Map(m => m.IntRequirement).Name("Required (Int)");
            Map(m => m.FthRequirement).Name("Required (Fai)");
            Map(m => m.ArcRequirement).Name("Required (Arc)");

            Map(m => m.NonInfusable).Name("Non-Infusable");

            Map(m => m.Effect1).Name("Effect 1");
            Map(m => m.Effect1Type).Name("Effect 1 Type");
            Map(m => m.Effect2).Name("Effect 2");
            Map(m => m.Effect2Type).Name("Effect 2 Type");

            Map(m => m.StaminaDamage).Name("Stamina Attack");
            Map(m => m.Critical).Name("Attack Power (Critical)");
            Map(m => m.Weight).Name("Weight");
        }
    }
}
