[返回](../../README.md)

## 1. 为什么使用 void 0 代替 undefined

一是因为 ECMAScript 5 之前，undefined 不是 Javascript 的保留字，可读写（ECMAScript 5 后只读），使用 void 0 不可被更改；二是 void 0 字符长度比 undefined 更短。

---

## 2.JS 数据类型有哪些

简单数据类型：\
 Number 、String、Boolean、Null、Undefined、BigInt、Symbol，其中 BigInt、Symbol 是 ES6 新增的两种数据类型\
 **`BigInt`**  可以表示任意大的整数。

```javascript
// BigInt和字符串互相转换
const str = "483948938490739487392843829483840838493";
const bigInt = new BigInt(str);
const tranStr = bigInt.toString();

// BigInt可互相加减
const destination = 200034343n - 2022n;
```

**`Symbol`** 可以理解为独一无二的值，阮大神对它的解释是：“ES5 的对象属性名都是字符串，这容易造成属性名的冲突。比如，你使用了一个他人提供的对象，但又想为这个对象添加新的方法（mixin 模式），新方法的名字就有可能与现有方法产生冲突。如果有一种机制，保证每个属性的名字都是独一无二的就好了，这样就从根本上防止属性名的冲突”

```javascript
// 此时的s1是不等于s2的
const s1 = Symbol("hello");
const s2 = Symbol("hello");
```

注意：Symbol 是不能用 new 来初始化的，因为 new 出来都是对象，而不是 Symbol 类型了

引用数据类型也叫复杂数据类型：\
 Object，其中普通对象，数组，正则，日期，Math 数学函数都属于 Object

数据分成两大类的本质区别：基本数据类型和引用数据类型它们在内存中的存储方式不同。\
基本数据类型是直接存储在栈中的简单数据段，占据空间小，属于被频繁使用的数据。\
引用数据类型是存储在堆内存中，占据空间大。引用数据类型在栈中存储了指针，该指针指向堆中该实体的起始地址，当解释器寻找引用值时，会检索其在栈中的地址，取得地址后从堆中获得实体。

---

## 3. 闭包

**`闭包`** ：就是一个函数 A，return 其内部的函数 B，B 函数能够在外部访问 A 函数内部的变量，这时候就形成了一个 B 函数的变量背包量。\
闭包形成的原理：**`作用域链`**，当前作用域可以访问上级作用域中的变量 \
闭包解决的问题：能够让函数作用域中的变量在函数执行结束之后不被销毁，同时也能在函数外部可以访问函数内部的局部变量。不同闭包中的变量隔离。\
闭包带来的问题：由于垃圾回收器不会将闭包中变量销毁，于是就造成了内存泄露，内存泄露积累多了就容易导致内存溢出。\
闭包的应用：能够模仿块级作用域，能够实现 **`柯里化`**，在构造函数中定义特权方法、Vue 中数据响应式 Observer 中使用闭包等。

---

## 4. 柯里化

柯里化，简单来说就是，把一个多参数的函数转化为单参数函数的方法。上代码：

```javascript
// 普通函数
function add(a, b) {
  return a + b;
}
add(1, 2);

// 柯里化后
function add(a) {
  return function (b) {
    return a + b;
  };
}

add(1)(2);
```

---

## 5. 作用域链

首先什么是 **`作用域`**：\
简单来说是变量的可用范围，可以使不同范围内的变量不互相干扰。\
JS 分为 **`全局作用域`** 、 **`函数作用域`**

1、函数在执行的过程中，先从自己内部寻找变量
2、如果找不到，再从创建当前函数所在的作用域去找，从此往上，也就是向上一级找\
上代码：

```javascript
var a = 100;
function process() {
  var a = 200;
  // 此时的a 很明显是200
  console.log(a);
}

// 但如果函数内没定义a呢
var a = 100;
function process() {
  // 此时a很明显是 100
  console.log(a);
}
```

---

## 6. 变量提升

JS 中使用 var 创建变量时会存在变量提升，也就是把使用 var 创建的变量提升到当前作用域的顶部。

```javascript
var a;
var b的是undefined;
console.log(a); //undefined
console.log(b); //undefined
a = 1;
b = 2;
console.log(a); // 1
console.log(b); // 2

// 注意：var变量提升只是声明提升，而赋值并没有提升，比如：
console.log(a); //undefined
console.log(b); //undefined
var a = 1;
var b = 2;
console.log(a); // 1
console.log(b); // 2
```

**`函数提升`** 函数声明，使用函数声明的函数会存在函数提升，即将声明的函数提升到当前作用域顶部
例如：

```javascript
a();
function a() {
  console.log("函数a");
}

// 相当于：
function a() {
  console.log("函数a");
}
a();
```

注意：函数提升高于变量提升，当存在同名时，在变量赋值之前函数声明还是函数声明，不会被覆盖，当变量赋值之后，函数声明将被变量覆盖。例如：

```javascript
console.log(a); // 打印的是函数
var a = 1;

console.log(a); // 1
function a() {
  console.log("函数a");
}

console.log(a); // 1
// 这里正是因为函数的提升优先级高于变量，所以后面变量a就把函数给覆盖了
```

[返回](../../README.md)
