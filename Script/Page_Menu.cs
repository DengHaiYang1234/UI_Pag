using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_Menu : UIBase
{
    public Button btn_Open;

    BagInfo bagData;
    Button btn_Quit;
    void Start()
    {
        btn_Open = gameObject.transform.Find("Btn_Open_Bag").GetComponent<Button>();
        btn_Open.onClick.AddListener(Open);
    }

    void Open()
    {
        UIManager.Instance.CreatPage<Page_Bag>();
    }

    void Quit()
    {
        //Application.Quit();
    }



}
