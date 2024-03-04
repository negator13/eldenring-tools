namespace EldenRingBlazor.Services.BuildPlanner
{
    public class ArmorEffectsService
    {
        public void ApplyPreCalculationArmorEffects(BuildPlannerInput input, string? armor, bool isPve = true)
        {
            if (armor == null)
            {
                return;
            }

            switch (armor.ToLowerInvariant())
            {
                case "preceptor's big hat":
                    input.MindBonus += 3;
                    break;
                case "queen's crescent crown":
                    input.IntelligenceBonus += 3;
                    break;
                case "greathood":
                    input.IntelligenceBonus += 2;
                    input.FaithBonus += 2;
                    break;
                case "ruler's mask":
                    input.FaithBonus += 1;
                    break;
                case "consort's mask":
                    input.DexterityBonus += 1;
                    break;
                case "marais mask":
                    input.ArcaneBonus += 1;
                    break;
                case "imp head (cat)":
                    input.IntelligenceBonus += 2;
                    break;
                case "imp head (wolf)":
                    input.EnduranceBonus += 2;
                    break;
                case "imp head (fanged)":
                    input.StrengthBonus += 2;
                    break;
                case "imp head (long-tongued)":
                    input.DexterityBonus += 2;
                    break;
                case "imp head (corpse)":
                    input.FaithBonus += 2;
                    break;
                case "imp head (elder)":
                    input.ArcaneBonus += 2;
                    break;
                case "silver tear mask":
                    input.ArcaneBonus += 8;
                    break;
                case "albinauric mask":
                    input.ArcaneBonus += 4;
                    break;
                case "crimson hood":
                    input.VigorBonus += 1;
                    break;
                case "navy hood":
                    input.MindBonus += 1;
                    break;
                case "omensmirk mask":
                    input.StrengthBonus += 2;
                    break;
                case "sacred crown helm":
                case "haligtree helm":
                case "commoner's simple garb":
                case "commoner's simple garb (altered)":
                case "commoner's garb":
                case "commoner's garb (altered)":
                    input.FaithBonus += 1;
                    break;
                case "okina mask":
                    input.DexterityBonus += 3;
                    // TODO: Reduce Focus by 50
                    break;
                case "haligtree knight helm":
                    input.FaithBonus += 2;
                    break;
                case "haima glintstone crown":
                    input.IntelligenceBonus += 2;
                    input.StrengthBonus += 2;
                    // TODO: Reduce FP by 10%
                    break;
                case "hierodas glintstone crown":
                    input.IntelligenceBonus += 2;
                    input.EnduranceBonus += 2;
                    // TODO: Reduce FP by 10%
                    break;
                case "twinsage glintstone crown":
                    input.IntelligenceBonus += 6;
                    // TODO: Reduce HP and Stamina by 9%
                    break;
                case "karolos glintstone crown":
                    input.IntelligenceBonus += 3;
                    // TODO: Reduce Stamina by 9%
                    break;
                case "olivinus glintstone crown":
                    input.IntelligenceBonus += 3;
                    // TODO: Reduce HP by 10%
                    break;
                case "lazuli glintstone crown":
                    input.IntelligenceBonus += 3;
                    input.DexterityBonus += 3;
                    // TODO: Reduce HP by 18%
                    break;
                case "witch's glintstone crown":
                    input.IntelligenceBonus += 3;
                    input.ArcaneBonus += 3;
                    // TODO: Reduce Stamina by 18%
                    break;
                default:
                    break;
            }
        }

        public void ApplyPostCalculationArmorEffects(CharacterStatsCalculation calc, string? armor, bool isPve = true)
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
