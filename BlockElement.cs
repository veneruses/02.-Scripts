using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GefestCapital;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Data = GefestCapital.Data;

namespace GefestCapital
{
    public class BlockElement : NestedElement
    {
        [System.Serializable]
        public struct ElementForOpening
        {
            public string Name;
            public string PrefabName;
            public bool IsAllowed;
            public FillElementDataWindow WindowToFillData;
        }

        [FormerlySerializedAs("elementsForOpening")] [SerializeField] private List<ElementForOpening> m_elementsForOpening;
        [SerializeField] private Button m_AddElementButton;
        [SerializeField] private ChooseElementWindow m_chooseElementWindow;

        protected override void Start()
        {
            if (!Application.isPlaying) return;
            base.Start();
            GetComponent<FamilyScreen>().SetSwipeInputHandler(transform.GetComponentInParent<SwipesInputHandler>());
            if (Data != null)
            {
                if (!string.IsNullOrEmpty(Data.ID))
                {
                    LoadAndInstantiateElements<UiElementData,UIElement>();
                }
            }
            else
            {
                OnDataSetAct += () =>
                {
                    LoadAndInstantiateElements<UiElementData,UIElement>();
                };
            }
            
            m_AddElementButton.onClick.AddListener((() =>
            {
                var newElement = Instantiate(m_chooseElementWindow, GameObject.Find("Canvas").transform);
                newElement.Init(m_elementsForOpening,transform);
            }));
        }
        public override void CreateData()
        {
            SetData(new ButtonData());
        }

        protected override void OnDataSet()
        {
            ScreenBaseElement screen = transform.GetComponentInParent<ScreenBaseElement>();
            (Data as ButtonData).IdScreenRelated = screen.Data.ID;
            (Data as ButtonData).GOToPinName = transform.parent.name;
            base.OnDataSet();
        }

        protected void LoadAndInstantiateElements<T,K>() where T: ButtonData where K: UIElement
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

        public void OpenDataWindow()
        {
            
        }
    }
}
