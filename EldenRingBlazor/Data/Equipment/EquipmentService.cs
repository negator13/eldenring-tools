using CsvHelper;
using EldenRingBlazor.DataAccess;
using System.Globalization;

namespace EldenRingBlazor.Data.Equipment
{
    public class EquipmentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IEnumerable<Weapon> _allWeapons;
        private readonly IEnumerable<WeaponUpgrade> _weaponUpgrades;
        private readonly IEnumerable<AttackElement> _attackElements;
        private readonly IEnumerable<WeaponCategory> _allWeaponCategories;
        
        public IEnumerable<Weapon> BaseWeapons { get; }
        public IEnumerable<WeaponCategory> WeaponCategories { get; }

        public EquipmentService(IWebHostEnvironment hostingEnvironment)
        {
            _webHostEnvironment = hostingEnvironment;

            _allWeapons = ReadWeaponsFromCsv();

            BaseWeapons = _allWeapons
                .Where(w => w.ReinforceTypeId == Affinities.Standard || w.ReinforceTypeId == Affinities.Somber || w.ReinforceTypeId == Affinities.StaffOrSeal1 || w.ReinforceTypeId == Affinities.StaffOrSeal2)
                .OrderBy(w => w.Name);

            _weaponUpgrades = ReadWeaponUpgradesFromCsv();
            _attackElements = ReadAttackElementsFromCsv();

            _allWeaponCategories = ReadWeaponCategoriesFromCsv();

            WeaponCategories  = _allWeaponCategories
                .Where(w => w.ReinforceTypeId == Affinities.Standard || w.ReinforceTypeId == Affinities.Somber || w.ReinforceTypeId == Affinities.StaffOrSeal1 || w.ReinforceTypeId == Affinities.StaffOrSeal2)
                .OrderBy(w => w.Name);
        }

        private IEnumerable<Weapon> ReadWeaponsFromCsv()
        {
            string weaponCsvPath = Path.Combine(_webHostEnvironment.ContentRootPath, VersionInfo.PatchVersion.Latest, "Raw_Data.csv");
            using var weaponsReader = new StreamReader(weaponCsvPath);
            using var weaponsCsv = new CsvReader(weaponsReader, CultureInfo.InvariantCulture);
            weaponsCsv.Context.RegisterClassMap<WeaponMap>();
            return weaponsCsv.GetRecords<Weapon>().ToList();
        }

        private IEnumerable<WeaponUpgrade> ReadWeaponUpgradesFromCsv()
        {
            string weaponUpgradeCsvPath = Path.Combine(_webHostEnvironment.ContentRootPath, VersionInfo.PatchVersion.Latest, "ReinforceParamWeapon.csv");
            using var weaponUpgradesReader = new StreamReader(weaponUpgradeCsvPath);
            using var weaponUpgradesCsv = new CsvReader(weaponUpgradesReader, CultureInfo.InvariantCulture);
            weaponUpgradesCsv.Context.RegisterClassMap<WeaponUpgradeMap>();
            return weaponUpgradesCsv.GetRecords<WeaponUpgrade>().ToList();
        }

        private IEnumerable<AttackElement> ReadAttackElementsFromCsv()
        {
            string attackElementCorrectCsvPath = Path.Combine(_webHostEnvironment.ContentRootPath, VersionInfo.PatchVersion.Latest, "AttackElementCorrectParam.csv");
            using var elementCorrectsReader = new StreamReader(attackElementCorrectCsvPath);
            using var elementCorrectsCsv = new CsvReader(elementCorrectsReader, CultureInfo.InvariantCulture);
            elementCorrectsCsv.Context.RegisterClassMap<AttackElementMap>();
            return elementCorrectsCsv.GetRecords<AttackElement>().ToList();
        }

        private IEnumerable<WeaponCategory> ReadWeaponCategoriesFromCsv()
        {
            string weaponCsvPath = Path.Combine(_webHostEnvironment.ContentRootPath, VersionInfo.PatchVersion.v1_02, "Weapons.csv");
            using var weaponsReader = new StreamReader(weaponCsvPath);
            using var weaponsCsv = new CsvReader(weaponsReader, CultureInfo.InvariantCulture);
            weaponsCsv.Context.RegisterClassMap<WeaponCategoryMap>();
            return weaponsCsv.GetRecords<WeaponCategory>().ToList();
        }

        // Raw_Data lookup
        public Weapon GetWeapon(int id)
        {
            var weapon = _allWeapons.SingleOrDefault(w => w.Id == id);

            return weapon;
        }

        // ReinforceWeaponParam lookup
        public WeaponUpgrade GetWeaponUpgrade(Weapon weapon, int upgradeLevel)
        {
            int id = weapon.ReinforceTypeId + upgradeLevel;

            var weaponUpgrade = _weaponUpgrades.SingleOrDefault(wu => wu.Id == id);

            weaponUpgrade.WeaponLevel = upgradeLevel;

            return weaponUpgrade;
        }

        // AttackElementCorrect lookup
        public AttackElement GetAttackElementCorrect(int id)
        {
            return _attackElements.SingleOrDefault(a => a.Id == id);
        }
    }
}
