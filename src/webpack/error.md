[返回](./index.md)

### 记录日常错误处理

1. 下载image-webpack-loader中的imagemin-gifsicle报错

控制台提示：
Error: Command failed: C:\windows\system32\cmd.exe /s /c “./configure --disable-shared

错误中有个关键的域名： raw.githubusercontent.com，很明显这是被和谐了，通过改host解决：

199.232.28.133		raw.githubusercontent.com

[返回](./index.md)