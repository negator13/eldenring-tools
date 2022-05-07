using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.BuildPlanner
{
    public class WeaponSlot
    {
        public Weapon Weapon { get; set; }

        public string Weapon1Name { get; set; }

        public int AffinityId { get; set; }

        public int Level { get; set; }
    }
}
