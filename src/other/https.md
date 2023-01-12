[返回](./index.md)

这里笔者声明：我从不写文章，我只是文章的搬运工，一下内容全是胡编乱造，呸，是东拼西凑！

HTTPS是在HTTP上建立SSL加密层，并对传输数据进行加密，是HTTP协议的安全版。HTTPS并非是应用层的一种新协议，只是HTTP通信接口部分用SSL和TLS协议。

经常我们开启https服务后，需要上传证书和密钥：例如：xxx.cert文件和server.key两个文件至服务端。\
这么说不够清晰，直接上代码举例，举个nodeJs的例子：
```javascript
const https = require('https');
const fs = require('fs');
const options = {
  key: fs.readFileSync('./server.key'),
  cert: fs.readFileSync('./xxx.cert')
}
const https_server = https.createServer(options);
https_server.listen(8000);
```

可以生成本地证书的方式这里不记录了(可参考文章：[本地生成https签名证书](https://blog.csdn.net/sinat_40914914/article/details/121248337))，在windows双击打开后可以看到提示，这个证书并不被信任：

![image](./images/cert.jpg)

因为这是本地生成的证书，并非是CA机构发布的证书（浏览器怎么校验是否是证书是否合法，见：[浏览器如何验证HTTPS证书的合法性？](https://www.zhihu.com/question/37370216)）

如果需要信任，则安装根证书，注意本地开启的服务域名需要和颁发给保持一致，这样浏览器就不会提示不安全了。

一张图解释，https的流程：

![ssl](./images/ssl.jpg)

了解这张图需要先理解啥是对称加密，非对称加密，各自的优缺点：[对称加密和非对称加密](https://zhuanlan.zhihu.com/p/436455172)

[返回](./index.md)