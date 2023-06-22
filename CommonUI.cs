using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using AYellowpaper.SerializedCollections;

namespace GefestCapital
{
    public class CommonUI : MonoBehaviour
    {
        [SerializedDictionary("Damage Type", "Description")]
        public SerializedDictionary<string, string> element = new SerializedDictionary<string, string>();

        [ShowInInspector]
        private StackWithVizualization<string> m_previousScreenIds = new StackWithVizualization<string>();

        [SerializeField] private GameObject m_currentScreen;

        [Button]
        public void AddElementToDictionary(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                element.Add(key, value);
        }

        [Button]
        public void RemoveElementByKey(string key)
        {
            if (!string.IsNullOrEmpty(key) && element.ContainsKey(key))
                element.Remove(key);
        }

        public void AddScreen(string id)
        {
            if (!m_previousScreenIds.Contains(id))
            {
                m_previousScreenIds.Push(id);
            }
        }

        public void SetCurrentScreen(GameObject screen)
        {
            m_currentScreen = screen;
        }

        public void DestroyCurrentScreen()
        {
            Destroy(m_currentScreen.gameObject);
        }

        public void LoadPreviousWindow()
        {
            if (m_previousScreenIds.Count > 1)
            {
                m_previousScreenIds.Pop();
                Destroy(m_currentScreen.gameObject);
                List<Data> elementsData = FilesHandle.LoadAllElements();
                var element = elementsData.Find(el => { return el.ID == m_previousScreenIds.Peek(); });
                //Из ресурсов загружаем префаб по id 
                ScreenBaseElement newScreen =
                    Instantiate(
                        Resources.Load<ScreenBaseElement>(Path.Combine("Prefabs", element.PrefabName)).gameObject,
                        GameObject.Find("Canvas").transform).GetComponent<ScreenBaseElement>();
                newScreen.SetData(element);
            }
        }
    }
}