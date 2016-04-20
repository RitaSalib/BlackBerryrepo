using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace BlackberryRepoPhone1.Services
{
    public  class FileService:IFileService
    {
          async public Task<object> GetFile(string path)
        {
            StreamReader sr = new StreamReader(path);
           
            int x = 3;
            return sr;
        }

         async public Task<string> ReadFileString(Object file)
        {
            
            var sr = file as StreamReader;
           
             string fileContent = await sr.ReadToEndAsync();
            return fileContent;
        }


        async public Task<string> GetDocumentsFilePath(string fileName)
        {
            try
            {
                return fileName;
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
           // await img.SetSourceAsync(stream);
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
            //await Windows.Storage.FileIO.WriteTextAsync(file, fileContent);
        }


        async public Task DeleteFile(string directoryPath, string fileName)
        {
            StorageFolder folder = await KnownFolders.DocumentsLibrary.GetFolderAsync(directoryPath);
            StorageFile file = await folder.GetFileAsync(fileName);
            await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }
    }
    
}
