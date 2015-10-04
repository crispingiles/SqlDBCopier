using System.Data.SqlClient;

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

        /// <summary>
        /// Get a <see cref="SqlConnection"/> which will need to be opened manually
        /// </summary>
        SqlConnection GetConnection();
    }
}
