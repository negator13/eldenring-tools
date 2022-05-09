namespace EldenRingBlazor.Data.BuildPlanner
{
    public class ArmorEffectsService
    {
        public void ApplyPreCalculationArmorEffects(BuildPlannerInput input, string armor, bool isPve = true)
        {
            if (armor == null)
            {
                return;
            }

            switch (armor.ToLowerInvariant())
            {
                case "preceptor's big hat":
                    input.Mind += 3;
                    break;
                case "queen's crescent crown":
                    input.Intelligence += 3;
                    break;
                case "greathood":
                    input.Intelligence += 2;
                    input.Faith += 2;
                    break;
                case "ruler's mask":
                    input.Faith += 1;
                    break;
                case "consort's mask":
                    input.Dexterity += 1;
                    break;
                case "marais mask":
                    input.Arcane += 1;
                    break;
                case "imp head (cat)":
                    input.Intelligence += 2;
                    break;
                case "imp head (wolf)":
                    input.Endurance += 2;
                    break;
                case "imp head (fanged)":
                    input.Strength += 2;
                    break;
                case "imp head (long-tongued)":
                    input.Dexterity += 2;
                    break;
                case "imp head (corpse)":
                    input.Faith += 2;
                    break;
                case "imp head (elder)":
                    input.Arcane += 2;
                    break;
                case "silver tear mask":
                    input.Arcane += 8;
                    break;
                case "albinauric mask":
                    input.Arcane += 4;
                    break;
                case "crimson hood":
                    input.Vigor += 1;
                    break;
                case "navy hood":
                    input.Mind += 1;
                    break;
                case "omensmirk mask":
                    input.Strength += 2;
                    break;
                case "sacred crown helm":
                case "haligtree helm":
                case "commoner's simple garb":
                case "commoner's simple garb (altered)":
                case "commoner's garb":
                case "commoner's garb (altered)":
                    input.Faith += 1;
                    break;
                case "okina mask":
                    input.Dexterity += 3;
                    break;
                case "haligtree knight helm":
                    input.Faith += 2;
                    break;
                default:
                    break;
            }
        }

        public void ApplyPostCalculationArmorEffects(CharacterStatsCalculation calc, string armor, bool isPve = true)
        {
            if (armor == null)
            {
                return;
            }

            switch (armor.ToLowerInvariant())
            {
                case "preceptor's big hat":
                    calc.Stamina *= 0.91;
                    break;
                case "greathood":
                    calc.Hp *= 0.91;
                    break;
                case "crimson tear scarab":
                case "cerulean tear scarab":
                case "ash-of-war scarab":
                case "glintstone scarab":
                case "incantation scarab":
                    calc.PhysicalNegation *= 0.90;
                    calc.MagicNegation *= 0.90;
                    calc.FireNegation *= 0.90;
                    calc.LightningNegation *= 0.90;
                    calc.HolyNegation *= 0.90;
                    break;
                case "silver tear mask":
                    // TODO: 0.95 damage
                    break;
                case "okina mask":
                    calc.Focus -= 49;
                    break;
                default:
                    break;
            }
        }
    }
}
