using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Helper.Log;

namespace Helper.Helper.Net.TCP
{
    /// <summary>
    ///     tcp 帮助类
    ///     http://blog.csdn.net/andrew_wx/article/details/6629721/
    /// </summary>
    public class TcpHelper
    {
        private static Func<string, string> _func;
        private static Socket _serverSocket;
        private static readonly byte[] Result = new byte[1024];
        private static CancellationTokenSource _cancellationToken;

        #region 创建Tcp服务端

        /// <summary>
        /// 释放线程
        /// </summary>
        public static void Dispose()
        {
            //取消任务
            _cancellationToken.Cancel();
        }

        /// <summary>
        /// </summary>
        /// <param name="prot"></param>
        /// <param name="func">代理方法由于处理从客户端接受的数据</param>
        public static void CreateTcpService(int prot, Func<string, string> func)
        {
            if (prot <= 0) return;
            _func = func;
            _cancellationToken = new CancellationTokenSource();
            var address = IPAddress.Parse("127.0.0.1");
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定IP地址：端口
            _serverSocket.Bind(new IPEndPoint(address, prot));
            //设定最多10个排队连接请求
            _serverSocket.Listen(10);
            Log4Helper.DebuggerLog(string.Format("启动监听{0}成功", _serverSocket.LocalEndPoint));

            //开启线程，监听客户端连接
            var myThread = new Thread(() =>
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    var serviceSocket = _serverSocket.Accept();
                    EndPoint endPoint = serviceSocket.RemoteEndPoint;
                    Log4Helper.DebuggerLog(string.Format("获取客户端：{0}，的连接。", endPoint.Serialize()));
                    var receiveThread = new Thread(ReceiveMessage);
                    receiveThread.Start(serviceSocket);
                }
                _serverSocket.Dispose();
            });
            myThread.Start();
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="obj"></param>
        private static void ReceiveMessage(object obj)
        {
            var serviceSocket = (Socket)obj;

            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    var receiveNumber = serviceSocket.Receive(Result);
                    var receive = Encoding.ASCII.GetString(Result, 0, receiveNumber);
                    Log4Helper.DebuggerLog(string.Format("接收客户端：{0}，消息：{1}", serviceSocket.RemoteEndPoint, receive));
                    if (_func != null)
                    {
                        string result = _func(receive);
                        serviceSocket.Send(Encoding.ASCII.GetBytes(result));
                    }
                    if (!_cancellationToken.IsCancellationRequested) break;
                }
                catch (Exception ex)
                {
                    Log4Helper.ErrorLog(ex.Message);
                    break;
                }
            }
            serviceSocket.Shutdown(SocketShutdown.Both);
            serviceSocket.Close();
            Dispose();
        }

        #endregion

        #region 客户端调用方式

        //TcpHelper.CreateTcpService(34324, (m) => m);
        ////客户端调用
        ////设定服务器IP地址  
        //IPAddress ip = IPAddress.Parse("127.0.0.1");
        //Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //clientSocket.Connect(new IPEndPoint(ip, 34324)); //配置服务器IP与端口  
        //clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
        //clientSocket.Receive(result);

        #endregion

    }
}