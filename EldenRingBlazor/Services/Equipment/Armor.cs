namespace EldenRingBlazor.Services.Equipment
{
    public class Armor
    {
        public Armor()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string? EquipSlot { get; set; }

        public double PhysicalNegation { get; set; }

        public double EffectivePhysicalNegation => 1 - PhysicalNegation / 100;

        public double StrikeNegation { get; set; }

        public double EffectiveStrikeNegation => 1 - StrikeNegation / 100;

        public double SlashNegation { get; set; }

        public double EffectiveSlashNegation => 1 - SlashNegation / 100;

        public double PierceNegation { get; set; }

        public double EffectivePierceNegation => 1 - PierceNegation / 100;

        public double MagicNegation { get; set; }

        public double EffectiveMagicNegation => 1 - MagicNegation / 100;

        public double FireNegation { get; set; }

        public double EffectiveFireNegation => 1 - FireNegation / 100;

        public double LightningNegation { get; set; }

        public double EffectiveLightningNegation => 1 - LightningNegation / 100;

        public double HolyNegation { get; set; }

        public double EffectiveHolyNegation => 1 - HolyNegation / 100;

        public double Immunity { get; set; }

        public double Robustness { get; set; }

        public double EffectiveRobustness => 1 - Robustness / 100;

        public double Focus { get; set; }

        public double Vitality { get; set; }

        public double Poise { get; set; }

        public double Weight { get; set; }

        public double PoiseToWeight => Poise / Weight;

        public double PhysicalNegationToWeight => PhysicalNegation / Weight;
    }
}
