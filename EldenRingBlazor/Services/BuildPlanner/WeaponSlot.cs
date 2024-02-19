using EldenRingBlazor.Services.AttackRating;
using EldenRingBlazor.Services.Equipment;

namespace EldenRingBlazor.Services.BuildPlanner
{
    public class WeaponSlot
    {
        private readonly EquipmentService _equipmentService;

        private IEnumerable<Weapon> weaponList = new List<Weapon>();
        private IEnumerable<string> filteredWeaponNames = new List<string>();

        private List<string> weaponCategoryNames = new List<string>();

        private int lastSelectedAffinity;
        private int? lastSelectedNormalUpgrade;
        private int? lastSelectedSpecialUpgrade;

        public IEnumerable<WeaponAffinity> AffinityList = new List<WeaponAffinity>();
        public IEnumerable<int> UpgradeList = new List<int>();

        public WeaponSlot(string slotName, EquipmentService equipmentService)
        {
            SlotName = slotName;

            _equipmentService = equipmentService;

            weaponList = _equipmentService.BaseWeapons;

            filteredWeaponNames = weaponList.Where(w => w.Name != null).Select(w => w.Name).ToList();

            weaponCategoryNames = new List<string>() { "All" };
            weaponCategoryNames.AddRange(weaponList.Select(c => c.WeaponType).Distinct().OrderBy(c => c));

            ScalingInfo = new List<ScalingRequirementsInfo>();
        }

        public Weapon? Weapon { get; set; }

        public string SlotName { get; set; }

        public string? WeaponName { get; set; }

        public int AffinityId { get; set; }

        public int Level { get; set; }

        public bool MeetsRequirements { get; set; }

        public ScalingRequirements? ScalingRequirements { get; set; }

        public List<ScalingRequirementsInfo> ScalingInfo { get; set; }

        public IEnumerable<string> SearchWeapons(string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value) || value == WeaponName)
                {
                    return filteredWeaponNames;
                }

                return filteredWeaponNames.Where(w => w.Contains(value, StringComparison.InvariantCultureIgnoreCase));
            }
            catch
            {
                return filteredWeaponNames;
            }
        }

        public void UpdateWeapon(string name)
        {
            var selectedWeapon = weaponList.FirstOrDefault(w => w.Name == name);

            if (selectedWeapon == null)
            {
                Weapon = null;
                WeaponName = null;
                AffinityId = 0;
                Level = 25;
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
                lastSelectedNormalUpgrade = lastSelectedNormalUpgrade == null ? weapon.MaxUpgrade : Level;
            }
            else
            {
                lastSelectedSpecialUpgrade = lastSelectedSpecialUpgrade == null ? weapon.MaxUpgrade : Level;
            }


            Weapon = weapon;
            WeaponName = weapon.Name;
            AffinityId = weapon.IsInfusable ? lastSelectedAffinity : 0;
            Level = weapon.MaxUpgrade > 10 ? lastSelectedNormalUpgrade.GetValueOrDefault() : lastSelectedSpecialUpgrade.GetValueOrDefault();

            AffinityList = weapon.IsInfusable ? Affinities.StandardAffinities : new List<WeaponAffinity>();

            UpgradeList = Enumerable.Range(0, weapon.MaxUpgrade + 1).AsQueryable();

            if (Level > weapon.MaxUpgrade)
            {
                Level = weapon.MaxUpgrade;
            }
        }

        public void GetScalingRequirements(AttackRatingCalculation Calculation)
        {
            var info = new List<ScalingRequirementsInfo>();

            if (Weapon == null || Calculation == null)
            {
                return;
            }

            var reqs = new ScalingRequirementsInfo(Weapon);

            info.Add(reqs);

            info.Add(new ScalingRequirementsInfo(RequirementsLabel.Scaling, Calculation));

            info.Add(new ScalingRequirementsInfo(RequirementsLabel.Grade, Calculation));

            ScalingInfo = info;
        }
    }
}
