using Azure;
using Azure.AI.TextAnalytics;
using System;

namespace VoiceWorker
{
   public class Program
    {

        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("chave api");
        private static readonly Uri endpoint = new Uri("url recurso");
        
        static void KeyPhraseExtraction(TextAnalyticsClient client)
        {
            Console.Write("Digite uma frase para obter palavras chaves:");
            Console.ReadKey();

            string text;
            text = Console.ReadLine();
            var response = client.ExtractKeyPhrases(text);
         
            Console.WriteLine("Palavras chave:");

            foreach (string keyphrase in response.Value)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }
        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            KeyPhraseExtraction(client);

            Console.Write("Pressione uma tecla para fechar.");
            Console.ReadKey();
        }       
    }
}
