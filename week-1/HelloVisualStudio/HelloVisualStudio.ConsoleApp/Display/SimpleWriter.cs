using System;
using System.Collections.Generic;
using System.Text;
using HelloVisualStudio.Library.Sorting;
using HelloVisualStudio.Library;

namespace HelloVisualStudio.ConsoleApp.Display
{
    /// <summary>
        /// (General purpose of class)
        /// Responsible for formatting and printing a collection of Products.
    /// </summary>
    /// 
    /// <remarks>
        /// (More detailed info, like implementation decisions)
    /// </remarks>
    /// 
    /// <example>
    /// </example>
    public class SimpleWriter : IWriter {

        private readonly ISorter _sorter;

        public SimpleWriter(ISorter sorter) {
            _sorter = sorter;
        }

        public void FormatAndDisplay(List<Product> catalog) {
            foreach (var product in _sorter.SortProducts(catalog)) {
                Console.WriteLine(product.Id);
            }
        }
    }
}
