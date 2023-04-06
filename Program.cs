using System;

namespace homework17
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");
      }
   }
   using DelegatesAndEvents;
using System.Globalization;

var fileLister = new FileFinder();

   // С отменой после первого найденного файла
   EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
   {
      Console.WriteLine(eventArgs.FoundFile);
      eventArgs.CancelRequested = true;
   };

   fileLister.FileFound += onFileFound;

fileLister.Find("D:\\otus\\DelegatesAndEvents\\DelegatesAndEvents");

// Вывод максимального элемента
Console.WriteLine(MaxGetter.GetMax<string>(new[] { "1", "2", "3" }, (value) => float.Parse(value, CultureInfo.InvariantCulture.NumberFormat)));


}
