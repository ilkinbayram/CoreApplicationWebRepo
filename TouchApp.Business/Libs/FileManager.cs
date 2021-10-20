using Business.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Business.Libs
{
    public interface IFileManager
    {
        DataResult<string> Upload(IFormFile file, string savePath = "uploads", string newName = null);

        DataResult<Dictionary<string, string>> UploadSaveDictionary(IFormFile file, string savePath = "uploads", string newName = null);
        DataResult<Dictionary<string, string>> UploadListFileSaveDictionary(List<IFormFile> files, string savePath = "uploads", string newName = null);
        DataResult<Dictionary<string, string>> UploadThumbnail(IFormFile file, int width = 100, int heigth = 100, string savePath = "uploads", string newName = null, string thumbnailNewName = null);
        DataResult<Dictionary<string, string>> UploadVideoSaveDictionary(IFormFile file, string savePath = "uploads", string newName = null);
        void Delete(string filename, string deletedPath = "uploads");
    }

    public class FileManager : IFileManager
    {
        public void Delete(string filename, string deletedPath = "uploads")
        {
            string path = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot", deletedPath,
                                filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public DataResult<Dictionary<string, string>> UploadSaveDictionary(IFormFile file, string savePath = "uploads", string newName = null)
        {
            DataResult<Dictionary<string, string>> result = new SuccessDataResult<Dictionary<string, string>>();

            try
            {
                var list = file.FileName.Split('.');

                string filename;

                if (newName == null)
                    filename = Guid.NewGuid() + "." + list[^1];
                else
                    filename = newName + "." + list[^1];

                var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
                if (!Directory.Exists(writePath))
                    Directory.CreateDirectory(writePath);

                var path = Path.Combine(writePath, filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                result = new SuccessDataResult<Dictionary<string, string>>();
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("imagePath", path);
                result.SetData(dictionary);

                return result;
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<Dictionary<string, string>>(message: ex.Message);
                return result;
            }
        }

        public DataResult<Dictionary<string, string>> UploadVideoSaveDictionary(IFormFile file, string savePath = "uploads", string newName = null)
        {
            DataResult<Dictionary<string, string>> result = new SuccessDataResult<Dictionary<string, string>>();

            try
            {
                var list = file.FileName.Split('.');

                string filename;

                if (newName == null)
                    filename = Guid.NewGuid() + "." + list[^1];
                else
                    filename = newName + "." + list[^1];

                var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
                if (!Directory.Exists(writePath))
                    Directory.CreateDirectory(writePath);

                var path = Path.Combine(writePath, filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                result = new SuccessDataResult<Dictionary<string, string>>();
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("videoPath", path);
                result.SetData(dictionary);

                return result;
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<Dictionary<string, string>>(message: ex.Message);
                return result;
            }
        }

        public DataResult<Dictionary<string, string>> UploadListFileSaveDictionary(List<IFormFile> files, string savePath = "uploads", string newName = null)
        {
            DataResult<Dictionary<string, string>> result = new SuccessDataResult<Dictionary<string, string>>();

            try
            {
                var dictionary = new Dictionary<string, string>();

                for (int i = 0; i < files.Count; i++)
                {
                    var list = files[i].FileName.Split('.');

                    string filename;

                    if (newName == null)
                        filename = Guid.NewGuid() + "." + list[^1];
                    else
                        filename = newName + "." + list[^1];

                    var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
                    if (!Directory.Exists(writePath))
                        Directory.CreateDirectory(writePath);

                    var path = Path.Combine(writePath, filename);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        files[i].CopyTo(stream);
                    }

                    result = new SuccessDataResult<Dictionary<string, string>>();
                    
                    dictionary.Add("imagePath"+i.ToString(), path);
                    result.SetData(dictionary);
                }

                return result;
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<Dictionary<string, string>>(message: ex.Message);
                return result;
            }
        }


        public DataResult<string> Upload(IFormFile file, string savePath = "uploads", string newName = null)
        {
            try
            {
                var list = file.FileName.Split('.');

                string filename;

                if (newName == null)
                    filename = Guid.NewGuid() + "." + list[^1];
                else
                    filename = newName + "." + list[^1];

                var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
                if (!Directory.Exists(writePath))
                    Directory.CreateDirectory(writePath);

                var path = Path.Combine(writePath, filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                SuccessDataResult<string> successResult = new SuccessDataResult<string>(filename);
                return successResult;
            }
            catch (Exception ex)
            {
                ErrorDataResult<string> errorDataResult = new ErrorDataResult<string>("");
                errorDataResult.SetMessages(ex.Message);
                return errorDataResult;
            }
        }



        public DataResult<Dictionary<string, string>> UploadThumbnail(IFormFile file, int width, int heigth, string savePath = "uploads", string newName = null, string thumbnailNewName = null)
        {
            DataResult<Dictionary<string, string>> result = new SuccessDataResult<Dictionary<string, string>>();

            try
            {
                if (file.ContentType == "image/png" || file.ContentType == "image/jpeg")
                {
                    var list = file.FileName.Split('.');

                    string filename;
                    string thumbnailFileName;

                    filename = newName == null 
                        ? (Guid.NewGuid().ToString() + "." + list[^1]).Replace("-", string.Empty)
                        : (newName + "." + list[^1]);

                    thumbnailFileName = thumbnailNewName == null 
                        ? (Guid.NewGuid().ToString() + "." + list[^1]).Replace("-", string.Empty)
                        : (thumbnailNewName + "." + list[^1]);

                    var writePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", savePath);
                    if (!Directory.Exists(writePath))
                        Directory.CreateDirectory(writePath);

                    var path = Path.Combine(writePath, filename);
                    var thumbnailPath = Path.Combine(writePath, thumbnailFileName);

                    Image image = null;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);

                        image = new Bitmap(stream);

                        var thumnailIcon = image.GetThumbnailImage(width, heigth, () => false, IntPtr.Zero);

                        thumnailIcon.Save(thumbnailPath);
                    }

                    result = new SuccessDataResult<Dictionary<string, string>>();
                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("imagePath", path);
                    dictionary.Add("thumbnailPath", path);
                    result.SetData(dictionary);
                }
                else
                {
                    result = new ErrorDataResult<Dictionary<string, string>>(message: Messages.WarningMessages.NOT_SUPPORTED_FileContentType);
                }
                
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<Dictionary<string, string>>(message: ex.Message);
            }

            return result;
        }
    }
}
