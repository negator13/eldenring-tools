using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class BuildPlannerInput
    {
        public int DisplayLevel => Level - 79;

        public int Level => Vigor + Mind + Endurance + Strength + Dexterity + Intelligence + Faith + Arcane;

        public bool TwoHand { get; set; }

        public int Vigor { get; set; }

        public int Mind { get; set; }

        public int Endurance { get; set; }

        public int Strength { get; set; }

        public int EffectiveStrength => TwoHand ? (int)Math.Floor(1.5 * Strength) : Strength;

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }

        public Weapon RightWeapon1 { get; set; }

        public string RightWeapon1Name { get; set; }

        public int RightWeapon1AffinityId { get; set; }

        public int RightWeapon1Level { get; set; }

        public Weapon LeftWeapon1 { get; set; }

        public string LeftWeapon1Name { get; set; }

        public int LeftWeapon1AffinityId { get; set; }

        public int LeftWeapon1Level { get; set; }
    }
}
