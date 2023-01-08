上代码：

```html
<div class="container">
  <div class="item">1</div>
  <div class="item">2</div>
  <div class="item">3</div>
</div>
```

```css
.container {
  width: 100%;
  height: 390px;
  display: flex;
  overflow-x: scroll;
  /*x轴吸附方向, 
   mandatory: 通常在 CSS 代码中我们都会使用这个，mandatory 的英文意思是强制性的，表示滚动结束后，滚动停止点一定会强制停在我们指定的地方
   proximity: 英文意思是接近、临近、大约，在这个属性中的意思是滚动结束后，滚动停止点可能就是滚动停止的地方，也可能会再进行额外移动，停在我们指定的地方*/
  scroll-snap-type: x mandatory;
  scroll-behavior: smooth;
}

.container::-webkit-scrollbar {
  width: 0;
}

.item {
  flex-shrink: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 3em;
  /*start center end使当前聚焦的滚动子元素在滚动方向上相对于父容器位置对齐。*/
  scroll-snap-align: start;
  scroll-snap-stop: always; /**/
}

.item:nth-child(1) {
  background-color: #62c454;
}
.item:nth-child(2) {
  background-color: #f5bd50;
}
.item:nth-child(3) {
  background-color: #ea695d;
}
```
