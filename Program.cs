using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

class TwitterCatMeme
{
    static async Task Main()
    {
        #region
        var api = "seuH4L8CwK5SIa9DgXF4J2yhj";
        var apiS = "raH841waiKPMczDk1wGcgGpakyQKNLLfIqTvF7oo905nqeuZ2N";
        var accessToken = "1521793351816732674-g9gFAnNnpLtOyBA8EZT4oGe8oVE3JX";
        var accessTokenS = "ghSo56s5ZM2Irs5APuD7gpjxSmh0zwhXXkfC1q9TRUXml";

        var Btoken = "AAAAAAAAAAAAAAAAAAAAAAfXbgEAAAAASQgxooxtrDdmkOq3HdmXy3ByGZQ%3Dm74XqHEp5Q4PjaWN46iW0fBJcJ98v7IUaC9U0w16RMRDeftP42";
        var appid = "24041223";
        #endregion

        var value = 115; // number of current picture
        while (true)
        {
            if ((DateTime.Now.Hour - 8 == 0 && DateTime.Now.Minute == 0) || (DateTime.Now.Hour - 18 == 0 && DateTime.Now.Minute == 0) )
            {
                if (value < 140) // number of how many pictures do you have
                {
                    if (File.Exists($"{value}.jpg"))
                    {
                        byte[] ImageB = File.ReadAllBytes($"{value}.jpg");
                        TwitterClient UserClient = new TwitterClient(api, apiS, accessToken, accessTokenS);
                        IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageB);
                        ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters($"CatMeme #{value} #Cats") { Medias = { ImageIMedia } });
                        value++;
                        Console.WriteLine($"Cat Mem id off {value - 1} was send on this {DateTime.Now} time");
                    }
                    else if (File.Exists($"{value}.png"))
                    {
                        byte[] ImageB = File.ReadAllBytes($"{value}.png");
                        TwitterClient UserClient = new TwitterClient(api, apiS, accessToken, accessTokenS);
                        IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageB);
                        ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters($"CatMeme #{value} #Cats") { Medias = { ImageIMedia } });
                        value++;
                        Console.WriteLine($"Cat Mem id off {value - 1} was send on this {DateTime.Now} time");
                    }
                    else
                    {
                        Console.WriteLine("File not recognized");
                    }
                }
                else
                {
                    Console.WriteLine("BRAK MEMOW");
                }
            }
            Thread.Sleep(59000);
        }
    }
}

