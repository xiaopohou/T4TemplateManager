using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Codenesium.GenerationLibrary.Generation;
using System.Security.Cryptography;
namespace Codenesium.TemplateGenerator.Classes.Generation
{
    public class GenerationManager
    {
        public TemplateExecutionResult ExecuteSingleTemplate(string workingDirectory,Template template, Dictionary<string, object> parameters)
        {
            Generator generator = new Generator(template, parameters,workingDirectory);
            TemplateExecutionResult executionResult = generator.ExecuteTemplateCustomHost();
            executionResult.TransformedText = AppendHash(executionResult.TransformedText);

            if (parameters.Keys.Contains("destinationFilename"))
            {
                SaveToDisk(executionResult.TransformedText, (string)parameters["destinationFilename"]);
            }

            return executionResult;
        }

        public List<TemplateExecutionResult> ExecuteForEachTemplate(string workingDirectory,Template template, Dictionary<string, object> parameters, XElement treeParameters)
        {
            List<TemplateExecutionResult> executionResults = new List<TemplateExecutionResult>();

            parameters["treeParameter"] = treeParameters.ToString();

            Generator generator = new Generator(template, parameters, workingDirectory);
            TemplateExecutionResult executionResult = generator.ExecuteTemplateCustomHost();
            executionResult.TransformedText = AppendHash(executionResult.TransformedText);
            executionResults.Add(executionResult);

            if (parameters.Keys.Contains("destinationFilename"))
            {
                SaveToDisk(executionResult.TransformedText, (string)parameters["destinationFilename"]);   
            }
         
            return executionResults;
        }

        /// <summary>
        /// Appends a string to the bottom of the generated text that represents a hash of the contents.
        /// This could be useful laster for determining if the file has been modified. Ignores whitespace changes.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string AppendHash(string input)
        {
            string data = input.Trim().Replace(" ","").Replace(Environment.NewLine,"");
            return input + Environment.NewLine + @"/*<GeneratorFileHash>" + GenerateHash(data) + @"</GeneratorFileHash>*/";
        }

        /// <summary>
        /// Generate an MD5 hash of a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string GenerateHash(string input)
        {
            MD5Cng crypt = new MD5Cng();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }

        /// <summary>
        /// Save the contents to a file. Create the first parent directory if it doesn't exists.
        /// There will be an exception if your directory contains any missing sub-directories. 
        /// </summary>
        /// <param name="transformedText"></param>
        /// <param name="destinationFilename"></param>
        private void SaveToDisk(string transformedText,string destinationFilename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(destinationFilename)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destinationFilename));
            }
            File.WriteAllText(destinationFilename, transformedText);
        }
    }
}
