[返回](./index.md)

前言：在使用 vue-cli 3.0 的过程中，虽然号称零配置布项，大大的简化了我们新工程的配置过程，但随之失去的就是配置的灵活性。

虽然 vue-cli 提供了 configureWebpack 和 chainWebpack 来拓展 webpack 的配置，但如果开发者对两者的不熟悉，经常会导致开发的配置覆盖了默认配置。

接下来笔者就从调试 vue.config.js 开始，以实例的方式对 vue-cli 的默认配置进行加工。

### 1. 配置 vscode 调试环境

工具栏：运行->添加配置（or 打开配置），选择 node, 初始配置：

```javascript
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": "Launch Program",
      "program": "${workspaceFolder}/xxx.js",
      "request": "launch",
      "skipFiles": [
        "<node_internals>/**"
      ],
      "type": "node"
    }
  ]
}
```

vue-cli 是通过 vue-cli-service 启动项目或打包项目的，所以修改工程的 program，表示运行程序，修改为 vue-cli-service 的地址为： "${workspaceRoot}/node_modules/@vue/cli-service/bin/vue-cli-service.js"

增加参数： "args": ["build"]，该参数参照 package.json 的 scripts，想运行哪个程序就使用对应的命令参数即可：

```json
"scripts": {
  "serve": "vue-cli-service serve",
  "build": "vue-cli-service build"
}
```

最终 debugger 参数为：

```javascript
{
  "type": "pwa-node",
  "request": "launch",
  "name": "Launch Program",
  "skipFiles": [
    "<node_internals>/**"
  ],
  "program": "${workspaceRoot}/node_modules/@vue/cli-service/bin/vue-cli-service.js",
  "args": ["build"]
}
```

vue-cli 默认运行 vue.config.js，在该文件对应的位置加上断点，按 F5 即可运行
![image](./image/breakpoint.jpg)

### 2. 实例： 修改默认copeWebapckPlugin配置

[返回](./index.md)
