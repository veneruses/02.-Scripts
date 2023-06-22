using UnityEngine;

[ExecuteInEditMode]
public class MoveToTopOrBottom : MonoBehaviour
{
    [SerializeField] private bool moveToTop = false; // Настройте эту переменную в окне редактора Unity

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (moveToTop)
        {
            // Переместить в самый верх иерархии
            rectTransform.SetAsLastSibling();
        }
        else
        {
            // Переместить в самый низ иерархии
            rectTransform.SetAsFirstSibling();
        }
    }
}