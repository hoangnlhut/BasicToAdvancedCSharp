using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Part28Caching
{
    file record AlphabetLetter(char Letter)
    {
        internal string Message =>
            $"The '{Letter}' character is the {Letter - 64} letter in the English alphabet.";
    }

    public partial class Program
    {
        
        const int MillisecondsDelayAfterAdd = 50;
        const int MillisecondsAbsoluteExpiration = 750;
        public static async Task Main(string[] args)
        {
            #region in-memory cache
            //await InMemoryCaching(args);
            #endregion

            #region Photo service scenario
            await PhotoServiceApp(args);
            #endregion
        }



        #region Photo service scenario
        private static async Task PhotoServiceApp(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient<CacheWorker>();
            builder.Services.AddHostedService<CacheWorker>();
            builder.Services.AddScoped<PhotoService>();
            builder.Services.AddSingleton(typeof(CacheSignal<>));

            using IHost host = builder.Build();

            await host.StartAsync();
        }
        #endregion

        #region in-memory cache
        static async Task InMemoryCaching(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddMemoryCache();
            using IHost host = builder.Build();

            IMemoryCache cache = host.Services.GetRequiredService<IMemoryCache>();

            var addLettersToCacheTask = IterateAlphabetAsync(letter =>
            {
                MemoryCacheEntryOptions options = new()
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMilliseconds(MillisecondsAbsoluteExpiration)
                };

                _ = options.RegisterPostEvictionCallback(OnPostEviction);

                AlphabetLetter alphabetLetter = cache.Set(letter, new AlphabetLetter(letter), options);

                Console.WriteLine($"{alphabetLetter.Letter} was cached.");

                return Task.Delay(TimeSpan.FromMilliseconds(MillisecondsDelayAfterAdd));
            });
            await addLettersToCacheTask;

            var readLettersFromCacheTask = IterateAlphabetAsync(letter =>
            {
                if (cache.TryGetValue(letter, out object? value) &&
                    value is AlphabetLetter alphabetLetter)
                {
                    Console.WriteLine($"{letter} is still in cache. {alphabetLetter.Message}");
                }

                return Task.CompletedTask;
            });
            await readLettersFromCacheTask;

            await host.RunAsync();
        }

        static async ValueTask IterateAlphabetAsync(Func<char, Task> asyncFunc)
        {
            for (char letter = 'A'; letter <= 'Z'; ++letter)
            {
                await asyncFunc(letter);
            }

            Console.WriteLine();
        }

        static void OnPostEviction(object key, object? letter, EvictionReason reason, object? state)
        {
            if (letter is AlphabetLetter alphabetLetter)
            {
                Console.WriteLine($"{alphabetLetter.Letter} was evicted for {reason}.");
            }
        }
        #endregion
    }
}
