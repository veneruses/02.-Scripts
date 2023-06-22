using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GefestCapital
{
    [ExecuteAlways]
    public abstract class UIElement : SerializedMonoBehaviour
    {
        [SerializeField][HideInInspector] public Data Data;
        [SerializeField] protected bool m_generateDataOnStart;
        [SerializeField] protected bool m_generateDataOnStartInEditor;
        [HideInInspector]public Action OnDataSetAct;
        protected virtual void Start()
        {
            if (Application.isPlaying)
            {
                if (m_generateDataOnStart)
                {
                    SetId();
                    SetPrefabName();
                }
            }
            else
            {
                if (m_generateDataOnStartInEditor)
                {
                    if (m_generateDataOnStart)
                    {
                        SetId();
                        SetPrefabName();
                    }
                }
            }
            
        }

        [Button]
        public void SetId()
        {
            if (Data==null || String.IsNullOrEmpty(Data.PrefabName) && String.IsNullOrEmpty(Data.ID))
            {
                CreateData();
            }

            if (String.IsNullOrEmpty(Data.ID))
            {
                Data.ID = System.Guid.NewGuid().ToString();
            }
        }

        [Button]
        public void SetPrefabName()
        {
            if (Data==null || String.IsNullOrEmpty(Data.PrefabName) && String.IsNullOrEmpty(Data.ID))
            {
                CreateData();
            }
            if (String.IsNullOrEmpty(Data.PrefabName))
            {
                Data.PrefabName = TextHelper.KeepOnlyPrefabName(gameObject.name);
            }
        }


        public abstract void CreateData();

        [Button]
        public void ClearData()
        {
            Data = null;
        }

        protected void Save<T>(T element) where T : UIElement
        {
            string folderPath = FilesHandle.s_folderContentName;
            string filePath = Path.Combine(FilesHandle.s_folderContentName, FilesHandle.s_fileContentName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Type[] types = FilesHandle.allowedToSaveTypes;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data[]), types);

            // Загружаем существующие данные
            List<Data> existingData = FilesHandle.LoadAllElements();
            
            //Если элемент с данным id уже присутствует - заменяем его на текущий элемент 
            bool currentIdIsUsed = false;
            for (int i = 0; i < existingData.Count; i++)
            {
                if (existingData[i].ID == Data.ID)
                {
                    currentIdIsUsed = true;
                    existingData[i] = Data;
                }
            }
            if (!currentIdIsUsed)
            {
                // Добавляем наш элемент в эти данные если id до этого не встречался
                existingData.Add(element.Data);
            }
            
           
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(stream, existingData.ToArray());
            }

            Debug.Log("Saved data to " + filePath+" type "+TextHelper.KeepOnlyPrefabName(element.name));
        }
        [Button]
        public virtual void SaveElement()
        {
            Save(this);
        }

        public virtual void SetData(Data data)
        {
            Data = data;
            OnDataSet();
        }

        protected virtual void OnDataSet()
        {
            OnDataSetAct?.Invoke();
        }

        private void OnApplicationQuit()
        {
            if(!Application.isPlaying) return;
            if (SaveManager.Instance.saveAfterExit)
            {
                SaveElement();
            }
        }

        private void OnDisable()
        {
            if(!Application.isPlaying) return;
            if (SaveManager.Instance.saveAfterExit)
            {
                SaveElement();
            }
        }
    }
}