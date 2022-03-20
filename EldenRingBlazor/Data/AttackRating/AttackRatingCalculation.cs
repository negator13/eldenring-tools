namespace EldenRingBlazor.Data.AttackRating
{
    public class AttackRatingCalculation
    {
        public AttackRatingCalculation()
        {

        }

        public AttackRatingCalculation(
            string name,
            AttackRatingComponent physical,
            AttackRatingComponent magic,
            AttackRatingComponent fire,
            AttackRatingComponent lightning,
            AttackRatingComponent holy)
        {
            Physical = physical ?? new AttackRatingComponent(DamageType.Physical);
            Magic = magic ?? new AttackRatingComponent(DamageType.Magic);
            Fire = fire ?? new AttackRatingComponent(DamageType.Fire);
            Lightning = lightning ?? new AttackRatingComponent(DamageType.Lightning);
            Holy = holy ?? new AttackRatingComponent(DamageType.Holy);
        }

        public string Name { get; set; }

        public int TotalAttackRating => Physical.Total + Magic.Total + Fire.Total + Lightning.Total + Holy.Total;

        public AttackRatingComponent Physical { get; set; }

        public AttackRatingComponent Magic { get; set; }

        public AttackRatingComponent Fire { get; set; }

        public AttackRatingComponent Lightning { get; set; }

        public AttackRatingComponent Holy { get; set; }
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

        public int Total { get; set; }

        public double StrScaling { get; set; }

        public double DexScaling { get; set; }

        public double IntScaling { get; set; }

        public double FthScaling { get; set; }

        public double ArcScaling { get; set; }
    }
}
