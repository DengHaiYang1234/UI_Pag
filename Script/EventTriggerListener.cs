using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

//将哪些事件设置为被监听事件
public class EventTriggerListener : MonoBehaviour,IPointerClickHandler,IDragHandler,IBeginDragHandler,IPointerUpHandler
{
    //UnityAction泛型委托,没有返回值，UnityAction onClick没有传入参数，UnityAction<PointerEventData>传入了一个PointerEventData参数
    public UnityAction<PointerEventData> onClick;
    public UnityAction<PointerEventData> onDrag;
    public UnityAction<PointerEventData> onBeginDrag;
    public UnityAction<PointerEventData> onPointerUp;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //如果onBeginDrag事件存在，则onBeginDrag(eventData)，监听该事件
        if (onBeginDrag != null)
        {
            onBeginDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(onDrag != null)
        {
            onDrag(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       if(onClick != null)
        {
            onClick(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(onPointerUp != null)
        {
            onPointerUp(eventData);
        }
    }
}
