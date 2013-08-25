using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert.Data.MailMergeData
{
    /// <summary>
    /// Represents data gathered and to be used in Mail Merge operations.
    /// </summary>
    public interface IMailMergeData
    {
        /// <summary>
        /// Gets or sets the table of data.
        /// </summary>
        DataTable Data { get; set; }

        /// <summary>
        /// Gets a collection of the field names available.
        /// </summary>
        IEnumerable<String> FieldNames { get; }
    }
}
