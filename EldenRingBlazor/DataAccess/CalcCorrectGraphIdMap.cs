using CsvHelper.Configuration;
using EldenRingBlazor.Data.CalcCorrect;

namespace EldenRingBlazor.DataAccess
{
    // CalcCorrectGraph_ID
    public class CalcCorrectGraphIdMap: ClassMap<CalcCorrectGraphId>
    {
        public CalcCorrectGraphIdMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.PhysicalCalcCorrectId).Name("CalcCorrectGraph ID (Physical)");
            Map(m => m.MagicCalcCorrectId).Name("CalcCorrectGraph ID (Magic)");
            Map(m => m.FireCalcCorrectId).Name("CalcCorrectGraph ID (Fire)");
            Map(m => m.LightningCalcCorrectId).Name("CalcCorrectGraph ID (Lightning)");
            Map(m => m.HolyCalcCorrectId).Name("CalcCorrectGraph ID (Holy)");
        }
    }
}
