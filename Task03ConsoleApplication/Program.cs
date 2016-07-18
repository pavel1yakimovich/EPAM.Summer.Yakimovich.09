using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(args[0]);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            char[] separator = {' ', ',', '.', '!', '@', '"', ')', '(', '?', ':', ';', '-', '_', '\''};
            string[] result = {};
            string text = "";

            while (!reader.EndOfStream)
            {
                text += reader.ReadLine();
            } 

            result = text.Split(separator);

            foreach (string word in result)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                Console.WriteLine($"Word: {pair.Key} was mentioned {pair.Value} time(s) in the text");
            }

            Console.ReadKey();
            reader.Close();
        }
    }
}
