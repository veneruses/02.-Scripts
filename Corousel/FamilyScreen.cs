using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FamilyScreen : MonoBehaviour //, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private SwipesInputHandler m_swipeInputHandler;
    [SerializeField] private int currentPhotoIndex = 0;
    [SerializeField] private RectTransform m_Container;
    [SerializeField] private float m_speed = 3f;
    [SerializeField] private float m_minElementScale = 0.8f;
    [SerializeField] private float m_centralElementScale = 1.0f;
    private Vector2 m_swipeOffset;
    [SerializeField] private float minOffset = 10;
    [SerializeField] private bool m_isVertical = false;
    [SerializeField] private float m_distanceBetweenElements = 50f;

    public List<RaycastResult> RaycastMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        return results;
    }

    private void Start()
    {
        if (m_swipeInputHandler)
        {
            SetSwipeInputHandler(m_swipeInputHandler);
        }
        if (m_Container.childCount > 0)
        {
            for (int i = 0; i < m_Container.childCount; i++)
            {
                var tr = m_Container.GetChild(i) as RectTransform;
                float t = Time.deltaTime * m_speed;
                if (i == currentPhotoIndex)
                {
                    tr.anchoredPosition = Vector2.zero;
                    tr.localScale = Vector3.one;
                }
                else if (i < currentPhotoIndex)
                {
                    ChildOffset(true, tr, i, 1);
                    tr.localScale = Vector3.one * m_minElementScale;
                }
                else if (i > currentPhotoIndex)
                {
                    ChildOffset(false, tr, i, 1);
                    tr.localScale = Vector3.one * m_minElementScale;
                }
            }
        }
    }

    protected void Update()
    {
        if (m_Container.childCount > 0)
        {
            for (int i = 0; i < m_Container.childCount; i++)
            {
                var tr = m_Container.GetChild(i) as RectTransform;
                float t = Time.deltaTime * m_speed;
                if (i == currentPhotoIndex)
                {
                    tr.anchoredPosition = Vector2.Lerp(tr.anchoredPosition,
                        Vector2.zero, t);
                    tr.localScale = Vector3.Lerp(tr.localScale, Vector3.one * m_centralElementScale, t);
                }
                else if (i < currentPhotoIndex)
                {
                    i = tr.gameObject.activeInHierarchy ? i : i++;
                    ChildOffset(true, tr, i, t);
                    tr.localScale = Vector3.Lerp(tr.localScale, Vector3.one * m_minElementScale, t);
                }
                else if (i > currentPhotoIndex)
                {
                    i = tr.gameObject.activeInHierarchy ? i : i--;
                    ChildOffset(false, tr, i, t);
                    tr.localScale = Vector3.Lerp(tr.localScale, Vector3.one * m_minElementScale, t);
                }
            }
        }
    }

    private void ChildOffset(bool prev, RectTransform transform, int index, float t)
    {
        if (prev)
        {
            if (!m_isVertical)
            {
                transform.anchoredPosition = Vector2.Lerp(transform.anchoredPosition,
                    Vector2.left * m_distanceBetweenElements / 2f * (currentPhotoIndex - index), t);
            }
            else
            {
                transform.anchoredPosition = Vector2.Lerp(transform.anchoredPosition,
                    Vector2.up * m_Container.rect.height * (currentPhotoIndex - index), t);
            }
        }
        else
        {
            if (!m_isVertical)
            {
                transform.anchoredPosition = Vector2.Lerp(transform.anchoredPosition,
                    Vector2.left * m_distanceBetweenElements / 2f * (currentPhotoIndex - index), t);
            }
            else
            {
                transform.anchoredPosition = Vector2.Lerp(transform.anchoredPosition,
                    Vector2.up * m_Container.rect.height * (currentPhotoIndex - index), t);
            }
        }
    }

    public void SetSwipeInputHandler(SwipesInputHandler handler)
    {
        m_swipeInputHandler = handler;
        
        if (m_swipeInputHandler)
        {
            if (m_isVertical)
            {
                m_swipeInputHandler.SwipeUp += () =>
                {
                    if (!m_swipeInputHandler.GetGameObjectsUnderMouse()
                            .Exists(result => result.gameObject == this.gameObject))
                    {
                        return;
                    }

                    if (currentPhotoIndex < m_Container.childCount - 1 &&
                        transform.GetChild(currentPhotoIndex+1).gameObject.activeInHierarchy)
                    {
                        currentPhotoIndex++;
                    }
                };

                m_swipeInputHandler.SwipeDown += () =>
                {
                    if (!m_swipeInputHandler.GetGameObjectsUnderMouse()
                            .Exists(result => result.gameObject == this.gameObject))
                    {
                        return;
                    }

                    if (currentPhotoIndex > 0 && transform.GetChild(currentPhotoIndex-1).gameObject.activeInHierarchy)
                    {
                        currentPhotoIndex--;
                    }
                };
            }
            else
            {
                m_swipeInputHandler.SwipeLeft += () =>
                {
                    if (!m_swipeInputHandler.GetGameObjectsUnderMouse()
                            .Exists(result => result.gameObject == this.gameObject))
                    {
                        return;
                    }

                    if (currentPhotoIndex < m_Container.childCount - 1 &&
                        transform.GetChild(currentPhotoIndex).gameObject.activeInHierarchy)
                    {
                        currentPhotoIndex++;
                    }
                };
                m_swipeInputHandler.SwipeRight += () =>
                {
                    if (!m_swipeInputHandler.GetGameObjectsUnderMouse()
                            .Exists(result => result.gameObject == this.gameObject))
                    {
                        return;
                    }

                    if (currentPhotoIndex > 0 && transform.GetChild(currentPhotoIndex).gameObject.activeInHierarchy)
                    {
                        currentPhotoIndex--;
                    }
                };
            }
        }
    }

    // void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    // {
    //     m_swipeOffset = eventData.position;
    // }
    //
    // void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    // {
    //     m_swipeOffset = eventData.position - m_swipeOffset;
    //     if (m_isVertical == false)
    //     {
    //         if (m_swipeOffset.x > minOffset)
    //         {
    //             if (currentPhotoIndex > 0)
    //                 currentPhotoIndex--;
    //         }
    //         else if (m_swipeOffset.x < -minOffset)
    //         {
    //             if (currentPhotoIndex < m_Container.childCount - 1)
    //                 currentPhotoIndex++;
    //         }
    //     }
    //     else
    //     {
    //         if (m_swipeOffset.y < minOffset)
    //         {
    //             if (currentPhotoIndex > 0)
    //                 currentPhotoIndex--;
    //         }
    //         else if (m_swipeOffset.y > -minOffset)
    //         {
    //             if (currentPhotoIndex < m_Container.childCount - 1)
    //                 currentPhotoIndex++;
    //         }
    //     }
    // }
    //
    // void IDragHandler.OnDrag(PointerEventData eventData)
    // {
    // }
}