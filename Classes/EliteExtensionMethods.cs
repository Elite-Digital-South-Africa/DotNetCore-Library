using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace EliteOpenLibrary.Classes
{
    public static class EliteExtensions
    {
        public static IHostBuilder ConfigureJsonAppConfiguration(this IHostBuilder builder,string fileName) => builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!appPath.EndsWith(Path.DirectorySeparatorChar)) appPath += Path.DirectorySeparatorChar;
            config.AddJsonFile(appPath + fileName, optional: false, reloadOnChange: true);
        });

        public static string FindArgumentValue(this string[] args,string argName,bool caseSensitive=false)
        {
            var result="";
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    var splitArg = args[i].Split("=");
                    if (splitArg.Length != 2) throw new ArgumentNullException(splitArg[0], "Argument " + splitArg[0] + " has an incorrect value.");
                    if(splitArg[0].Equals(argName,caseSensitive? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase))
                    {
                        result = splitArg[1];
                        break;
                    }
                }
            }
            return result;
        }

        public static string Sha256(this string inputStr)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(inputStr));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

    }
}