
using Muslim.Assembly.Helper;
using System.Diagnostics;

Stopwatch stopwatch1 = new Stopwatch();

Stopwatch stopwatch2 = new Stopwatch();




stopwatch1.Start();

AssemblyHelper.GetAllAssembly();

stopwatch1.Stop();

Console.WriteLine("Elapsed Time 1 : " + stopwatch1.Elapsed);




stopwatch2.Start();

AssemblyHelper.GetAllAssembly();

stopwatch2.Stop();

Console.WriteLine("Elapsed Time 2 : " + stopwatch2.Elapsed);




var x = 3;
