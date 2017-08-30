using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    private static bool gameStarted;
    private static bool gameFinished;
    private static bool isPaused;
    private static int starsCounter = 0;
    [SerializeField]
    private UnityEngine.UI.Text startCounterText;
    private static UnityEngine.UI.Text starsText;

    private static List<BrickLine> brickLinesList = new List<BrickLine>();
    private bool timeReached =false;
    private bool movio = false;
    private int time;
    int actualTime = 0;
    private int spawnTimeInterval = 2;

    #region Getters and Setters

    public static bool GameFinished
    {
        get
        {
            return gameFinished;
        }

        set
        {
            gameFinished = value;
        }
    }

    public static bool GameStarted
    {
        get
        {
            return gameStarted;
        }

        set
        {
            gameStarted = value;
        }
    }

    public static bool IsPaused
    {
        get
        {
            return isPaused;
        }

        set
        {
            isPaused = value;
        }
    }

    public static int StarsCounter
    {
        get
        {
            return starsCounter;
        }

        set
        {
            starsCounter = value;
        }
    }

    #endregion

    void Start()
    {
        brickLinesList.Add(new BrickLine());
        starsCounter = 0;
        gameStarted = false;
        isPaused = false;
        gameFinished = false;
        starsText = startCounterText;
    }


    void Update()
    {
        actualTime = (int)Time.timeSinceLevelLoad;
        if (actualTime % spawnTimeInterval == 0 && actualTime > 0)
        {
            time = actualTime;
            timeReached = true;
        }
        if (timeReached && time != actualTime)
        {
            timeReached = false;
            for (int i = 0; i < brickLinesList.Count; i++)
            {
                brickLinesList[i].moveDownLine();
            }
            brickLinesList.Add(new BrickLine());
        }


        if (gameFinished)
        {
            finishGame();
        }
    }

    private void finishGame()
    {
        gameFinished = false;
        SettingsManager.saveMaxScore(starsCounter.ToString());
        Debug.Log("Game Over");
    }

    /// <summary>
    /// Add a 'quantity' number of stars in the stars counter;
    /// </summary>
    /// <param name="quantity">The specific quantity number that wnat to be added. 1 is for default</param>
    public static void sumStar(int quantity = 1)
    {
        starsCounter += quantity;
        starsText.text = starsCounter.ToString();
    }

    public static void destroyBrickLine(GameObject brickLine)
    {
        int i = 0;
        bool sw = false;
        while(!sw && i < brickLinesList.Count)
        {
            if (brickLine.Equals(brickLinesList[i].BrickLineGameObject))
            {
                brickLinesList.Remove(brickLinesList[i]);
                Destroy(brickLinesList[i].BrickLineGameObject);
                sw = true;
            }
            i++;
        }
    }

    public class BrickLine
    {

        #region Internal Parameters (Only private Access)
        private Vector3 startReferencePosition = new Vector3(-2.4f, 2.4f);
        private float unitX = 0.6f;
        private float unitY = 0.6f;
        private int numberOfBlocksInLine = 9;

        #region Bricks And Walls Prefabs
        //Al the posible spawnable Objects

        //Bricks
        private static GameObject blueBrickPreafb= Resources.Load("Bricks/BlueBrick") as GameObject;
        private static GameObject darkBlueBrickPrefab= Resources.Load("Bricks/DarkBlueBrick") as GameObject;
        private static GameObject darkGreenBrickPrefab = Resources.Load("Bricks/DarkGreenBrick") as GameObject;
        private static GameObject darkPinkBrickPrefab= Resources.Load("Bricks/DarkPinkBrick") as GameObject;
        private static GameObject darkVioletBrickPrefab= Resources.Load("Bricks/DarkVioletBrick") as GameObject;
        private static GameObject darkYellowBrickPrefab = Resources.Load("Bricks/DarkYellowBrick") as GameObject;
        private static GameObject greenBrickPrefab = Resources.Load("Bricks/GreenBrick") as GameObject;
        private static GameObject pinkBrickPrefab = Resources.Load("Bricks/PinkBrick") as GameObject;
        private static GameObject violetBrickPrefab = Resources.Load("Bricks/VioletBrick") as GameObject;
        private static GameObject yellowBrickPrefab = Resources.Load("Bricks/YellowBrick") as GameObject;
        //Walls
        private static GameObject blueWallPrefab = Resources.Load("Walls/BlueWall") as GameObject;
        private static GameObject cyanWallPrefab= Resources.Load("Walls/CyanWall") as GameObject;
        private static GameObject greenWallPrefab = Resources.Load("Walls/GreenWall") as GameObject;
        private static GameObject lightGreenWallPrefab = Resources.Load("Walls/LightGreenWall") as GameObject;
        private static GameObject orangeWallPrefab = Resources.Load("Walls/OrangeWall") as GameObject;
        private static GameObject pinkWallPrefab = Resources.Load("Walls/PinkWall") as GameObject;
        private static GameObject redWallPrefab = Resources.Load("Walls/RedWall") as GameObject;
        private static GameObject violetWallPrefab = Resources.Load("Walls/VioletWall") as GameObject;

        #endregion

        #region The array of the prefabs above to handle spawnable objects easier

        //Array with all the posible Spawnable Bricks Objects
        private GameObject[] brickPrefabsArray =
        {
            blueBrickPreafb,
            darkBlueBrickPrefab,
            darkGreenBrickPrefab,
            darkPinkBrickPrefab,
            darkVioletBrickPrefab,
            darkYellowBrickPrefab,
            greenBrickPrefab,
            pinkBrickPrefab,
            violetBrickPrefab,
            yellowBrickPrefab
        };

        //Array with all the posible Spawnable wall objects
        private GameObject[] wallPrefabsArray =
        {
            blueWallPrefab,
            cyanWallPrefab,
            greenWallPrefab,
            lightGreenWallPrefab,
            orangeWallPrefab,
            pinkWallPrefab,
            redWallPrefab,
            violetWallPrefab
        };

        #endregion

        //Actual Bircks of the BrickLine
        private static GameObject spawnable1;
        private static GameObject spawnable2;
        private static GameObject spawnable3;
        private static GameObject spawnable4;
        private static GameObject spawnable5;
        private static GameObject spawnable6;
        private static GameObject spawnable7;
        private static GameObject spawnable8;
        private static GameObject spawnable9;

        //Array of the objects above to handle the actual spawnable objects in the BrickLine easier
        private GameObject[] bricksOfLine =
        {
            spawnable1,
            spawnable2,
            spawnable3,
            spawnable4,
            spawnable5,
            spawnable6,
            spawnable7,
            spawnable8,
            spawnable9
        };
        #endregion

        private GameObject brickLineGameObject;

        public GameObject BrickLineGameObject
        {
            get
            {
                return brickLineGameObject;
            }
        }

        /// <summary>
        /// The Constructor Method of BrickLine Class (Object)
        /// </summary>
        public BrickLine()
        {
            brickLineGameObject = new GameObject("BrickLine");
            brickLineGameObject.transform.position = startReferencePosition;
            brickLineGameObject.tag = "Brick";
            //brickLineGameObject = Instantiate(new GameObject("BrickLine"), startReferencePosition, Quaternion.identity) as GameObject;
            for (int i = 0; i < numberOfBlocksInLine; i++)
            {
                int randomType = (int)Random.Range(0, 6);
                int randomRange = (int)Random.Range(1, 100);
                if (true/*randomType == 2 || randomType == 4*/)//Brick
                {
                    bool found = false;
                    int j = 0;
                    while (!found && j < brickPrefabsArray.Length)
                    {
                        if (brickPrefabsArray[j].GetComponent<Spawnable>().isInsideProbabilytInterval(randomRange))
                        {
                            bricksOfLine[i] = Instantiate(brickPrefabsArray[j], new Vector3(startReferencePosition.x + (unitX * i), startReferencePosition.y, 0), Quaternion.identity) as GameObject;
                            bricksOfLine[i].transform.SetParent(brickLineGameObject.transform);
                            found = true;
                        }
                        j++;
                    }

                }
                //else
                //    if (randomType == 3)//Wall
                //{
                //    bool found = false;
                //    int j = 0;
                //    while (!found && j < wallPrefabsArray.Length)
                //    {
                //        if (wallPrefabsArray[j].GetComponent<Spawnable>().isInsideProbabilytInterval(randomRange))
                //        {
                //            bricksOfLine[i] = Instantiate(wallPrefabsArray[j], new Vector3(startReferencePosition.x + (unitX * i), startReferencePosition.y, 0), Quaternion.identity) as GameObject;
                //            bricksOfLine[i].transform.SetParent(brickLineGameObject.transform);
                //            found = true;
                //        }
                //        j++;
                //    }
                //}
                //else
                //{
                //    //Space, Nothing is instantiated
                //}
                
            }
        }

        /// <summary>
        /// Moves down all the bricks in the BrickLine
        /// </summary>
        public void moveDownLine()
        {
            //brickLineGameObject.transform.position = Vector3.Lerp(brickLineGameObject.transform.position, new Vector3(brickLineGameObject.transform.position.x, brickLineGameObject.transform.position.y - unitY, 0), 0.06f);
            brickLineGameObject.transform.position = new Vector3(brickLineGameObject.transform.position.x, brickLineGameObject.transform.position.y - unitY, 0);
            //for (int i = 0; i < numberOfBlocksInLine; i++)
            //{
            //    Debug.Log(bricksOfLine[i]);
            //    //Debug.Log(bricksOfLine[i].GetComponent<Transform>().position);
            //    //this.bricksOfLine[i].transform.position = new Vector3(bricksOfLine[i].transform.position.x, bricksOfLine[i].transform.position.y - unidadY, 0f);
            //}
        }

    }
}
