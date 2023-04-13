using System.Net;

namespace Sample.ConsoleApp;

public static class CpuSample
{
    public static void Do()
    {
        //ContextSwitch();
        //InfiniteLoop();
        InfiniteWebRequest();
    }

    static void ContextSwitch()
    {
        var thread = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(5000);
            }
        });

        thread.Start();
    }

    static void InfiniteLoop()
    {
        var thread = new Thread[Environment.ProcessorCount];

        for (var i = 0; i < thread.Length; i++)
        {
            thread[i] = new Thread(() =>
            {
                while (true)
                {
                }
            });
            thread[i].Start();
        }
    }

    static void InfiniteWebRequest()
    {
        var thread = new Thread[Environment.ProcessorCount];

        for (var i = 0; i < thread.Length; i++)
        {
            thread[i] = new Thread(() =>
            {
                while (true)
                {
                    var request = WebRequest.Create("https://www.google.com");
                    request.Method = "GET";

                    using (var response = (HttpWebResponse)request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var content = reader.ReadToEnd();
                    }
                }
            });
            thread[i].Start();
        }
    }
}