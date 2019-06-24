using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormUhal : MonoBehaviour {
    public int speed;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        /*  if (Input.GetButtonDown("RotateRight"))
          {
              transform.Rotate(Vector3.zAngle * speed);
          }
          if (Input.GetButtonDown("RotateLeft"))
          {
              transform.Rotate(Vector3.left * speed);
          }*/
        float RotateLeft = Input.GetAxis("RotateLeft");
       // if (Input.GetButtonDown("RotateLeft"))
        transform.Rotate(0, 0, RotateLeft *speed, Space.World);
        //if (Input.GetAxis("RotateRight"))
        //transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
  

    }
}
