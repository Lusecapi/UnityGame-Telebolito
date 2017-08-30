using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseZone : MonoBehaviour {

    [SerializeField]
    private GameObject loseMenuPrefab;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (collider.tag.Equals("Ball"))
        {
            LevelManager.GameFinished = true;
            GameObject menu= Instantiate(loseMenuPrefab);
            menu.GetComponent<LoseMenuScript>().ActualScore = LevelManager.StarsCounter;
        }
        Destroy(collider.gameObject);

    }
}
