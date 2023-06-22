using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GefestCapital;
using UnityEngine;
using UnityEngine.UI;

namespace GefestCapital
{
    public class TransitionButtonElement : NestedElement
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener((() =>
            {
                if (Data is TransitionButtonData bd)
                {
                    if (!String.IsNullOrEmpty(bd.GameObjectToTransitId))
                    {
                        InstantiateElementByTransitionId(bd.GameObjectToTransitId);
                        return;
                    }
                    if (!String.IsNullOrEmpty(bd.GameObjectToTransitPrefab))
                    {
                        bd.GameObjectToTransitId= InstantiateElementByTransitName(bd.GameObjectToTransitPrefab).Data.ID;
                        return;
                    }

                    ButtonWindow buttonWindow =  Instantiate(Resources.Load<ButtonWindow>(Path.Combine("Prefabs","ButtonWindow") ),GameObject.Find("Canvas").transform);
                    buttonWindow.SetConnectedButton(this);
                }
            }));
        }

        public override void CreateData()
        {
            Data = new TransitionButtonData();
            ScreenBaseElement screen = transform.GetComponentInParent<ScreenBaseElement>();
            (Data as TransitionButtonData).IdScreenRelated = screen.Data.ID;
            (Data as TransitionButtonData).GOToPinName = transform.parent.name;
        }

        public void InstantiateElementByTransitionId(string elementId)
        {
            GameObject.FindWithTag("CommonUi").GetComponent<CommonUI>().DestroyCurrentScreen();
            List<Data> existingData = FilesHandle.LoadAllElements();
            Data neededScreenData = existingData.First(element => element.ID == elementId);
            
            if (neededScreenData != null)
            {
                var instance = Instantiate(ResourceLoader.LoadResourceRecursively<GameObject>(neededScreenData.PrefabName), GameObject.Find("Canvas").transform).GetComponent<ScreenBaseElement>();
                instance.Data = neededScreenData;
            }
           
        }

        public ScreenBaseElement InstantiateElementByTransitName(string prefabName)
        {
            GameObject.FindWithTag("CommonUi").GetComponent<CommonUI>().DestroyCurrentScreen();
            ScreenBaseElement prefab =
                ResourceLoader.LoadResourceRecursively<ScreenBaseElement>(prefabName); //Resources.Load<ScreenBaseElement>(Path.Combine("Prefabs", prefabName));
            ScreenBaseElement newElement = Instantiate<ScreenBaseElement>(prefab, GameObject.Find("Canvas").transform).GetComponent<ScreenBaseElement>();
            newElement.CreateData();
            newElement.SetId();
            newElement.SetPrefabName();
            return newElement;
        }

        public override void SetData(Data data)
        {
            base.SetData(data);
        }
    }
}