using System;
using System.Collections;

namespace homework17
{
   public static class CollectionMaximum
   {
      public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : class
      {
         T maxItem = null;
         float maxValue = float.MinValue; 
         
         foreach (T item in e)
         {
            var floatItem = getParameter(item);            
            if (floatItem >= maxValue)
            {
               maxValue = floatItem;
               maxItem = item;
            }
         }

         return maxItem;
      }
   }
}
