using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebServer
{
    class ServerMain
    {
        public static void server()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://+:8005/");

            server.Start();
                                                                                            
            while (true)
            {
                System.Threading.Thread.Sleep(100);
                HttpListenerContext context = server.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                var body = new StreamReader(context.Request.InputStream).ReadToEnd();

                Console.WriteLine(body);
                TextReader tr = new StreamReader("index.html");
                string msg = tr.ReadToEnd();  //getting the page's content

                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                Stream st = response.OutputStream;
                st.Write(buffer, 0, buffer.Length);

                context.Response.Close();
            }

        }

    }
}