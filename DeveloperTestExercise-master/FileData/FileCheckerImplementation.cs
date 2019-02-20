using FileData.Interfaces;

namespace FileData
{
    public class FileCheckerImplementation
    {
        private readonly IFileChecker _fileChecker;

        public FileCheckerImplementation(IFileChecker fileDetails)
        {
            _fileChecker = fileDetails;
        }

        public object Check(string[] args)
        {
            return _fileChecker.Run(args);
        }
    }
}
