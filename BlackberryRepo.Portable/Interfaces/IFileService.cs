using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface IFileService
    {
        Task<object> GetFile(string path);
        Task<string> ReadFileString(object file);
        Task<string> GetDocumentsFilePath(string fileName);
        Task<object> GetDocumentsBitmap(string filePath);
        Task<ObservableCollection<object>> GetFilesInDirectory(string directoryPath);
        Task CreateFile(string directorypath, string fileName, string fileContent);
        Task DeleteFile(string directoryPath, string fileName);
    }
}
