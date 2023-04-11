using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
namespace homework17
{
   public class FileSearchEventArgs: CancelEventArgs
   {
      private string _name { get; init; }
      public FileSearchEventArgs(string name) {_name = name; }
   }

   public class FileSearch
   {      
      public event EventHandler<FileSearchEventArgs> FileFound;

      public void Search(string path, ref LinkedList<String> SearchResult)
      {
         foreach (var file in Directory.EnumerateFiles(path))
         {
            SearchResult?.AddLast(file);
            if (FileFound is not null)
            {
               var arg = new FileSearchEventArgs(file);
               FileFound(this, arg);
               if (arg.Cancel) 
               {
                  Console.WriteLine("Cancel event");
                  return;
               }
            }            
         }
      }
   }

}
