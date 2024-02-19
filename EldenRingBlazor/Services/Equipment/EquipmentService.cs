using CsvHelper;
using EldenRingBlazor.CsvMappings;
using EldenRingBlazor.Services.BuildPlanner;
using System.Globalization;

namespace EldenRingBlazor.Services.Equipment
{
    public class EquipmentService
    {
        private readonly string _webRootPath;

        private readonly IEnumerable<Weapon> _allWeapons;
        private readonly IEnumerable<WeaponUpgrade> _weaponUpgrades;
        private readonly IEnumerable<AttackElement> _attackElements;
        private readonly IEnumerable<PassiveEffect> _passiveEffects;

        public readonly IEnumerable<Armor> Armor;
        public readonly IEnumerable<Talisman> Talismans;
        public readonly IEnumerable<StartingClass> StartingClasses;

        public IEnumerable<Weapon> BaseWeapons { get; }

        public EquipmentService(IWebHostEnvironment hostingEnvironment)
        {
            _webRootPath = hostingEnvironment.WebRootPath;

            _allWeapons = ReadWeaponsFromCsv();

            BaseWeapons = _allWeapons
                .Where(w => w.IsBaseWeapon())
                .OrderBy(w => w.Name);

            _weaponUpgrades = ReadWeaponUpgradesFromCsv();
            _attackElements = ReadAttackElementsFromCsv();

            _passiveEffects = ReadPassiveEffectsFromCsv();

            Armor = ReadArmorFromCsv();

            Talismans = ReadTalismansFromCsv();

            StartingClasses = ReadStartingClassesFromCsv();
        }

        private IEnumerable<Weapon> ReadWeaponsFromCsv()
        {
            string weaponCsvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "Raw_Data.csv");
            using var weaponsReader = new StreamReader(weaponCsvPath);
            using var weaponsCsv = new CsvReader(weaponsReader, CultureInfo.InvariantCulture);
            weaponsCsv.Context.RegisterClassMap<WeaponMap>();
            return weaponsCsv.GetRecords<Weapon>().ToList();
        }

