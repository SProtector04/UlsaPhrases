namespace UlsaPhrases.Models
{
    public class Phrase
    {
        public int Id { get; set; } 
        public required string PhraseStatement { get; set; } 
        public string? PhraseAuthor { get; set; }
        public string? PhraseDedication { get; set; }
        public string? PhraseDate { get; set; }
        public string? PhraseContext { get; set; }

        public Phrase()
        {

        }
    }
}
