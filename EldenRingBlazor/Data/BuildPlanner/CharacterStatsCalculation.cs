using EldenRingBlazor.Data.AttackRating;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class CharacterStatsCalculation
    {
        public CharacterStatsCalculation()
        {
            PassiveEffects = new List<string>();
        }

        public double Hp { get; set; }

        public double Fp { get; set; }

        public double Stamina { get; set; }

        public double EquipLoad { get; set; }

        public double Discovery { get; set; }

        public double Poise { get; set; }


        // TODO: Resistances

        public double BaseResistance { get; set; }

        public double Immunity { get; set; }

        public double Robustness { get; set; }

        public double Focus { get; set; }

        public double Vitality { get; set; }

        public double BaseDefense { get; set; }

        public double PhysicalDefense { get; set; }

        public double MagicDefense { get; set; }

        public double FireDefense { get; set; }

        public double LightningDefense { get; set; }

        public double HolyDefense { get; set; }

        public double PhysicalNegation { get; set; }

        public double MagicNegation { get; set; }

        public double FireNegation { get; set; }

        public double LightningNegation { get; set; }

        public double HolyNegation { get; set; }

        // TODO: Immunity, Robustness, Focus, Vitality

        public AttackRatingCalculation RightWeapon1 { get; set; }

        public AttackRatingCalculation RightWeapon2 { get; set; }

        public AttackRatingCalculation RightWeapon3 { get; set; }

        public AttackRatingCalculation LeftWeapon1 { get; set; }

        public AttackRatingCalculation LeftWeapon2 { get; set; }

        public AttackRatingCalculation LeftWeapon3 { get; set; }

        public List<string> PassiveEffects { get; set; }
    }
}
