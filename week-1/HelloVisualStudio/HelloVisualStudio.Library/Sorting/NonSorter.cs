using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.Library.Sorting {
    public class NonSorter : ISorter {
        public List<Product> SortProducts(List<Product> catalog) {
            return catalog;
        }
    }
}
