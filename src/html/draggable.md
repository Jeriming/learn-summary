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

示例代码：
[demo](./code/draggable-test.html)

[返回](./index.md)
