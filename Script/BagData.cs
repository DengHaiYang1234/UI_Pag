using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagData : UIBase
{
    public static BagData _Instance;

    public static BagData Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = new BagData();
                _Instance.newDict = ConfigUtil.Instances.bagInfo;
            }
            return _Instance;
        }
    }
    public Dictionary<string, BagInfo> newDict = new Dictionary<string, BagInfo>();
}
