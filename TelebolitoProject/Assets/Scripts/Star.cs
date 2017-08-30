using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Bat") && !LevelManager.GameFinished){
            LevelManager.sumStar();
            Destroy(gameObject);
        }
    }
}
