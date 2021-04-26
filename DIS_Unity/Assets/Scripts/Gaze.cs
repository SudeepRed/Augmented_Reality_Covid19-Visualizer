using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    
    List<InfoBehaviour> infos = new List<InfoBehaviour>();
    private GameObject[] mapState;
    // Start is called before the first frame update
    void Start()
    {
        infos = FindObjectsOfType<InfoBehaviour>().ToList();
        mapState= GameObject.FindGameObjectsWithTag("mapState");

    }
  
    //Raycast to check whcih mesh is hit
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward, out RaycastHit hit))
        {
            Debug.Log(hit.collider.name);
            GameObject go = hit.collider.gameObject;
            Debug.Log(hit.transform.name);
            //if a mesh with tag "mapState" is hit then open its info
            if (go.CompareTag("mapState"))
            {
                
                Debug.Log("hit");
                openInfo(go.GetComponent<InfoBehaviour>(),go);
            }
        }
        
    }
    //Function to call openInfo from info behaviour script of the trasnfrom
    void openInfo(InfoBehaviour desiedInfo,GameObject o)
    {
        foreach(InfoBehaviour info in infos)
        {
            if (info == desiedInfo)
            {
                info.openInfo();
            }
            else
            {
                info.closeInfo();
            }
        }
        foreach (GameObject obj in mapState)
        {
            if (obj == o)
            {
                if (obj.GetComponent<Floater>() != null)
                    obj.GetComponent<Floater>().rotate = true;
            }
            else
            {
                if (obj.GetComponent<Floater>() != null)
                    obj.GetComponent<Floater>().rotate = false;
            }
        }
    }
    
    void closeAll()
    {
        foreach (InfoBehaviour info in infos)
        {
            info.closeInfo();
        }
    }
}
