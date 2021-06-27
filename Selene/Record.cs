//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    public class Record
    {
        /// <summary>
        /// Gets or sets action name.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets response text value.
        /// </summary>
        public string Response { get; set; }

        public override string ToString()
        {
            return $"{Action} -> {Response}";

        }
    }
}
