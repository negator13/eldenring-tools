using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.AttackRating
{
    public class ModifiedWeapon : WeaponUpgrade
    {
        public ModifiedWeapon(Weapon weapon, WeaponUpgrade weaponUpgrade) : base(weaponUpgrade.WeaponLevel)
        {
            Name = $"{weapon.Name} +{weaponUpgrade.WeaponLevel}";

            AttackElementCorrectId = weaponUpgrade.AttackElementCorrectId;

            PhysicalAttack = weapon.PhysicalAttack * weaponUpgrade.PhysicalAttack;
            MagicAttack = weapon.MagicAttack * weaponUpgrade.MagicAttack;
            FireAttack = weapon.FireAttack * weaponUpgrade.FireAttack;
            LightningAttack = weapon.LightningAttack * weaponUpgrade.LightningAttack;
            HolyAttack = weapon.HolyAttack * weaponUpgrade.HolyAttack;

            StrScaling = weapon.StrScaling * weaponUpgrade.StrScaling;
            DexScaling = weapon.DexScaling * weaponUpgrade.DexScaling;
            IntScaling = weapon.IntScaling * weaponUpgrade.IntScaling;
            FthScaling = weapon.FthScaling * weaponUpgrade.FthScaling;
            ArcScaling = weapon.ArcScaling * weaponUpgrade.ArcScaling;

            PhysicalCorrectId = weapon.PhysicalCorrectId;
            MagicCorrectId = weapon.MagicCorrectId;
            FireCorrectId = weapon.FireCorrectId;
            LightningCorrectId = weapon.LightningCorrectId;
            HolyCorrectId = weapon.HolyCorrectId;

            StrRequirement = weapon.StrRequirement;
            DexRequirement = weapon.DexRequirement;
            IntRequirement = weapon.IntRequirement;
            FthRequirement = weapon.FthRequirement;
            ArcRequirement = weapon.ArcRequirement;
        }
    }
}
