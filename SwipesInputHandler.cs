using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipesInputHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Action SwipeLeft;
    public Action SwipeRight;
    public Action SwipeUp;
    public Action SwipeDown;
    [SerializeField] private float minOffset = 10;
    private Vector2 m_swipeOffset;
    private List<GameObject> _gameObjectsUnderMaus = new List<GameObject>();

    private void FixedUpdate()
    {
        _gameObjectsUnderMaus = null;
    }

    public List<GameObject> GetGameObjectsUnderMouse()
    {
        if (_gameObjectsUnderMaus != null && _gameObjectsUnderMaus.Count > 0)
        {
            return _gameObjectsUnderMaus;
        }

        return _gameObjectsUnderMaus = RaycastMouse().Select(element => element.gameObject).ToList();
    }

    public List<RaycastResult> RaycastMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        Debug.Log(results.Count);

        return results;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        m_swipeOffset = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        m_swipeOffset = eventData.position - m_swipeOffset;

        if (Math.Abs(m_swipeOffset.x) > Math.Abs(m_swipeOffset.y))
        {
            if (m_swipeOffset.x > minOffset)
            {
                SwipeRight?.Invoke();
            }
            else if (m_swipeOffset.x < -minOffset)
            {
                SwipeLeft?.Invoke();
            }
        }
        else
        {
            if (m_swipeOffset.y < minOffset)
            {
                SwipeDown?.Invoke();
            }

            else if (m_swipeOffset.y > -minOffset)
            {
                SwipeUp?.Invoke();
            }
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
    }
}