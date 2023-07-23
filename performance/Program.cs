
using Muslim.Assembly.Helper;
using System.Diagnostics;

Stopwatch stopwatch1 = new Stopwatch();

Stopwatch stopwatch2 = new Stopwatch();

Stopwatch stopwatch3 = new Stopwatch();

Stopwatch stopwatch4 = new Stopwatch();



stopwatch1.Start();

var x = AssemblyHelper.GetTypesByName("ErrorMessage");
//foreach (var a in x)
//{
//    Console.WriteLine(a);
//}
stopwatch1.Stop();

Console.WriteLine($"GetAssemblyName Time 1 :" + stopwatch1.Elapsed);

stopwatch2.Start();

AssemblyHelper.GetTypesByName("ErrorMessage");
//foreach (var a in x)
//{
//    Console.WriteLine(a);
//}
stopwatch2.Stop();

Console.WriteLine($"GetAssemblyName Time 1 :" + stopwatch2.Elapsed);







//stopwatch2.Start();

//AssemblyHelper.GetAllAssemblies();

//stopwatch2.Stop();

//Console.WriteLine("GetAssemblyName Time 2 : " + stopwatch2.Elapsed);


//stopwatch3.Start();

//AssemblyHelper.GetAssemblyName(typeof(Class1));

//stopwatch3.Stop();

//Console.WriteLine("GetAssemblyName Time 3 : " + stopwatch3.Elapsed);



//stopwatch4.Start();

//AssemblyHelper.GetAssemblyName(typeof(Class1));

//stopwatch4.Stop();

//Console.WriteLine("GetAssemblyName Time 4 : " + stopwatch4.Elapsed);




var xsrgsgwregwergwrgwrg = 3;
