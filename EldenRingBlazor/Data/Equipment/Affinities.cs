namespace EldenRingBlazor.Data.Equipment
{
    public static class Affinities
    {
        //public static readonly Dictionary<int, string> ReinforceTypeIdMap = new Dictionary<int, string>
        //{
        //    { Standard, "" },
        //    { Heavy, "Heavy" },
        //    { Heavy2, "Heavy" },
        //    { Keen, "Keen" },
        //    { Keen2, "Keen" },
        //    { Quality, "Quality" },
        //    { Fire, "Fire" },
        //    { FlameArt, "Flame Art" },
        //    { Lightning, "Lightning" },
        //    { Sacred, "Sacred" },
        //    { Magic, "Magic" },
        //    { Cold, "Cold" },
        //    { Poison, "Poison" },
        //    { Blood, "Blood" },
        //    { Occult, "Occult" },
        //};

        public static string FromReinforceTypeId(this int reinforceTypeId)
        {
           var ReinforceTypeIdMap = new Dictionary<int, string>
        {
            { Standard, "" },
            { Heavy, "Heavy" },
            { Heavy2, "Heavy" },
            { Keen, "Keen" },
            { Keen2, "Keen" },
            { Quality, "Quality" },
            { Fire, "Fire" },
            { FlameArt, "Flame Art" },
            { Lightning, "Lightning" },
            { Sacred, "Sacred" },
            { Magic, "Magic" },
            { Cold, "Cold" },
            { Poison, "Poison" },
            { Blood, "Blood" },
            { Occult, "Occult" },
        };

            if (!ReinforceTypeIdMap.ContainsKey(reinforceTypeId))
            {
                return "";
            }

            return ReinforceTypeIdMap[reinforceTypeId];
        }

        public static readonly int Standard = 0;

        public static readonly int Heavy = 100;

        public static readonly int Heavy2 = 6000;

        public static readonly int Keen = 200;

        public static readonly int Keen2 = 5000;

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

        public static readonly int StaffOrSeal3 = 3000;

        public static readonly int Shield = 8100;

        public static readonly int Greatshield1 = 8200;

        public static readonly int Greatshield2 = 8300;

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

        public static List<WeaponAffinity> ShieldAffinities = new List<WeaponAffinity>
    {
         new WeaponAffinity
        {
            Id = Shield, Name = "--"
        },
          new WeaponAffinity
        {
            Id = Greatshield1, Name = "--"
        },
            new WeaponAffinity
        {
            Id = Greatshield2, Name = "--"
        },
    };
    }
}
