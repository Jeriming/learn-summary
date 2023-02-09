[返回](./index.md)

今天在本地使用NodeJs开启一个简单的JSONP服务
```javascript
const app = express()

app.use(express.urlencoded({extended: false}))

app.get('/api/jsonp', (req, res) => {
    // 得到函数的名称
    const funcName = req.query.callback
    // 定义要发送到客户端的数据对象
    const data = {name:'lilei', age:18}
    // 拼接出一个函数的调用
    const scriptStr = `${funcName}(${JSON.stringify(data)})`
    // 把拼接的字符串，响应给客户端
    res.send(scriptStr)
})

const cors = require('cors')
app.use(cors())

const router = require('./apiRouter')
app.use('/api', router)

app.listen(8001, ()=> {
    console.log('express 服务器运行在 http://localhost:8001')
})
```

然后在某战点调用该jsonp服务，结果报错：

Refused to load the font '<URL>' because it violates the following Content Security Policy directive: "font-src 'self'".

一搜，原理是该站点开启了CSP策略，那么什么是CSP策略呢？

MDN的解释是：内容安全策略 (CSP) 是一个额外的安全层，用于检测并削弱某些特定类型的攻击，包括跨站脚本 (XSS (en-US)) 和数据注入攻击等。无论是数据盗取、网站内容污染还是散发恶意软件，这些攻击都是主要的手段。

CSP 被设计成完全向后兼容（除 CSP2 在向后兼容有明确提及的不一致; 更多细节查看这里 章节 1.1）。不支持 CSP 的浏览器也能与实现了 CSP 的服务器正常合作，反之亦然：不支持 CSP 的浏览器只会忽略它，如常运行，默认为网页内容使用标准的同源策略。如果网站不提供 CSP 头部，浏览器也使用标准的同源策略。

为使 CSP 可用，你需要配置你的网络服务器返回 Content-Security-Policy HTTP 头部 ( 有时你会看到一些关于X-Content-Security-Policy头部的提法，那是旧版本，你无须再如此指定它)。

仔细看该站点的请求可以看到响应头含有一条策略：
Content-Security-Policy: "default-src 'self' 'unsafe-inline'

其中就能看到 "default-src 'self'，表示所有内容均只能来自站点的同一个源，其他源就会报错，所以需要解决上诉问题，需要将localhost:8001加入这个白名单内。

CSP更多函数看文档示例：

- 示例 1
一个网站管理者想要所有内容均来自站点的同一个源 (不包括其子域名)

Content-Security-Policy: default-src 'self'
Copy to Clipboard
- 示例 2
一个网站管理者允许内容来自信任的域名及其子域名 (域名不必须与 CSP 设置所在的域名相同)

Content-Security-Policy: default-src 'self' *.trusted.com
Copy to Clipboard
- 示例 3
一个网站管理者允许网页应用的用户在他们自己的内容中包含来自任何源的图片，但是限制音频或视频需从信任的资源提供者 (获得)，所有脚本必须从特定主机服务器获取可信的代码。

Content-Security-Policy: default-src 'self'; img-src *; media-src media1.com media2.com; script-src userscripts.example.com
Copy to Clipboard
在这里，各种内容默认仅允许从文档所在的源获取，但存在如下例外：

图片可以从任何地方加载 (注意 "*" 通配符)。
多媒体文件仅允许从 media1.com 和 media2.com 加载 (不允许从这些站点的子域名)。
可运行脚本仅允许来自于 userscripts.example.com。
- 示例 4
一个线上银行网站的管理者想要确保网站的所有内容都要通过 SSL 方式获取，以避免攻击者窃听用户发出的请求。

Content-Security-Policy: default-src https://onlinebanking.jumbobank.com
Copy to Clipboard
该服务器仅允许通过 HTTPS 方式并仅从onlinebanking.jumbobank.com域名来访问文档。

- 示例 5
一个在线邮箱的管理者想要允许在邮件里包含 HTML，同样图片允许从任何地方加载，但不允许 JavaScript 或者其他潜在的危险内容 (从任意位置加载)。

Content-Security-Policy: default-src 'self' *.mailsite.com; img-src *
Copy to Clipboard
注意这个示例并未指定script-src (en-US)。在此 CSP 示例中，站点通过 default-src 指令的对其进行配置，这也同样意味着脚本文件仅允许从原始服务器获取。

有两种方式可以设置CSP策略：\
1.通过服务器（或代理服务器）设置站点的响应头；\
2.通过设置html的meta标签：\<meta http-equiv="Content-Security-Policy" content="style-src 'self' 'unsafe-inline';。。。。">

[返回](./index.md)
