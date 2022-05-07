using EldenRingBlazor.Data.AttackRating;
using EldenRingBlazor.Data.CalcCorrect;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class BuildPlannerService
    {
        private CalcCorrectService _calcCorrectService;
        private AttackRatingCalculationService _attackRatingCalculationService;

        public BuildPlannerService(
            CalcCorrectService calcCorrectService,
            AttackRatingCalculationService attackRatingCalculationService)
        {
            _calcCorrectService = calcCorrectService;
            _attackRatingCalculationService = attackRatingCalculationService;
        }

        public CharacterStatsCalculation? CalculateStats(BuildPlannerInput input)
        {
            try
            {
                input.Vigor = Math.Min(input.Vigor, 99);
                input.Mind = Math.Min(input.Mind, 99);
                input.Endurance = Math.Min(input.Endurance, 99);
                input.Strength = Math.Min(input.Strength, 99);
                input.Dexterity = Math.Min(input.Dexterity, 99);
                input.Intelligence = Math.Min(input.Intelligence, 99);
                input.Faith = Math.Min(input.Faith, 99);
                input.Arcane = Math.Min(input.Arcane, 99);

                var calculation = new CharacterStatsCalculation();

                calculation.Hp = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Hp, input.Vigor));

                calculation.Fp = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Fp, input.Mind));

                calculation.Stamina = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Stamina, input.Endurance));

                calculation.EquipLoad = _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.EquipLoad, input.Endurance);

                //calculation.Discovery = 100 + (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Discovery, input.Arcane));

                calculation.Discovery = 100 + input.Arcane;

                calculation.BaseDefense =  _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Defense_Level, input.Level);

                calculation.PhysicalDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.PhysicalDefense_Strength, input.Strength);

                calculation.MagicDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.MagicDefense_Intelligence, input.Intelligence);

                calculation.FireDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.FireDefense_Vigor, input.Vigor);

                calculation.LightningDefense = calculation.BaseDefense;

                calculation.HolyDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.HolyDefense_Arcane, input.Arcane);

                calculation.BaseResistance = _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Resistance_Level, input.Level);

                calculation.Immunity = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Immunity_Vigor, input.Vigor);

                calculation.Robustness = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Robustness_Endurance, input.Endurance);

                calculation.Focus = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Focus_Mind, input.Mind);

                calculation.Vitality = calculation.BaseResistance + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.Vitality_Arcane, input.Arcane);

                // TODO: Talismans

                // TODO: Other weapon slots

                var rightWeapon1Input = new AttackRatingCalculationInput
                {
                    Strength = input.Strength,
                    Dexterity = input.Dexterity,
                    Intelligence = input.Intelligence,
                    Faith = input.Faith,
                    Arcane = input.Arcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.RightWeapon1.Weapon,
                    AffinityId = input.RightWeapon1.AffinityId,
                    WeaponLevel = input.RightWeapon1.Level
                };

                calculation.RightWeapon1 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon1Input);

                var rightWeapon2Input = new AttackRatingCalculationInput
                {
                    Strength = input.Strength,
                    Dexterity = input.Dexterity,
                    Intelligence = input.Intelligence,
                    Faith = input.Faith,
                    Arcane = input.Arcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.RightWeapon2.Weapon,
                    AffinityId = input.RightWeapon2.AffinityId,
                    WeaponLevel = input.RightWeapon2.Level
                };

                calculation.RightWeapon2 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon2Input);

                var rightWeapon3Input = new AttackRatingCalculationInput
                {
                    Strength = input.Strength,
                    Dexterity = input.Dexterity,
                    Intelligence = input.Intelligence,
                    Faith = input.Faith,
                    Arcane = input.Arcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.RightWeapon3.Weapon,
                    AffinityId = input.RightWeapon3.AffinityId,
                    WeaponLevel = input.RightWeapon3.Level
                };

                calculation.RightWeapon3 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon3Input);

                var leftWeapon1Input = new AttackRatingCalculationInput
                {
                    Strength = input.Strength,
                    Dexterity = input.Dexterity,
                    Intelligence = input.Intelligence,
                    Faith = input.Faith,
                    Arcane = input.Arcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.LeftWeapon1.Weapon,
                    AffinityId = input.LeftWeapon1.AffinityId,
                    WeaponLevel = input.LeftWeapon1.Level
                };

                calculation.LeftWeapon1 = _attackRatingCalculationService.CalculateAttackRating(leftWeapon1Input);

                var leftWeapon2Input = new AttackRatingCalculationInput
                {
                    Strength = input.Strength,
                    Dexterity = input.Dexterity,
                    Intelligence = input.Intelligence,
                    Faith = input.Faith,
                    Arcane = input.Arcane,
                    TwoHand = input.TwoHand,
                    Weapon = input.LeftWeapon2.Weapon,
                    AffinityId = input.LeftWeapon2.AffinityId,
                    WeaponLevel = input.LeftWeapon2.Level
                };

                calculation.LeftWeapon2 = _attackRatingCalculationService.CalculateAttackRating(leftWeapon2Input);

                var leftWeapon3Input = new AttackRatingCalculationInput
                {
                    Strength = input.Strength,
                    Dexterity = input.Dexterity,
                    Intelligence = input.Intelligence,
                    Faith = input.Faith,
                    Arcane = input.Arcane,
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
    }
}
