using EldenRingBlazor.Data.AttackRating;
using EldenRingBlazor.Data.CalcCorrect;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class BuildPlannerService
    {
        private CalcCorrectService _calcCorrectService;
        private AttackRatingCalculationService _attackRatingCalculationService;
        private ArmorEffectsService _armorEffectsService;
        private WeaponEffectsService _weaponEffectsService;
        private TalismanService _talismanService;

        public BuildPlannerService(
            CalcCorrectService calcCorrectService,
            AttackRatingCalculationService attackRatingCalculationService,
             ArmorEffectsService armorEffectsService,
              WeaponEffectsService weaponEffectsService,
             TalismanService talismanService)
        {
            _calcCorrectService = calcCorrectService;
            _attackRatingCalculationService = attackRatingCalculationService;
            _armorEffectsService = armorEffectsService;
            _weaponEffectsService = weaponEffectsService;
            _talismanService = talismanService;
        }

        public CharacterStatsCalculation? CalculateStats(BuildPlannerInput input)
        {
            try
            {
                // Reset armor and talisman bonuses
                input.VigorBonus = 0;
                input.MindBonus = 0;
                input.EnduranceBonus = 0;
                input.StrengthBonus = 0;
                input.DexterityBonus = 0;
                input.IntelligenceBonus = 0;
                input.FaithBonus = 0;
                input.ArcaneBonus = 0;

                input.Vigor = Math.Min(input.Vigor, 99);
                input.Mind = Math.Min(input.Mind, 99);
                input.Endurance = Math.Min(input.Endurance, 99);
                input.Strength = Math.Min(input.Strength, 99);
                input.Dexterity = Math.Min(input.Dexterity, 99);
                input.Intelligence = Math.Min(input.Intelligence, 99);
                input.Faith = Math.Min(input.Faith, 99);
                input.Arcane = Math.Min(input.Arcane, 99);

                _armorEffectsService.ApplyPreCalculationArmorEffects(input, input.Head?.Name);
                _armorEffectsService.ApplyPreCalculationArmorEffects(input, input.Chest?.Name);
                _armorEffectsService.ApplyPreCalculationArmorEffects(input, input.Arms?.Name);
                _armorEffectsService.ApplyPreCalculationArmorEffects(input, input.Legs?.Name);

                _weaponEffectsService.ApplyPreCalculationWeaponEffects(input, input.RightWeapon1?.WeaponName);
                _weaponEffectsService.ApplyPreCalculationWeaponEffects(input, input.RightWeapon2?.WeaponName);
                _weaponEffectsService.ApplyPreCalculationWeaponEffects(input, input.RightWeapon3?.WeaponName);
                _weaponEffectsService.ApplyPreCalculationWeaponEffects(input, input.LeftWeapon1?.WeaponName);
                _weaponEffectsService.ApplyPreCalculationWeaponEffects(input, input.LeftWeapon2?.WeaponName);
                _weaponEffectsService.ApplyPreCalculationWeaponEffects(input, input.LeftWeapon3?.WeaponName);

                _talismanService.ApplyPreCalculationTalismanEffects(input, input.Talisman1?.Name);
                _talismanService.ApplyPreCalculationTalismanEffects(input, input.Talisman2?.Name);
                _talismanService.ApplyPreCalculationTalismanEffects(input, input.Talisman3?.Name);
                _talismanService.ApplyPreCalculationTalismanEffects(input, input.Talisman4?.Name);

                var calculation = new CharacterStatsCalculation();

                calculation.Hp = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Hp, input.EffectiveVigor));

                calculation.Fp = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Fp, input.EffectiveMind));

                calculation.Stamina = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Stamina, input.EffectiveEndurance));

                calculation.EquipLoad = _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.EquipLoad, input.EffectiveEndurance);

                calculation.Discovery = 100 + input.Arcane;

                calculation.BaseDefense =  _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Defense_Level, input.EffectiveLevel);

                calculation.PhysicalDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.PhysicalDefense_Strength, input.EffectiveStrength);

                calculation.MagicDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.MagicDefense_Intelligence, input.EffectiveIntelligence);

                calculation.FireDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.FireDefense_Vigor, input.EffectiveVigor);

                calculation.LightningDefense = calculation.BaseDefense;

                calculation.HolyDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.HolyDefense_Arcane, input.EffectiveArcane);

                calculation.BaseResistance = _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Resistance_Level, input.EffectiveLevel);

                calculation.Immunity = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Immunity_Vigor, input.EffectiveVigor);

                calculation.Robustness = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Robustness_Endurance, input.EffectiveEndurance);

                calculation.Focus = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Focus_Mind, input.EffectiveMind);

                calculation.Vitality = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Vitality_Arcane, input.EffectiveArcane);

                calculation.TotalWeight += input.Head?.Weight ?? 0;
                calculation.TotalWeight += input.Chest?.Weight ?? 0;
                calculation.TotalWeight += input.Arms?.Weight ?? 0;
                calculation.TotalWeight += input.Legs?.Weight ?? 0;

                calculation.TotalWeight += input.Talisman1?.Weight ?? 0;
                calculation.TotalWeight += input.Talisman2?.Weight ?? 0;
                calculation.TotalWeight += input.Talisman3?.Weight ?? 0;
                calculation.TotalWeight += input.Talisman4?.Weight ?? 0;

                calculation.TotalWeight += input.RightWeapon1?.Weapon?.Weight ?? 0;
                calculation.TotalWeight += input.RightWeapon2?.Weapon?.Weight ?? 0;
                calculation.TotalWeight += input.RightWeapon3?.Weapon?.Weight ?? 0;

                calculation.TotalWeight += input.LeftWeapon1?.Weapon?.Weight ?? 0;
                calculation.TotalWeight += input.LeftWeapon2?.Weapon?.Weight ?? 0;
                calculation.TotalWeight += input.LeftWeapon3?.Weapon?.Weight ?? 0;

                calculation.Poise += input.Head?.Poise ?? 0;
                calculation.Poise += input.Chest?.Poise ?? 0;
                calculation.Poise += input.Arms?.Poise ?? 0;
                calculation.Poise += input.Legs?.Poise ?? 0;

                ApplyDamageNegation(calculation, input);

                ApplyResistanceNegation(calculation, input);

                _armorEffectsService.ApplyPostCalculationArmorEffects(calculation, input.Head?.Name);
                _armorEffectsService.ApplyPostCalculationArmorEffects(calculation, input.Chest?.Name);
                _armorEffectsService.ApplyPostCalculationArmorEffects(calculation, input.Arms?.Name);
                _armorEffectsService.ApplyPostCalculationArmorEffects(calculation, input.Legs?.Name);

                _weaponEffectsService.ApplyPostCalculationWeaponEffects(calculation, input.RightWeapon1?.WeaponName);
                _weaponEffectsService.ApplyPostCalculationWeaponEffects(calculation, input.RightWeapon2?.WeaponName);
                _weaponEffectsService.ApplyPostCalculationWeaponEffects(calculation, input.RightWeapon3?.WeaponName);
                _weaponEffectsService.ApplyPostCalculationWeaponEffects(calculation, input.LeftWeapon1?.WeaponName);
                _weaponEffectsService.ApplyPostCalculationWeaponEffects(calculation, input.LeftWeapon2?.WeaponName);
                _weaponEffectsService.ApplyPostCalculationWeaponEffects(calculation, input.LeftWeapon3?.WeaponName);

                _talismanService.ApplyPostCalculationTalismanEffects(calculation, input.Talisman1?.Name);
                _talismanService.ApplyPostCalculationTalismanEffects(calculation, input.Talisman2?.Name);
                _talismanService.ApplyPostCalculationTalismanEffects(calculation, input.Talisman3?.Name);
                _talismanService.ApplyPostCalculationTalismanEffects(calculation, input.Talisman4?.Name);

                var rightWeapon1Input = new AttackRatingCalculationInput
                {
                    Strength = input.EffectiveStrength,
                    Dexterity = input.EffectiveDexterity,
                    Intelligence = input.EffectiveIntelligence,
                    Faith = input.EffectiveFaith,
                    Arcane = input.EffectiveArcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.RightWeapon1.Weapon,
                    AffinityId = input.RightWeapon1.AffinityId,
                    WeaponLevel = input.RightWeapon1.Level
                };

                calculation.RightWeapon1 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon1Input);

                var rightWeapon2Input = new AttackRatingCalculationInput
                {
                    Strength = input.EffectiveStrength,
                    Dexterity = input.EffectiveDexterity,
                    Intelligence = input.EffectiveIntelligence,
                    Faith = input.EffectiveFaith,
                    Arcane = input.EffectiveArcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.RightWeapon2.Weapon,
                    AffinityId = input.RightWeapon2.AffinityId,
                    WeaponLevel = input.RightWeapon2.Level
                };

                calculation.RightWeapon2 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon2Input);

                var rightWeapon3Input = new AttackRatingCalculationInput
                {
                    Strength = input.EffectiveStrength,
                    Dexterity = input.EffectiveDexterity,
                    Intelligence = input.EffectiveIntelligence,
                    Faith = input.EffectiveFaith,
                    Arcane = input.EffectiveArcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.RightWeapon3.Weapon,
                    AffinityId = input.RightWeapon3.AffinityId,
                    WeaponLevel = input.RightWeapon3.Level
                };

                calculation.RightWeapon3 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon3Input);

                var leftWeapon1Input = new AttackRatingCalculationInput
                {
                    Strength = input.EffectiveStrength,
                    Dexterity = input.EffectiveDexterity,
                    Intelligence = input.EffectiveIntelligence,
                    Faith = input.EffectiveFaith,
                    Arcane = input.EffectiveArcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.LeftWeapon1.Weapon,
                    AffinityId = input.LeftWeapon1.AffinityId,
                    WeaponLevel = input.LeftWeapon1.Level
                };

                calculation.LeftWeapon1 = _attackRatingCalculationService.CalculateAttackRating(leftWeapon1Input);

                var leftWeapon2Input = new AttackRatingCalculationInput
                {
                    Strength = input.EffectiveStrength,
                    Dexterity = input.EffectiveDexterity,
                    Intelligence = input.EffectiveIntelligence,
                    Faith = input.EffectiveFaith,
                    Arcane = input.EffectiveArcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.LeftWeapon2.Weapon,
                    AffinityId = input.LeftWeapon2.AffinityId,
                    WeaponLevel = input.LeftWeapon2.Level
                };

                calculation.LeftWeapon2 = _attackRatingCalculationService.CalculateAttackRating(leftWeapon2Input);

                var leftWeapon3Input = new AttackRatingCalculationInput
                {
                    Strength = input.EffectiveStrength,
                    Dexterity = input.EffectiveDexterity,
                    Intelligence = input.EffectiveIntelligence,
                    Faith = input.EffectiveFaith,
                    Arcane = input.EffectiveArcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.LeftWeapon3.Weapon,
                    AffinityId = input.LeftWeapon3.AffinityId,
                    WeaponLevel = input.LeftWeapon3.Level
                };

                calculation.LeftWeapon3 = _attackRatingCalculationService.CalculateAttackRating(leftWeapon3Input);

                return calculation;
            }
            catch
            {
                return null;
            }
        }

        private void ApplyDamageNegation(CharacterStatsCalculation calculation, BuildPlannerInput input)
        {
            // TODO: Encapsulate this calculation better
            calculation.PhysicalNegation = (1 - (
                (input.Head?.EffectivePhysicalNegation ?? 1) *
                (input.Chest?.EffectivePhysicalNegation ?? 1) *
                (input.Arms?.EffectivePhysicalNegation ?? 1) *
                (input.Legs?.EffectivePhysicalNegation ?? 1)
                )) * 100;

            calculation.StrikeNegation = (1 - (
                (input.Head?.EffectiveStrikeNegation ?? 1) *
                (input.Chest?.EffectiveStrikeNegation ?? 1) *
                (input.Arms?.EffectiveStrikeNegation ?? 1) *
                (input.Legs?.EffectiveStrikeNegation ?? 1)
                )) * 100;

            calculation.SlashNegation = (1 - (
                (input.Head?.EffectiveSlashNegation ?? 1) *
                (input.Chest?.EffectiveSlashNegation ?? 1) *
                (input.Arms?.EffectiveSlashNegation ?? 1) *
                (input.Legs?.EffectiveSlashNegation ?? 1)
                )) * 100;

            calculation.PierceNegation = (1 - (
                (input.Head?.EffectivePierceNegation ?? 1) *
                (input.Chest?.EffectivePierceNegation ?? 1) *
                (input.Arms?.EffectivePierceNegation ?? 1) *
                (input.Legs?.EffectivePierceNegation ?? 1)
                )) * 100;

            calculation.MagicNegation = (1 - (
                (input.Head?.EffectiveMagicNegation ?? 1) *
                (input.Chest?.EffectiveMagicNegation ?? 1) *
                (input.Arms?.EffectiveMagicNegation ?? 1) *
                (input.Legs?.EffectiveMagicNegation ?? 1)
                )) * 100;

            calculation.FireNegation = (1 - (
                (input.Head?.EffectiveFireNegation ?? 1) *
                (input.Chest?.EffectiveFireNegation ?? 1) *
                (input.Arms?.EffectiveFireNegation ?? 1) *
                (input.Legs?.EffectiveFireNegation ?? 1)
                )) * 100;

            calculation.LightningNegation = (1 - (
                (input.Head?.EffectiveLightningNegation ?? 1) *
                (input.Chest?.EffectiveLightningNegation ?? 1) *
                (input.Arms?.EffectiveLightningNegation ?? 1) *
                (input.Legs?.EffectiveLightningNegation ?? 1)
                )) * 100;

            calculation.HolyNegation = (1 - (
                (input.Head?.EffectiveHolyNegation ?? 1) *
                (input.Chest?.EffectiveHolyNegation ?? 1) *
                (input.Arms?.EffectiveHolyNegation ?? 1) *
                (input.Legs?.EffectiveHolyNegation ?? 1)
                )) * 100;
        }

        private void ApplyResistanceNegation(CharacterStatsCalculation calculation, BuildPlannerInput input)
        {
            calculation.Robustness += calculation.RobustnessArmor = (input.Head?.Robustness ?? 0) + (input.Chest?.Robustness ?? 0) + (input.Arms?.Robustness ?? 0) + (input.Legs?.Robustness ?? 0);
            calculation.Immunity += calculation.ImmunityArmor = (input.Head?.Immunity ?? 0) + (input.Chest?.Immunity ?? 0) + (input.Arms?.Immunity ?? 0) + (input.Legs?.Immunity ?? 0);
            calculation.Focus += calculation.FocusArmor = (input.Head?.Focus ?? 0) + (input.Chest?.Focus ?? 0) + (input.Arms?.Focus ?? 0) + (input.Legs?.Focus ?? 0);
            calculation.Vitality += calculation.VitalityArmor = (input.Head?.Vitality ?? 0) + (input.Chest?.Vitality ?? 0) + (input.Arms?.Vitality ?? 0) + (input.Legs?.Vitality ?? 0);
        }
    }
}
