[返回](./index.md)

要使其他的 HTML 元素可拖拽，必须要满足以下三点

1. 将想要拖拽的元素的 draggable 属性设置为 true， 默认设置 draggable 值为 true
2. 为要拖拽的元素添加 dragstart 事件
3. 在添加的事件中设置要拖拽的数据

拖放事件参数如下：

| 事件 | 绑定事件 | 描述                       | 事件绑定元素 |
| ---- | -------- | -------------------------- | ------------ |
| drag | ondrag   | 元素被拖拽过程中触发的事件 | 拖拽元素     |
| dragend | ondragend   | 拖动操作结束 | 拖拽元素     |
| dragenter | ondragenter   | 进入有效的放置目标时候触发的事件 | 放置目标位置元素     |
| dragleave | ondragleave   | 离开有效的放置目标触发的事件 | 放置目标位置元素     |
| dragover | ondragover   | 在放置目标内移动触发的事件 | 放置目标位置元素     |
| dragstart | ondragstart   | 在拖拽元素上开始触发拖拽的事件 | 拖拽元素     |
| drop | ondrop   | 在有效的放置目标放置触发的事件 | 放置目标位置     |

一些功能示例+注解：
```javascript
/* HTML 代码如下
 <div class="dropzone">
   <div id="draggable" draggable="true">
     该节点可拖拉
   </div>
 </div>
 <div class="dropzone"></div>
 <div class="dropzone"></div>
 <div class="dropzone"></div>
*/

// 被拖拉节点
var dragged;

document.addEventListener('dragstart', function (event) {
  // 保存被拖拉节点
  dragged = event.target;
  // 被拖拉节点的背景色变透明
  event.target.style.opacity = 0.5;
}, false);

document.addEventListener('dragend', function (event) {
  // 被拖拉节点的背景色恢复正常
  event.target.style.opacity = '';
}, false);

document.addEventListener('dragover', function (event) {
  // 防止拖拉效果被重置，允许被拖拉的节点放入目标节点
  event.preventDefault();
}, false);

document.addEventListener('dragenter', function (event) {
  // 目标节点的背景色变紫色
  // 由于该事件会冒泡，所以要过滤节点
  if (event.target.className === 'dropzone') {
    event.target.style.background = 'purple';
  }
}, false);

document.addEventListener('dragleave', function( event ) {
  // 目标节点的背景色恢复原样
  if (event.target.className === 'dropzone') {
    event.target.style.background = '';
  }
}, false);

document.addEventListener('drop', function( event ) {
  // 防止事件默认行为（比如某些元素节点上可以打开链接），
  event.preventDefault();
  if (event.target.className === 'dropzone') {
    // 恢复目标节点背景色
    event.target.style.background = '';
    // 将被拖拉节点插入目标节点
    dragged.parentNode.removeChild(dragged);
    event.target.appendChild( dragged );
  }
}, false);
```

示例代码：
[demo](./code/draggable-test.html)

[返回](./index.md)
