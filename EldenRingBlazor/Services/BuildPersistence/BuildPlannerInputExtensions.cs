using EldenRingBlazor.Services.BuildPlanner;

namespace EldenRingBlazor.Services.BuildPersistence
{
    public static class BuildPlannerInputExtensions
    {
        public static SerializedBuildInput Serialize(this BuildPlannerInput input)
        {
            var data = new SerializedBuildInput();

            data.BuildId = input.BuildId;

            data.Name = input.Name;
            data.StartingClass = input.StartingClass?.Name;

            data.Vigor = input.Vigor;
            data.Mind = input.Mind;
            data.Endurance = input.Endurance;
            data.Strength = input.Strength;
            data.Dexterity = input.Dexterity;
            data.Intelligence = input.Intelligence;
            data.Faith = input.Faith;
            data.Arcane = input.Arcane;

            data.TwoHand = input.TwoHand;

            data.Talisman1 = input.Talisman1?.Name;
            data.Talisman2 = input.Talisman2?.Name;
            data.Talisman3 = input.Talisman3?.Name;
            data.Talisman4 = input.Talisman4?.Name;

            data.Head = input.Head?.Name;
            data.Chest = input.Chest?.Name;
            data.Arms = input.Arms?.Name;
            data.Legs = input.Legs?.Name;

            data.RightWeapon1 = input.RightWeapon1?.WeaponName;
            data.RightWeapon1Affinity = input.RightWeapon1?.AffinityId ?? 0;
            data.RightWeapon1Level = input.RightWeapon1?.Level ?? 0;

            data.RightWeapon2 = input.RightWeapon2?.WeaponName;
            data.RightWeapon2Affinity = input.RightWeapon2?.AffinityId ?? 0;
            data.RightWeapon2Level = input.RightWeapon2?.Level ?? 0;

            data.RightWeapon3 = input.RightWeapon3?.WeaponName;
            data.RightWeapon3Affinity = input.RightWeapon3?.AffinityId ?? 0;
            data.RightWeapon3Level = input.RightWeapon3?.Level ?? 0;

            data.LeftWeapon1 = input.LeftWeapon1?.WeaponName;
            data.LeftWeapon1Affinity = input.LeftWeapon1?.AffinityId ?? 0;
            data.LeftWeapon1Level = input.LeftWeapon1?.Level ?? 0;

            data.LeftWeapon2 = input.LeftWeapon2?.WeaponName;
            data.LeftWeapon2Affinity = input.LeftWeapon2?.AffinityId ?? 0;
            data.LeftWeapon2Level = input.LeftWeapon2?.Level ?? 0;

            data.LeftWeapon3 = input.LeftWeapon3?.WeaponName;
            data.LeftWeapon3Affinity = input.LeftWeapon3?.AffinityId ?? 0;
            data.LeftWeapon3Level = input.LeftWeapon3?.Level ?? 0;

            return data;
        }
    }
}
