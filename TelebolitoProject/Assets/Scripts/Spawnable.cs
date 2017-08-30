using UnityEngine;
using System.Collections;

public class Spawnable : MonoBehaviour {

    [SerializeField]
    private Vector2 spawnProbabilityInterval;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// To verify if the random number generated in LevelManager script is inside its probability interval (Closed interval [a b])
    /// and it can be spawned.
    /// </summary>
    /// <param name="number"> The random number</param>
    /// <returns>true if the numbers is between it probability interval, false in aany other case</returns>
    public bool isInsideProbabilytInterval(int number)
    {
        if (number >= spawnProbabilityInterval.x && number <= spawnProbabilityInterval.y)
        {
            return true;
        }
        return false;
    }
}
