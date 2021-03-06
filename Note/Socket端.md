## VS2017 
新建项目->Visual C#->控制台应用(.NET Framework)

> Obj文件夹里面为生成的中间文件。

## Socket端
### 初始化Socket
引用，在Net里面
`using System.Net.Sockets;`

初始化一个severSocket，第一个参数代表ip的类型，选择没有v6的，即ipv4。第二个参数是socket类型。第三个是设置tcp还是udp。

> ip4 即 xx.xx.xx.xx  
> Dgram 数据报，利用邮差送报，会丢失  
> Stream 流（比较稳定）中间建立了通道，有流  
> 用的是tcp协议


### 绑定ip及端口号
绑定ip。服务器只有一个外网ip。

绑定ip先要初始化一个ipaddress 填入ip。

然后初始化端口号 ipendpoint。

最后利用bind去绑定ip和端口号。
> 127.0.0.1 代表本机 万能  

### 监听端口send、receive
对端口进行监听，队列为10个。Listen需要的参数是队列。

接收端口号，Accept。Accept会返回一个socket。

利用新的这个socket进行send数据。数据不能是string，必须是byte数组。

`System.Text.Encoding.UTF8.GetBytes`

send之后就等待接收，Receive。

Receive之后把byte转string打印出来。


## 客户端
### 初始化同上

### 连接
利用connect去连接ip及端口
` clientSocket.Connect(new IPEndPoint(IPAddress.Parse("10.65.85.44"),88)); `

### 端口号 IPEndPoint 

### 注意
一个先发送，后接收，另一个就先接收，后发送。 
```
Console.ReadKey();
```
这个可以让控制台暂停等待下一步动作。


## 异步消息接收消息
使用 Receive 方法，一直是暂停在那里直到有东西传过来。
### 使用线程
**StartServerAsync**
*BeginReceive* 开始异步接收数据。
socketFlags 不使用 。
CallBack 使用哪个方法处理，用事件的方式。
*EndReceive* 结束接收

**Callback**
在callback中结束接收。Callback需要有一个参数 IAsyncResult 类型 用于接收object。

end需要一个返回值，是返回的信息的count，对这个count进行判断。

相应的，在begin的data可以拿出来用了 end的时候返回一个count。

最后在callback继续调用begin，这样就形成了一个循环。

在客户端也是这样，循环调用 send。


## 多个客户端发送消息的接收
使用BeginAccept方法和EndAccept方法。
然后在一个callback里面进行循环。
```
private static void AcceptCallBack(IAsyncResult ar)
        {
            Socket acceptSocket = ar.AsyncState as Socket;
            Socket cliectSocket = acceptSocket.EndAccept(ar);
            string send = "你好";
            Byte[] dataBuffer = Encoding.UTF8.GetBytes(send);
            cliectSocket.Send(dataBuffer);
            cliectSocket.BeginReceive(msg.Data, msg.BeginCount, msg.EndCount, SocketFlags.None, ReceiveCallBack, cliectSocket);
            acceptSocket.BeginAccept(AcceptCallBack, acceptSocket);
        }
```


## 客户端关闭异常情况
try-catch语句
```
exception e
```
然后对异常进行捕获，如果有异常就 close。下一个还可以继续通讯。close的时候要注意是否这个socket为null。

客户端输入某个字符串就关闭，但关闭之后一直发空消息给服务器端。

服务器端对count进行判断。如果为 0 就关闭（不需要循环，因为这个流已经关闭了）。


## 总结
Accept的方式去建立连接，Connect是客户端的，两者都是用Receive来接收消息
。
异步的方式就是多一个Begin。
### 异步
与同步相对应，异步指的是让CPU暂时搁置当前请求的响应,处理下一个请求,当通过轮询或其他方式得到回调通知后,开始运行。

多线程将异步操作放入另一线程中运行，通过轮询或回调方法得到完成通知,但是完成端口，由操作系统接管异步操作的调度，通过硬件中断，在完成时触发回调方法，此方式不需要占用额外线程。
