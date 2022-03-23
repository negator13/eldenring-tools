using CsvHelper;
using EldenRingBlazor.Data.CalcCorrect;
using EldenRingBlazor.DataAccess;
using System.Globalization;

namespace EldenRingBlazor.Data.AttackRating
{
    public class AttackRatingCalculationService
    {
        public IEnumerable<Weapon> Weapons { get; }
        private IEnumerable<Weapon> _allWeapons;
        private IEnumerable<WeaponUpgrade> _weaponUpgrades;
        private IEnumerable<AttackElement> _attackElements;

        private CalcCorrectService _calcCorrectService;

        public AttackRatingCalculationService(IWebHostEnvironment hostingEnvironment, CalcCorrectService calcCorrectService)
        {
            _calcCorrectService = calcCorrectService;

            string contentPath = hostingEnvironment.WebRootPath;

            string weaponCsvPath = Path.Combine(contentPath, "1.03", "Raw_Data.csv");
            string weaponUpgradeCsvPath = Path.Combine(contentPath, "1.03", "ReinforceParamWeapon.csv");
            string attackElementCorrectCsvPath = Path.Combine(contentPath, "1.03", "AttackElementCorrectParam.csv");

            using var weaponsReader = new StreamReader(weaponCsvPath);
            using var weaponsCsv = new CsvReader(weaponsReader, CultureInfo.InvariantCulture);
            weaponsCsv.Context.RegisterClassMap<WeaponMap>();

            _allWeapons = weaponsCsv.GetRecords<Weapon>().ToList();

            Weapons = _allWeapons
                .Where(w => w.ReinforceTypeId == Affinities.Standard || w.ReinforceTypeId == Affinities.Somber)
                .OrderBy(w => w.Name);

            using var weaponUpgradesReader = new StreamReader(weaponUpgradeCsvPath);
            using var weaponUpgradesCsv = new CsvReader(weaponUpgradesReader, CultureInfo.InvariantCulture);
            weaponUpgradesCsv.Context.RegisterClassMap<WeaponUpgradeMap>();
            _weaponUpgrades = weaponUpgradesCsv.GetRecords<WeaponUpgrade>().ToList();

            using var elementCorrectsReader = new StreamReader(attackElementCorrectCsvPath);
            using var elementCorrectsCsv = new CsvReader(elementCorrectsReader, CultureInfo.InvariantCulture);
            elementCorrectsCsv.Context.RegisterClassMap<AttackElementMap>();
            _attackElements = elementCorrectsCsv.GetRecords<AttackElement>().ToList();
        }

        public AttackRatingCalculation CalculateAttackRating(AttackRatingCalculationInput input)
        {
            var weaponId = input.WeaponId;
            var affinityId = input.WeaponAffinity;

            var affinitizedId = weaponId + affinityId;

            var baseWeapon = GetWeapon(affinitizedId);

            _calcCorrectService.GetCalcCorrectGraphIds(baseWeapon);

            var weaponUpgrade = GetWeaponUpgrade(baseWeapon, input.WeaponLevel);

            var modifiedWeapon = ApplyWeaponUpgradeModifiers(baseWeapon, weaponUpgrade);

            var attackElement = GetAttackElementCorrect(baseWeapon.AttackElementCorrectId);

            var attackRating = GetCorrections(input, modifiedWeapon, attackElement);

            return attackRating;
        }

        // Raw_Data lookup
        public Weapon GetWeapon(int id)
        {
            var weapon = _allWeapons.SingleOrDefault(w => w.Id == id);

            return weapon;
        }

        // ReinforceWeaponParam lookup
        private WeaponUpgrade GetWeaponUpgrade(Weapon weapon, int upgradeLevel)
        {
            int id = weapon.ReinforceTypeId + upgradeLevel;

            var weaponUpgrade = _weaponUpgrades.SingleOrDefault(wu => wu.Id == id);

            weaponUpgrade.WeaponLevel = upgradeLevel;

            return weaponUpgrade;
        }

        // AttackElementCorrect lookup
        private AttackElement GetAttackElementCorrect(int id)
        {
            return _attackElements.SingleOrDefault(a => a.Id == id);
        }

        private ModifiedWeapon ApplyWeaponUpgradeModifiers(Weapon weapon, WeaponUpgrade weaponUpgrade)
        {
            return new ModifiedWeapon(weapon, weaponUpgrade);
        }

        private AttackRatingCalculation GetCorrections(AttackRatingCalculationInput input, ModifiedWeapon weapon, AttackElement attackElementCorrect)
        {
            var physical = GetCorrection(DamageType.Physical, input, weapon, attackElementCorrect);
            var magic = GetCorrection(DamageType.Magic, input, weapon, attackElementCorrect);
            var fire = GetCorrection(DamageType.Fire, input, weapon, attackElementCorrect);
            var lightning = GetCorrection(DamageType.Lightning, input, weapon, attackElementCorrect);
            var holy = GetCorrection(DamageType.Holy, input, weapon, attackElementCorrect);

            var calculation = new AttackRatingCalculation(weapon, physical, magic, fire, lightning, holy);

            return calculation;
        }

