using CsvHelper.Configuration;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.DataAccess
{
    public class WeaponCategoryMap : ClassMap<WeaponCategory>
    {
        // Weapons (Full data sheet)
        public WeaponCategoryMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.WeaponName).Name("Weapon Name");
            Map(m => m.Affinity).Name("Affinity");
            Map(m => m.WeaponType).Name("Weapon Type");
            Map(m => m.WeaponGroupId).Name("Weapon Group ID");
            Map(m => m.WeaponId).Name("Weapon ID");
            Map(m => m.ImbueTypeId).Name("Imbue Type ID");
            Map(m => m.ReinforceTypeId).Name("Reinforce Type ID");
        }
    }
}
