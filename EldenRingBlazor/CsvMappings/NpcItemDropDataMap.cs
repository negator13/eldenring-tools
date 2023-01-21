using CsvHelper.Configuration;
using EldenRingBlazor.Data.ItemDrops;

namespace EldenRingBlazor.CsvMappings
{
    public class NpcItemDropDataMap : ClassMap<NpcItemDropData>
    {
        public NpcItemDropDataMap()
        {
            Map(m => m.NpcId).Name("NPC ID");
            Map(m => m.ItemLotEnemyId).Name("ItemLot_Enemy ID");
            Map(m => m.Name).Name("Name");
            Map(m => m.Location).Name("Location #1");
            Map(m => m.ItemDrop1).Name("Items Drop 1");
            Map(m => m.ItemDrop1Chance).Name("Item Chance 1");
            Map(m => m.ItemDrop2).Name("Item Drop 2");
            Map(m => m.ItemDrop2Chance).Name("Item Chance 2");
            Map(m => m.ItemDrop3).Name("Item Drop 3");
            Map(m => m.ItemDrop3Chance).Name("Item Chance 3");
            Map(m => m.ItemDrop4).Name("Item Drop 4");
            Map(m => m.ItemDrop4Chance).Name("Item Chance 4");
            Map(m => m.ItemDrop5).Name("Item Drop 5");
            Map(m => m.ItemDrop5Chance).Name("Item Chance 5");
            Map(m => m.ItemDrop6).Name("Item Drop 6");
            Map(m => m.ItemDrop6Chance).Name("Item Chance 6");
            Map(m => m.ItemDrop7).Name("Item Drop 7");
            Map(m => m.ItemDrop7Chance).Name("Item Chance 7");
            Map(m => m.ItemDrop8).Name("Item Drop 8");
            Map(m => m.ItemDrop8Chance).Name("Item Chance 8");
            Map(m => m.ItemDrop9).Name("Item Drop 9");
            Map(m => m.ItemDrop9Chance).Name("Item Chance 9");
            Map(m => m.ItemDrop10).Name("Item Drop 10");
            Map(m => m.ItemDrop10Chance).Name("Item Chance 10");
        }
    }
}
