using UnityEngine;
using System.Collections;
public class PortalSpawner : MonoBehaviour
{
    
    public string PortalSpawn = "PortalPress";
    public GameObject Portal;
    public GameObject Pengu;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Portal,new Vector2(Pengu.transform.position.x+3,Pengu.transform.position.y),transform.rotation);
        }
    }
}