using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static string Save(string user, string data)
    {
        string sendData = "user=" + user + "&" + "data=" + data;//发送的数据
        string url = "http://192.168.199.185:8080/save/?" + sendData;//请求路径
                                                                     //string url = "http://192.168.199.107:8080/save/?" + sendData;//请求路径
        string backMsg = "";//接收服务端返回数据
        try
        {
            System.Net.WebRequest httpRquest = System.Net.HttpWebRequest.Create(url);
            httpRquest.Method = "GET";
            /*byte[] dataArray = System.Text.Encoding.UTF8.GetBytes(sendData);               
            System.IO.Stream requestStream = null;
            if (string.IsNullOrWhiteSpace(sendData) == false)
            {
                requestStream = httpRquest.GetRequestStream();
                requestStream.Write(dataArray, 0, dataArray.Length);
                requestStream.Close();
            }*/
            System.Net.WebResponse response = httpRquest.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
            backMsg = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            //requestStream.Dispose();
            responseStream.Close();
            responseStream.Dispose();
        }
        catch (System.Exception e1)
        {
            //Console.WriteLine(e1.ToString());
            Debug.Log(e1.ToString());
        }
        return backMsg;
    }


    //从服务器读取数据，返回该user之前存储的data
    public static string Load(string user)
    {
        string sendData = "user=" + user;//发送的数据
        string url = "http://192.168.199.185:8080/load?" + sendData;
        //string url = "http://192.168.199.107:8080/load?" + sendData;
        string backMsg = "";//接收服务端返回数据
        try
        {
            System.Net.WebRequest httpRquest = System.Net.HttpWebRequest.Create(url);
            httpRquest.Method = "GET";
            System.Net.WebResponse response = httpRquest.GetResponse();//获取服务器的返回，存在等待可能
            System.IO.Stream responseStream = response.GetResponseStream();//获取服务器返回的字符流
            System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);//将返回的字符流以UTF8格式赋给StreamReader
            backMsg = reader.ReadToEnd();//将StreamReader全部数据赋给字符串
                                         //关闭连接与释放资源
            reader.Close();
            reader.Dispose();
            //requestStream.Dispose();
            responseStream.Close();
            responseStream.Dispose();
        }
        catch (System.Exception e1)
        {
            //Console.WriteLine(e1.ToString());
            Debug.Log(e1.ToString());
        }
        return backMsg;//返回信息
    }
}
