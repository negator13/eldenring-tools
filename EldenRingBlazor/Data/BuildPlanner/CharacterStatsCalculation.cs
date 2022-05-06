using EldenRingBlazor.Data.AttackRating;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class CharacterStatsCalculation
    {
        public CharacterStatsCalculation()
        {

        }

        public int Hp { get; set; }

        public int Fp { get; set; }

        public int Stamina { get; set; }

        public double EquipLoad { get; set; }

        public int Discovery { get; set; }

        public int Poise { get; set; }

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

        // TODO: Immunity, Robustness, Focus, Vitality

        public AttackRatingCalculation RightWeapon1 { get; set; }

        public AttackRatingCalculation RightWeapon2 { get; set; }

        public AttackRatingCalculation RightWeapon3 { get; set; }

        public AttackRatingCalculation LeftWeapon1 { get; set; }

        public AttackRatingCalculation LeftWeapon2 { get; set; }

        public AttackRatingCalculation LeftWeapon3 { get; set; }
    }
}
