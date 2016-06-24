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
            bool again = false;
            string userReply;
            do
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

                } while (reply.IndexOf(findPoint) != -1);

                bool userResponse;
                do
                {
                    Console.Write("Again? (y/n): ");
                    userReply = Console.ReadLine();
                    //Console.WriteLine(again);

                    if (userReply == "y")
                    {
                        again = true;
                        userResponse = true;
                    }
                    else if (userReply == "n")
                    {
                        again = false;
                        userResponse = true;

                    }
                    else
                    {
                        userResponse = false;
                    }
                } while (userResponse == false);
                 
               


            } while (again == true);







            // Console.ReadLine();
        }
    }
}
