[返回](../../README.md)

## Unity 从入门到放弃

注：本文记录关键节点，详细内容，去官网找吧！！！

### 1. 环境

中文官网：https://developer.unity.cn/ \
英文官网：https://unity.com/\
Assets: https://assetstore.unity.com/?locale=zh-CN 加上 locale=zh-CN 可以登录，否则一直报 IP 问题 \
中文文档：https://docs.unity.cn/cn/2020.2/Manual/ManualVersions.html \
英文文档：https://docs.unity3d.com/Manual/index.html \
英文教程：https://learn.unity.com/projects 包含大量免费教程，学习必备 \
中文教程：https://learn.u3d.cn/ 教程很少，一半收费

中文网站打开速度快，但是资源相对匮乏，英文打开超慢，但资料丰富，大家可以各取所需！

### 2. 第一课 Unity Playground

链接： https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-playground-109917

1. 新建一个空项目（该示例是 2D，建一个 2D 的接口），等初始化完成

2. 打开上面链接，将资源加入"我的资源”中，加入完成后点击“在 unity 中打开"

3. unity 编辑器中，"Window"-> "Package Manager"就能看到刚刚的资源了，先 Download 再 Import

4. 如果编译有报错： "eterministic compilation failed. You can disable Deterministic builds in Player Settings
   Library\PackageCache\com.unity.multiplayer-hlapi@1.0.4\Editor\Tools\Weaver\AssemblyInfo.cs(22,28): error CS8357: The specified version string contains wildcards, which are not compatible with determinism. Either remove wildcards from the version string, or disable determinism for this compilation"，需要更新下 "Multiplayer HLAPI"从包管理器可以看到是 1.0.4 更新到 1.1.1，如果没有更新的箭头，先 remove，再使用添加，选择 "Add package from git URl...",输入链接： "https://github.com/needle-mirror/com.unity.multiplayer-hlapi.git",这是这个组件在githua的仓库地址

5. 可以愉快的运行看代码了

[返回](../../README.md)
