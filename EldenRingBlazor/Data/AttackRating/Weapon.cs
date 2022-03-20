﻿namespace EldenRingBlazor.Data.AttackRating
{
    public class Weapon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AttackElementCorrectId { get; set; }

        public int ReinforceTypeId { get; set; }

        public int PhysicalCorrectId { get; set; }

        public int MagicCorrectId { get; set; }

        public int FireCorrectId { get; set; }

        public int LightningCorrectId { get; set; }

        public int HolyCorrectId { get; set; }

        public double PhysicalAttack { get; set; }

        public double FireAttack { get; set; }

        public double MagicAttack { get; set; }

        public double LightningAttack { get; set; }

        public double HolyAttack { get; set; }

        public double StrScaling { get; set; }

        public double DexScaling { get; set; }

        public double IntScaling { get; set; }

        public double FthScaling { get; set; }

        public double ArcScaling { get; set; }

        public int MaxUpgrade { get; set; }
    }
}
