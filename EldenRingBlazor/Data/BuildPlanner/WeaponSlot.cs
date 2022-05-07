using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class WeaponSlot
    {
        public Weapon Weapon { get; set; }

        public string WeaponName { get; set; }

        public int AffinityId { get; set; }

        public int Level { get; set; }
    }
}
