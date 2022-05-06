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
                var calculation = new CharacterStatsCalculation();

                calculation.Hp = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_Hp, input.Vigor));

                calculation.Fp = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_Fp, input.Mind));

                calculation.Stamina = (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_Stamina, input.Endurance));

                calculation.EquipLoad = _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_EquipLoad, input.Endurance);

                calculation.Discovery = 100 + (int)Math.Floor(_calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_Discovery, input.Arcane));

                calculation.BaseDefense =  _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_Defense_Level, input.Level);

                calculation.PhysicalDefense = calculation.BaseDefense + _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_PhysicalDefense_Strength, input.Strength);

                // TODO: What is CalcCorrectId_PhysicalDefense_Vitality?
                //calculation.PhysicalDefense += _calcCorrectService.GetSpecificCalcCorrectOutputRaw(CalcCorrectIds.CalcCorrectId_PhysicalDefense_Vitality, input.Level);

                // TODO: Resistances, immunities

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
