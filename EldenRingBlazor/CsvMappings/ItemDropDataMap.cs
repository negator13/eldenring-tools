using CsvHelper.Configuration;
using EldenRingBlazor.Services.ItemDrops;

namespace EldenRingBlazor.CsvMappings
{
    public class ItemDropDataMap : ClassMap<ItemDropData>
    {
        public ItemDropDataMap()
        {
            Map(m => m.Item).Name("item");
            Map(m => m.BaseWeight).Name("Base Weight");
        }
    }
}
