using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class BuildPlannerInput
    {
        public BuildPlannerInput(EquipmentService equipmentService)
        {
            RightWeapon1 = new WeaponSlot(equipmentService);
            RightWeapon2 = new WeaponSlot(equipmentService);
            RightWeapon3 = new WeaponSlot(equipmentService);
            LeftWeapon1 = new WeaponSlot(equipmentService);
            LeftWeapon2 = new WeaponSlot(equipmentService);
            LeftWeapon3 = new WeaponSlot(equipmentService);
        }

        public int DisplayLevel => Level - 79;

        public int Level => Vigor + Mind + Endurance + Strength + Dexterity + Intelligence + Faith + Arcane;

        public StartingClass StartingClass { get; set; }

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

        public Armor Head { get; set; }

        public Armor Chest { get; set; }

        public Armor Arms { get; set; }

        public Armor Legs { get; set; }

        public Talisman Talisman1 { get; set; }
        public Talisman Talisman2 { get; set; }
        public Talisman Talisman3 { get; set; }
        public Talisman Talisman4 { get; set; }
    }
}
