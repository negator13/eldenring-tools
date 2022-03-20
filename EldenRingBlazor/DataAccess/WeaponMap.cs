using CsvHelper.Configuration;
using EldenRingBlazor.Data.AttackRating;

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
        }
    }
}
