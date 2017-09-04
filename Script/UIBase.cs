using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    public void SetImgSprit(Image img,string name)
    {
        img.sprite = Resources.Load<GameObject>("Data/" + name).GetComponent<Image>().sprite;
    }

    //添加将要被监听的一些监听事件
    public EventTriggerListener SetEvenListen(GameObject obj)
    {
        //声明一个监听，将obj需要被监听的事件添加进来
        
        var eventListen = obj.GetComponent<EventTriggerListener>();
        //若物体没有挂载监听事件，则动态挂载一个需要被监听的事件
        if(eventListen == null)
        {
            eventListen = obj.AddComponent<EventTriggerListener>();
        }
        return eventListen;
    }
}
