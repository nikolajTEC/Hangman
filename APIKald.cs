using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class APIKald
    {
        public static string ApiKald()
        {
            //string apiUrl = "https://random-word-api.herokuapp.com/word?lang=es";
            string apiURL = 
            var randomWord = "";
            try
            {
                 randomWord = GetRandomWord(apiUrl);

                if (randomWord != null)
                {
                    Console.WriteLine($"Random word: {randomWord}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve a random word.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return randomWord;
        }

        static string GetRandomWord(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = response.Content.ReadAsStringAsync().Result;
                    int startIndex = jsonResult.IndexOf("\"word\":\"") + 8;
                    int endIndex = jsonResult.IndexOf("\"", startIndex);
                    string randomWord = jsonResult.Substring(startIndex, endIndex - startIndex);
                    return randomWord;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }
    }
}
