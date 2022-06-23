using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TpSofttek.Data 
{ 
    public class Connection
{
    private string ConnectionString = string.Empty;
    public Connection()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        ConnectionString = builder.GetSection("ConnectioString: StringSql").Value;

    }
    public string getConnection()
    {
        return ConnectionString;
    }

}
}
