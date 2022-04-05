namespace EldenRingBlazor.Data.Equipment
{
    public class Weapon
    {
        public int Id { get; set; }

        public string Name { get; set; }

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

        public string Effect1Type { get; set; }

        public int Effect2 { get; set; }

        public string Effect2Type { get; set; }

        public int Critical { get; set; }

        public double Weight { get; set; }

        public bool IsInfusable => Infusable == "Yes";
    }
}
