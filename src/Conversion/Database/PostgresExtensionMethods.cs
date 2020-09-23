using System;
using System.Text;
using System.Text.RegularExpressions;

namespace pillepalle1.Conversion.Database
{
    public static class PostgresExtensionMethods
    {
        public static string ToMicrosoftConnectionString(this string connectionString)
        {
            StringBuilder connectionStringBuilder = new StringBuilder();

            Regex templConString = new Regex(@"^(?<protocol>\w+)://(?<user>\w+):(?<pass>\w+)@(?<host>[\.\w]+):(?<port>\w+)/(?<database>\w+)/*$");
            Match match = templConString.Match(connectionString);

            string protocol = match.Groups["protocol"].Value;
            string user = match.Groups["user"].Value;
            string pass = match.Groups["pass"].Value;
            string host = match.Groups["host"].Value;
            string port = match.Groups["port"].Value;
            string database = match.Groups["database"].Value;

            if (!String.IsNullOrWhiteSpace(user))
            {
                connectionStringBuilder.Append("Username=" + user);
            }

            if (!String.IsNullOrWhiteSpace(pass))
            {
                connectionStringBuilder.Append(";" + "Password=" + pass);
            }

            if (!String.IsNullOrWhiteSpace(host))
            {
                connectionStringBuilder.Append(";" + "Host=" + host);
            }

            if (!String.IsNullOrWhiteSpace(port))
            {
                connectionStringBuilder.Append(";" + "Port=" + port);
            }

            if (!String.IsNullOrWhiteSpace(database))
            {
                connectionStringBuilder.Append(";" + "Database=" + database);
            }

            connectionStringBuilder.Append(";" + "Keepalive=60");

            return connectionStringBuilder.ToString();
        }
    }
}
