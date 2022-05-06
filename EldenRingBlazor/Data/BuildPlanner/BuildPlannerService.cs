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
                    Weapon = input.RightWeapon1,
                    AffinityId = input.RightWeapon1AffinityId,
                    WeaponLevel = input.RightWeapon1Level
                };

                calculation.RightWeapon1 = _attackRatingCalculationService.CalculateAttackRating(rightWeapon1Input);

                return calculation;
            }
            catch
            {
                return null;
            }
        }
    }
}
