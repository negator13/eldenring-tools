namespace EldenRingBlazor.Data.AttackRating
{
    public class ScalingRequirementsInfo
    {
        public string Label { get; set; }

        public string Strength { get; set; }

        public string Dexterity { get; set; }

        public string Intelligence { get; set; }

        public string Faith { get; set; }

        public string Arcane { get; set; }
    }

    public class ScalingRequirements
    {
        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }
    }
}
