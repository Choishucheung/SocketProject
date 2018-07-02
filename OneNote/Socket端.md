# Socket端
## 初始化
引用，在Net里面
`using System.Net.Sockets;`

初始化一个severSocket，第一个参数代表ip的类型，选择没有v6的，即ipv4。第二个参数是socket类型。第三个是设置tcp还是udp。

> ip4 即 xx.xx.xx.xx  
> Dgram 数据报，利用邮差送报，会丢失  
> Stream 流（比较稳定）中间建立了通道，有流  

绑定ip。服务器只有一个外网ip。
绑定ip先要初始化一个ipaddress 填入ip。
然后初始化端口号 ipendpoint。
最后利用bind去绑定ip和端口号。
> 127.0.0.1 代表本机 万能  


