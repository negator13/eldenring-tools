using EldenRingBlazor.WellKnown;

namespace EldenRingBlazor.Services.Equipment
{
    public static class Affinities
    {
        public static string FromReinforceTypeId(this int reinforceTypeId)
        {
            var ReinforceTypeIdMap = new Dictionary<int, string>
        {
            { Standard, WeaponAffinities.Standard },
            { Heavy, WeaponAffinities.Heavy },
            { Heavy2, WeaponAffinities.Heavy },
            { Keen, WeaponAffinities.Keen },
            { Keen2, WeaponAffinities.Keen },
            { Quality, WeaponAffinities.Quality  },
            { Fire, WeaponAffinities.Fire },
            { FlameArt, WeaponAffinities.FlameArt },
            { Lightning, WeaponAffinities.Lightning },
            { Sacred, WeaponAffinities.Sacred },
            { Magic, WeaponAffinities.Magic },
            { Cold, WeaponAffinities.Cold },
            { Poison, WeaponAffinities.Poison },
            { Blood, WeaponAffinities.Blood },
            { Occult, WeaponAffinities.Occult },
        };

            if (!ReinforceTypeIdMap.ContainsKey(reinforceTypeId))
            {
                return string.Empty;
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

        public static readonly int NormalCrossbow = 3100;

        public static readonly int SomberCrosbow = 3200;

        public static readonly int SmallShield = 8000;

        public static readonly int Shield = 8100;

        public static readonly int Greatshield1 = 8200;

        public static readonly int Greatshield2 = 8300;

        public static List<WeaponAffinity> StandardAffinities = new List<WeaponAffinity>
    {
        new WeaponAffinity
        {
            Id = Standard, Name = WeaponAffinities.Standard
        },
        new WeaponAffinity
        {
            Id = Heavy, Name = WeaponAffinities.Heavy
        },
        new WeaponAffinity
        {
            Id = Keen, Name = WeaponAffinities.Keen
        },
        new WeaponAffinity
        {
            Id = Quality, Name = WeaponAffinities.Quality
        },
        new WeaponAffinity
        {
            Id = Fire, Name = WeaponAffinities.Fire
        },
        new WeaponAffinity
        {
            Id = FlameArt, Name = WeaponAffinities.FlameArt
        },
        new WeaponAffinity
        {
            Id = Lightning, Name = WeaponAffinities.Lightning
        },
        new WeaponAffinity
        {
            Id = Sacred, Name = WeaponAffinities.Sacred
        },
        new WeaponAffinity
        {
            Id = Magic, Name = WeaponAffinities.Magic
        },
        new WeaponAffinity
        {
            Id = Cold, Name = WeaponAffinities.Cold
        },
        new WeaponAffinity
        {
            Id = Poison, Name = WeaponAffinities.Poison
        },
        new WeaponAffinity
        {
            Id = Blood, Name = WeaponAffinities.Blood
        },
        new WeaponAffinity
        {
            Id = Occult, Name = WeaponAffinities.Occult
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
