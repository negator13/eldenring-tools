namespace EldenRingBlazor.Data.Equipment
{
    public class Weapon
    {
        public Weapon()
        {
            Name = string.Empty;
            WeaponType = string.Empty;
            Infusable = string.Empty;
        }

        public Weapon(string name, string weaponType, string infusable)
        {
            Name = name;
            WeaponType = weaponType;
            Infusable = infusable;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string WeaponType { get; set; }

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

        public int StrRequirement { get; set; }

        public int DexRequirement { get; set; }

        public int IntRequirement { get; set; }

        public int FthRequirement { get; set; }

        public int ArcRequirement { get; set; }

        public string Infusable { get; set; }

        public double StaminaDamage { get; set; }

        public int Effect1 { get; set; }

        public string? Effect1Type { get; set; }

        public int Effect2 { get; set; }

        public string? Effect2Type { get; set; }

        public int Critical { get; set; }

        public double Weight { get; set; }

        public bool IsInfusable => Infusable == "Yes";

        public string? TwoHandStrengthBonus { get; set; }

        public bool IsTwoHandDualWield => TwoHandStrengthBonus == "No";

        public bool IsBaseWeapon()
        {
            return ReinforceTypeId == Affinities.Standard || ReinforceTypeId == Affinities.Somber
                || ReinforceTypeId == Affinities.StaffOrSeal1  || ReinforceTypeId == Affinities.StaffOrSeal2 || ReinforceTypeId == Affinities.StaffOrSeal3
                || ReinforceTypeId == Affinities.NormalCrossbow || ReinforceTypeId == Affinities.SomberCrosbow
                || ReinforceTypeId == Affinities.SmallShield || ReinforceTypeId == Affinities.Shield || ReinforceTypeId == Affinities.Greatshield1 || ReinforceTypeId == Affinities.Greatshield2;
        }
    }
}
