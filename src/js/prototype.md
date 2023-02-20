[返回](./js.md)

### 1. 原型链继承

原理：原型链继承：让一个构造函数的原型是另一个类型的实例，那么这个构造函数 new 出来的实例就具有该实例的属性，原型链继承的。\
优点：写法方便简洁，容易理解。\
缺点：在父类构造函数中定义的引用类型值的实例属性，会在子类原型上变成原型属性被所有子类实例所共享。同时在创建子类的实例时，不能向超类的构造函数中传递参数。

代码：

```javascript
function A(name) {
  this.name = name;
  this.scopes = [1, 2];
}

function B(name) {
  this.name = name;
}

B.prototype = new A();

const b = new B("hell");
b instanceof B; // true
b instanceof A; // true
b.scopes.push(3);
// 但是b 修改了scopes会导致其他类实例的scopes也会发生变化
const b2 = new B("hi");
b2.scopes; // [1,2,3]
```

### 2. 构造函数继承

原理：在子类型构造函数的内部调用父类型构造函数；使用 apply() 或 call() 方法将父对象的构造函数绑定在子对象上。\
优点：解决了原型链实现继承的不能传参的问题和父类的原型共享的问题。\
缺点：借用构造函数的缺点是方法都在构造函数中定义，因此无法实现函数复用。在父类的原型中定义的方法，对子类而言也是不可见的，结果所有类都只能使用构造函数模式。

代码：

```javascript
function A(name) {
  this.name = name;
  this.scopes = [1, 2];
}

function B(name) {
  A.call(this, name);
}

const b1 = new B("hell");
b1 instanceof B; // true;
b1 instanceof A; // false;
b1.scopes.push(3);

const b2 = new B("hi");
b1.scopes; // [1, 2]
```

### 3. 组合式继承

原理： 将原型链和借用构造函数的组合到一块。使用原型链实现对原型属性和方法的继承，而通过借用构造函数来实现对实例属性的继承。这样，既通过在原型上定义方法实现了函数复用，又能够保证每个实例都有自己的属性。\
优点就是解决了原型链继承和借用构造函数继承造成的影响。\
缺点是无论在什么情况下，都会调用两次超类构造函数：一次是在创建子类原型的时候，另一次是在子类构造函数内部。

代码：

```javascript
function A(name) {
  this.name = name;
  this.scopes = [1, 2];
}

function B(name) {
  A.call(this, name);
}
B.prototype = new A();
const b1 = new B("hell");
b1 instanceof B; // true;
b1 instanceof A; // true;
b1.scopes.push(3);

const b2 = new B("hi");
b1.scopes; // [1, 2]
```

### 4. 原型式继承

利用一个空对象作为媒介，将某个空对象直接赋值给构造函数的原型\
缺点：无法传递参数，原型链继承多个实例的引用类型属性指向相同，可能被篡改。
```javascript
function myObject(obj){
  function F(){}
  // 构造函数F的原型直接
  F.prototype = obj;
  return new F();
}

var obj = {
  name: '1',
  scopes: ['hello', 'world']
}
var o1 = myObject(obj);
obj.name = '2';
obj.scopes.push('hey');

var o2 = myObject(obj);
// 此时o2.name也是2了
```

### 5. 寄生式继承

在原型式继承的基础上，增强对象，返回构造函数，上代码：
```javascript
function myObject(obj){
  function F(){}
  // 构造函数F的原型直接
  F.prototype = obj;
  return new F();
}
function createObj(original){
  var clone = myObject(original); // 通过调用 myObject() 函数创建一个新对象
  clone.sayHi = function(){  // 以某种方式来增强对象
    console.log("hi");
  };
  return clone; // 返回这个对象
}

var p = {
  name: '1',
  scopes: ['hello', 'world']
};
var o1 = createObj(p);
var o2 = createObj(p);

o1.name = '2';
o1.scopes.push('3')
// o2.name还是‘1’，但是o2.scopes还是发生改变了
```
由上可知原型式的问题还是没解决？ps: 为了引出寄生组合式继承，这八股文也是煞费苦心啊
### 6. 寄生式组合继承

原理：通过借用构造函数来继承属性，通过原型链的混成形式来继承方法。本质上，就是使用寄生式继承来继承超类型的原型，然后再将结果指定给子类型的原型。\
优点是：高效率只调用一次父构造函数，并且因此避免了在子原型上面创建不必要，多余的属性。与此同时，原型链还能保持不变；\
缺点是：代码复杂

代码：

```javascript
function A(name) {
  this.name = name;
  this.scopes = [1, 2];
}

function B(name) {
  A.call(this, name);
}

function initPrototype(subType, superType) {
  const pro = Object.create(superType.prototype);
  pro.constructor = subType;
  subType.prototype = pro;
}
initPrototype(B, A);
const b1 = new B("hell");

b1.scopes.push(3);

const b2 = new B("hi");
```

### 5. ES6 的 class extends

class 关键字只是原型的语法糖，JavaScript 继承仍然是基于原型实现的。 优点：语法简单易懂,操作更方便。缺点：并不是所有的浏览器都支持

[返回](./js.md)
