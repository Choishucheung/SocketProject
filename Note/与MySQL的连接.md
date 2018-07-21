## 关键字
MySqlClient MySqlConnection  MySqlCommand  MySqlDataReader  MySqlDataReader  ExecuteReader  ExecuteNonQuery

## MySQL

1、Create new schema 增加一个库

2、Create Table 新增一个表，增加字段等，设置为PK即为Personal Key，主键。

3、在user 那里右键，点击select，可以进行表格内容修改。

4、Alter Table 设置表格 点击AI，自动生成id。



## 初步连接
### 需要添加 MySQL.dll
工程中有个引用，右键添加引用。
> 注意：dll如果不是从自己电脑里面的MySQL引入的话可能会有问题

### 1、引入dll
```
using MySql.Data.MySqlClient;
```

### 2、建立连接
用一个字符串，写下MySQL的数据库连接串。（SQL版本不同，字符串也不同），将字符串给连接通道MySqlConnection去实例化。最后open打开通道。

```
string connStr = "server=localhost;port=3306;database=mytest;user=root;password=asd1235a;SslMode = none;";
MySqlConnection conn = new MySqlConnection(connStr);
conn.Open();
```

### 3、向数据库查询
要向数据库发送一个命令MySqlCommand，命令实例化需要语句与通道对象。
```
MySqlCommand comm = new MySqlCommand("select * from user where id = 1",conn);
```

### 4、执行语句
查询语句ExecuteReader返回一个读取流，Execute有很多种，返回的东西也不同，这里返回读取流就需要实例化一个流MySqlDataReader。
```
MySqlDataReader reader =  comm.ExecuteReader();
```


### 5、解析MySqlDataReader
先HasRows判断是否有读取到，然后对这个流进行解析。
```
reader.Read();
string username = reader.GetString("username");//传递索引
```

### 6、关闭
需要关闭流及通道（close）。


### 7、注意
*C#连接MySQL异常:The host localhost does not support SSL connections*

有可能是连接串写错了，建议根据MySQL版本进行查询。



## 插入操作
ExecuteNonQuery意思是除了查询的其他操作。

```
MySqlCommand comm = new MySqlCommand("insert into user set username ='"+username + "'" + ",password='"+paw+"'",conn);
comm.ExecuteNonQuery();
```
> 注意：username等这些字符串是用户输入的，用户会输入语句进行SQL命令注入，需要进行判断。

利用@去填入未知的值，之后用Parameters再把值填入未知参数中。
```
MySqlCommand cmd = new MySqlCommand("insert into user set username =@u,password=@p", conn);
cmd.Parameters.AddWithValue("u", "用户");
```

## 删除，更新
SQL语句不同。
```
delete from user where id = @id
update user set password = @pwd where id = 1
```



