//-----------------------------------------------------------------------
//  <author>Laura Kolčavová</author>
//  <date>2021-06-27</date>
//-----------------------------------------------------------------------

namespace Selene
{
    /// <summary>
    /// Wrapper class for <see cref="Selene.Log"/> entry.
    /// </summary>
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

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        public string Error { get; set; }

        public override string ToString()
        {
            string output = Action;

            if(!string.IsNullOrEmpty(Response))
            {
                output += $" -> {Response}";
            }

            if (!string.IsNullOrEmpty(Error))
            {
                output += $" : {Error}";
            }

            return output;
        }
    }
}
