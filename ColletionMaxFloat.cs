using System;
using System.Collections.Generic;
using System.Text;

namespace homework17
{
   public static class ColletionMaxFloat
   {
      public static T GetColletionMax<T>(this IEnumerable<T> Enumerable, Func<T, float> getParameter) where T : class
      {
         T maxItem = null;
         float max = float.MinValue; 
         
         foreach (T item in Enumerable)
         {
            var floatItem = getParameter(item);            
            if (floatItem > max)
            {
               max = floatItem;
               maxItem = item;
            }
         }

         return maxItem;
      }
   }
}
