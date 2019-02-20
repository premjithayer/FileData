using System;
using FileData.Interfaces;
using FileData.Repositories.Helpers;
using NLog;

namespace FileData.Repositories
{
    public class FileChecker : IFileChecker
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ThirdPartyTools.FileDetails _fileDetailsTool;

        public FileChecker()
        {
            _fileDetailsTool = new ThirdPartyTools.FileDetails();
        }
        public object Run(string[] args)
        {
            if (!FileCheckerHelper.ValidateArguments(args))
                throw new ArgumentException("Provided arguments are null or not valid, please contact with System Admin!");

            var functionalityToPerform = args[0];
            var filepath = args[1];

            if (FileCheckerHelper.IsInstructedToCheckVersionOrSize(functionalityToPerform))
            {
                Logger.Trace($"Checking Version for {filepath}");
                return _fileDetailsTool.Version(filepath.Trim());
            }

            if (FileCheckerHelper.IsInstructedToCheckVersionOrSize(functionalityToPerform, checkIfSize: true))
            {
                Logger.Trace($"Checking Size for {filepath}");
                return _fileDetailsTool.Size(filepath.Trim());
            }

            throw new ArgumentException($"Provided arguments are not valid: {functionalityToPerform}");
        }
    }
}
