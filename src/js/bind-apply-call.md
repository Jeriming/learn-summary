[返回](./js.md)

## bind apply call 之间区别

以下代码一目了然：

```javascript
const obj = {
  a: 1,
  func: function (arg) {
    console.log(this.a, arg);
  },
};
const obj2 = {
  a: 2,
};
obj.func(2);
obj.func.call(obj2, 2);
obj.func.apply(obj2, [2]);
obj.func.bind(obj2)(2);
```

1. bind 在改变 this 指向的时候，返回一个改变执行上下文的函数，不会立即执行函数，而是需要调用该函数的时候再调用即可；
2. bind() 方法创建一个新的函数，在 bind() 被调用时，这个新函数的 this 被指定为 bind() 的第一个参数，而其余参数将作为新函数的参数，供调用时使用；
3. call 和 apply 在改变 this 指向的同时执行了该函数；
4. call 的参数用逗号隔开传入；
5. apply 接受一个参数数组；

基于 bind 不立即执行的特性，可以用来向回调函数内传参：

```javascript
function callback(arg) {
  console.log(arg);
}

function runFunc(cb) {
  setTimeout(() => {
    // 这里异步回调cb
    cb();
  }, 100);
}

function outFunc(opt) {
  return runFunc(callback.bind(this, opt));
}
outFunc(123);
```

bind小技巧，当在class中使用 addEventListener,removeEventListener 对外暴漏绑定事件和销毁事件this指向问题，上代码：
```javascript
class Action {
  constructor() {
    // 如果直接绑定 onClickEvent 则打印的this是window
    this.clickEvent = this.onClickEvent.bind(this);
  }
  onClickEvent() {
    console.log(this);
  }
  addEvent() {
    window.addEventListener('click', this.clickEvent)
  }
  removeEvent() {
    window.removeEventListener('click', this.clickEvent)
  }
}
```


[返回](./js.md)
