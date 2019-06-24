using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portalize : MonoBehaviour
{
    public int Portal;
    public int XPos;
    public int YPos;
  
    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = new Vector2(XPos,YPos);
    }
}
