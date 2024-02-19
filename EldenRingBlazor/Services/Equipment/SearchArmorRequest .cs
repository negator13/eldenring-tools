namespace EldenRingBlazor.Services.Equipment
{
    public class SearchArmorRequest
    {
        public string? EquipSlot { get; set; } = "All";

        public int MinPoise { get; set; }

        public double MaxWeight { get; set; }


        public static List<string> EquipSlots = new List<string>
        {
            "All",
            "Head",
            "Body",
            "Arm",
            "Leg"
        };
    }
}
