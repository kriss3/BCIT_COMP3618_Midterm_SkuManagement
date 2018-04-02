using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrpSkuViewer.View.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// BCIT COMP3618 
        /// Krzysztof Szczurowski Midterm Project
        /// Repo: https://github.com/kriss3/BCIT_COMP3618_Midterm_SkuManagement.git
        /// Description: Extension method to be able to cast IEnumerable colleciton of <T> objects to collection of Obeservables;
        /// </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> objCollection)
        {
            var myCollecton = new ObservableCollection<T>();
            foreach (var c in objCollection)
                myCollecton.Add(c);
            return myCollecton;
        }
    }
}
