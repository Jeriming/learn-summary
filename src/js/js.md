[返回](../../README.md)

## 1. 零碎知识点

记录比较零散但常用的一些知识点，详见：[Other](./other.md)

## 2. 箭头函数及 this 指向

记录比较零散但常用的一些知识点，详见：[箭头函数](./arrow-function.md)

## 3. call apply bind

call、apply、bind 的作用都是改变函数运行时的 this 指向，但用法不一样，详见： [call apply bind](./bind-apply-call.md)

## 4. 事件循环 Event loop，宏任务与微任务

所有的任务可以分为同步任务和异步任务，同步任务，顾名思义，就是立即执行的任务，同步任务一般会直接进入到主线程中执行；而异步任务，就是异步执行的任务，比如 ajax 网络请求，setTimeout 定时函数等都属于异步任务，异步任务会通过事件队列( Event Queue )的机制来进行协调。详见： [宏任务与微任务](./marco.md)

## 5. es5 对象的继承方式

ES5 如何实现继承，分别为：原型链继承、构造函数继承、组合式继承、寄生式组合继承。详见：[ES5 继承方式](./prototype.md)

## 6. 创建 ajax 过程

详见：[创建 ajax 过程](./ajax.md)

## 7. echarts

主要介绍 echarts custom series 的使用方法，详见：[custom echarts](./custom-echarts.md)

## 8. 易错变态题目

详见：[变态题](./bt.md)

## 9. 严格模式

ECMAScript 5的[严格模式](./strict-mode.md)是采用具有限制性 JavaScript 变体的一种方式，从而使代码隐式地脱离“马虎模式/稀松模式/懒散模式“（sloppy）模式。

## 10. JS Array.sort的原理

sort() 方法用原地算法对数组的元素进行排序，并返回数组。默认排序顺序是在将元素转换为字符串，然后比较它们的 UTF-16 代码单元值序列时构建的

由于它取决于具体实现，因此无法保证排序的时间和空间复杂性。详见：[JS Array.sort的原理](./sort.md)

## 10. JS 作用域和作用域链

什么是作用域什么事作用域链？详见：[JS 作用域和作用域链](./js-scope.md)

[返回](../../README.md)
