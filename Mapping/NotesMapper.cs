using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Mapping
{
    public static class NotesMapper
    {
        public static object ToBriefNote(Note source)
        {
            return new 
            { 
                source.NoteId,
                source.Title,
                source.Kind,
                source.Year,
                source.Region,
                source.TastingDate,
                source.BrewingMethod,
                source.ImpressionComment,
                Rate = source.ImpressionRate,
            };
        }

        public static object ToDetailedNote(Note source)
        {
            return new 
            {
                source.NoteId,

                source.Title,
                source.Kind,
                source.Region,
                source.Year,
                source.WellCombinedWith,
                source.OtherComment,
                source.TastingDate,
                
                Brewing = new
                {
                    Amount = source.BrewingAmount,
                    Dishware = source.BrewingDishware,
                    Method = source.BrewingMethod,
                    Temperature = source.BrewingTemperature,
                    Volume = source.BrewingVolume,
                },

                DryLeaf = new
                {
                    Appearance = source.DryLeafAppearance,
                    Aroma = source.DryLeafAroma,
                },

                Infusion = new
                {
                    Appearance = source.InfusionAppearance,
                    Aroma = source.InfusionAroma,
                    Comment = source.InfusionComment,
                    Body = source.InfusionBody,
                    Balance = source.InfusionBalance,
                    Bouquet = source.InfusionBouquet,
                    Extractivity = source.InfusionExtractivity,
                },

                Aftertaste = new
                {
                    Intense = source.AftertasteIntense,
                    Duration = source.AftertasteDuration,
                    Comment = source.AftertasteComment,
                },

                Impression = new
                {
                    Comment = source.ImpressionComment,
                    Rate = source.ImpressionRate,
                },

                source.Dishware,
                source.Taste,
                source.DescriptorSet,
            };
        }
    }
}
