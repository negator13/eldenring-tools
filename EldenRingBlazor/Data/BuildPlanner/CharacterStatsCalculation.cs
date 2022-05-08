using EldenRingBlazor.Data.AttackRating;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class CharacterStatsCalculation
    {
        public CharacterStatsCalculation()
        {
            PassiveEffects = new List<string>();
        }

        public double Hp { get; set; }

        public int DisplayHp => (int)Math.Floor(Hp);

        public double Fp { get; set; }

        public int DisplayFp => (int)Math.Floor(Fp);

        public double Stamina { get; set; }

        public int DisplayStamina => (int)Math.Floor(Stamina);

        public double EquipLoad { get; set; }

        public double DisplayEquipLoad => Math.Round(EquipLoad, 1);

        public double Discovery { get; set; }

        public int DisplayDiscovery => (int)Math.Floor(Discovery);

        public double Poise { get; set; }

        public int DisplayPoise => (int)Math.Floor(Poise);

        public double TotalWeight { get; set; }

        public double DisplayWeight => Math.Round(TotalWeight, 1);

        public double EquipBurdenPercent => Math.Round((TotalWeight / EquipLoad) * 100, 2);

        public double BaseResistance { get; set; }

        public double Immunity { get; set; }

        public int DisplayImmunity => (int)Math.Floor(Immunity);

        public double Robustness { get; set; }

        public int DisplayRobustness => (int)Math.Floor(Robustness);

        public double Focus { get; set; }

        public int DisplayFocus => (int)Math.Floor(Focus);

        public double Vitality { get; set; }

        public int DisplayVitality => (int)Math.Floor(Vitality);

        public double BaseDefense { get; set; }

        public double PhysicalDefense { get; set; }

        public int DisplayPhysicalDefense => (int)Math.Floor(PhysicalDefense);

        public double MagicDefense { get; set; }

        public int DisplayMagicDefense => (int)Math.Floor(MagicDefense);

        public double FireDefense { get; set; }

        public int DisplayFireDefense => (int)Math.Floor(FireDefense);

        public double LightningDefense { get; set; }

        public int DisplayLightningDefense => (int)Math.Floor(LightningDefense);

        public double HolyDefense { get; set; }

        public int DisplayHolyDefense => (int)Math.Floor(HolyDefense);

        public double PhysicalNegation { get; set; }

        public double DisplayPhysicalNegation => Math.Round(PhysicalNegation, 3);

        public double MagicNegation { get; set; }

        public double DisplayMagicNegation => Math.Round(MagicNegation, 3);

        public double FireNegation { get; set; }

        public double DisplayFireNegation => Math.Round(FireNegation, 3);

        public double LightningNegation { get; set; }

        public double DisplayLightningNegation => Math.Round(LightningNegation, 3);

        public double HolyNegation { get; set; }

        public double DisplayHolyNegation => Math.Round(HolyNegation, 3);

        public AttackRatingCalculation RightWeapon1 { get; set; }

        public AttackRatingCalculation RightWeapon2 { get; set; }

        public AttackRatingCalculation RightWeapon3 { get; set; }

        public AttackRatingCalculation LeftWeapon1 { get; set; }

        public AttackRatingCalculation LeftWeapon2 { get; set; }

        public AttackRatingCalculation LeftWeapon3 { get; set; }

        public List<string> PassiveEffects { get; set; }
    }
}
