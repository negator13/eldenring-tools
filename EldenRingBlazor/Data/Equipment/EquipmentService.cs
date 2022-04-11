﻿using CsvHelper;
using EldenRingBlazor.CsvMappings;
using System.Globalization;

namespace EldenRingBlazor.Data.Equipment
{
    public class EquipmentService
    {
        private readonly string _webRootPath;

        private readonly IEnumerable<Weapon> _allWeapons;
        private readonly IEnumerable<WeaponUpgrade> _weaponUpgrades;
        private readonly IEnumerable<AttackElement> _attackElements;
        private readonly IEnumerable<PassiveEffect> _passiveEffects;

        public IEnumerable<Weapon> BaseWeapons { get; }
        public IEnumerable<Weapon> WeaponCategories { get; }

        public EquipmentService(IWebHostEnvironment hostingEnvironment)
        {
            _webRootPath = hostingEnvironment.WebRootPath;

            _allWeapons = ReadWeaponsFromCsv();

            BaseWeapons = _allWeapons
                .Where(w => w.IsBaseWeapon())
                .OrderBy(w => w.Name);

            _weaponUpgrades = ReadWeaponUpgradesFromCsv();
            _attackElements = ReadAttackElementsFromCsv();

            WeaponCategories = _allWeapons
                .Where(w => w.ReinforceTypeId == Affinities.Standard || w.ReinforceTypeId == Affinities.Somber || w.ReinforceTypeId == Affinities.StaffOrSeal1 || w.ReinforceTypeId == Affinities.StaffOrSeal2)
                .OrderBy(w => w.Name);

            _passiveEffects = ReadPassiveEffectsFromCsv();
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

        // Raw_Data lookup
        public Weapon? GetWeapon(int id)
        {
            var weapon = _allWeapons.SingleOrDefault(w => w.Id == id);
            return weapon;
        }

        // ReinforceWeaponParam lookup
        public WeaponUpgrade? GetWeaponUpgrade(Weapon weapon, int upgradeLevel)
        {
            int id = weapon.ReinforceTypeId + upgradeLevel;

            var weaponUpgrade = _weaponUpgrades.SingleOrDefault(wu => wu.Id == id);

            if (weaponUpgrade != null)
            {
                weaponUpgrade.WeaponLevel = upgradeLevel;
            }

            return weaponUpgrade;
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
                    (request.WeaponCategory == null || w.WeaponType == request.WeaponCategory)
                    && (request.MaxStrength == 0 || w.StrRequirement <= request.MaxStrength)
                    && (request.MaxDexterity == 0 || w.StrRequirement <= request.MaxDexterity)
                    && (request.MaxIntelligence == 0 || w.StrRequirement <= request.MaxIntelligence)
                    && (request.MaxFaith == 0 || w.StrRequirement <= request.MaxFaith)
                    && (request.MaxArcane == 0 || w.StrRequirement <= request.MaxArcane)
                    && (request.MaxWeight == 0 || w.Weight <= request.MaxWeight))
                .OrderBy(w => w.Name) // TODO: Order by Scalings, etc
                //.Skip(request.Offset)
                //.Take(request.Limit)
                .ToList();

            var modifiedWeapons = filteredWeapons.Select(w => GetModifiedWeapon(w, request));

            return modifiedWeapons.ToList();
        }

        public ModifiedWeapon GetModifiedWeapon(Weapon weapon, SearchWeaponsRequest request)
        {
            var affinitizedId = weapon.Id + request.Affinity;
            var baseWeapon = GetWeapon(affinitizedId);
            var weaponUpgrade = GetWeaponUpgrade(baseWeapon, baseWeapon.IsInfusable ? request.UpgradeLevel : request.SomberUpgradeLevel);
            return new ModifiedWeapon(weapon, weaponUpgrade);
        }
    }
}
