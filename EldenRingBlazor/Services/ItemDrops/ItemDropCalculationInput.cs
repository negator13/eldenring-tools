﻿namespace EldenRingBlazor.Services.ItemDrops
{
    public class ItemDropCalculationInput
    {
        public string Item { get; set; } = string.Empty;

        public int Discovery { get; set; }

        public double ItemChance { get; set; }
    }
}
