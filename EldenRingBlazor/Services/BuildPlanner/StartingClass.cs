namespace EldenRingBlazor.Services.BuildPlanner
{
    public class StartingClass
    {
        public StartingClass()
        {
            Name = "Vagabond";
        }

        public string Name { get; set; }

        public int Vigor { get; set; }

        public int Mind { get; set; }

        public int Endurance { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }

        public static StartingClass Default = new StartingClass
        {
            Name = "Vagabond",
            Vigor = 15,
            Mind = 10,
            Endurance =11,
            Strength = 14,
            Dexterity = 13,
            Intelligence = 9,
            Faith = 9,
            Arcane = 7
        };
    }
}
