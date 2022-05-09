using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class BuildPlannerInput
    {
        public BuildPlannerInput(EquipmentService equipmentService)
        {
            RightWeapon1 = new WeaponSlot("Right Weapon 1", equipmentService);
            RightWeapon2 = new WeaponSlot("Right Weapon 2", equipmentService);
            RightWeapon3 = new WeaponSlot("Right Weapon 3", equipmentService);
            LeftWeapon1 = new WeaponSlot("Left Weapon 1", equipmentService);
            LeftWeapon2 = new WeaponSlot("Left Weapon 2", equipmentService);
            LeftWeapon3 = new WeaponSlot("Left Weapon 3", equipmentService);
        }

        public int DisplayLevel => Level - 79;

        public int Level => ActualVigor + ActualMind + ActualEndurance + ActualStrength + ActualDexterity + ActualIntelligence + ActualFaith + ActualArcane;

        public StartingClass StartingClass { get; set; }

        public bool TwoHand { get; set; }

        public int Vigor { get; set; }

        public int VigorBonus { get; set; }

        public int ActualVigor => Vigor - VigorBonus;

        public int Mind { get; set; }

        public int MindBonus { get; set; }

        public int ActualMind => Mind - MindBonus;

        public int Endurance { get; set; }

        public int EnduranceBonus { get; set; }

        public int ActualEndurance => Endurance - EnduranceBonus;

        public int Strength { get; set; }
        
        public int StrengthBonus { get; set; }

        public int ActualStrength => Strength - StrengthBonus;

        public int Dexterity { get; set; }

        public int DexterityBonus { get; set; }

        public int ActualDexterity => Dexterity - DexterityBonus;

        public int Intelligence { get; set; }

        public int IntelligenceBonus { get; set; }

        public int ActualIntelligence => Intelligence - IntelligenceBonus;

        public int Faith { get; set; }

        public int FaithBonus { get; set; }

        public int ActualFaith => Faith - FaithBonus;

        public int Arcane { get; set; }

        public int ArcaneBonus { get; set; }

        public int ActualArcane => Arcane - ArcaneBonus;

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
