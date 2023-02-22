[返回](./index.md)

vue实例在初始化时，调用一个observe方法，observe方法内部实例化了一个Observer类；

判断需要数据绑定的是数组还是对象，如果是数组，则调用observeArray，对数组的每个成员遍历调用observe方法；\
如果对数组数据进行了pop、push这样的操作，是没法对push进去的数据进行双向绑定的，为解决这一问题，Vue.js提供的方法是重写push、pop、shift、unshift、splice、sort、reverse这七个数组方法

如果是对象，则调用walk，会对对象的每个属性进行defineReactive（Object.keys(obj)）

defineReactive：通过Object.definProperty的getter中，使用dep.depend进行依赖收集

然后在setter中进行 dep.notify

Dep的notify调用的是遍历调用subs（Watcher类，相当于订阅者）的 sub.update()

Watcher内的 deps数组，最终调用Watcher的update进行渲染


[返回](./index.md)