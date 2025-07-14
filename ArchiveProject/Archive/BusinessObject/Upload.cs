using System.IO;

namespace Archive.BusinessObject
{
    public class Upload
    {
        public static string UploadFile(string sourceFilePath, string fileName, string destinationDirectoryPath, DataAccess.File file)
        {
            try
            {
                string destinationFilePath = Path.Combine(destinationDirectoryPath, fileName);

                if (File.Exists(file.FilePath))
                    File.Delete(file.FilePath);

                if (!File.Exists(destinationFilePath))
                {
                    File.Copy(sourceFilePath, destinationFilePath);
                }

                return File.Exists(destinationFilePath)
                    ? "آپلود با موفقیت انجام شد"
                    : "آپلود با شکست مواجه شد";

            }
            catch
            {
                return "خطا در هنگام آپلود: ";
            }
        }

    }
}
