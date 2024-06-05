using Gtb.WeasyPrint.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Gtb.WeasyPrint.Test")]

namespace Gtb.WeasyPrint
{

    public class FilesManager
    {
        public string FolderPath { get; }

        public FilesManager(string path = null)
        {
            FolderPath = GetFolderPath(path);
        }

        public Task InitFilesAsync()
        {
            return Task.Run(() =>
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                else
                {
                    DeleteFiles();
                    Directory.CreateDirectory(FolderPath);
                }

                var folderData = FileResx.weasyprint_python_binary;

                var compressedFileName = Path.Combine(FolderPath, "data.zip");

                File.WriteAllBytes(compressedFileName, folderData);

                ZipFile.ExtractToDirectory(compressedFileName, FolderPath);

                File.Delete(compressedFileName);

            });
        }

        public bool IsFilesExsited()
        {
            if (!Directory.Exists(FolderPath))
                return false;

            var files = Directory.GetFiles(FolderPath);

            var dirs = Directory.GetDirectories(FolderPath);

            var hasPython = files.Where(a => a.Contains("python.exe")).FirstOrDefault() != null;
            var hasScripts = dirs.Where(a => a.Contains("Scripts")).FirstOrDefault() != null;

            if (!hasScripts)
                return false;

            if (!hasPython)
                return false;


            return true;
        }

        public Task<string> CreateFile(string fileName, byte[] data)
        {
            return Task.Run(() =>
            {
                var path = Path.Combine(FolderPath, fileName);

                File.WriteAllBytes(path, data);

                return path;
            });
        }

        public Task Delete(string fileName)
        {
            return Task.Run(() =>
            {
                var path = Path.Combine(FolderPath, fileName);

                if (File.Exists(path))
                    File.Delete(path);
            });
        }

        public Task<byte[]> ReadFile(string fileName)
        {
            return Task.Run(() =>
            {
                var path = Path.Combine(FolderPath, fileName);

                if (File.Exists(path))
                    return File.ReadAllBytes(path);

                return null;
            });
        }

        private string GetFolderPath(string path)
        {
            var folderName = "netwrapper-weasyprint";
            if (path == null) { 
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var fullPath = Path.Combine(appDataPath, folderName);
                return fullPath;
            }
            return Path.Combine(path, folderName);
            
        }

        private void DeleteFiles()
        {
            if (!Directory.Exists(FolderPath))
                return;


            Directory.Delete(FolderPath, true);

        }
    }
}
