namespace EldenRingBlazor.Data.BuildPlanner
{
    public class TalismanService
    {
        public void ApplyPreCalculationTalismanEffects(BuildPlannerInput input, string talisman, bool isPve = true)
        {
            switch (talisman.ToLowerInvariant())
            {
                case "radagon's scarseal":
                    input.Vigor += 3;
                    input.Endurance += 3;
                    input.Strength += 3;
                    input.Dexterity +=3;
                    break;
                case "radagon's soreseal":
                    input.Vigor += 5;
                    input.Endurance += 5;
                    input.Strength += 5;
                    input.Dexterity +=5;
                    break;
                case "marika's scarseal":
                    input.Mind += 3;
                    input.Intelligence += 3;
                    input.Faith += 3;
                    input.Arcane +=3;
                    break;
                case "marika's soreseal":
                    input.Mind += 5;
                    input.Intelligence += 5;
                    input.Faith += 5;
                    input.Arcane +=5;
                    break;
                case "starscourge heirloom":
                    input.Strength += 5;
                    break;
                case "prosthesis-wearer heirloom":
                    input.Dexterity += 5;
                    break;
                case "stargazer heirloom":
                    input.Intelligence += 5;
                    break;
                case "two fingers heirloom":
                    input.Faith += 5;
                    break;
            }
        }

