using POC2_UI.Helpers;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFileHelper))]
namespace POC2_UI.Helpers
{
    public class AndroidFileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var libFolder =  Path.Combine(path, "..","Library","Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}