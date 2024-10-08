﻿using EldenRingBlazor.Services.Equipment;

namespace EldenRingBlazor.Services.AttackRating
{
    public class AttackRatingCalculationInput
    {
        public bool TwoHand { get; set; }

        public int Strength { get; set; }

        public int EffectiveTwoHandStrength => TwoHand ? (int)Math.Floor(1.5 * Strength) : Strength;

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }

        public Weapon? Weapon { get; set; }

        public string? WeaponName { get; set; }

        public int AffinityId { get; set; }

        public int WeaponLevel { get; set; }
    }
}
