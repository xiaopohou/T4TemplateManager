using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.GenerationLibrary.Generation.Helpers
{
    public static class CommonHelper
    {

        /// <summary>
        /// Utility function to convert underscore to camelCase. I see underscores between parameters a lot in sql databases.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        
        public static string ToUpperCaseFirstLeter(this string obj)
        {

            return obj[0].ToString().ToUpper() + obj.Substring(1, obj.Length - 1);
        }

        public static string ToLowerCaseFirstLeter(this string obj)
        {

            return obj[0].ToString().ToLower() + obj.Substring(1, obj.Length - 1);
        }

       
    }
}
