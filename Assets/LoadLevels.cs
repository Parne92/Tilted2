using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour {
    public int Level;
	

    void OnTriggerEnter2D(Collider2D other)
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(Level);
    }
}
