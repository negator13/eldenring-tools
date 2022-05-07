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

        public WeaponSlot RightWeapon1 { get; set; }

        public WeaponSlot RightWeapon2 { get; set; }

        public WeaponSlot RightWeapon3 { get; set; }

        public WeaponSlot LeftWeapon1 { get; set; }

        public WeaponSlot LeftWeapon2 { get; set; }

        public WeaponSlot LeftWeapon3 { get; set; }
    }
}
