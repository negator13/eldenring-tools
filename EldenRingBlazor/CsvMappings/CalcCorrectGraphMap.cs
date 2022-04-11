using CsvHelper.Configuration;
using EldenRingBlazor.Data.CalcCorrect;

namespace EldenRingBlazor.CsvMappings
{
    // CalcCorrectGraph
    public class CalcCorrectGraphMap: ClassMap<CalcCorrectGraph>
    {
        public CalcCorrectGraphMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Row Name");
            Map(m => m.StatMax0).Name("Stat Max 0");
            Map(m => m.StatMax1).Name("Stat Max 1");
            Map(m => m.StatMax2).Name("Stat Max 2");
            Map(m => m.StatMax3).Name("Stat Max 3");
            Map(m => m.StatMax4).Name("Stat Max 4");
            Map(m => m.GrowMax0).Name("Grow 0");
            Map(m => m.GrowMax1).Name("Grow 1");
            Map(m => m.GrowMax2).Name("Grow 2");
            Map(m => m.GrowMax3).Name("Grow 3");
            Map(m => m.GrowMax4).Name("Grow 4");
            Map(m => m.AdjustGrow0).Name("Adjustment Point - Grow 0");
            Map(m => m.AdjustGrow1).Name("Adjustment Point - Grow 1");
            Map(m => m.AdjustGrow2).Name("Adjustment Point - Grow 2");
            Map(m => m.AdjustGrow3).Name("Adjustment Point - Grow 3");
            Map(m => m.AdjustGrow4).Name("Adjustment Point - Grow 4");
        }
    }
}
