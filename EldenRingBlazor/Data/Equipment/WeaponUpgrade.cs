namespace EldenRingBlazor.Data.Equipment
{
    public class WeaponUpgrade : Weapon
    {
        public WeaponUpgrade() : base()
        {

        }

        public WeaponUpgrade(Weapon weapon, int weaponLevel) : base(weapon.Name, weapon.WeaponType, weapon.Infusable)
        {
            WeaponLevel = weaponLevel;
        }

        public int WeaponLevel { get; set; }

        public double StaminaAttackScaling { get; set; }

        public double PhysicalGuard { get; set; }

    }
}
