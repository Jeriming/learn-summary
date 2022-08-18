[返回](./index.md)

## 哈希类

### 两数之和

给出一个整型数组 numbers 和一个目标值 target，请在数组中找出两个加起来等于目标值的数的下标，返回的下标按升序排列。
（注：返回的数组下标从 1 开始算起，保证 target 一定可以由数组里面 2 个数字相加得到）

要求：空间复杂度 O(n)，时间复杂度 O(nlogn)

[3,2,4],6

#### 示例 1

```
输入：[3,2,4],6
返回值：[2,3]
说明：因为 2+4=6 ，而 2的下标为2 ， 4的下标为3 ，又因为 下标2 < 下标3 ，所以返回[2,3]
```

#### 示例 2

```
输入：[20,70,110,150],90
返回值：[1,2]
说明：20+70=90
```

分析：
这题一看是哈希题型，必须想到 map，只要两者之和恰好等于目标值的下标，又用到哈希，嘿嘿，哈希存什么最省？存差值，一次循环搞定：

```javascript
function twoSum(numbers, target) {
  const length = numbers.length;
  const oMap = new Map();
  for (let i = 0; i < length; i++) {
    let less = target - numbers[i];
    if (!oMap.has(less)) {
      // 如果插值不在map内，则把当前值存入map
      oMap.set(numbers[i], i + 1);
    } else {
      // 差值存在map内，说明已找到，直接返回
      return [oMap.get(less), i + 1];
    }
  }
  return [];
}
```

[返回](./index.md)