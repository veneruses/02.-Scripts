using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScrollButton : MonoBehaviour
{
    [SerializeField] private GameObject m_objectToInstantiate;
    private Button m_button;

    private void Start()
    {
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(() =>
        {
            var newObject = Instantiate(m_objectToInstantiate, transform.parent);
            newObject.GetComponent<FamilyScreen>().SetSwipeInputHandler(transform.GetComponentInParent<SwipesInputHandler>());
        });
    }
}
