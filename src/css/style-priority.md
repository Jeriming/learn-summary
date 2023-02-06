[返回](./css.md)

优先级关系：内联样式 > ID 选择器 > 类选择器 = 属性选择器 = 伪类选择器 > 标签选择器 = 伪元素选择器

1. ID 选择器， 如 #id{}
2. 类选择器， 如 .class{}
3. 属性选择器， 如 a[href="segmentfault.com"]{}
4. 伪类选择器， 如 :hover{}
5. 伪元素选择器， 如 ::before{}
6. 标签选择器， 如 span{}
7. 通配选择器， 如 \*{}

所有 CSS 的选择符由上述 7 种基础的选择器或者组合而成，组合的方式有 3 种：\
后代选择符： .father .child{}\
子选择符： .father > .child{}\
相邻选择符: .bro1 + .bro2{}

```html
<style>
  .a + span {
    color: red;
  }
  .bb span {
    color: green;
  }
  .bb > span {
    color: blue;
  }
</style>
<div class="bb">
  <span id="a" class="a">1111111111111111111111</span>
  <span>1111111111111111111111</span>
  <!-- 这三者优先级一样，谁在下面优先级高 -->
</div>
```

如果优先级都一样，则越在下面的优先级高

```html
<style>
  span {
    color: red;
  }
  span {
    color: blue;
  }
</style>
<span>aa</span>
<!-- aa是蓝色 -->
```

!important是个挂，我们不讨论

网上有很多使用选择器加权值的算法，我一直不喜欢，比如id选择器是100，类选择器10，那是不是说同一个标签使用11个类选择器（110）权重就大于一个id选择器（100）的权值呢？显然不是。。。

关于内部样式和外部样式的补充：

首先，什么是内部样式？其实这是针对CSS的引入方式来说的，引入CSS的三种方式分别为：外部样式、内部样式和行内样式。

- 外部样式\
就是通过link或者在style内@import的方式，例如：
```html
<link rel="stylesheet" href="test.css" >

<style>
  @import url("test.css");
</style>
```
这两种样式的区别：

- 内部样式：\
就是写在style标签内的样式，例如：
```html
<style>
  .test {
    color: green;
  }
</style>
```

行内样式不解释了，这三种中优先级最高的。

根据测试，这三种类型有限：行内样式大于>外部样式=内部样式

如果两个文件中有同名的样式，那谁的优先级高？是在最下面的文件优先级高（ps:并不是有的人说所说的，最靠近节点的优先级高，还有放在节点后面的样式呢）

[返回](./css.md)
