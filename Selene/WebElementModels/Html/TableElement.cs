//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene.WebElementModels.Html
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using Selene.Helpers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class TableElement : WebElementModel
    {
        public ReadOnlyCollection<TRow> Rows => GetTRows();

        public TableElement(IWebDriver driver, IWebElement wrappedElement)
            : base(driver, wrappedElement)
        {           
        }

        private ReadOnlyCollection<TRow> GetTRows()
        {
            var rows = new List<TRow>();

            foreach (var row in WrappedElement.FindElements(By.CssSelector("tbody tr")))
            {
                rows.Add(new TRow(row));
            }

            return rows.AsReadOnly();
        }

        public class TRow : IWrapsElement
        {
            public IWebElement WrappedElement { get; }

            public ReadOnlyCollection<TCol> Cols => GetTCols();

            public TRow(IWebElement row)
            {
                WrappedElement = row;
            }

            private ReadOnlyCollection<TCol> GetTCols()
            {
                var cols = new List<TCol>();

                foreach (var col in WrappedElement.FindElements(By.CssSelector("td")))
                {
                    cols.Add(new TCol(col));
                }

                return cols.AsReadOnly();
            }

            public TCol GetColByAttr(string attr, string value) =>
                Cols.Where(c => Get.Attr(c, attr) == value).FirstOrDefault();
        }

        public class TCol : IWrapsElement
        {
            public IWebElement WrappedElement { get; }

            public TCol(IWebElement col)
            {
                WrappedElement = col;
            }


        }
    }
}
