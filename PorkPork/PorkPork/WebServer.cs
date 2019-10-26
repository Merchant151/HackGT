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
            server.Prefixes.Add("http://127.0.0.1:8005/");
            server.Prefixes.Add("http://localhost:8005/");

            server.Start();
                                                                                            
            while (true)
            {
                System.Threading.Thread.Sleep(100);
                HttpListenerContext context = server.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;

                Stream st = response.OutputStream;
                st.Write(buffer, 0, buffer.Length);
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                context.Response.Close();
            }

        }

    }
}