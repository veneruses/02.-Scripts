using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GefestCapital
{
 
    public class CreateFolderButton : MonoBehaviour
    {
        [SerializeField] private InputField m_inputField;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnCLick);
        }

        public void OnCLick()
        {
        }
    }   
}
