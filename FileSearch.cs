using System;
using System.IO;
using System.Reflection;
namespace homework17
{
   public class SearchParam : EventArgs
   {
      public string Name { get; }
      public bool Cancel { get; set; }

      public SearchParam(string name) { Name = name; }
   }

   public class FileSearch
   {
      public event EventHandler<SearchParam> param;

      public void Search(string path)
      {
         foreach (var file in Directory.EnumerateFiles(path))
         {            
            SearchParam param = RaiseSearchResult(file);
            if (param.Cancel) return;
         }
      }

      private SearchParam RaiseSearchResult(string name)
      {
         var param = new SearchParam(name);
         param?.Invoke(this, param);
         return param;
      }
   }

}
