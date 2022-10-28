using EldenRingBlazor.Data.Equipment;
using EldenRingBlazor.Data.Extensions;
using System.ComponentModel;

namespace EldenRingBlazor.Data.AttackRating
{
    public class ScalingRequirementsInfo
    {
        public ScalingRequirementsInfo(Weapon weapon)
        {
            Label = RequirementsLabel.Requirements.GetDescription();
            Strength = $"{weapon.StrRequirement}";
            Dexterity = $"{weapon.DexRequirement}";
            Intelligence = $"{weapon.IntRequirement}";
            Faith = $"{weapon.FthRequirement}";
            Arcane = $"{weapon.ArcRequirement}";
        }

        public ScalingRequirementsInfo(RequirementsLabel label, AttackRatingCalculation attackRatingCalculation)
        {
            if (label == RequirementsLabel.Scaling)
            {
                Label = RequirementsLabel.Scaling.GetDescription();
                Strength = $"{attackRatingCalculation.StrScaling:0.#}";
                Dexterity = $"{attackRatingCalculation.DexScaling:0.#}";
                Intelligence = $"{attackRatingCalculation.IntScaling:0.#}";
                Faith = $"{attackRatingCalculation.FthScaling:0.#}";
                Arcane = $"{attackRatingCalculation.ArcScaling:0.#}";
            }
            else
            {
                Label = RequirementsLabel.Grade.GetDescription();
                Strength = $"{attackRatingCalculation.StrScaling.GetScalingGrade()}";
                Dexterity = $"{attackRatingCalculation.DexScaling.GetScalingGrade()}";
                Intelligence = $"{attackRatingCalculation.IntScaling.GetScalingGrade()}";
                Faith = $"{attackRatingCalculation.FthScaling.GetScalingGrade()}";
                Arcane = $"{attackRatingCalculation.ArcScaling.GetScalingGrade()}";
            }
        }

        public string Label { get; set; }

        public string Strength { get; set; }

        public string Dexterity { get; set; }

        public string Intelligence { get; set; }

        public string Faith { get; set; }

        public string Arcane { get; set; }
    }

    public enum RequirementsLabel
    {
        [Description("Reqs.")]
        Requirements,
        [Description("Scaling")]
        Scaling,
        [Description("")]
        Grade
    }

    public class ScalingRequirements
    {
        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }
    }
}
