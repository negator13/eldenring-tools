namespace EldenRingBlazor.Data.CalcCorrect
{
    public class CalcCorrectGraphInstance
    {
        public CalcCorrectGraphInstance(int inputStat, double statMin, double statMax, double growMin, double growMax, double adjustMin, double adjustMax)
        {
            InputStat = inputStat <= 0 ? 1 : Math.Min(inputStat, 150);
            StatMin = statMin;
            StatMax = statMax;
            GrowMin = growMin;
            GrowMax = growMax;
            AdjustMin = adjustMin;
            AdjustMax = adjustMax;
        }

        public int InputStat { get; }

        public double StatMin { get; }

        public double StatMax { get; }

        public double GrowMin { get; }

        public double GrowMax { get; }

        public double AdjustMin { get; }

        public double AdjustMax { get; }

        public double Output
        {
            get
            {
                var growth = GetGrowth();

                return (GrowMin + ((GrowMax - GrowMin) * growth)) * .01;
            }
        }

        private double GetGrowth()
        {
            var ratio = GetRatio();

            if (AdjustMin >= 0)
            {
                return Math.Pow(ratio, Math.Abs(AdjustMin));
            }
            else
            {
                return 1 - Math.Pow(1 - ratio, Math.Abs(AdjustMin));
            }
        }

        private double GetRatio()
        {
            return (InputStat - StatMin) / (StatMax - StatMin);
        }
    }
}
