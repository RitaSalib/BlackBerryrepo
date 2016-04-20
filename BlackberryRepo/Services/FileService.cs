using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace BlackberryRepo.Services
{
    
        public class FileService : IFileService
        {


            async public Task<object> GetFile(string path)
            {
                StorageFile file = await KnownFolders.DocumentsLibrary.GetFileAsync(path);
                return file;
            }

            async public Task<string> ReadFileString(object file)
            {
                StorageFile storageFile = file as StorageFile;
                string fileContent = await FileIO.ReadTextAsync(storageFile);
                return fileContent;
            }


            async public Task<string> GetDocumentsFilePath(string fileName)
            {
                try
                {
                    StorageFile file = await KnownFolders.DocumentsLibrary.GetFileAsync(fileName);
                    return file.Path;
                }
                catch (Exception e)
                {
                }

                return null;
            }


            async public Task<object> GetDocumentsBitmap(string filePath)
            {
                StorageFile imgFile = (StorageFile)await GetFile(filePath);
                IRandomAccessStream stream = await imgFile.OpenAsync(FileAccessMode.Read);
                BitmapImage img = new BitmapImage();
                await img.SetSourceAsync(stream);
                return img;
            }


            async public Task<ObservableCollection<object>> GetFilesInDirectory(string directoryPath)
            {
                StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync(directoryPath);
                IReadOnlyList<StorageFile> filesList = await folder.GetFilesAsync();
                ObservableCollection<object> files = new ObservableCollection<object>();
                foreach (StorageFile file in filesList)
                {
                    files.Add(file);
                }
                return files;
            }


            async public Task CreateFile(string directorypath, string fileName, string fileContent)
            {
                StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync(directorypath);
                StorageFile file = await folder.CreateFileAsync(fileName);
                await Windows.Storage.FileIO.WriteTextAsync(file, fileContent);
            }


            async public Task DeleteFile(string directoryPath, string fileName)
            {
                StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync(directoryPath);
                StorageFile file = await folder.GetFileAsync(fileName);
                await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
        }
    
}
