using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
//读取文件Excel通过Excel2Json转换工具转换后的txt文件
public class BagInfo
{
    public readonly string Sequence;
    public readonly string Name;
    public readonly string Label;
    public int Count;
}
    
public class ConfigUtil : MonoBehaviour
{
    //单利
    public static ConfigUtil Instances;
    //声明一个字典，键值为BagInfo类
    public Dictionary<string, BagInfo> bagInfo;

    private void Awake()
    {
        Instances = this;
    }

    public void Init()
    {
        bagInfo = Load<BagInfo>();
        ExportToJson(BagData.Instance.newDict);
    }

    //将转换后的txt文件放入要存入的字典中
    Dictionary<string,T> Load<T>() where T :class
    {
        string rName = typeof(T).Name;
        TextAsset textAsset = Resources.Load<TextAsset>("Data/" + rName);
        Dictionary<string, T> data = JsonMapper.ToObject<Dictionary<string, T>>(textAsset.text);
        return data;
    }

    public void ExportToJson<T>(Dictionary<string,T> rData)where T : class
    {
        string rDataName = typeof(T).Name;
        string outFilePath = Application.persistentDataPath +  rDataName + ".txt";
        string jsonText = JsonMapper.ToJson(rData);

        FileStream fs = new FileStream(outFilePath, FileMode.Create);
        byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonText);
        fs.Write(data, 0, data.Length);
        fs.Flush();
        fs.Close();
        
    }
}
