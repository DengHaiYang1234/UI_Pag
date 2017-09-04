using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private void Awake()
    {
        GameObject manager = new GameObject("Manager");
        manager.AddComponent<UIManager>();
        manager.AddComponent<ConfigUtil>();
        manager.AddComponent<SaveAndLoad>();
        manager.AddComponent<BagData>();
        DontDestroyOnLoad(manager);
        UIManager.Instance.CreatPage<Page_Menu>();
        ConfigUtil.Instances.Init();
    }
}
