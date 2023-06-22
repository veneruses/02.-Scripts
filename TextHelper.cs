using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GefestCapital
{
    public class TextHelper
    {
        public static string KeepOnlyPrefabName(string input)
        {
            //Удаляет все скобки и все пробелы из имени побъекта чтобы получить голое имя префаба
            string pattern = @"\s*\(.*\)\s*"; 
            string replacement = "";
        
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replacement);
        
            result = result.Replace(" ", "");
        
            return result;
        }
    }
}

