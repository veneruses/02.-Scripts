using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace GefestCapital
{
    public abstract class ScreenBaseElement : UIElement
    {
        protected override void Start()
        {
            if (!Application.isPlaying) return;
            base.Start();
            if (Data != null)
            {
                if (!string.IsNullOrEmpty(Data.ID))
                {
                    LoadAndInstantiateElements<ButtonData,NestedElement>();
                    GameObject.FindWithTag("CommonUi").GetComponent<CommonUI>().AddScreen(Data.ID);
                }
            }
            else
            {
                OnDataSetAct += () =>
                {
                    GameObject.FindWithTag("CommonUi").GetComponent<CommonUI>().AddScreen(Data.ID);
                    LoadAndInstantiateElements<ButtonData,NestedElement>();
                };
            }

            GameObject.FindWithTag("CommonUi").GetComponent<CommonUI>().SetCurrentScreen(gameObject);
        }

        [Button]
        protected virtual void LoadAndInstantiateElements<T,K>()where T: ButtonData where K: NestedElement
        {
            List<Data> elementsData = FilesHandle.LoadAllElements();
            List<T> childElements = GetChildElements<T>(elementsData, Data.ID);
            for (int i = 0; i < childElements.Count; i++)
            {
                GameObject prefab = ResourceLoader.LoadResourceRecursively<GameObject>(childElements[i].PrefabName);
                Transform parent = gameObject.GetComponentsInChildren<Transform>()
                    .FirstOrDefault(t => t.name == childElements[i].GOToPinName);
                K loadedElement = Instantiate(prefab, parent).GetComponent<K>();
                loadedElement.SetData(childElements[i]);
            }
        }


        public List<T> GetChildElements<T>(List<Data> elements, string parentId) where T: ButtonData
        {
            List<T> childElements = new List<T>();
            foreach (Data element in elements)
            {
                if (element is T bd)
                {
                    if (bd.IdScreenRelated == parentId)
                    {
                        childElements.Add(bd);
                    }
                }
            }

            return childElements;
        }

        public override void CreateData()
        {
            Data = new Data();
            OnDataSet();
        }

        protected abstract void SaveChildElements();
    }
}