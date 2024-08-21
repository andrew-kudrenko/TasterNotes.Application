using System.ComponentModel.DataAnnotations;
using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Models.Notes
{
    public class CreateDescriptorSetDto
    {
        public int Earthy { get; set; }        
        public int Animal { get; set; }
        public int Mineral { get; set; }
        public int Sea { get; set; }
        public int Confectionary { get; set; }
        public int Bread { get; set; }
        public int Creamy { get; set; }
        public int Herbaceous { get; set; }
        public int Vegetable { get; set; }
        public int Spicy { get; set; }
        public int Floral { get; set; }
        public int FreshFruity { get; set; }
        public int Citrus { get; set; }
        public int Tropical { get; set; }
        public int Candied { get; set; }
        public int Berry { get; set; }
        public int DriedFrruity { get; set; }
        public int Nutty { get; set; }
        public int Woody { get; set; }
        public int Yeast { get; set; }
        public int Chemical { get; set; }
        public int Mushroom { get; set; }

        public DescriptorSet ToDescriptorSet()
        {
            return new()
            {
                Chemical = Chemical,
                Floral = Floral,
                Animal = Animal,
                Berry = Berry,
                Bread = Bread,
                Creamy = Creamy,
                Candied = Candied,
                Citrus = Citrus,
                Confectionary = Confectionary,
                DriedFrruity = DriedFrruity,
                Earthy = Earthy, 
                Nutty = Nutty,
                Woody = Woody,
                Yeast = Yeast,
                FreshFruity = FreshFruity,
                Herbaceous = Herbaceous,
                Mineral = Mineral,
                Mushroom = Mushroom,
                Sea = Sea,
                Spicy = Spicy,
                Tropical = Tropical,
                Vegetable = Vegetable,
            };
        }
    }
}
