using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSoft.SqlDBCopier.Core
{
    /// <summary>
    /// Used to return an open <see cref="SqlConnection"/>
    /// </summary>
    public interface ISqlConnectionProvider
    {
        /// <summary>
        /// Get an open <see cref="SqlConnection"/>
        /// </summary>
        SqlConnection GetOpenConnection();
    }
}
