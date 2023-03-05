[返回](./index.md)

大致流程：
webpack启动后，从entry开始，递归解析entry依赖的所有module，找到每一个module.rules里面配置的loader进行相应的转换处理，对module转换后，解析出当前module依赖的其他的模块，解析的结果是一个一个的chunk，最后webpack会将所有的chunk转换成文件输出的output\
在整个构建的过程中，webpack会在特定的时期执行plugin。\
entry:模块入口，使得源文件假如到构建流程中\
output:配置如何输出文件\
module:配置各类型的模块的处理规则\
plugin:配置拓展插件\
devServer:实现本地服务，包括http 模块热更新 source map等

loader和plugin的区别

- loader是webpack的编译方法，webpack自身只能处理js，对于别的资源需要loader来处理

- webpack只能打包，相关的编译工作需要loader

- loader本质是一个方法，使用时需要安装非内置的loader

综上，loader使得webpack可以处理各种类型的文件


plugin

- plugin提供一些webpack额外的拓展，帮助webpack优化代码，提供功能

[返回](./index.md)