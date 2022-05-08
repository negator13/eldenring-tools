using EldenRingBlazor.Data.AttackRating;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class WeaponSlot
    {
        private readonly EquipmentService _equipmentService;

        private IEnumerable<Weapon> weaponList = new List<Weapon>();
        private IEnumerable<string> filteredWeaponNames = new List<string>();
        

        private string weaponCategory = "All";
        private List<string> weaponCategoryNames = new List<string>();

        private int lastSelectedAffinity;
        private int lastSelectedNormalUpgrade;
        private int lastSelectedSpecialUpgrade;

        public IEnumerable<WeaponAffinity> AffinityList = new List<WeaponAffinity>();
        public IEnumerable<int> UpgradeList = new List<int>();

        public WeaponSlot(EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;

            weaponList = _equipmentService.BaseWeapons;

            filteredWeaponNames = weaponList.Select(w => w.Name);

            weaponCategoryNames = new List<string>() { "All" };
            weaponCategoryNames.AddRange(weaponList.Select(c => c.WeaponType).Distinct().OrderBy(c => c));

            ScalingRequirements = new List<ScalingRequirementsInfo>();
        }

        public Weapon Weapon { get; set; }

        public string WeaponName { get; set; }

        public int AffinityId { get; set; }

        public int Level { get; set; }

        public List<ScalingRequirementsInfo> ScalingRequirements { get; set; }

        public Task<IEnumerable<string>> SearchWeapons(string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value) || value == WeaponName)
                {
                    return Task.FromResult(filteredWeaponNames);
                }

                return Task.FromResult(filteredWeaponNames.Where(w => w.Contains(value, StringComparison.InvariantCultureIgnoreCase)));
            }
            catch
            {
                return Task.FromResult(filteredWeaponNames);
            }
        }

        private void UpdateWeaponCategory(string category)
        {
            try
            {
                weaponCategory = category;

                var matchingWeapons = category == "All" ? weaponList : weaponList.Where(c => c.WeaponType == category);

                filteredWeaponNames = matchingWeapons.Select(c => c.Name).OrderBy(c => c);
            }
            catch
            {

            }
        }

        public void UpdateWeapon(string name)
        {
            try
            {
                var selectedWeapon = weaponList.FirstOrDefault(w => w.Name == name);

                if (selectedWeapon == null)
                {
                    return;
                }

                var weapon = _equipmentService.GetWeapon(selectedWeapon.Id);

                if (weapon == null)
                {
                    return;
                }

                if (weapon.Infusable == "Yes")
                {
                    lastSelectedAffinity = AffinityId;
                }

                if (weapon.MaxUpgrade > 10)
                {
                    lastSelectedNormalUpgrade = Level;
                }
                else
                {
                    lastSelectedSpecialUpgrade = Level;
                }


                Weapon = weapon;
                WeaponName = weapon.Name;
                AffinityId = weapon.IsInfusable ? lastSelectedAffinity : 0;
                Level = weapon.MaxUpgrade > 10 ? lastSelectedNormalUpgrade : lastSelectedSpecialUpgrade;

                AffinityList = weapon.IsInfusable ? Affinities.StandardAffinities : new List<WeaponAffinity>();

                UpgradeList = Enumerable.Range(0, weapon.MaxUpgrade + 1).AsQueryable();

                if (Level > weapon.MaxUpgrade)
                {
                    Level = weapon.MaxUpgrade;
                }
            }
            catch
            {

            }
        }
    }
}
