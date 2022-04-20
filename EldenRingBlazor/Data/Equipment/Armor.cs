namespace EldenRingBlazor.Data.Equipment
{
    public class Armor
    {
        public int Id { get; set; }

        //public int ArmorId { get; set; }

        //public int ArmorSetId { get; set; }

        //public int Category { get; set; }

        public string? Name { get; set; }

        public string? EquipSlot { get; set; }

        public double PhysicalNegation { get; set; }

        public double StrikeNegation { get; set; }

        public double SlashNegation { get; set; }

        public double PierceNegation { get; set; }

        public double MagicNegation { get; set; }

        public double FireNegation { get; set; }

        public double LightningNegation { get; set; }

        public double HolyNegation { get; set; }

        public int Immunity { get; set; }

        public int Robustness { get; set; }

        //public int Frost { get; set; }

        public int Focus { get; set; }

        //public int Sleep { get; set; }

        public int Vitality { get; set; }

        public int Poise { get; set; }

        public double Weight { get; set; }

        public double PoiseToWeight => Poise / Weight;

        public double PhysicalNegationToWeight => PhysicalNegation / Weight;
    }
}
