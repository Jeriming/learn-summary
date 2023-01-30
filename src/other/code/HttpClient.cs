using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace HttpClient
{
  class Program
  {
    static void Main(string[] args)
    {
      string operation;
      do
      {
        Console.WriteLine("按任意键发送数据到服务端");
        Console.ReadLine();
        var wc = new WebClient();
        var url = "http://127.0.0.1:8080";
        Console.WriteLine("请求服务地址:{0}，时间：{1}", url, DateTime.Now.ToString());
        //模拟一个json数据发送到服务端
        var data = new Data(1, "张三");
        var jsonModel = JsonConvert.SerializeObject(data);
        //发送到服务端并获得返回值
        var returnInfo = wc.UploadData(url, Encoding.UTF8.GetBytes(jsonModel));
        //把服务端返回的信息转成字符串
        var str = Encoding.UTF8.GetString(returnInfo);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("服务端返回信息：{0},时间：{1}", str, DateTime.Now.ToString());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("请问是否继续：继续 【y】,退出【n】");
        operation = Console.ReadLine();
      } while (operation == "y");
    }

    class Data
    {
      public Data(int id, string name)
      {
        this.ID = id;
        this.Name = name;
      }
      public int ID { get; set; }

      public string Name { get; set; }
    }
  }
}