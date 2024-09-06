using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Models.Request.Notes
{
    public class UpdateDescriptorSetRequest
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

        public void Assign(DescriptorSet destination)
        {
            destination.Chemical = Chemical;
            destination.Floral = Floral;
            destination.Animal = Animal;
            destination.Berry = Berry;
            destination.Bread = Bread;
            destination.Creamy = Creamy;
            destination.Candied = Candied;
            destination.Citrus = Citrus;
            destination.Confectionary = Confectionary;
            destination.DriedFrruity = DriedFrruity;
            destination.Earthy = Earthy;
            destination.Nutty = Nutty;
            destination.Woody = Woody;
            destination.Yeast = Yeast;
            destination.FreshFruity = FreshFruity;
            destination.Herbaceous = Herbaceous;
            destination.Mineral = Mineral;
            destination.Mushroom = Mushroom;
            destination.Sea = Sea;
            destination.Spicy = Spicy;
            destination.Tropical = Tropical;
            destination.Vegetable = Vegetable;
        }
    }
}
