using System;
using System.IO;
using System.Web;

namespace SingleLegMLM.Code
{
    public class Common
    {
        public static string UploadImage(string FilePath, HttpPostedFileBase PostFile, string prefix)
        {

            string LogoFileName = "";
            try
            {
                string PhysicalPath = HttpContext.Current.Server.MapPath(FilePath);
                try
                {
                    Directory.CreateDirectory(PhysicalPath);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
                string fname = prefix + DateTime.Now.ToString("yyyyMMddHmmss") + DateTime.Now.Millisecond.ToString() + Path.GetExtension(PostFile.FileName);
                PostFile.SaveAs(PhysicalPath + fname);
                LogoFileName = fname;
            }
            catch (Exception)
            {
                LogoFileName = "";
            }
            return LogoFileName;
        }
        //public static bool DeleteImage(string FilePath, string FileName)
        //{
        //    bool IsDelete = false;
        //    string file_name = PropMdl.Logo;
        //    string path = Server.MapPath("//Images//Hotel//" + file_name);
        //    FileInfo file = new FileInfo(path);
        //    if (file.Exists)//check file exsit or not
        //    {
        //        file.Delete();
        //    }
        //    return IsDelete;
        //}
    }
}