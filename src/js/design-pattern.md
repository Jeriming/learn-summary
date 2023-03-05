[返回](./js.md)

设计模式（Design pattern），是一套杯反复使用、多数人知晓的、经过分类编目的、代码设计经验的总结，不是具体的代码。

设计模式的五大原则

- 单一职责 一个程序只做一件事，如果功能过于复杂就拆分开，每个部分保持独立
- 开发封闭 对扩展开放，对修改封闭 增加需求时，扩展新代码，而非修改旧代码
- 李氏置换 子类能覆盖父类（继承）
- 接口独立 类似于单一职责，关注于接口 保存接口的单一独立
- 依赖倒置 只关注接口而不关注具体类的实现

### 工厂模式

工厂模式主要是为创建实例提供了接口，将 new 操作进行单独封装

实例，比如 Vue3.0 的 createApp，不是通过直接 new Vue 了。

### 单例模式

```javascript
class SingleObject {
  constructor() {
    this.isLogin = false;
  }
  login() {
    this.isLogin = true;
  }
}

SingleObject.getInstance = (function () {
  let instance;
  // 利用闭包把外部函数的变量保存在内存中
  return function () {
    // 如果不存在实例，新建一个实例
    if (!instance) {
      instance = new SingleObject();
    }
    // 如果存在，则直接返回
    return instance;
  };
})();

const a = SingleObject.getInstance();
const b = SingleObject.getInstance();
// a进行登录操作
a.login();
// 单例模式，无论创建多少个实例，都是一模一样的
console.log(a === b); // true
// 由于a已登录，b和a一样，b也已登录
console.log(b.isLogin); // true
```

### 适配器模式

本来的不适合使用的方法，转成适合的

举个例子：

笔记本电脑通常没有过多插槽，这时需要使用一个转接口进行插槽的扩展

```javascript
class Iphone {
  getName() {
    return "我是iphone插头";
  }
}

class Target {
  constructor() {
    this.t = new Iphone();
  }
  getName() {
    return `${this.t.getName()},已转接成andorid插头`;
  }
}

const target = new Target();
console.log(target.getName()); // 我是iphone插头,已转接成andorid插头
```

### 装饰器模式

装饰器模式与适配器模式不同的是，适配器是同名接口不能用，装饰器是需要拓展新接口

为对象添加新功能、不改变原有的结构和功能、将现有对象和装饰器进行分离，两者独立存在

```javascript
class Circle {
  draw() {
    console.log("画圆");
  }
}

class Decorator {
  // 传入circle实例
  constructor(circle) {
    this.circle = circle;
  }
  setBorder() {
    console.log("设置边框");
  }
  draw() {
    this.circle.draw();
    // 画圆之后设置边框
    this.setBorder();
  }
}

let c = new Circle();
let decorator = new Decorator(c);
decorator.draw();
```

比如上面代码，需要拓展画圆后设置边框，在不改变旧代码的情况下，新增新功能！

### 代理模式

使用者无权访问目标对象

中间加代理，通过代理做授权控制

### 观察者模式

发布订阅 一对多的关系

[返回](./js.md)
