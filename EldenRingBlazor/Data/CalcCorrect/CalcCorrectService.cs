using CsvHelper;
using EldenRingBlazor.CsvMappings;
using System.Globalization;
using EldenRingBlazor.Data.Equipment;

namespace EldenRingBlazor.Data.CalcCorrect
{
    public class CalcCorrectService
    {
        private IEnumerable<CalcCorrectGraph> _calcCorrectGraphs;
        private IEnumerable<CalcCorrectGraphId> _calcCorrectGraphIds;

        public CalcCorrectService(IWebHostEnvironment hostingEnvironment)
        {
            string contentPath = hostingEnvironment.WebRootPath;

            string calcCorrectGraphCsvPath = Path.Combine(contentPath, VersionInfo.PatchVersion.Latest, "CalcCorrectGraph.csv");
            string calcCorrectGraphIdCsvPath = Path.Combine(contentPath, VersionInfo.PatchVersion.Latest, "CalcCorrectGraph_ID.csv");

            using var calcCorrectGraphsReader = new StreamReader(calcCorrectGraphCsvPath);
            var calcCorrectGraphsCsv = new CsvReader(calcCorrectGraphsReader, CultureInfo.InvariantCulture);
            calcCorrectGraphsCsv.Context.RegisterClassMap<CalcCorrectGraphMap>();
            _calcCorrectGraphs = calcCorrectGraphsCsv.GetRecords<CalcCorrectGraph>().ToList();

            using var calcCorrectIdsReader = new StreamReader(calcCorrectGraphIdCsvPath);
            var calcCorrectIdsCsv = new CsvReader(calcCorrectIdsReader, CultureInfo.InvariantCulture);
            calcCorrectIdsCsv.Context.RegisterClassMap<CalcCorrectGraphIdMap>();
            _calcCorrectGraphIds = calcCorrectIdsCsv.GetRecords<CalcCorrectGraphId>().ToList();
        }

        public void GetCalcCorrectGraphIds(Weapon weapon)
        {
            var calcCorrectGraphId = _calcCorrectGraphIds.SingleOrDefault(c => c.Id == weapon.Id);

            weapon.PhysicalCorrectId = calcCorrectGraphId.PhysicalCalcCorrectId;
            weapon.MagicCorrectId = calcCorrectGraphId.MagicCalcCorrectId;
            weapon.FireCorrectId = calcCorrectGraphId.FireCalcCorrectId;
            weapon.LightningCorrectId = calcCorrectGraphId.LightningCalcCorrectId;
            weapon.HolyCorrectId = calcCorrectGraphId.HolyCalcCorrectId;
        }

        public CalcCorrectGraph GetCalcCorrectGraph(int id)
        {
            return _calcCorrectGraphs.SingleOrDefault(c => c.Id == id);
        }

        public CalcCorrectGraphInstance GetSpecificCalcCorrect(CalcCorrectGraph graph, int statValue)
        {
            double statMin;
            double statMax;
            double growMin;
            double growMax;
            double adjustMin;
            double adjustMax;

            if (statValue > graph.StatMax4)
            {
                // Same as being above Stat 3, because you can't go above 150
                // TODO: need to verify this is correct
                statMax = graph.StatMax4;
                statMin = graph.StatMax3;
                growMax = graph.GrowMax4;
                growMin = graph.GrowMax3;
                adjustMax = graph.AdjustGrow4;
                adjustMin = graph.AdjustGrow3;
            }
            else if (statValue > graph.StatMax3)
            {
                statMax = graph.StatMax4;
                statMin = graph.StatMax3;
                growMax = graph.GrowMax4;
                growMin = graph.GrowMax3;
                adjustMax = graph.AdjustGrow4;
                adjustMin = graph.AdjustGrow3;
            }
            else if (statValue > graph.StatMax2)
            {
                statMax = graph.StatMax3;
                statMin = graph.StatMax2;
                growMax = graph.GrowMax3;
                growMin = graph.GrowMax2;
                adjustMax = graph.AdjustGrow3;
                adjustMin = graph.AdjustGrow2;

            }
            else if (statValue > graph.StatMax1)
            {
                statMax = graph.StatMax2;
                statMin = graph.StatMax1;
                growMax = graph.GrowMax2;
                growMin = graph.GrowMax1;
                adjustMax = graph.AdjustGrow2;
                adjustMin = graph.AdjustGrow1;

            }
            else
            {
                statMax = graph.StatMax1;
                statMin = graph.StatMax0;
                growMax = graph.GrowMax1;
                growMin = graph.GrowMax0;
                adjustMax = graph.AdjustGrow1;
                adjustMin = graph.AdjustGrow0;
            }

            var specificCalcCorrect = new CalcCorrectGraphInstance(statValue, statMin, statMax, growMin, growMax, adjustMin, adjustMax);

            return specificCalcCorrect;
        }
    }
}
