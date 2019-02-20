using System.Configuration;
using System.Linq;
using NLog;

namespace FileData.Repositories.Helpers
{
    static class FileCheckerHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        internal static bool IsInstructedToCheckVersionOrSize(string functionalityToPerform, bool checkIfSize = false)
        {
            string checkKeys = checkIfSize ? ConfigurationManager.AppSettings["sizeCheckKeys"] : ConfigurationManager.AppSettings["versionCheckKeys"];
            var keys = checkKeys.Split('~');

            var isExists = keys.Contains(functionalityToPerform.Trim());

            return isExists;
        }

        internal static bool ValidateArguments(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Logger.Warn("No Arguments found! please contact Application Administrator!");
                return false;
            }

            if (args.Length == 1)
            {
                Logger.Warn(
                    "Insufficient Arguments, either intruction or file path is missing. Please contact System Administrator!");
                return false;
            }

            if (args.Length > 2)
            {
                Logger.Warn("More arguments than expected! But first two will be processed.");
                return true;
            }

            return true;
        }
    }
}