        public void ApplyPostCalculationTalismanEffects(CharacterStatsCalculation calc, string talisman, bool isPve = true)
        {
            switch (talisman.ToLowerInvariant())
            {
                case "crimson amber medallion":
                    calc.Hp *= 1.06;
                    break;
                case "crimson amber medallion +1":
                    calc.Hp *= 1.07;
                    break;
                case "crimson amber medallion +2":
                    calc.Hp *= 1.08;
                    break;
                case "crimson seed talisman":
                    calc.PassiveEffects.Add("1.2x HP restored by Flask of Crimson Tears");
                    break;
                case "blessed dew talisman":
                    calc.PassiveEffects.Add("+2 HP/s regeneration (Blessed Dew Talisman)");
                    break;
                case "cerulean amber medallion":
                    calc.Fp *= 1.07;
                    break;
                case "cerulean amber medallion +1":
                    calc.Fp *= 1.09;
                    break;
                case "cerulean amber medallion +2":
                    calc.Fp *= 1.11;
                    break;
                case "cerulean seed talisman":
                    calc.PassiveEffects.Add("1.2x FP restored by Flask of Cerulean Tears");
                    break;
                case "viridian amber medallion":
                    calc.Stamina *= 1.11;
                    break;
                case "viridian amber medallion +1":
                    calc.Stamina *= 1.13;
                    break;
                case "viridian amber medallion +2":
                    calc.Stamina *= 1.15;
                    break;
                case "green turtle talisman":
                    calc.PassiveEffects.Add("+8 Stamina/s regeneration (Green Turtle Talisman)");
                    break;
                case "arsenal charm":
                    calc.EquipLoad *= 1.15;
                    break;
                case "arsenal charm +1":
                    calc.EquipLoad *= 1.17;
                    break;
                case "great jar's arsenal":
                    calc.EquipLoad *= 1.19;
                    break;
                case "erdtree's favor":
                    calc.Hp *= 1.03;
                    calc.Stamina *= 1.07;
                    calc.EquipLoad *= 1.05;
                    break;
                case "erdtree's favor +1":
                    calc.Hp *= 1.035;
                    calc.Stamina *= 1.085;
                    calc.EquipLoad *= 1.065;
                    break;
                case "erdtree's favor +2":
                    calc.Hp *= 1.04;
                    calc.Stamina *= 1.1;
                    calc.EquipLoad *= 1.08;
                    break;
                case "radagon's scarseal":
                case "marika's scarseal":
                    calc.PhysicalNegation *= .9;
                    calc.MagicNegation *= .9;
                    calc.FireNegation *= .9;
                    calc.LightningNegation *= .9;
                    calc.HolyNegation *= .9;
                    break;
                case "radagon's soreseal":
                case "marika's soreseal":
                    calc.PhysicalNegation *= .85;
                    calc.MagicNegation *= .85;
                    calc.FireNegation *= .85;
                    calc.LightningNegation *= .85;
                    calc.HolyNegation *= .85;
                    break;
                case "dragoncrest shield talisman":
                    calc.PhysicalNegation *= isPve ? 1.1 : 1.02;
                    break;
                case "dragoncrest shield talisman +1":
                    calc.PhysicalNegation *= isPve ? 1.13 : 1.03;
                    break;
                case "dragoncrest shield talisman +2":
                    calc.PhysicalNegation *= isPve ? 1.17 : 1.04;
                    break;
                case "dragoncrest greatshield talisman":
                    calc.PhysicalNegation *= isPve ? 1.2 : 1.05;
                    break;
                case "spelldrake talisman":
                    calc.MagicNegation *= isPve ? 1.13 : 1.04;
                    break;
                case "spelldrake talisman +1":
                    calc.MagicNegation *= isPve ? 1.17 : 1.05;
                    break;
                case "spelldrake talisman +2":
                    calc.MagicNegation *= isPve ? 1.2 : 1.06;
                    break;
                case "flamedrake talisman":
                    calc.FireNegation *= isPve ? 1.13 : 1.04;
                    break;
                case "flamedrake talisman +1":
                    calc.FireNegation *= isPve ? 1.17 : 1.05;
                    break;
                case "flamedrake talisman +2":
                    calc.FireNegation *= isPve ? 1.2 : 1.06;
                    break;
                case "boltdrake talisman":
                    calc.LightningNegation *= isPve ? 1.13 : 1.04;
                    break;
                case "boltdrake talisman +1":
                    calc.LightningNegation *= isPve ? 1.17 : 1.05;
                    break;
                case "boltdrake talisman +2":
                    calc.LightningNegation *= isPve ? 1.2 : 1.06;
                    break;
                case "haligdrake talisman":
                    calc.HolyNegation *= isPve ? 1.13 : 1.04;
                    break;
                case "haligdrake talisman +1":
                    calc.HolyNegation *= isPve ? 1.17 : 1.05;
                    break;
                case "haligdrake talisman +2":
                    calc.HolyNegation *= isPve ? 1.2 : 1.06;
                    break;
                case "pearldrake talisman":
                    calc.MagicNegation *= isPve ? 1.05 : 1.02;
                    calc.FireNegation *= isPve ? 1.05 : 1.02;
                    calc.LightningNegation *= isPve ? 1.05 : 1.02;
                    calc.HolyNegation *= isPve ? 1.05 : 1.02;
                    break;
                case "pearldrake talisman +1":
                    calc.MagicNegation *= isPve ? 1.07 : 1.03;
                    calc.FireNegation *= isPve ? 1.07 : 1.03;
                    calc.LightningNegation *= isPve ? 1.07 : 1.03;
                    calc.HolyNegation *= isPve ? 1.07 : 1.03;
                    break;
                case "pearldrake talisman +2":
                    calc.MagicNegation *= isPve ? 1.09 : 1.04;
                    calc.FireNegation *= isPve ? 1.09 : 1.04;
                    calc.LightningNegation *= isPve ? 1.09 : 1.04;
                    calc.HolyNegation *= isPve ? 1.09 : 1.04;
                    break;
                case "immunizing horn charm":
                    calc.Immunity += 90;
                    break;
                case "immunizing horn charm +1":
                    calc.Immunity += 140;
                    break;
                case "stalwart horn charm":
                    calc.Robustness += 90;
                    break;
                case "stalwart horn charm +1":
                    calc.Robustness += 140;
                    break;
                case "clarifying horn charm":
                    calc.Focus += 90;
                    break;
                case "clarifying horn charm +1":
                    calc.Focus += 140;
                    break;
                case "mottled necklace":
                    calc.Immunity += 40;
                    calc.Robustness += 40;
                    calc.Focus += 40;
                    break;
                case "mottled necklace +1":
                    calc.Immunity += 60;
                    calc.Robustness += 60;
                    calc.Focus += 60;
                    break;
                case "prince of death's pustule":
                    calc.Vitality += 90;
                    break;
                case "prince of death's cyst":
                    calc.Vitality += 140;
                    break;
                // TODO: More passive effects

                case "bull-goat's talisman":
                    calc.Poise /= 0.75;
                    break;
                case "silver scarab":
                    calc.Discovery += 75;
                    break;
                default:
                    break;
            }
        }
    }
}
