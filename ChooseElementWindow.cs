using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GefestCapital
{
    public class ChooseElementWindow : SerializedMonoBehaviour
    {
        [SerializeField] private Button m_okButton;

        [SerializeField] private TMPro.TMP_Dropdown m_dropDown;

        [SerializeField] private List<BlockElement.ElementForOpening> m_elementsForOpening;

        public void Init(List<BlockElement.ElementForOpening> elementsForOpening,Transform transformToSpawn)
        {
            m_elementsForOpening = elementsForOpening;
            m_okButton.onClick.AddListener(() =>
            {
                var selectedElement =
                    m_elementsForOpening.First(element => element.Name == m_dropDown.options[m_dropDown.value].text);
                var loadedObject = ResourceLoader.LoadResourceRecursively<GameObject>(selectedElement.PrefabName);
                var newFillDataInElement = Instantiate(selectedElement.WindowToFillData, GameObject.Find("Canvas").transform);
                newFillDataInElement.Init(transformToSpawn);
                gameObject.SetActive(false);
            });
            FillDropdown();
        }

        private void FillDropdown()
        {
            // Заполняем список опций на основе ключей словаря
            List<string> options = new List<string>();
            foreach (var element in m_elementsForOpening)
            {
                if (!element.IsAllowed)
                    return;
                options.Add(element.Name);
            }

            // Очищаем текущие опции
            m_dropDown.options.Clear();

            // Добавляем новые опции в выпадающий список
            m_dropDown.AddOptions(options);
            
        }
    }
}