        private AttackRatingComponent GetCorrection(DamageType damageType, AttackRatingCalculationInput input, ModifiedWeapon weapon, AttackElement attackElementCorrect)
        {
            int calcCorrectId;
            double baseDamage;

            bool hasStrScaling;
            bool hasDexScaling;
            bool hasIntScaling;
            bool hasFthScaling;
            bool hasArcScaling;

            switch (damageType)
            {
                case DamageType.Physical:
                    calcCorrectId = weapon.PhysicalCorrectId;
                    baseDamage = weapon.PhysicalAttack;
                    hasStrScaling = attackElementCorrect.PhysicalStr;
                    hasDexScaling = attackElementCorrect.PhysicalDex;
                    hasIntScaling = attackElementCorrect.PhysicalInt;
                    hasFthScaling = attackElementCorrect.PhysicalFth;
                    hasArcScaling = attackElementCorrect.PhysicalArc;
                    break;
                case DamageType.Magic:
                    calcCorrectId = weapon.MagicCorrectId;
                    baseDamage = weapon.MagicAttack;
                    hasStrScaling = attackElementCorrect.MagicStr;
                    hasDexScaling = attackElementCorrect.MagicDex;
                    hasIntScaling = attackElementCorrect.MagicInt;
                    hasFthScaling = attackElementCorrect.MagicFth;
                    hasArcScaling = attackElementCorrect.MagicArc;
                    break;
                case DamageType.Fire:
                    calcCorrectId = weapon.FireCorrectId;
                    baseDamage = weapon.FireAttack;
                    hasStrScaling = attackElementCorrect.FireStr;
                    hasDexScaling = attackElementCorrect.FireDex;
                    hasIntScaling = attackElementCorrect.FireInt;
                    hasFthScaling = attackElementCorrect.FireFth;
                    hasArcScaling = attackElementCorrect.FireArc;
                    break;
                case DamageType.Lightning:
                    calcCorrectId = weapon.LightningCorrectId;
                    baseDamage = weapon.LightningAttack;
                    hasStrScaling = attackElementCorrect.LightningStr;
                    hasDexScaling = attackElementCorrect.LightningDex;
                    hasIntScaling= attackElementCorrect.LightningInt;
                    hasFthScaling= attackElementCorrect.LightningFth;
                    hasArcScaling = attackElementCorrect.LightningArc;
                    break;
                case DamageType.Holy:
                    calcCorrectId = weapon.HolyCorrectId;
                    baseDamage = weapon.HolyAttack;
                    hasStrScaling = attackElementCorrect.HolyStr;
                    hasDexScaling = attackElementCorrect.HolyDex;
                    hasIntScaling= attackElementCorrect.HolyInt;
                    hasFthScaling= attackElementCorrect.HolyFth;
                    hasArcScaling= attackElementCorrect.HolyArc;
                    break;
                default:
                    throw new ArgumentException($"Unknown DamageType {damageType}");
            }

            var calcCorrectGraph = GetCalcCorrectGraph(calcCorrectId);

            var effectiveStrength = input.TwoHand ? (int)Math.Floor((input.Strength) * 1.5) : input.Strength;

            var strCorrection = _calcCorrectService.GetSpecificCalcCorrect(calcCorrectGraph, effectiveStrength);
            var dexCorrection = _calcCorrectService.GetSpecificCalcCorrect(calcCorrectGraph, input.Dexterity);
            var intCorrection = _calcCorrectService.GetSpecificCalcCorrect(calcCorrectGraph, input.Intelligence);
            var fthCorrection = _calcCorrectService.GetSpecificCalcCorrect(calcCorrectGraph, input.Faith);
            var arcCorrection = _calcCorrectService.GetSpecificCalcCorrect(calcCorrectGraph, input.Arcane);

            var strScaling = hasStrScaling ? baseDamage * weapon.StrScaling * .01 * strCorrection.Output : 0;
            var dexScaling = hasDexScaling ? baseDamage * weapon.DexScaling * .01 * dexCorrection.Output : 0;
            var intScaling = hasIntScaling ? baseDamage * weapon.IntScaling * .01 * intCorrection.Output : 0;
            var fthScaling = hasFthScaling ? baseDamage * weapon.FthScaling * .01 * fthCorrection.Output : 0;
            var arcScaling = hasArcScaling ? baseDamage * weapon.ArcScaling * .01 * arcCorrection.Output : 0;

            var meetsAllStatReqs = true;
            if (effectiveStrength < weapon.StrRequirement && hasStrScaling)
            {
                meetsAllStatReqs = false;
            }

            if (input.Dexterity < weapon.DexRequirement && hasDexScaling)
            {
                meetsAllStatReqs = false;
            }

            if (input.Intelligence < weapon.IntRequirement && hasIntScaling)
            {
                meetsAllStatReqs = false;
            }

            if (input.Faith < weapon.FthRequirement && hasFthScaling)
            {
                meetsAllStatReqs = false;
            }

            if (input.Arcane < weapon.ArcRequirement && hasArcScaling)
            {
                meetsAllStatReqs = false;
            }

            var totalScaling = meetsAllStatReqs ? strScaling + dexScaling + intScaling + fthScaling + arcScaling : (-baseDamage * 0.4);

            var totalDamage = baseDamage + totalScaling;

            var finalComponent = new AttackRatingComponent(damageType)
            {
                Total = (int)Math.Floor(totalDamage),
                Base = (int)Math.Floor(baseDamage),
                TotalScaling = (int)Math.Floor(totalScaling),
                StrScaling = strScaling,
                DexScaling = dexScaling,
                IntScaling = intScaling,
                FthScaling = fthScaling,
                ArcScaling = arcScaling,
            };

            return finalComponent;
        }

        // CalcCorrectGraph lookup
        private CalcCorrectGraph GetCalcCorrectGraph(int calcCorrectId)
        {
            var graph = _calcCorrectService.GetCalcCorrectGraph(calcCorrectId);

            if (graph == null)
            {
                throw new ArgumentException($"CalcCorrectId {calcCorrectId} not found");
            }

            return graph;
        }
    }
}
