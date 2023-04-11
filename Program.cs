using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace homework17
{
   class Program
   {
      static private bool TimeoutEceeded = false;
      static void Main(string[] args)
      {
         System.Timers.Timer timer = new System.Timers.Timer(10);
         timer.Elapsed += OnTimedEvent;
         timer.Start();
        
         Console.WriteLine("Hello World!");

         FileSearch fileSearch = new FileSearch();
         fileSearch.FileFound += OnFileFound;
         var lst = new LinkedList<string>();
         fileSearch.Search(".", ref lst);
         fileSearch.FileFound -= OnFileFound;

         Console.WriteLine($"The longest file name is {lst.GetMax<string>(x => x.Length)}");
      }
      static public void OnFileFound(Object obj, CancelEventArgs arg)
      {
        Console.WriteLine("Rised event");
        if (TimeoutEceeded) arg.Cancel = true;
      }
      static void OnTimedEvent(Object obj, System.Timers.ElapsedEventArgs arg)
      {
        TimeoutEceeded = true;
        var timer = (System.Timers.Timer)obj;
        timer.Elapsed -= OnTimedEvent;
        timer.Stop();
      }
   }
}
