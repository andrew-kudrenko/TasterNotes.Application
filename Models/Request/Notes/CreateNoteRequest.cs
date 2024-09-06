using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Models.Request.Notes
{
    public class CreateNoteRequest
    {
        public Guid? DishwareId { get; set; }
        public CreateTasteRequest Taste { get; set; } = new();
        public CreateDescriptorSetRequest DescriptorSet { get; set; } = new();

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

        public Note ToNote(Guid userId)
        {
            return new()
            {
                UserId = userId,
                DishwareId = DishwareId,
                Taste = Taste.ToTaste(),
                DescriptorSet = DescriptorSet.ToDescriptorSet(),

                Title = Title,
                Kind = Kind,
                Region = Region,
                Year = Year,
                TastingDate = TastingDate,

                AftertasteComment = AftertasteComment,
                AftertasteDuration = AftertasteDuration,
                AftertasteIntense = AftertasteIntense,

                BrewingAmount = BrewingAmount,
                BrewingDishware = BrewingDishware,
                BrewingMethod = BrewingMethod,
                BrewingTemperature = BrewingTemperature,
                BrewingVolume = BrewingVolume,

                DryLeafAppearance = DryLeafAppearance,
                DryLeafAroma = DryLeafAroma,

                InfusionAppearance = InfusionAppearance,
                InfusionAroma = InfusionAroma,
                InfusionBalance = InfusionBalance,
                InfusionBody = InfusionBody,
                InfusionBouquet = InfusionBouquet,
                InfusionComment = InfusionComment,

                InfusionExtractivity = InfusionExtractivity,
                ImpressionComment = ImpressionComment,
                ImpressionRate = ImpressionRate,
                OtherComment = OtherComment,
                WellCombinedWith = WellCombinedWith,
            };
        }
    }
}
