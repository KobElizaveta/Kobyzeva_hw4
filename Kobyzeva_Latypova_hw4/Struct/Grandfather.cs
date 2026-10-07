using Kobyzeva_Latypova_hw4.Enum;

namespace Kobyzeva_Latypova_hw4.Struct
{
    internal struct Grandfather
    {
        public string Name;
        public GrumpinessLevel GrumpinessLevel;
        public string[] GrumblingPhrases;
        public byte BruiseCount;

        public Grandfather(string name, GrumpinessLevel grumpinessLevel, string[] grumblingPhrases, byte bruiseCount)
        {
            Name = name;
            GrumpinessLevel = grumpinessLevel;
            GrumblingPhrases = grumblingPhrases;
            BruiseCount = bruiseCount;
        }


        public static byte BruisesForUsingFoulLanguage(Grandfather grandfather, params string[] listOfSwearWords)
        {
            byte bruiseCount = 0;
            foreach (string wordGrandfather in grandfather.GrumblingPhrases)
            {
                if (listOfSwearWords.Contains(wordGrandfather))
                {
                    bruiseCount++;
                }
            }

            Console.WriteLine($"{grandfather.Name} получил от бабки {bruiseCount} фингалов(-ла),\nЕго лексикон: {string.Join(", ", grandfather.GrumblingPhrases)}");
            return bruiseCount;
        }
    }
}
