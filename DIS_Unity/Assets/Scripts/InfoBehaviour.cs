
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    const float speed = 0.05f;
    [SerializeField]
    Transform SectionInfo;
    Vector3 s;
    Vector3 desiredScale;
    private Transform p;

    //Variable initialization
    private void Start()
    {
        p = SectionInfo;
        s.Set(0.08f, 0.08f, 0.08f);
        desiredScale = s;
    }
    //Anmimating the pop up behaviour using Lerp
    void Update()
    {
        p.localScale = Vector3.Lerp(p.localScale, desiredScale, Time.deltaTime + speed);
    }
    //Opens the Info
    public void openInfo()
    {
        desiredScale = Vector3.one;
    }
    //Closes the info
    public void closeInfo()
    {
        desiredScale = s;
    }
}
