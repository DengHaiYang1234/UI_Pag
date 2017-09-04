using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class Page_Bag : UIBase
{
    RectTransform rectTran;
    GridLayoutGroup grid;
    Button btn_AddArms;
    Button btn_Close;
    int num;
    public GameObject tran_Move;
    Button btn_AddDefense;
    Button btn_AddShoes;
    //Button btn_OpenRecord; 
    //BagInfo bagInfo;
    public Dictionary<string, BagInfo> item_Dict;
    void Start()
    {
        item_Dict = BagData.Instance.newDict;
        //通过根节点，依照路径找到RectTransform组件
        rectTran = gameObject.transform.Find("Bag_ScrollView/Bag_Viewport/Content_Bag").GetComponent<RectTransform>();
        //通过根节点，依照路径找到Button组件
        btn_AddArms = gameObject.transform.Find("Bag_ScrollView/Btn_AddArms").GetComponent<Button>();
        btn_AddDefense = gameObject.transform.Find("Bag_ScrollView/Btn_AddDefense").GetComponent<Button>();
        btn_AddShoes = gameObject.transform.Find("Bag_ScrollView/Btn_AddShoes").GetComponent<Button>();
        btn_Close = gameObject.transform.Find("Bag_ScrollView/Btn_Close").GetComponent<Button>();
        //btn_OpenRecord = gameObject.transform.Find("Bag_ScrollView/Btn_OpenRecord").GetComponent<Button>();
        SetEvenListen(btn_AddArms.gameObject).onClick = AddArms;
        SetEvenListen(btn_AddDefense.gameObject).onClick = AddDefense;
        SetEvenListen(btn_AddShoes.gameObject).onClick = AddShoes;
        SetEvenListen(btn_Close.gameObject).onClick = Close;
        //SetEvenListen(btn_OpenRecord.gameObject).onClick = OpenRecord;
        tran_Move = gameObject.transform.Find("Bag_ScrollView/tran_Move").gameObject;
        //GridLayoutGroup组件是挂载在RectTransform身上的，所以可以直接获取
        grid = rectTran.GetComponent<GridLayoutGroup>();
        //通过默认文件夹找到Image预制体
        //按钮监听要做的事情
        //btn_AddArms.onClick.AddListener(AddArms);
        //btn_Close.onClick.AddListener(Close);
        Init();
    }

    void AddArms(PointerEventData eventData)
    {
        if (item_Dict.Count > 0)
        {
            foreach (var pair in item_Dict)
            {
                if (pair.Value.Label == "ui_icon_battle")
                {
                    var item_Img = UIManager.Instance.CreatComItem<Com_Item>(rectTran);
                    item_Img.rDataName = pair.Key;
                    pair.Value.Count++;
                    SaveAndLoad.Save(pair.Key, pair.Value.Count.ToString());
                    var image = item_Img.gameObject.transform.Find("Tran_DragPoint/Img_drag").GetComponent<Image>();
                    SetImgSprit(image, pair.Value.Label);
                }
            }
        }
        num++;
        Boundary();
    }

    void AddDefense(PointerEventData eventData)
    {
        if (item_Dict.Count > 0)
        {
            foreach (var pair in item_Dict)
            {
                if (pair.Value.Label == "ui_icon_foodbag")
                {
                    var item_Img = UIManager.Instance.CreatComItem<Com_Item>(rectTran);
                    pair.Value.Count++;
                    item_Img.rDataName = pair.Key;
                    SaveAndLoad.Save(pair.Key, pair.Value.Count.ToString());
                    var image = item_Img.gameObject.transform.Find("Tran_DragPoint/Img_drag").GetComponent<Image>();
                    SetImgSprit(image, pair.Value.Label);
                }
            }
        }
        num++;
        Boundary();
    }

    void AddShoes(PointerEventData eventData)
    {
        if (item_Dict.Count > 0)
        {
            foreach (var pair in item_Dict)
            {
                if (pair.Value.Label == "ui_icon_defitem")
                {

                    var item_Img = UIManager.Instance.CreatComItem<Com_Item>(rectTran);
                    pair.Value.Count++;
                    item_Img.rDataName = pair.Key;
                    SaveAndLoad.Save(pair.Key, pair.Value.Count.ToString());
                    var image = item_Img.gameObject.transform.Find("Tran_DragPoint/Img_drag").GetComponent<Image>();
                    SetImgSprit(image, pair.Value.Label);
                }
            }
        }
        num++;
        Boundary();
    }

    void Boundary()
    {
        //itemHeight计算GridLayoutGroup的边界大小
        var itemHeight = grid.spacing.y + grid.cellSize.y;
        //RectTransform的大小尺寸，就为点击生成的个数除以GridLayoutGroup的大小，取整数乘以itemHeight。就可以让生成的个数始终刚好填充满边框，不会出现多余
        rectTran.sizeDelta = new Vector2(0, itemHeight * Mathf.Ceil((float)num / grid.constraintCount));
    }

    void Close(PointerEventData eventData)
    {
        UIManager.Instance.CloseMenuUI("Page_Bag");
    }

    void Init()
    {
        foreach (var pair in item_Dict)
        {
            if (SaveAndLoad.Load(pair.Key) == "读取失败!")
            {
                return;
            } 
            for (int i = 1; i <= Convert.ToInt32(SaveAndLoad.Load(pair.Key)); i++)
            {
                pair.Value.Count = Convert.ToInt32(SaveAndLoad.Load(pair.Key));
                var item_Img = UIManager.Instance.CreatComItem<Com_Item>(rectTran);
                item_Img.rDataName = pair.Key;
                var image = item_Img.gameObject.transform.Find("Tran_DragPoint/Img_drag").GetComponent<Image>();
                SetImgSprit(image, pair.Value.Label);
            }
        }
    }
}
