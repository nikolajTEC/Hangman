namespace Hangman
{
    internal class Program
    {
        static string[] words = { "banan", "solskin", "kage", "elefant", "skovtur" };
        static int correctCounter = 0;
        static int incorrectCounter = 0;
        static char[] incorrectLetters = new char[7];
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til hangman");
            StartGame();
        }
        private static void StartGame()
        {
            bool gameOver;
            //Random random = new Random();
            //int randomIndex = random.Next(0, words.Length);
            //string randomWord = words[randomIndex];
            string randomWord = APIKald.ApiKald(); 
            char[] guessedLetters = new char[randomWord.Length];

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                guessedLetters[i] = '_';
            }
            do
            {
                Display(guessedLetters);
                gameOver = GuessWord(randomWord, guessedLetters);
            }
            while (!gameOver);

            if (correctCounter == randomWord.Length)
            {
                Display(guessedLetters);
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine($"Defeat!, the word was {randomWord}");
            }
        }

        private static bool GuessWord(string randomWord, char[] guessedLetters)
        {
            Console.WriteLine("Guess a letter");
            char guessedLetter = Console.ReadKey().KeyChar;
            if (guessedLetters.Contains(guessedLetter) || incorrectLetters.Contains(guessedLetter))
            {
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("You've already guessed this letter. Try again.");
                return false;
            }
            if (randomWord.Contains(guessedLetter))
            {
                CorrectGuess(randomWord, guessedLetter, guessedLetters);
                if (correctCounter == randomWord.Length)
                    return true;
            }
            else
            {
                IncorrectGuess();
                incorrectLetters[incorrectCounter - 1] = guessedLetter;
                if (incorrectCounter == 7)
                    return true;
            }
            Console.Clear();
            return false;
        }

        private static void IncorrectGuess()
        {
            Console.WriteLine("Du har gættet forkert");
            incorrectCounter++;
        }

        private static void CorrectGuess(string randomWord, char guessedLetter, char[] guessedLetters)
        {
            Console.WriteLine("Du har gættet rigtigt");
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (randomWord[i] == guessedLetter)
                {
                    guessedLetters[i] = guessedLetter;
                    correctCounter++;
                }

            }
        }
        private static void Display(char[] guessedLetters)
        {

            Console.SetCursorPosition(30, 10);
            string spacedWord = string.Join(" ", guessedLetters);
            Console.WriteLine("Current word: " + spacedWord);
            Console.WriteLine("Incorrect letters: " + new string(incorrectLetters));
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            DisplayHangman(incorrectCounter);
        }
        static void DisplayHangman(int incorrectGuesses)
        {

            // Display the Hangman figure based on the incorrect guesses
            switch (incorrectGuesses)
            {
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  O   |");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" /    |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("  O   |");
                    Console.WriteLine(" /|\\  |");
                    Console.WriteLine(" / \\  |");
                    Console.WriteLine("      |");
                    Console.WriteLine("      |");
                    break;
            }
        }
    }
}