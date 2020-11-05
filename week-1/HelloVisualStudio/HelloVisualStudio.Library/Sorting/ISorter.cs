using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.Library.Sorting {
    public interface ISorter {
        List<Product> SortProducts(List<Product> catalog);
    }
}
