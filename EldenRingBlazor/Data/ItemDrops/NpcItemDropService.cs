using CsvHelper;
using EldenRingBlazor.CsvMappings;
using EldenRingBlazor.Data.BuildPlanner;
using System.Globalization;

namespace EldenRingBlazor.Data.ItemDrops
{
    public class NpcItemDropService
    {
        private readonly string _webRootPath;

        public readonly IEnumerable<ItemDropData> _allItemDrops;

        private readonly IEnumerable<NpcItemDropData> _allNpcItemDrops;

        public NpcItemDropService(IWebHostEnvironment hostingEnvironment)
        {
            _webRootPath = hostingEnvironment.WebRootPath;

            var npcItemDrops = ReadNpcItemDropsFromCsv();

            _allNpcItemDrops = npcItemDrops.Where(i => i.ItemLotEnemyId > 0).ToList();

            var randomDrop = _allNpcItemDrops.First(i => i.Name == "Oracle Envoy");

            var calc = CalculateItemDrops(new CharacterStatsCalculation { Discovery = 274 }, randomDrop);

            _allItemDrops = ReadItemDropsFromCsv();
        }

        private IEnumerable<NpcItemDropData> ReadNpcItemDropsFromCsv()
        {
            string itemDropsCsvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "Item_Drop_Data.csv");
            using var itemDropsReader = new StreamReader(itemDropsCsvPath);
            using var itemDropsCsv = new CsvReader(itemDropsReader, CultureInfo.InvariantCulture);
            itemDropsCsv.Context.RegisterClassMap<NpcItemDropDataMap>();
            return itemDropsCsv.GetRecords<NpcItemDropData>().ToList();
        }

        private IEnumerable<ItemDropData> ReadItemDropsFromCsv()
        {
            string itemDropsCsvPath = Path.Combine(_webRootPath, VersionInfo.PatchVersion.Latest, "Drops.csv");
            using var itemDropsReader = new StreamReader(itemDropsCsvPath);
            using var itemDropsCsv = new CsvReader(itemDropsReader, CultureInfo.InvariantCulture);
            itemDropsCsv.Context.RegisterClassMap<ItemDropDataMap>();
            return itemDropsCsv.GetRecords<ItemDropData>().ToList();
        }

        public ItemDropsCalculation CalculateItemDrops(CharacterStatsCalculation characterStats, NpcItemDropData itemDropData)
        {
            var itemDropsCalculation = new ItemDropsCalculation();

            var discovery = characterStats.Discovery / 100;

            if (itemDropData.ItemDrop1 != null)
            {
                itemDropsCalculation.ItemDrop1 = Calculate(discovery, itemDropData.ItemDrop1Chance, itemDropData.ItemDrop1);
            }

            if (itemDropData.ItemDrop2 != null)
            {
                itemDropsCalculation.ItemDrop2 = Calculate(discovery, itemDropData.ItemDrop2Chance, itemDropData.ItemDrop2);
            }

            if (itemDropData.ItemDrop3 != null)
            {
                itemDropsCalculation.ItemDrop3 = Calculate(discovery, itemDropData.ItemDrop3Chance, itemDropData.ItemDrop3);
            }

            if (itemDropData.ItemDrop4 != null)
            {
                itemDropsCalculation.ItemDrop4 = Calculate(discovery, itemDropData.ItemDrop4Chance, itemDropData.ItemDrop4);
            }

            if (itemDropData.ItemDrop5 != null)
            {
                itemDropsCalculation.ItemDrop5 = Calculate(discovery, itemDropData.ItemDrop5Chance, itemDropData.ItemDrop5);
            }

            if (itemDropData.ItemDrop6 != null)
            {
                itemDropsCalculation.ItemDrop6 = Calculate(discovery, itemDropData.ItemDrop6Chance, itemDropData.ItemDrop6);
            }

            if (itemDropData.ItemDrop7 != null)
            {
                itemDropsCalculation.ItemDrop7 = Calculate(discovery, itemDropData.ItemDrop7Chance, itemDropData.ItemDrop7);
            }

            if (itemDropData.ItemDrop8 != null)
            {
                itemDropsCalculation.ItemDrop8 = Calculate(discovery, itemDropData.ItemDrop8Chance, itemDropData.ItemDrop8);
            }

            if (itemDropData.ItemDrop9 != null)
            {
                itemDropsCalculation.ItemDrop9 = Calculate(discovery, itemDropData.ItemDrop9Chance, itemDropData.ItemDrop9);
            }

            if (itemDropData.ItemDrop10 != null)
            {
                itemDropsCalculation.ItemDrop10 = Calculate(discovery, itemDropData.ItemDrop10Chance, itemDropData.ItemDrop10);
            }

            return itemDropsCalculation;
        }

        private ItemDropCalculation Calculate(double discovery, string baseWeightString, string name)
        {
            baseWeightString = baseWeightString.Replace("%", "");
            double.TryParse(baseWeightString, out var baseWeight);
            baseWeight *= 10;
            var adjustedWeight = Math.Floor(discovery * baseWeight);
            var percentChance = adjustedWeight / (1000+ (adjustedWeight - baseWeight));

            return new ItemDropCalculation
            {
                Name = name,
                PercentChance = Math.Round(percentChance * 100, 2, MidpointRounding.ToZero),
            };
        }

        public ItemDropCalculation Calculate(ItemDropCalculationInput input)
        {
            double adjustedDiscovery = (double)input.Discovery / 100;
            var adjustedWeight = Math.Floor(adjustedDiscovery * input.ItemChance);
            var percentChance = adjustedWeight / (1000+ (adjustedWeight - input.ItemChance));

            return new ItemDropCalculation
            {
                PercentChance = Math.Round(percentChance * 100, 2, MidpointRounding.ToZero),
            };
        }
    }

    public class ItemDropsCalculation
    {
        public ItemDropCalculation? ItemDrop1 { get; set; }
        public ItemDropCalculation? ItemDrop2 { get; set; }
        public ItemDropCalculation? ItemDrop3 { get; set; }
        public ItemDropCalculation? ItemDrop4 { get; set; }
        public ItemDropCalculation? ItemDrop5 { get; set; }
        public ItemDropCalculation? ItemDrop6 { get; set; }
        public ItemDropCalculation? ItemDrop7 { get; set; }
        public ItemDropCalculation? ItemDrop8 { get; set; }
        public ItemDropCalculation? ItemDrop9 { get; set; }
        public ItemDropCalculation? ItemDrop10 { get; set; }
    }

    public class ItemDropCalculation
    {
        public string Name { get; set; }
        public double PercentChance { get; set; }
    }
}
