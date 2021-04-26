
using UnityEngine;
using System.Net;
using System.IO;

public class APIhelper 
{
    // Start is called before the first frame update
    public static State GetNewState()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.rootnet.in/covid19-in/unofficial/covid19india.org/statewise");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        Debug.Log(json);
        return JsonUtility.FromJson<State>(json);

    }
}
