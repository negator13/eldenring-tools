using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.AttackRating
{
    public class AttackRatingCalculation
    {
        public AttackRatingCalculation(
            ModifiedWeapon weapon,
            AttackRatingComponent physical,
            AttackRatingComponent magic,
            AttackRatingComponent fire,
            AttackRatingComponent lightning,
            AttackRatingComponent holy,
            AttackRatingComponent sorceryIncantation)
        {
            Name = weapon.Name;

            StrScaling = Math.Round(weapon.StrScaling, 2);
            DexScaling = Math.Round(weapon.DexScaling, 2);
            IntScaling = Math.Round(weapon.IntScaling, 2);
            FthScaling = Math.Round(weapon.FthScaling, 2);
            ArcScaling = Math.Round(weapon.ArcScaling, 2);

            StaminaDamage = (int)Math.Floor(weapon.StaminaDamage);

            Physical = physical ?? new AttackRatingComponent(DamageType.Physical);
            Magic = magic ?? new AttackRatingComponent(DamageType.Magic);
            Fire = fire ?? new AttackRatingComponent(DamageType.Fire);
            Lightning = lightning ?? new AttackRatingComponent(DamageType.Lightning);
            Holy = holy ?? new AttackRatingComponent(DamageType.Holy);
            SorceryIncantation = sorceryIncantation ?? new AttackRatingComponent(DamageType.SorceryIncantation);
        }

        public string Name { get; set; }

        public int DisplayTotalAttackRating => (int)Math.Floor(TotalAttackRating);

        public double TotalAttackRating => Physical.Total + Magic.Total + Fire.Total + Lightning.Total + Holy.Total;

        public int StaminaDamage { get; set; }

        public double StrScaling { get; set; }

        public double DexScaling { get; set; }

        public double IntScaling { get; set; }

        public double FthScaling { get; set; }

        public double ArcScaling { get; set; }

        public bool MeetsRequirements { get; set; }

        public AttackRatingComponent Physical { get; set; }

        public AttackRatingComponent Magic { get; set; }

        public AttackRatingComponent Fire { get; set; }

        public AttackRatingComponent Lightning { get; set; }

        public AttackRatingComponent Holy { get; set; }

        public AttackRatingComponent SorceryIncantation { get; set; }

        public PassiveEffect Effect1 { get; set; }

        public PassiveEffect Effect2 { get; set; }
    }

    public class AttackRatingComponent
    {
        public AttackRatingComponent(DamageType damageType)
        {
            DamageType = damageType;
        }

        public DamageType DamageType { get; set; }

        public double Base { get; set; }

        public int TotalScaling { get; set; }

        public int DisplayTotal { get; set; }

        public double Total { get; set; }

        public double StrScaling { get; set; }

        public double DexScaling { get; set; }

        public double IntScaling { get; set; }

        public double FthScaling { get; set; }

        public double ArcScaling { get; set; }
    }
}
