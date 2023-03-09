[返回](./index.md)

今天碰到小师妹问我，父组件在使用子组件时，属性只写值的情况下，子组件接收到的是什么？，比如代码：
```javascript
// 子组件
export default {
    name: 'child',
    props: {
        disabled: {
            type: Boolean,
            default: false
        }
    }
}

// 父组件
<child disabled></child>
```

我脱口而出是空字符串，然后跑了一下，竟然是true，what我心里一万只草泥马飞奔而过！！！丢脸丢大了，万般无奈翻阅起vue源码：

为后面少走弯路，直接上初始化函数调用链：
initMixin内部实现了Vue.prototype._init =>\
initState 这里初始化props、methods、data、computed与watch =>\
initProps => \
validateProp : 这里就处理这种情形

```javascript
/*验证prop,不存在用默认值替换，类型为bool则声称true或false，当使用default中的默认值的时候会将默认值的副本进行observe*/
export function validateProp (
  key: string,/*prop的key值*/
  propOptions: Object,/*prop的参数，https://cn.vuejs.org/v2/guide/components.html#Prop-验证 */
  propsData: Object,/*props数据*/
  vm?: Component/*vm实例*/
): any {
  /*获取prop参数*/
  const prop = propOptions[key]
  /*该prop是否存在，也就是父组件是否正常传入，存在absent为false，反之为true*/
  const absent = !hasOwn(propsData, key)
  /*获得prop的value*/
  let value = propsData[key]
  // handle boolean props
  /*处理bool类型的属性*/
  if (isType(Boolean, prop.type)) {
    /*当父组件没有传入prop并且default中也不存在该prop时，赋值为false*/
    if (absent && !hasOwn(prop, 'default')) {
      value = false
    } else if (!isType(String, prop.type) && (value === '' || value === hyphenate(key))) {
      value = true
    }
  }
  // check default value
  /*当属性值不存在（即父组件没有传递下来）*/
  if (value === undefined) {
    /*获取属性的默认值*/
    value = getPropDefaultValue(vm, prop, key)

    // since the default value is a fresh copy,
    // make sure to observe it.
    /*由于默认值是一份新的拷贝副本，确保已经对它进行observe，有观察者观察它的变化。*/

    /*把之前的shouldConvert保存下来，当observe结束以后再设置回来*/
    const prevShouldConvert = observerState.shouldConvert
    observerState.shouldConvert = true
    observe(value)
    observerState.shouldConvert = prevShouldConvert
  }
  if (process.env.NODE_ENV !== 'production') {
    assertProp(prop, key, value, vm, absent)
  }
  return value
}
```

原理一目了然！！！问题解决

[返回](./index.md)