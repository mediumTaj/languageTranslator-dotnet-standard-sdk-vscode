using IBM.WatsonDeveloperCloud.LanguageTranslator.v2;
using IBM.WatsonDeveloperCloud.LanguageTranslator.v2.Model;
using System;

namespace LanguageTranslatorDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TranslatorExample translatorExample = new TranslatorExample();
        }
    }

    public class TranslatorExample
    {
        private LanguageTranslatorService languageTranslator = new LanguageTranslatorService();
        private string username = "";
        private string password = "";

        public TranslatorExample()
        {
            if(string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username");
            }

            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("password");
            }
            
            languageTranslator.SetCredential(username, password);

            AskForInput();
        }

        private void AskForInput()
        {
            Console.WriteLine("\nTranslate english to spanish: ");
            var input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please type a phrase to translate from english to spanish.");
                AskForInput();
            }

            Translate(input);
        }

        private void Translate(string input)
        {
            var response = languageTranslator.Translate("en-es", input);

            if (response != null)
            {
                if (response.Translations != null && response.Translations.Count > 0)
                {
                    foreach (Translations translation in response.Translations)
                    {
                        if (!string.IsNullOrEmpty(translation.Translation))
                        {
                            Console.WriteLine(string.Format("response: {0}", translation.Translation.ToString()));
                        }
                        else
                        {
                            Console.WriteLine("Translation is empty.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There are no translations.");
                }
            }
            else
            {
                Console.WriteLine("Response is null.");
            }

            AskForInput();
        }
    }
}
