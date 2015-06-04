using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class GACInterface
    {
        /// <summary>
        /// This is a massive hack to resolve assembly references. We look in diffent places in the GAC and then
        /// we return the exectubale as a last resort. 
        /// TODO:Refactor this code to not suck.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FindDllInGAC(string name)
        {
            string directory = Path.Combine(@"c:\Windows\assembly\GAC_MSIL",name);
            string response = FindDll(directory,name);

            if(response != String.Empty)
            {
                return response;
            }

            directory = Path.Combine(@"c:\Windows\assembly\GAC_32", name);
            response = FindDll(directory,name);

            if (response != String.Empty)
            {
                return response;
            }

            directory = Path.Combine(@"c:\Windows\assembly\GAC_64", name);
            response = FindDll(directory,name);
            if (response != String.Empty)
            {
                return response;
            }


            response = Application.ExecutablePath;
            if (response != String.Empty)
            {
                return response;
            }
            return String.Empty;
        }

        private static string FindDll(string directory, string name)
        {
            try
            {
                string[] subdirectories = Directory.GetDirectories(directory);

                if (subdirectories.Length == 1)
                {
                    string[] files = Directory.GetFiles(subdirectories[0]);
                    foreach (string file in files)
                    {
                        if (Path.GetFileName(file) == name + ".dll")
                        {
                            return file;
                        }
                    }
                }
                return String.Empty;
            }
            catch (DirectoryNotFoundException)
            {
                return String.Empty;
            }
        }
    }
}
