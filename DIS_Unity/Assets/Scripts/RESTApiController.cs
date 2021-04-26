using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
public class RESTApiController : MonoBehaviour
{
  
  
    public Material red;
    public Material yellow;
    public Material orange;


    private readonly string url = "https://api.rootnet.in/covid19-in/unofficial/covid19india.org/statewise";

    private void Start()
    {
        OnButtonRandomPokemon();
    }

    public void OnButtonRandomPokemon()
    {
               
        StartCoroutine(GetInfoStates());
    }

    IEnumerator GetInfoStates()
    {


        UnityWebRequest result = UnityWebRequest.Get(url);

        yield return result.SendWebRequest();

        if (result.result==UnityWebRequest.Result.ConnectionError || result.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(result.error);
            yield break;
        }

        JSONNode infoStates = JSON.Parse(result.downloadHandler.text);
        Debug.Log("Info " + infoStates.Count);
        JSONNode stateInfo = infoStates["data"]["statewise"];
        Debug.Log(stateInfo);

        for (int i = 0, j = stateInfo.Count - 1; i < stateInfo.Count; i++, j--)
        {
            if(GameObject.Find(stateInfo[i]["state"])!=null)
            {
                if (stateInfo[i]["active"] >= 70000)
                {
                    GameObject.Find(stateInfo[i]["state"]).GetComponent<MeshRenderer>().material = red;
                }
                else if(stateInfo[i]["active"] < 70000 && stateInfo[i]["active"] >= 25000)
                {
                    GameObject.Find(stateInfo[i]["state"]).GetComponent<MeshRenderer>().material = orange;
                }
                else
                {
                    GameObject.Find(stateInfo[i]["state"]).GetComponent<MeshRenderer>().material = yellow;
                }
                Transform parent = GameObject.Find(stateInfo[i]["state"]).transform.parent;
                Transform infoContiner = parent.GetChild(0).transform;
                foreach(Transform t in infoContiner.transform)
                {
                    if (t.tag == "state")
                    {
                        TextMeshPro text = t.gameObject.GetComponent<TextMeshPro>();
                        text.SetText(stateInfo[i]["state"]);
                    }
                    if(t.tag=="active")
                    {
                        TextMeshPro text = t.gameObject.GetComponent<TextMeshPro>();
                        text.SetText("Active Cases " + stateInfo[i]["active"]);
                    }
                    if (t.tag == "deaths")
                    {
                        TextMeshPro text = t.gameObject.GetComponent<TextMeshPro>();
                        text.SetText("Deaths " + stateInfo[i]["deaths"]);
                    }
                    if (t.tag == "recovered")
                    {
                        TextMeshPro text = t.gameObject.GetComponent<TextMeshPro>();
                        text.SetText("Recovered " + stateInfo[i]["recovered"]);
                    }
                }
            }
                
            
        }


            
 
            
        
        
    }

  
}
