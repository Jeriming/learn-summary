[返回](./index.md)

本文以 Vue-router 3.x 为例

首先，看 vue-router 的使用方法：

html template

```html
<router-link to="/test">Test page</router-link>

<!-- 路由出口 -->
<router-view></router-view>
```

main.js

```javascript
Vue.use(Router);
// 定义的路由
const routes = [
  { path: "/", component: Home },
  { path: "/test", component: Test },
];

const router = new VueRouter({
  routes, // (缩写) 相当于 routes: routes
});

const app = new Vue({
  router,
}).$mount("#app");
```

从 main.js 开始来阅读源码，

Vue.use(Router);
就灰调用 install

```javascript
/* 判断是否已安装过 */
if (install.installed && _Vue === Vue) return;
install.installed = true;

// 混入
Vue.mixin({
  beforeCreate() {
    this._router.init(this);
  },
  destroyed() {
    registerInstance(this);
  },
});

// init在VueRouter的类中:
/* 将当前vm实例保存在app中 */
this.apps.push(app);

// 开启监听
if (history instanceof HTML5History) {
  history.transitionTo(history.getCurrentLocation());
} else if (history instanceof HashHistory) {
  const setupHashListener = () => {
    history.setupListeners();
  };
  history.transitionTo(
    history.getCurrentLocation(),
    setupHashListener,
    setupHashListener
  );
}
history.listen((route) => {
  this.apps.forEach((app) => {
    app._route = route;
  });
});
```

初始化就从 VueRouter 的构造函数开始

初始化了 matcher

```javascript
// inBrowser = typeof window !== 'undefined'
constructor() {
  this.matcher = createMatcher(options.routes || [], this)
  if (!inBrowser) {
    mode = 'abstract'
  }
  switch (mode) {
    case 'history':
      // window.addEventListener('popstate', xx);
      this.history = new HTML5History(this, options.base)
      break
    case 'hash':
      this.history = new HashHistory(this, options.base, this.fallback)
      break
    case 'abstract':
      // abstract抽象模式，用于非浏览器的时候
      this.history = new AbstractHistory(this, options.base)
      break
    default:
      if (process.env.NODE_ENV !== 'production') {
        assert(false, `invalid mode: ${mode}`)
      }
  }
}
```

[返回](./index.md)
