namespace EldenRingBlazor.Data.Equipment
{
    public class WeaponUpgrade: Weapon
    {
        public WeaponUpgrade() :base()
        {

        }

        public WeaponUpgrade(int weaponLevel) : base()
        {
            WeaponLevel = weaponLevel;
        }

        public int WeaponLevel { get; set; }

        public double StaminaAttackScaling { get; set; }

        public double PhysicalGuard { get; set; }

    }
}
