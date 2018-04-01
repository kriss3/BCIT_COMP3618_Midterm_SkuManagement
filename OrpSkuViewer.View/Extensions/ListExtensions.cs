using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrpSkuViewer.View.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> objCollection)
        {
            var myCollecton = new ObservableCollection<T>();
            foreach (var c in objCollection)
                myCollecton.Add(c);
            return myCollecton;
        }
    }
}
