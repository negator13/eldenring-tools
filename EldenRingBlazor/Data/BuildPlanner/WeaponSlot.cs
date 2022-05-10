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

        public WeaponSlot(string slotName, EquipmentService equipmentService)
        {
            SlotName = slotName;

            _equipmentService = equipmentService;

            weaponList = _equipmentService.BaseWeapons;

            filteredWeaponNames = weaponList.Select(w => w.Name);

            weaponCategoryNames = new List<string>() { "All" };
            weaponCategoryNames.AddRange(weaponList.Select(c => c.WeaponType).Distinct().OrderBy(c => c));

            ScalingInfo = new List<ScalingRequirementsInfo>();
        }

        public Weapon Weapon { get; set; }

        public string SlotName { get; set; }

        public string WeaponName { get; set; }

        public int AffinityId { get; set; }

        public int Level { get; set; }

        public ScalingRequirements ScalingRequirements { get; set; }

        public List<ScalingRequirementsInfo> ScalingInfo { get; set; }

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
                    Weapon = null;
                    WeaponName = null;
                    AffinityId = 0;
                    Level = 0;
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

        public void GetScalingRequirements(AttackRatingCalculation Calculation)
        {
            var info = new List<ScalingRequirementsInfo>();

            if (Weapon == null || Calculation == null)
            {
                return;
            }

            var reqs = new ScalingRequirementsInfo
            {
                Label = "Reqs.",
                Strength = $"{Weapon.StrRequirement}",
                Dexterity = $"{Weapon.DexRequirement}",
                Intelligence = $"{Weapon.IntRequirement}",
                Faith = $"{Weapon.FthRequirement}",
                Arcane = $"{Weapon.ArcRequirement}",
            };

            info.Add(reqs);

            info.Add(new ScalingRequirementsInfo
            {
                Label = "Scaling",
                Strength = $"{Calculation.StrScaling:0.#}",
                Dexterity = $"{Calculation.DexScaling:0.#}",
                Intelligence = $"{Calculation.IntScaling:0.#}",
                Faith = $"{Calculation.FthScaling:0.#}",
                Arcane = $"{Calculation.ArcScaling:0.#}",
            });

            info.Add(new ScalingRequirementsInfo
            {
                Label = "",
                Strength = $"{Calculation.StrScaling.GetScalingGrade()}",
                Dexterity = $"{Calculation.DexScaling.GetScalingGrade()}",
                Intelligence = $"{Calculation.IntScaling.GetScalingGrade()}",
                Faith = $"{Calculation.FthScaling.GetScalingGrade()}",
                Arcane = $"{Calculation.ArcScaling.GetScalingGrade()}",
            });

            //ScalingRequirements = reqs;
            ScalingInfo = info;
        }
    }
}
