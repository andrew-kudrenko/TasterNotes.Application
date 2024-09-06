using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Models.Request.Notes
{
    public class UpdateTasteRequest
    {
        public int Sweety { get; set; }
        public int Sour { get; set; }
        public int Bitter { get; set; }
        public int Salty { get; set; }
        public int Umami { get; set; }

        public void Assign(Taste destination)
        {
            destination.Bitter = Bitter;
            destination.Salty = Salty;
            destination.Sour = Sour;
            destination.Sweety = Sweety;
            destination.Umami = Umami;
        }
    }
}
