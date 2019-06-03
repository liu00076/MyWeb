using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Helper;

namespace TestClass.TcpTest
{
    public class TcpClientTest
    {
        public void TestTcpConnection()
        {
            //创建tcp链接
            TcpHelper.CreateTcpService(34324, (m) =>  m + "\r\n");

            //客户端调用
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 34324)); //配置服务器IP与端口  
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                return;
            }
            byte[] result = new byte[1024];
            //通过 clientSocket 发送数据
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Thread.Sleep(1000);    //等待1秒钟
                    string sendMessage = "client send Message Help " + DateTime.Now;
                    clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
                    Console.WriteLine("向服务器发送消息：{0}" , sendMessage);
                    int length = clientSocket.Receive(result);
                    Console.WriteLine("接收服务器消息：{0}", Encoding.ASCII.GetString(result, 0, length));
                    if (i == 2)
                    {
                        TcpHelper.Dispose();
                    }
                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }
            
            Console.WriteLine("发送完毕，按回车键退出");
            Console.ReadLine();  

        }
    }

}
