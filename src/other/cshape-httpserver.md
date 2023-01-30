[返回](./index.md)

使用Http服务一般步骤如下：

- 创建一个HTTP侦听器对象并初始化
- 添加需要监听的URI 前缀
- 开始侦听来自客户端的请求
- 处理客户端的Http请求
- 关闭HTTP侦听器

详细见代码：[code](./code/MyHttp.cs)

出现的问题和解决方案：
1. 使用 Newtonsoft.Json 发现编译的时候找不到包，解决方案在dotnet工程使用命令：dotnet add package Newtonsoft.Json，就会下载该包，并写入csproj工程文件中

2. 例如字符串str = $"abc"，这是因为framework版本问题，使用String.Formate("abc")替换即可

3. 跨域问题，设置了Access-Control-Allow-Origin：* 前端还是报跨域，origin设置成功又报错：Content-Type不支持，设置headers后，又报错：“The value of the 'Access-Control-Allow-Credentials' header in the response is '' which must be 'true”，这个问题我后面单独开个章节一步一步解决

4. 在启动 httpListener.Start();的时候出现[System.Net.HttpListenerException]（） ：{“拒绝访问。”}\
解决方案：netsh http add urlacl url=http://+:8080/ user=username\
查看windows系统的登录用户名，用gitbash输入命令：whoami

C#将字符串转换成unicode形式：[unicode](./code/UnicodeTest.cs)

零宽字符集合：[零宽字符](https://blog.csdn.net/qq_42718938/article/details/107378362)

[返回](./index.md)