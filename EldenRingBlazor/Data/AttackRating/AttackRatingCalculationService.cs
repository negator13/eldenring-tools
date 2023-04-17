using EldenRingBlazor.Data.CalcCorrect;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.AttackRating
{
    public class AttackRatingCalculationService
    {
        private CalcCorrectService _calcCorrectService;
        private EquipmentService _equipmentService;

        public AttackRatingCalculationService(CalcCorrectService calcCorrectService,
            EquipmentService equipmentService)
        {
            _calcCorrectService = calcCorrectService;
            _equipmentService = equipmentService;
        }

        public AttackRatingCalculation? CalculateAttackRating(AttackRatingCalculationInput input)
        {
            if (input.Weapon == null)
            {
                return null;
            }

            input.Strength = Math.Min(input.Strength, 99);
            input.Dexterity = Math.Min(input.Dexterity, 99);
            input.Intelligence = Math.Min(input.Intelligence, 99);
            input.Faith = Math.Min(input.Faith, 99);
            input.Arcane = Math.Min(input.Arcane, 99);

            var weaponId = input.Weapon.Id;
            var affinityId = input.AffinityId;

            var affinitizedId = weaponId + affinityId;

            var baseWeapon = _equipmentService.GetWeapon(affinitizedId);

            if (baseWeapon == null)
            {
                return null;
            }

            _calcCorrectService.GetCalcCorrectGraphIds(baseWeapon);

            var weaponUpgrade = _equipmentService.GetWeaponUpgrade(baseWeapon, input.WeaponLevel);

            if (weaponUpgrade == null)
            {
                return null;
            }

            var modifiedWeapon = ApplyWeaponUpgradeModifiers(baseWeapon, weaponUpgrade);

            var attackElement = _equipmentService.GetAttackElementCorrect(baseWeapon.AttackElementCorrectId);

            if (attackElement == null)
            {
                return null;
            }

            var attackRating = GetCorrections(input, modifiedWeapon, attackElement);

            return attackRating;
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

            var sorceryIncantation = GetCorrection(DamageType.SorceryIncantation, input, weapon, attackElementCorrect);

            var calculation = new AttackRatingCalculation(weapon, physical, magic, fire, lightning, holy, sorceryIncantation);

            calculation.Effect1 = GetPassiveEffect(input, weapon, weapon.Effect1);
            calculation.Effect2 = GetPassiveEffect(input, weapon, weapon.Effect2);

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
                case DamageType.SorceryIncantation:
                    calcCorrectId = weapon.MagicCorrectId;
                    baseDamage = 100;
                    hasStrScaling = attackElementCorrect.MagicStr;
                    hasDexScaling = attackElementCorrect.MagicDex;
                    hasIntScaling = attackElementCorrect.MagicInt;
                    hasFthScaling = attackElementCorrect.MagicFth;
                    hasArcScaling = attackElementCorrect.MagicArc;
                    break;
                default:
                    throw new ArgumentException($"Unknown DamageType {damageType}");
            }

            var calcCorrectGraph = _calcCorrectService.GetCalcCorrectGraph(calcCorrectId);
            var effectiveStrength = weapon.IsTwoHandDualWield ? input.Strength : input.EffectiveStrength;

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
                Total = totalDamage,
                DisplayTotal = (int)Math.Floor(totalDamage),
                Base = (int)Math.Floor(baseDamage),
                TotalScaling = (int)Math.Floor(totalScaling),
                StrScaling = strScaling,
                DexScaling = dexScaling,
                IntScaling = intScaling,
                FthScaling = fthScaling,
                ArcScaling = arcScaling
            };

            return finalComponent;
        }

        private PassiveEffect GetPassiveEffect(AttackRatingCalculationInput input, ModifiedWeapon weapon, int effectId)
        {
            var passiveEffect = new PassiveEffect { Type = "None", Value = 0 };

            if (effectId == -1)
            {
                return passiveEffect;
            }

            var upgradedEffectId = effectId;
            if (effectId >= 10000)
            {
                // 4-digit IDs don't scale with upgrades
                upgradedEffectId = effectId + weapon.WeaponLevel;
            }

            var effect = _equipmentService.GetPassiveEffect(upgradedEffectId);

            if (effect == null)
            {
                // Workaround: SpEffectParam seems incomplete for certain (4-digit) IDs
                effect = _equipmentService.GetPassiveEffect(effectId);
            }

            if (effect == null)
            {
                return passiveEffect;
            }

            double scaling = 0;

            if (effect.Type == "None")
            {
                return passiveEffect;
            }

            if (effect.Type == "Blood" || effect.Type == "Poison" || effect.Type == "Madness" || effect.Type == "Sleep")
            {
                // ARC scaling does not apply to Rot
                scaling  = GetPassiveEffectCorrection(input, weapon, effect);
            }

            var value = effect.Value + scaling;

            return new PassiveEffect { Type = effect.Type, Value = Math.Floor(value) };
        }

        private double GetPassiveEffectCorrection(AttackRatingCalculationInput input, ModifiedWeapon weapon, PassiveEffect effect)
        {
            int calcCorrectId = 6; // Passive Effects (Arcane)
            var calcCorrectGraph = _calcCorrectService.GetCalcCorrectGraph(calcCorrectId);
            var arcCorrection = _calcCorrectService.GetSpecificCalcCorrect(calcCorrectGraph, input.Arcane);

            var baseAmount = effect.Value;

            var effectScaling = baseAmount * arcCorrection.Output * weapon.ArcScaling * .01;

            var meetsAllStatReqs = input.Arcane >= weapon.ArcRequirement;

            return meetsAllStatReqs ? effectScaling : 0;
        }
    }
}
