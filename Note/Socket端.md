## VS2017 
新建项目->Visual C#->控制台应用(.NET Framework)

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





