using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XMLSystem.Xml;
public class XmlLoader : MonoBehaviour
{
    private void Start()
    {
        Save();
    }

    public void Load()
    {
        XmlDocument doc = new XmlDocument("Content/Data.Xml");
        
        foreach (var node in doc.ChildNodes)
        {
            if (node.Attributes["type"].Value == "button")
            {
                GameObject button = new GameObject(node.Name, typeof(RectTransform));
                button.transform.SetParent(transform);
                button.AddComponent<Button>();
                RectTransform rectTransform = button.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = node.GetValue<Vector2>("position");
                if (node.Attributes["size"] != null)
                {
                    rectTransform.sizeDelta = node.GetValue<Vector2>("size");
                }
            }
        }
        
    }

    public void Save()
    {
        XmlDocument doc = new XmlDocument();
        XmlDocumentNode mainNode = XmlDocument.CreateNode("Data");
        doc.SetMainNode(mainNode);
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            XmlDocumentNode node = XmlDocument.CreateNode(button.name,mainNode);
            node.AddAttribute("position",button.GetComponent<RectTransform>().anchoredPosition);
            node.AddAttribute("size",button.GetComponent<RectTransform>().sizeDelta);
        }
        doc.Save("Content/Data1.Xml");
    }
}
