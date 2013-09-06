using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert.Data.MailMergeData
{
    public class MailMergeData : IMailMergeData
    {
        public System.Data.DataTable Data { get; set; }

        public IEnumerable<string> FieldNames
        {
            get
            {
                if (Data != null)
                    foreach (DataColumn column in Data.Columns)
                        yield return column.ColumnName;
            }
        }

        public MailMergeData()
        {

        }

        public MailMergeData(System.Data.DataTable data)
        {
            Data = data;
        }
    }
}
