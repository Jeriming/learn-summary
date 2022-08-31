[返回](./js.md)

- 结果输出
```javascript
let flag1 = null || undefined;
let flag2 = null && undefined;
if (flag1 === true) console.log('flag1');
if (flag2 === false) console.log('flag2');
```

这道题考察点： 逻辑与、或的处理，null undefined 和false之间的关系
|| 逻辑或运算符，如果前面为true，则后面的不运算，如果为false就运算后面的，则其值为||运算符的后面的值\
flag1 为 undefined， undefined 不等于 true

&& 逻辑与运算符，如果前面为false,则后面的不运算，如果为true就运算后面的，其值为&&运算符后面的值\
flag2 为 null ，null 也不等于 false，所以这题都不打印

拓展：
null == false; // false\
undefined == false; // false\
NaN == NaN; // false\
null == undefined; // true
0 == false; // true

[返回](./js.md)