[返回](./index.md)

1. 参数限定词

- 参数限定词

在 GLSL ES 中，可以为函数参数指定限定词，以控制参数的行为。我们可以将函数参数定义成：（1）传递给函数的，（2）将要在函数中被赋值的，（3）既是传递给函数的，也是将要在函数中被赋值的。其中（2）和（3）都有点类似于 C 语言中的指针。下表展示了这些参数的限定字。

| 类别       | 规则                                   | 描述                                                                                                             |
| ---------- | -------------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| in         | 向函数中传入值                         | 参数传入函数，函数内可以使用参数的值，也可以修改其值。但函数内部的修改不会影响传入的变量                         |
| const in   | 向函数中传入值                         | 参数传入函数，函数内可以使用参数的值，但不能修改传入的变量的引用，若其在函数内被修改，会影响到函数外部传入的变量 |
| out        | 在函数中被赋值，并被传出               | 传入变量的引用，若其在函数内被修改，会影响到函数外部传入的变量                                                   |
| inout      | 传入函数，同时在函数中被赋值，并被传出 | 传入变量的引用，函数会用到变量的初始值，然后修改变量的值。会影响到函数外部传入的变量                             |
| <无：默认> | 将一个值传给函数                       | 和 in 一样                                                                                                       |

2. 内置函数

除了允许用户自定义函数，GLSL ES 还提供了很多常用的内置函数，下表概括了 GLSL ES 的内置函数：
| 类别 | 内置函数 |
| ---------- | ---------------- |
| 角度函数 | radians（角度制转弧度制），degrees（弧度制转角度制） |
| 三角函数 | sin,cos,tan,asin,acos,atan |
| 指数函数 | pow,exp,log,exp2,log2,sqrt,inversesqrt |
| 通用函数 | abs,min,max,mod,sign,floor,ceil,clamp,mix,step,smoothstep,fract |
| 几何函数 | length,distance,dot,cross,nor-malize,reflect,faceforward |
| 矩阵函数 | matrixCmpMult（逐元素乘法） |
| 矢量函数 | lessThan,lessThanEqual,greaterThan,greaterThanEqual,equal,notEqual,any,all,not |
| 纹理查询函数 | texture2D,textureCube,texture2DProj,texture2DLod,textureCubeLod,texture2DProjLod |

[返回](./index.md)
