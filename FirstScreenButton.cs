using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace GefestCapital
{
    public class FirstScreenButton : MonoBehaviour
{
    // [FormerlySerializedAs("UieLement")] public UIElement uiElement = null;

    private void Start()
    {
        // if (UieLement.Id == "")
        // {
        //     UieLement.Id = System.Guid.NewGuid().ToString();
        //     UieLement.ParentId = GetComponentInParent<ScreenBaseElement>().UIELement.Id;
        //     UieLement.PrefabName = KeepOnlyPrefabName(gameObject.name);
        //     if (transform.parent != null) 
        //     {
        //         UieLement.HierarchyParentName = transform.parent.gameObject.name;
        //     }
        //     UieLement.Data = new TextData();
        // }
        //
        // if (Application.isPlaying)
        // {
        //     List<UIELement> uieLements = LoadElements(Path.Combine(FilesHandle.s_folderContentName, FilesHandle.s_fileContentName));
        //     if (uieLements != null)
        //     {
        //         //Если в списке элементов с файлика базы данных нет элемента с таким же id
        //         if (uieLements.FirstOrDefault(element => element.Id == UieLement.Id) == null)
        //         {
        //             SaveElements(Path.Combine(FilesHandle.s_folderContentName, FilesHandle.s_fileContentName), UieLement);
        //         }
        //     }
        //     
        // }
    }

    // public void SaveElement(object objToSerialize)
    // {
    //     
    //     // XmlSerializer xmlSerializer = new XmlSerializer(objToSerialize.GetType());
    //     // using (StringWriter textWriter = new StringWriter())
    //     // {
    //     //     xmlSerializer.Serialize(textWriter, objToSerialize);
    //     //     string xml = textWriter.ToString();
    //     //
    //     //     // Здесь вы можете сохранить xml в файл или использовать его для других целей
    //     //     Debug.Log(xml);
    //     // }
    // }
    // public void SaveElements(params UIELement[] objToSerialize)
    // {
    //     
    //     // XmlSerializer xmlSerializer = new XmlSerializer(objToSerialize.GetType());
    //     // using (StringWriter textWriter = new StringWriter())
    //     // {
    //     //     xmlSerializer.Serialize(textWriter, objToSerialize);
    //     //     string xml = textWriter.ToString();
    //     //
    //     //     // Здесь вы можете сохранить xml в файл или использовать его для других целей
    //     //     Debug.Log(xml);
    //     // }
    // }
    //
    // public void SaveElements(string filePath, params UIELement[] objToSerialize)
    // {
    //     // Получение имени папки из пути файла
    //     string directoryName = Path.GetDirectoryName(filePath);
    //
    //     // Проверка существования папки, и если не существует - создание
    //     if (!Directory.Exists(directoryName))
    //     {
    //         Directory.CreateDirectory(directoryName);
    //     }
    //
    //     List<UIELement> existingElements = new List<UIELement>();
    //
    //     if (File.Exists(filePath))
    //     {
    //         // Загрузка существующих элементов
    //         existingElements = LoadElements(filePath);
    //     }
    //
    //     // Добавление новых элементов
    //     existingElements.AddRange(objToSerialize);
    //
    //     XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UIELement>));
    //     using (StreamWriter fileWriter = new StreamWriter(filePath))
    //     {
    //         xmlSerializer.Serialize(fileWriter, existingElements);
    //     }
    // }
    //
    // public List<UIELement> LoadElements(string filePath)
    // {
    //     List<UIELement> elements = new List<UIELement>();
    //     if (File.Exists(filePath))
    //     {
    //         XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UIELement>));
    //         using (StreamReader fileReader = new StreamReader(filePath))
    //         {
    //             elements = (List<UIELement>)xmlSerializer.Deserialize(fileReader);
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log("File does not exist: " + filePath);
    //     }
    //
    //     return elements;
    // }
    //
    // public List<UIELement> GetChildElements(List<UIELement> elements, string parentId)
    // {
    //     List<UIELement> childElements = new List<UIELement>();
    //     foreach(UIELement element in elements)
    //     {
    //         if (element.ParentId == parentId)
    //         {
    //             childElements.Add(element);
    //         }
    //     }
    //
    //     return childElements;
    // }
    //
    // public string KeepOnlyPrefabName(string input)
    // {
    //     //Удаляет все скобки и все пробелы из имени побъекта чтобы получить голое имя префаба
    //     string pattern = @"\s*\(.*\)\s*"; 
    //     string replacement = "";
    //
    //     Regex rgx = new Regex(pattern);
    //     string result = rgx.Replace(input, replacement);
    //
    //     result = result.Replace(" ", "");
    //
    //     return result;
    // }
}
}
