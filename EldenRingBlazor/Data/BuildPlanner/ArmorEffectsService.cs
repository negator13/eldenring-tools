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
                    input.MindBonus += 3;
                    break;
                case "queen's crescent crown":
                    input.Intelligence += 3;
                    input.IntelligenceBonus += 3;
                    break;
                case "greathood":
                    input.Intelligence += 2;
                    input.Faith += 2;
                    input.IntelligenceBonus += 2;
                    input.FaithBonus += 2;
                    break;
                case "ruler's mask":
                    input.Faith += 1;
                    input.FaithBonus += 1;
                    break;
                case "consort's mask":
                    input.Dexterity += 1;
                    input.DexterityBonus += 1;
                    break;
                case "marais mask":
                    input.Arcane += 1;
                    input.ArcaneBonus += 1;
                    break;
                case "imp head (cat)":
                    input.Intelligence += 2;
                    input.IntelligenceBonus += 2;
                    break;
                case "imp head (wolf)":
                    input.Endurance += 2;
                    input.EnduranceBonus += 2;
                    break;
                case "imp head (fanged)":
                    input.Strength += 2;
                    input.StrengthBonus += 2;
                    break;
                case "imp head (long-tongued)":
                    input.Dexterity += 2;
                    input.DexterityBonus += 2;
                    break;
                case "imp head (corpse)":
                    input.Faith += 2;
                    input.FaithBonus += 2;
                    break;
                case "imp head (elder)":
                    input.Arcane += 2;
                    input.ArcaneBonus += 2;
                    break;
                case "silver tear mask":
                    input.Arcane += 8;
                    input.ArcaneBonus += 8;
                    break;
                case "albinauric mask":
                    input.Arcane += 4;
                    input.ArcaneBonus += 4;
                    break;
                case "crimson hood":
                    input.Vigor += 1;
                    input.VigorBonus += 1;
                    break;
                case "navy hood":
                    input.Mind += 1;
                    input.MindBonus += 1;
                    break;
                case "omensmirk mask":
                    input.Strength += 2;
                    input.StrengthBonus += 2;
                    break;
                case "sacred crown helm":
                case "haligtree helm":
                case "commoner's simple garb":
                case "commoner's simple garb (altered)":
                case "commoner's garb":
                case "commoner's garb (altered)":
                    input.Faith += 1;
                    input.FaithBonus += 1;
                    break;
                case "okina mask":
                    input.Dexterity += 3;
                    input.DexterityBonus += 3;
                    break;
                case "haligtree knight helm":
                    input.Faith += 2;
                    input.FaithBonus += 2;
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
