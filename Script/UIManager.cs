using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : UIBase
{
    public static UIManager Instance;

    public GameObject UIRoot;

    public Dictionary<string, UIBase> uiDick = new Dictionary<string, UIBase>();

    void Awake()
    {
        Instance = this;
        StartPlane();
    }

    public void StartPlane()
    {
        var menu = Resources.Load("Ui/UIRoot") as GameObject;
        UIRoot = Instantiate(menu);
        UIRoot.name = "UIRoot";
        DontDestroyOnLoad(UIRoot);
    }

    //CreatPage类型必须将指定的MonoBehaviour作为基类
    public T CreatPage<T>() where T : UIBase
    {
        string rName = typeof(T).Name;
        GameObject page = Resources.Load("Ui/" + rName) as GameObject;
        var newPage = Instantiate(page) as GameObject;
        newPage.name = rName;
        newPage.transform.SetParent(UIRoot.transform);
        newPage.transform.localScale = Vector3.one;
        var menuScript = newPage.AddComponent<T>();
        uiDick.Add(rName, menuScript);
        return menuScript as T;
    }

    public T GetMuenUI<T>()where T : UIBase
    {
        string rName = typeof(T).Name;
        return uiDick[rName] as T;
    }

    public void CloseMenuUI(string rName) 
    {
        Destroy(uiDick[rName].gameObject);
        uiDick.Remove(rName);
    }

    public void OpenMenuUI(string rName)
    {
        uiDick[rName].gameObject.SetActive(true);
    }

    public T CreatComItem<T>(Transform trans)where T : UIBase
    {
        string rName = typeof(T).Name;
        GameObject findItem = Resources.Load("UI/" + rName) as GameObject;
        var item = Instantiate(findItem as GameObject);
        item.transform.SetParent(trans);
        item.transform.localScale = Vector3.one;
        var comItemScript = item.AddComponent<T>();
        return comItemScript as T;
    }
}
