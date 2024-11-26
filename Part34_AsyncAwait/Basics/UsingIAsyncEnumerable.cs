using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part34_AsyncAwait.Basics
{
    public class UsingIAsyncEnumerable
    {
        public static async void MainIAsyncEnumerable()
        {
            var enumarateS = ReadWordsFromStreamAsync();
            await foreach (var word in enumarateS)
            {
                Console.WriteLine($"Word: {word}");
            }
        }

        public static async IAsyncEnumerable<string> ReadWordsFromStreamAsync()
        {
            string data =
                @"This is a line of text.
              Here is the second line of text.
              And there is one more for good measure.
              Wait, that was the penultimate line.";

            using var readStream = new StringReader(data);

            string? line = await readStream.ReadLineAsync();
            while (line != null)
            {
                foreach (string word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    yield return word;
                }

                line = await readStream.ReadLineAsync();
            }
        }
    }
}
