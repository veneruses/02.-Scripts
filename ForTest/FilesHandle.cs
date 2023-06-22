using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

namespace GefestCapital
{
    public class FilesHandle : MonoBehaviour
    {
        public static string s_folderContentName = "Content";
        public static string s_fileContentName = "SavedElements.xml";

        public static Type[] allowedToSaveTypes =
        {
            typeof(UiElementData), typeof(TransitionButtonData), typeof(ButtonData), typeof(ScreenData),
            typeof(ButtonScreenOpenerData)
        };
        public static bool saveElements = true;
        public static FilesHandle Instance;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public static List<Data> LoadAllElements()
        {
            string filePath = Path.Combine(FilesHandle.s_folderContentName, FilesHandle.s_fileContentName);
            var elements = new List<Data>();
            Type[] types = allowedToSaveTypes;
            if (File.Exists(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data[]),types);
                
                using (StreamReader fileReader = new StreamReader(filePath))
                {
                    Data[] loadedElements = (Data[])xmlSerializer.Deserialize(fileReader);
                    elements.AddRange(loadedElements);
                }
            }
            else
            {
                Debug.Log("File does not exist: " + filePath);
            }

            return elements;
        }

        public T CheckElementMathing<T>(string id) where T: Data
        {
            List<Data> datas = LoadAllElements();
            T mathElement = null;
            mathElement = datas.Find(el => { return el.ID == id; }) as T;
            return mathElement;
        }
    }
    
    
}
