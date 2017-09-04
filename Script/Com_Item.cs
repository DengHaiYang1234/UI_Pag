using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
//被监听的事件，当有反应时，则响应

public class Com_Item : UIBase
{
    Transform tranDrag;
    Transform initPoint;
    //Image image;
    public string rDataName;

    void Start()
    {
        //image = gameObject.transform.Find("Tran_DragPoint/Img_drag").GetComponent<Image>();
        initPoint = gameObject.transform.parent;
        tranDrag = gameObject.transform.Find("Tran_DragPoint");
        SetEvenListen(tranDrag.gameObject).onDrag = OnDrag;
        SetEvenListen(tranDrag.gameObject).onClick = Click;
        SetEvenListen(tranDrag.gameObject).onPointerUp = OnPointerUp;
        SetEvenListen(tranDrag.gameObject).onBeginDrag = OnBeginDrag;
    }

    public void OnDrag(PointerEventData eventData)
    {
        tranDrag.position = eventData.position;
    }

    public void Click(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.name == "Bag_Destory_Item")
        {
            //Debug.Log("删除前：" + Convert.ToInt32(SaveAndLoad.Load(rDataName)));
            //BagData.Instance.newDict[rDataName].Count--;
            BagData.Instance.newDict[rDataName].Count--;
            //Debug.Log("a:" + a);
            //Debug.Log("这个：" + BagData.Instance.newDict[rDataName].Count);
            SaveAndLoad.Save(rDataName, BagData.Instance.newDict[rDataName].Count.ToString());
            //Debug.Log("删除：" + Convert.ToInt32(SaveAndLoad.Load(rDataName)));
            
            Destroy(gameObject);
        }
        else
        {
            tranDrag.localPosition = Vector3.zero;
            tranDrag.transform.parent.gameObject.transform.SetParent(initPoint);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var newItem = UIManager.Instance.GetMuenUI<Page_Bag>().tran_Move;
        gameObject.transform.SetParent(newItem.transform);
    }
}
