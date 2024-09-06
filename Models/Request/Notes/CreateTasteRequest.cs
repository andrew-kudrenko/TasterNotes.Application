using TasterNotes.Persistence.Models.Notes;

namespace TasterNotes.Application.Models.Request.Notes
{
    public class CreateTasteRequest
    {
        public int Sweety { get; set; }
        public int Sour { get; set; }
        public int Bitter { get; set; }
        public int Salty { get; set; }
        public int Umami { get; set; }

        public Taste ToTaste()
        {
            return new()
            {
                Bitter = Bitter,
                Salty = Salty,
                Sour = Sour,
                Sweety = Sweety,
                Umami = Umami,
            };
        }
    }
}
