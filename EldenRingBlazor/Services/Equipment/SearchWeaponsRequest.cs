namespace EldenRingBlazor.Services.Equipment
{
    public class SearchWeaponsRequest
    {
        public string? WeaponCategory { get; set; } = "All";

        public int UpgradeLevel { get; set; } = 25;

        public int SomberUpgradeLevel { get; set; } = 10;

        public int Affinity { get; set; } = -1;

        public int MaxStrength { get; set; } = 99;

        public bool TwoHand { get; set; }

        public int EffectiveStrength => TwoHand ? (int)Math.Floor(1.5 * MaxStrength) : MaxStrength;

        public int MaxDexterity { get; set; } = 99;

        public int MaxIntelligence { get; set; } = 99;

        public int MaxFaith { get; set; } = 99;

        public int MaxArcane { get; set; } = 99;
    }
}
