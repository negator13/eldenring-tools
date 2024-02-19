using EldenRingBlazor.Services.AttackRating;
using EldenRingBlazor.Services.Equipment;

namespace EldenRingBlazor.Services.BuildPlanner
{
    public class WeaponSlot
    {
        private readonly EquipmentService _equipmentService;

        private IEnumerable<Weapon> _weaponList = new List<Weapon>();
        private IEnumerable<string> _filteredWeaponNames = new List<string>();

        private int _lastSelectedAffinity;
        private int? _lastSelectedNormalUpgrade;
        private int? _lastSelectedSpecialUpgrade;

        public IEnumerable<WeaponAffinity> AffinityList = new List<WeaponAffinity>();
        public IEnumerable<int> UpgradeList = new List<int>();

        public WeaponSlot(string slotName, EquipmentService equipmentService)
        {
            SlotName = slotName;

            _equipmentService = equipmentService;

            _weaponList = _equipmentService.BaseWeapons;

            _filteredWeaponNames = _weaponList.Where(w => w.Name != null).Select(w => w.Name).ToList();

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
                    return _filteredWeaponNames;
                }

                return _filteredWeaponNames.Where(w => w.Contains(value, StringComparison.InvariantCultureIgnoreCase));
            }
            catch
            {
                return _filteredWeaponNames;
            }
        }

        public void UpdateWeapon(string name)
        {
            var selectedWeapon = _weaponList.FirstOrDefault(w => w.Name == name);

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
                _lastSelectedAffinity = AffinityId;
            }

            if (weapon.MaxUpgrade > 10)
            {
                _lastSelectedNormalUpgrade = _lastSelectedNormalUpgrade == null ? weapon.MaxUpgrade : Level;
            }
            else
            {
                _lastSelectedSpecialUpgrade = _lastSelectedSpecialUpgrade == null ? weapon.MaxUpgrade : Level;
            }


            Weapon = weapon;
            WeaponName = weapon.Name;
            AffinityId = weapon.IsInfusable ? _lastSelectedAffinity : 0;
            Level = weapon.MaxUpgrade > 10 ? _lastSelectedNormalUpgrade.GetValueOrDefault() : _lastSelectedSpecialUpgrade.GetValueOrDefault();

            AffinityList = weapon.IsInfusable ? Affinities.StandardAffinities : new List<WeaponAffinity>();

            UpgradeList = Enumerable.Range(0, weapon.MaxUpgrade + 1).AsQueryable();

            if (Level > weapon.MaxUpgrade)
            {
                Level = weapon.MaxUpgrade;
            }
        }

        public void GetScalingRequirements(AttackRatingCalculation? Calculation)
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
