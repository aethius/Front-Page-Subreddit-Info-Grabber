using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RedditFrontPageSubredditCount
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://reddit.com/r/all");

            string findPoint = "data-subreddit=\"";
            //string findPoint = "goofygoober";

            // For seeing the entire html grabbed from the source
            // Console.WriteLine(reply);
            // File.WriteAllText(@"C:\users\anthony\documents\C#\redditfrontpage.txt", reply);
            int count = 0;
            do
            {
                count++;
                int first = reply.IndexOf(findPoint) + findPoint.Length;
               // Console.WriteLine(reply.IndexOf(findPoint));
                reply = reply.Substring(first);

                int second = reply.IndexOf("\"");

                string subreddit = reply.Substring(0, second);

                Console.Write(count + " ");
                Console.WriteLine(subreddit);

            } while (reply.IndexOf(findPoint) != -1 );









            Console.ReadLine();
        }
    }
}
