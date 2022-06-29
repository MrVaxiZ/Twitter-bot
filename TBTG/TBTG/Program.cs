using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

//To use it you have to download "Tweetinvi" from NuGet
class TwitterPictureBot
{
    static async Task Main()
    {
        
        var api = "";
        var apiS = "";
        var accessToken = "";
        var accessTokenS = "";

        var value = 0; // number of current picture
        while (true)
        {
            if (DateTime.Now.Hour - 8 == 0 && DateTime.Now.Minute == 0) //Date on which picture should be released
            {
                if (value < 100) // number of how many pictures do you have
                {
                    
                    if (File.Exists($"{value}.jpg")) //cheking for file type you can add more if you want
                    {
                        byte[] ImageB = File.ReadAllBytes($"{value}.jpg");
                        TwitterClient UserClient = new TwitterClient(api, apiS, accessToken, accessTokenS);
                        IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageB);                 //Here you can add comment to your picture
                        ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters($"Picture #{value}") { Medias = { ImageIMedia } });
                        value++;
                        Console.WriteLine($"Picture id off {value - 1} was send on this {DateTime.Now} time");
                    }
                    else if (File.Exists($"{value}.png"))
                    {
                        byte[] ImageB = File.ReadAllBytes($"{value}.png");
                        TwitterClient UserClient = new TwitterClient(api, apiS, accessToken, accessTokenS);
                        IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageB);
                        ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters($"Picture #{value}") { Medias = { ImageIMedia } });
                        value++;
                        Console.WriteLine($"Picture id off {value - 1} was send on this {DateTime.Now} time");
                    }
                    else
                    {
                        Console.WriteLine("File not recognized");
                    }
                }
                else
                {
                    Console.WriteLine("No more pictures found");
                }
            }
            Thread.Sleep(59000);
        }
    }
}

