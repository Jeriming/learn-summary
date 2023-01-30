[返回](./index.md)

1. 使用vscode创建一个可调试的dotnet窗口程序

以 WindowSharingHider 工程代码为示例，并迁移到测试项目中

- 首先创建一个空文件夹“my-doenet-test”，vscode打开，vscode安装 OmniSharp 的C#拓展插件

- 命令行执行：dotnet new winforms，这是创建窗口程序的命令，命令大全详见官方文档：[dotnet new](https://learn.microsoft.com/zh-cn/dotnet/core/tools/dotnet-new)

- 创建项目成功，代码如下：


```csharp
namespace my_dotnet_test;

static class Program
{
  /// <summary>
  ///  The main entry point for the application.
  /// </summary>
  [STAThread]
  static void Main()
  {
    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    Application.Run(new MainWindow());
  }
}
```

这个时候将 WindowSharingHider 的代码和文件直接拷贝，并改名即可迁移过来，F5直接可调试

[返回](./index.md)