        private IEnumerable<WeaponUpgrade> ReadWeaponUpgradesFromCsv()
        {
            string weaponUpgradeCsvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "ReinforceParamWeapon.csv");
            using var weaponUpgradesReader = new StreamReader(weaponUpgradeCsvPath);
            using var weaponUpgradesCsv = new CsvReader(weaponUpgradesReader, CultureInfo.InvariantCulture);
            weaponUpgradesCsv.Context.RegisterClassMap<WeaponUpgradeMap>();
            return weaponUpgradesCsv.GetRecords<WeaponUpgrade>().ToList();
        }

        private IEnumerable<AttackElement> ReadAttackElementsFromCsv()
        {
            string attackElementCorrectCsvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "AttackElementCorrectParam.csv");
            using var elementCorrectsReader = new StreamReader(attackElementCorrectCsvPath);
            using var elementCorrectsCsv = new CsvReader(elementCorrectsReader, CultureInfo.InvariantCulture);
            elementCorrectsCsv.Context.RegisterClassMap<AttackElementMap>();
            return elementCorrectsCsv.GetRecords<AttackElement>().ToList();
        }

        private IEnumerable<PassiveEffect> ReadPassiveEffectsFromCsv()
        {
            string csvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "SpEffectParam.csv");
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<PassiveEffectMap>();
            return csv.GetRecords<PassiveEffect>().ToList();
        }

        private IEnumerable<Armor> ReadArmorFromCsv()
        {
            string armorCsvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "Armor.csv");
            using var armorReader = new StreamReader(armorCsvPath);
            using var armorCsv = new CsvReader(armorReader, CultureInfo.InvariantCulture);
            armorCsv.Context.RegisterClassMap<ArmorMap>();
            return armorCsv.GetRecords<Armor>().ToList();
        }

        private IEnumerable<Talisman> ReadTalismansFromCsv()
        {
            string csvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "Talisman.csv");
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<TalismanMap>();
            return csv.GetRecords<Talisman>().ToList();
        }

        private IEnumerable<StartingClass> ReadStartingClassesFromCsv()
        {
            string csvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "StartingClasses.csv");
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<StartingClassMap>();
            return csv.GetRecords<StartingClass>().ToList();
        }

        // Raw_Data lookup
        public Weapon? GetWeapon(int id)
        {
            var weapon = _allWeapons.SingleOrDefault(w => w.Id == id);
            return weapon;
        }

        // ReinforceWeaponParam lookup
        public WeaponUpgrade GetWeaponUpgrade(Weapon weapon, int upgradeLevel)
        {
            int id = weapon.ReinforceTypeId + upgradeLevel;

            var weaponUpgrade = _weaponUpgrades.SingleOrDefault(wu => wu.Id == id);

            if (weaponUpgrade != null)
            {
                weaponUpgrade.WeaponLevel = upgradeLevel;
            }

            return weaponUpgrade ?? new WeaponUpgrade(weapon, 0);
        }

        // AttackElementCorrect lookup
        public AttackElement? GetAttackElementCorrect(int id)
        {
            return _attackElements.SingleOrDefault(a => a.Id == id);
        }

        // SpEffectParam lookup
        public PassiveEffect? GetPassiveEffect(int id)
        {
            return _passiveEffects.SingleOrDefault(e => e.Id == id);
        }

        public List<ModifiedWeapon> SearchWeapons(SearchWeaponsRequest request)
        {
            var filteredWeapons = _allWeapons
                .Where(w =>
                    (request.WeaponCategory == null || request.WeaponCategory == "All" || w.WeaponType == request.WeaponCategory)
                    && (w.IsTwoHandDualWield ? w.StrRequirement <= request.MaxStrength : w.StrRequirement <= request.EffectiveStrength)
                    && (w.DexRequirement <= request.MaxDexterity)
                    && (w.IntRequirement <= request.MaxIntelligence)
                    && (w.FthRequirement <= request.MaxFaith)
                    && (w.ArcRequirement <= request.MaxArcane))
                .ToList();

            var modifiedWeapons = filteredWeapons.Select(w => GetModifiedWeapon(w, request));

            if (request.Affinity > -1)
            {
                modifiedWeapons = modifiedWeapons.Where(m => m.AffinityName == Affinities.FromReinforceTypeId(request.Affinity));
            }

            return modifiedWeapons
                .OrderBy(m => m.BaseName)
                .ToList();
        }

        public ModifiedWeapon GetModifiedWeapon(Weapon weapon, SearchWeaponsRequest request)
        {
            var weaponUpgrade = GetWeaponUpgrade(weapon, weapon.MaxUpgrade > 10 ? request.UpgradeLevel : request.SomberUpgradeLevel);
            var modifiedWeapon = new ModifiedWeapon(weapon, weaponUpgrade);
            var baseWeaponId = weapon.Id - weapon.ReinforceTypeId;
            modifiedWeapon.BaseName = GetWeapon(baseWeaponId)?.Name ?? modifiedWeapon.Name;
            modifiedWeapon.AffinityName = Affinities.FromReinforceTypeId(weapon.ReinforceTypeId);
            return modifiedWeapon;
        }

        public List<Armor> SearchArmor(SearchArmorRequest request)
        {
            var filteredArmor = Armor
                .Where(w =>
                    (request.EquipSlot == null || request.EquipSlot == "All" || w.EquipSlot == request.EquipSlot)
                    && (request.MaxWeight == 0 || w.Weight <= request.MaxWeight)
                    && (request.MinPoise == 0 || w.Poise >= request.MinPoise))
                .ToList();

            return filteredArmor
                .OrderBy(m => m.Name)
                .ToList();
        }
    }
}
