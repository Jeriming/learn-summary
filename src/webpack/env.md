[返回](./index.md)

现在项目中随处可见：process.env.NODE_ENV === 'production'，那么process.env.ENV 是什么东西？在哪里配置的呢？

首先，process 是 Node.js 中的 一个全局变量，提供来有关当前 Node.js 进程的信息并对其进行控制。而 process 中的 env 则是返回包含用户环境的对象。通俗点说，就是可以通过 process.env 拿到当前项目运行环境的信息。

我们常可以在scripts看到：
"build": "cross-env NODE_ENV=production vue-cli-service build"

而NODE_ENV=production就是向process.env传递NODE_ENV（cross-env后面再解释）

而基于vue-cli构建的项目，在script中可以看到：\
vue-cli-service build --mode development\
相当于设置了一个mode，也可以在你的项目根目录中放置下列文件来指定环境变量：
```sh
.env                # 在所有的环境中被载入
.env.local          # 在所有的环境中被载入，但会被 git 忽略
.env.[mode]         # 只在指定的模式中被载入
.env.[mode].local   # 只在指定的模式中被载入，但会被 git 忽略
```

一个环境文件只包含环境变量的“键=值”对：
```sh
FOO=bar
VUE_APP_NOT_SECRET_CODE=some_value
```

官方链接：[https://cli.vuejs.org/zh/guide/mode-and-env.html#%E7%8E%AF%E5%A2%83%E5%8F%98%E9%87%8F](https://cli.vuejs.org/zh/guide/mode-and-env.html#%E7%8E%AF%E5%A2%83%E5%8F%98%E9%87%8F)

[返回](./index.md)