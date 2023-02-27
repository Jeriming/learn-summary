[返回](./index.md)

v-model的原理：v-model会把它关联的响应式数据（如info.message），动态地绑定到表单元素的value属性上，然后监听表单元素的input事件：当v-model绑定的响应数据发生变化时，表单元素的value值也会同步变化；当表单元素接受用户的输入时，input事件会触发，input的回调逻辑会把表单元素value最新值同步赋值给v-model绑定的响应式数据。

源码解析：

1. 编译过程

render函数的流程大概是：
$mount()->compileToFunctions()->compile()->baseCompile()
真正的编译过程都是在这个 baseCompile()里面执行，执行步骤可以分为三个过程：

- 解析模版字符串生成 AST: const ast = parse(template.trim(), options)
- 优化语法树: optimize(ast, options)
- 生成代码: const code = generate(ast, options)

generate() 首先通过 genElement()->genData$2()->genDirectives() 生成 code，再把 code 用 with(this){return ${code}}} 包裹起来,最终的到 render 函数.

v-model 跟其他指令一样，会被解析到 el.directives 中，之后会通过 genDirectives 方法处理这些指令

2. model
   先看代码：

```javascript
function model(el, dir, _warn) {
  warn$1 = _warn;
  var value = dir.value;
  var modifiers = dir.modifiers;
  var tag = el.tag;
  var type = el.attrsMap.type;

  {
    // inputs with type="file" are read only and setting the input's
    // value will throw an error.
    if (tag === "input" && type === "file") {
      warn$1(
        "<" +
          el.tag +
          ' v-model="' +
          value +
          '" type="file">:\n' +
          "File inputs are read only. Use a v-on:change listener instead.",
        el.rawAttrsMap["v-model"]
      );
    }
  }

  if (el.component) {
    genComponentModel(el, value, modifiers);
    // component v-model doesn't need extra runtime
    return false;
  } else if (tag === "select") {
    genSelect(el, value, modifiers);
  } else if (tag === "input" && type === "checkbox") {
    genCheckboxModel(el, value, modifiers);
  } else if (tag === "input" && type === "radio") {
    genRadioModel(el, value, modifiers);
  } else if (tag === "input" || tag === "textarea") {
    genDefaultModel(el, value, modifiers);
  } else if (!config.isReservedTag(tag)) {
    genComponentModel(el, value, modifiers);
    // component v-model doesn't need extra runtime
    return false;
  } else {
    warn$1(
      "<" +
        el.tag +
        ' v-model="' +
        value +
        '">: ' +
        "v-model is not supported on this element type. " +
        "If you are working with contenteditable, it's recommended to " +
        "wrap a library dedicated for that purpose inside a custom component.",
      el.rawAttrsMap["v-model"]
    );
  }

  // ensure runtime directive metadata
  return true;
}
```



[返回](./index.md)