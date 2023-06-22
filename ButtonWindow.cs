using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AYellowpaper.SerializedCollections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace GefestCapital
{
    public class ButtonWindow : SerializedMonoBehaviour
    {
        [SerializeField] private TransitionButtonElement m_buttonElementConnected; //К какой кнопке привязано данное окно
        [SerializeField] private Button m_okButton;
        [SerializeField] private TMPro.TMP_Dropdown m_dropDown;
        // Словарь для связывания текста вариантов с именами префабов
        [SerializeField] private Dictionary<string, string> optionPrefabMap = new Dictionary<string, string>
        {
            { "Подразделы", "SubsectionsScreen" },{ "Главный экран", "FIrstScreen" }
        };
        
        void Start()
        {
            // Заполняем список опций на основе ключей словаря
            List<string> options = new List<string>();
            foreach (string option in optionPrefabMap.Keys)
            {
                options.Add(option);
            }

            // Очищаем текущие опции
            m_dropDown.options.Clear();

            // Добавляем новые опции в выпадающий список
            m_dropDown.AddOptions(options);
            
            m_okButton.onClick.AddListener((() => SetButtonTransition(m_dropDown)));
        }

        // Этот метод будет вызываться при изменении выбранного значения
        void SetButtonTransition(TMPro.TMP_Dropdown change)
        {
            string selectedOption = change.options[change.value].text;
            
            if (optionPrefabMap.TryGetValue(selectedOption, out string prefabName))
            {
                (m_buttonElementConnected.Data as TransitionButtonData).GameObjectToTransitPrefab = prefabName;
                gameObject.SetActive(false);
            }
        }

        public void SetConnectedButton(TransitionButtonElement button)
        {
            m_buttonElementConnected = button;
        }
    }
}