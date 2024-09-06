using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Models.Request.Notes
{
    public class UpdateNoteRequest
    {
        public Guid NoteId { get; set; }
        public Guid? DishwareId { get; set; }
        public UpdateTasteRequest Taste { get; set; } = null!;
        public UpdateDescriptorSetRequest DescriptorSet { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Kind { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int? Year { get; set; }
        public DateOnly? TastingDate { get; set; }

        public string BrewingMethod { get; set; } = string.Empty;
        public int BrewingTemperature { get; set; }
        public int BrewingVolume { get; set; }
        public int BrewingAmount { get; set; }
        public string BrewingDishware { get; set; } = string.Empty;

        public string DryLeafAppearance { get; set; } = string.Empty;
        public string DryLeafAroma { get; set; } = string.Empty;

        public string InfusionAppearance { get; set; } = string.Empty;
        public string InfusionAroma { get; set; } = string.Empty;
        public string InfusionComment { get; set; } = string.Empty;
        public int InfusionBody { get; set; }
        public int InfusionBalance { get; set; }
        public int InfusionBouquet { get; set; }
        public int InfusionExtractivity { get; set; }

        public int AftertasteIntense { get; set; }
        public int AftertasteDuration { get; set; }
        public string AftertasteComment { get; set; } = string.Empty;

        public string WellCombinedWith { get; set; } = string.Empty;
        public string ImpressionComment { get; set; } = string.Empty;
        public int ImpressionRate { get; set; }
        public string OtherComment { get; set; } = string.Empty;

        public void Assign(Note destination)
        {

            Taste.Assign(destination.Taste);
            DescriptorSet.Assign(destination.DescriptorSet);

            destination.Title = Title;
            destination.Kind = Kind;
            destination.Region = Region;
            destination.Year = Year;
            destination.TastingDate = TastingDate;

            destination.AftertasteComment = AftertasteComment;
            destination.AftertasteDuration = AftertasteDuration;
            destination.AftertasteIntense = AftertasteIntense;

            destination.BrewingAmount = BrewingAmount;
            destination.BrewingDishware = BrewingDishware;
            destination.BrewingMethod = BrewingMethod;
            destination.BrewingTemperature = BrewingTemperature;
            destination.BrewingVolume = BrewingVolume;

            destination.DryLeafAppearance = DryLeafAppearance;
            destination.DryLeafAroma = DryLeafAroma;

            destination.InfusionAppearance = InfusionAppearance;
            destination.InfusionAroma = InfusionAroma;
            destination.InfusionBalance = InfusionBalance;
            destination.InfusionBody = InfusionBody;
            destination.InfusionBouquet = InfusionBouquet;
            destination.InfusionComment = InfusionComment;

            destination.InfusionExtractivity = InfusionExtractivity;
            destination.ImpressionComment = ImpressionComment;
            destination.ImpressionRate = ImpressionRate;
            destination.OtherComment = OtherComment;
            destination.WellCombinedWith = WellCombinedWith;
        }
    }
}
