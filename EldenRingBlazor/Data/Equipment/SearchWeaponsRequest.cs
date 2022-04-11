namespace EldenRingBlazor.Data.Equipment
{
    public class SearchWeaponsRequest
    {
        //public int Limit { get; set; } = 10;

        //public int Offset { get; set; } = 0;

        public string? WeaponCategory { get; set; }

        public int UpgradeLevel { get; set; } = 25;

        public int SomberUpgradeLevel { get; set; } = 10;

        public int Affinity { get; set; }

        public int MaxStrength { get; set; }

        public bool TwoHand { get; set; }

        public int EffectiveStrength => TwoHand ? (int)Math.Floor(1.5 * MaxStrength) : MaxStrength;

        public int MaxDexterity { get; set; }

        public int MaxIntelligence { get; set; }

        public int MaxFaith { get; set; }

        public int MaxArcane { get; set; }

        public double MaxWeight { get; set; }
    }
}
