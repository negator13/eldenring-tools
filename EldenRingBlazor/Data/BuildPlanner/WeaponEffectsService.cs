namespace EldenRingBlazor.Data.BuildPlanner
{
    public class WeaponEffectsService
    {
        public void ApplyPreCalculationWeaponEffects(BuildPlannerInput input, string weapon, bool isPve = true)
        {
            if (weapon == null)
            {
                return;
            }

            switch (weapon.ToLowerInvariant())
            {
                default:
                    break;
            }
        }

        public void ApplyPostCalculationWeaponEffects(CharacterStatsCalculation calc, string weapon, bool isPve = true)
        {
            if (weapon == null)
            {
                return;
            }

            switch (weapon.ToLowerInvariant())
            {
                case "cleanrot spear":
                    calc.Immunity += 50;
                    break;
                case "grave scythe":
                    calc.Vitality += 35;
                    break;
                case "pest's glaive":
                    calc.MagicNegation += 2;
                    calc.FireNegation += 2;
                    calc.LightningNegation += 2;
                    calc.HolyNegation += 2;
                    break;
                case "pillory shield":
                    calc.Vitality += 50;
                    break;
                case "ice crest shield":
                    calc.Robustness += 40;
                    break;
                case "rift shield":
                    calc.Focus += 40;
                    break;
                case "perfumer's shield":
                    calc.Immunity += 40;
                    break;
                case "shield of the guilty":
                    calc.Focus += 40;
                    break;
                case "spiralhorn shield":
                    calc.Immunity += 40;
                    calc.Robustness += 40;
                    calc.Focus += 40;
                    break;
                case "smoldering shield":
                    calc.Robustness += 30;
                    break;
                case "coil shield":
                    calc.Immunity += 40;
                    break;
                case "eclipse crest greatshield":
                    calc.Immunity += 50;
                    calc.Robustness += 50;
                    calc.Focus += 50;
                    break;
                case "ant's skull plate":
                    calc.Immunity += 60;
                    break;
                default:
                    break;
            }
        }
    }
}
