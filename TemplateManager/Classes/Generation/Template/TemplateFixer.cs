using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;


namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class TemplateFixer
    {
        public TemplateFixer()
        {
        }

        /// <summary>
        /// Because templates can't be in visual studio with a .tt extension or they will generate files on compile
        /// We store them in the solution with a .ttt extension and copy them in the compile and rename them when we run the tool.
        /// </summary>
        /// <param name="inputDirectory"></param>

        public void FixTemplates(string inputDirectory)
        {
            if (Directory.Exists(inputDirectory))
            {
                List<String> directories = Directory.GetDirectories(inputDirectory).ToList(); //this should be the templates directory that is in the executable directory


                foreach (string directory in directories) //This should be directory of template directories
                {
                    List<String> files = Directory.GetFiles(directory).ToList();
                    foreach (string file in files)
                    {
                        if (Path.GetExtension(file) == ".ttt") //the file is on of our renames t4 templates
                        {
                            FileInfo info = new FileInfo(file);
                            string newFileName = Path.Combine(Path.GetDirectoryName(file) ,Path.GetFileNameWithoutExtension(file) +".tt"); //renbame the file
                            if(File.Exists(newFileName)) 
                            {
                                File.Delete(newFileName);//delete the existing template if it exists
                            }
                            info.CopyTo(newFileName); //create the tt file
                        }
                    }

                }
            }
        }
    }
}
    
