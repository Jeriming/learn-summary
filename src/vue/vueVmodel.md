[返回](./index.md)

v-model的原理：v-model会把它关联的响应式数据（如info.message），动态地绑定到表单元素的value属性上，然后监听表单元素的input事件：当v-model绑定的响应数据发生变化时，表单元素的value值也会同步变化；当表单元素接受用户的输入时，input事件会触发，input的回调逻辑会把表单元素value最新值同步赋值给v-model绑定的响应式数据。

源码解析：

1. 编译过程

render函数的流程大概是：
$mount()->compileToFunctions()->compile()->baseCompile()
真正的编译过程都是在这个baseCompile()里面执行，执行步骤可以分为三个过程：\
- 解析模版字符串生成AST
- 优化语法树
- 生成代码



[返回](./index.md)