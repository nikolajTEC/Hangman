using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Hangman
{
    public class APIKald
    {
        public static string ApiKald()
        {
            //string apiUrl = "https://random-word-api.herokuapp.com/word";
            string apiUrl = "https://random-word-form.repl.co/random/noun?";
            var randomWord = "";
            try
            {
                randomWord = GetRandomWord(apiUrl);
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
                    string apiResult = response.Content.ReadAsStringAsync().Result;

                    // Deserialize JSON array to a List<string>
                    var deserializedObject = JsonConvert.DeserializeObject<string[]>(apiResult);

                    // Access the first element of the array
                    string randomWord = deserializedObject?.FirstOrDefault(); // Handle the case where deserializedObject is null
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
