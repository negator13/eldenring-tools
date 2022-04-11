namespace EldenRingBlazor.Data.Equipment
{
    public static class WeaponExtensions
    {
        public static string GetScalingGrade(this double scaling)
        {
            if (scaling >= 175)
            {
                return "S";
            }
            else if (scaling >= 140)
            {
                return "A";
            }
            else if (scaling >= 90)
            {
                return "B";
            }
            else if (scaling >= 60)
            {
                return "C";
            }
            else if (scaling >= 25)
            {
                return "D";
            }
            else if (scaling > 0)
            {
                return "E";
            }
            else
            {
                return "-";
            }
        }
    }
}
