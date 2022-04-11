namespace EldenRingBlazor.Data.Equipment
{
    public class ModifiedWeapon : WeaponUpgrade
    {
        public ModifiedWeapon(Weapon weapon, WeaponUpgrade weaponUpgrade) : base(weaponUpgrade?.WeaponLevel ?? 0)
        {
            var name = weapon.Name;

            if (weaponUpgrade?.WeaponLevel > 0 )
            {
                name = $"{weapon.Name} +{weaponUpgrade.WeaponLevel}";
            }

            Name = name;
            WeaponType = weapon.WeaponType;

            AttackElementCorrectId = weaponUpgrade?.AttackElementCorrectId ?? weapon.AttackElementCorrectId;

            PhysicalAttack = weapon.PhysicalAttack * (weaponUpgrade?.PhysicalAttack ?? 1);
            MagicAttack = weapon.MagicAttack * (weaponUpgrade?.MagicAttack ?? 1);
            FireAttack = weapon.FireAttack * (weaponUpgrade?.FireAttack ?? 1);
            LightningAttack = weapon.LightningAttack * (weaponUpgrade?.LightningAttack ?? 1);
            HolyAttack = weapon.HolyAttack * (weaponUpgrade?.HolyAttack ?? 1);

            StrScaling = weapon.StrScaling * (weaponUpgrade?.StrScaling ?? 1);
            DexScaling = weapon.DexScaling * (weaponUpgrade?.DexScaling ?? 1);
            IntScaling = weapon.IntScaling * (weaponUpgrade?.IntScaling ?? 1);
            FthScaling = weapon.FthScaling * (weaponUpgrade?.FthScaling ?? 1);
            ArcScaling = weapon.ArcScaling * (weaponUpgrade?.ArcScaling ?? 1);

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

            Effect1 = weapon.Effect1;
            Effect2 = weapon.Effect2;
            Effect1Type = weapon.Effect1Type;
            Effect2Type = weapon.Effect2Type;

            StaminaDamage = weapon.StaminaDamage * (weaponUpgrade?.StaminaAttackScaling ?? 1);

            Critical = weapon.Critical;
            Weight = weapon.Weight;

            Infusable = weapon.Infusable;
            TwoHandDualWield = weapon.TwoHandDualWield;
        }

        public string BaseName { get; set; }

        public int AffinityId { get; set; }

        public string AffinityName { get; set; }
    }
}
