namespace CST350_BibleVerseBenchmark_DanielThompson.Models
{
    public class BibleModel
    {
        // Declaration of class variables
        public int ID { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BibleModel() 
        {
            ID = 0;
            Book = string.Empty;
            Chapter = 0;
            Verse = 0;
            Text = string.Empty;
        }

        /// <summary>
        /// Paramertized Constructor that intializes the class variables to the parameters
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="book"></param>
        /// <param name="chapter"></param>
        /// <param name="verse"></param>
        /// <param name="text"></param>
        public BibleModel(int iD, string book, int chapter, int verse, string text)
        {
            ID = iD;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
        }
    }
}
