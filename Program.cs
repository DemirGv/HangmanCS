using System.Text;

namespace HangmanCS
{
    internal class Program
    {
        private static string? word;

        static void Main(string[] args)
        {            
            List<string> wordList = new List<string>();
            string secretWord = GetSecretWord(wordList);            
            char[] letters = new string('_', secretWord.Length).ToCharArray();
            StringBuilder stringBuilder = new StringBuilder();                       
            List<string> wrongWords = new List<string>();          
            int guesses = 0;
            
            //for (int i = 0; i < guesses.Length; i++)        
            do
            {
                AddWrongLetter(stringBuilder);
                AddWrongWord(wrongWords, secretWord, word);
                AddLetter(letters, secretWord);

                guesses++;
                
                Console.WriteLine(stringBuilder+": wrong guesses and guesses left: " + (10 - guesses));

            } while (guesses < 10);
            Console.WriteLine("Game Over");
        }
        
        private static void AddLetter(char[] letters,string secretWord)
        {
            char letter = Console.ReadKey(true).KeyChar;
            foreach (char item in secretWord)
            {                
                if (!letters.Contains(letter) && secretWord.Contains(letter))
                {
                Console.Write(letter);            
                }
            }
        }
        private static void AddWrongWord(List<string> wrongWords,string secretWord, string word)
        {
            if (!secretWord.Equals(word))
            {
                wrongWords.Add(word);
            }            
        }
        private static string GetSecretWord(List<string> wordList)
        {
            if (wordList.Count == 0)
            {       
                wordList.AddRange(new string[] { "ö","å","örn",
                    "hav","ark","ko","tå","fot","sol","far" });                
            }
            Random random = new Random();
            string secretWord = wordList[random.Next(wordList.Count)];
            return secretWord;
        }
        private static void AddWrongLetter(StringBuilder stringBuilder)
        {            
            foreach (char letter in stringBuilder)
            {
                if (stringBuilder.Length == 0)                    
                {
                    stringBuilder.Insert(0, letter);                
                    Console.WriteLine(stringBuilder.ToString());
                }
                else if (!stringBuilder.Contains(letter))
                {                    
                    stringBuilder.Append(", " + letter);
                    Console.WriteLine(stringBuilder.ToString());
                }
            }            
        }
        
                      

    }
}