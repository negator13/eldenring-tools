namespace EldenRingBlazor.Data.AttackRating
{
    public static class Affinities
    {
        public static readonly int Standard = 0;

        public static readonly int Heavy = 100;

        public static readonly int Keen = 200;

        public static readonly int Quality = 300;

        public static readonly int Fire = 400;

        public static readonly int FlameArt = 500;

        public static readonly int Lightning = 600;

        public static readonly int Sacred = 700;

        public static readonly int Magic = 800;

        public static readonly int Cold = 900;

        public static readonly int Poison = 1000;

        public static readonly int Blood = 1100;

        public static readonly int Occult = 1200;

        public static readonly int Somber = 2200;

        public static readonly int StaffOrSeal1 = 1900;

        public static readonly int StaffOrSeal2 = 2400;

        public static List<WeaponAffinity> StandardAffinities = new List<WeaponAffinity>
    {
        new WeaponAffinity
        {
            Id = Standard, Name = "Standard"
        },
        new WeaponAffinity
        {
            Id = Heavy, Name = "Heavy"
        },
        new WeaponAffinity
        {
            Id = Keen, Name = "Keen"
        },
        new WeaponAffinity
        {
            Id = Quality, Name = "Quality"
        },
        new WeaponAffinity
        {
            Id = Fire, Name = "Fire"
        },
        new WeaponAffinity
        {
            Id = FlameArt, Name = "Flame Art"
        },
        new WeaponAffinity
        {
            Id = Lightning, Name = "Lightning"
        },
        new WeaponAffinity
        {
            Id = Sacred, Name = "Sacred"
        },
        new WeaponAffinity
        {
            Id = Magic, Name = "Magic"
        },
        new WeaponAffinity
        {
            Id = Cold, Name = "Cold"
        },
        new WeaponAffinity
        {
            Id = Poison, Name = "Poison"
        },
        new WeaponAffinity
        {
            Id = Blood, Name = "Blood"
        },
        new WeaponAffinity
        {
            Id = Occult, Name = "Occult"
        },
    };

        public static List<WeaponAffinity> SomberAffinities = new List<WeaponAffinity>
    {
         new WeaponAffinity
        {
            Id = Somber, Name = "--"
        },
    };

        public static List<WeaponAffinity> StaffOrSealAffinities = new List<WeaponAffinity>
    {
         new WeaponAffinity
        {
            Id = StaffOrSeal1, Name = "--"
        },
          new WeaponAffinity
        {
            Id = StaffOrSeal2, Name = "--"
        },
    };
    }
}
