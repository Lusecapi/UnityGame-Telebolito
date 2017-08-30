using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    //http://answers.unity3d.com/questions/170362/keep-constant-velocity.html

    [SerializeField]
    private float force = 10f;
    [SerializeField]
    private float ballVelocity;
    private Rigidbody2D myRigidBody;
    private bool isMoving;

    public Rigidbody2D MyRigidBody
    {
        get
        {
            return myRigidBody;
        }

        set
        {
            myRigidBody = value;
        }
    }

    // Use this for initialization
    void Start() {

        myRigidBody = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update() {

    }


    void FixedUpdate()
    {
        //if (LevelManager.GameStarted)
        //{
        //    isMoving = true;
        //}
        if (LevelManager.GameStarted && !isMoving)
        {
            isMoving = true;
            myRigidBody.isKinematic = false;
            transform.SetParent(null);
            myRigidBody.AddForce(new Vector2(force, force));
        }

        myRigidBody.velocity = ballVelocity * (myRigidBody.velocity.normalized);

        if (isMoving)
        {
            
            if (myRigidBody.velocity.x > -2 && myRigidBody.velocity.x < 2)
            {
                if (Mathf.Sign(myRigidBody.velocity.x) == 1)
                {
                    myRigidBody.AddForce(new Vector2(force, 0f));
                }
                else
                {
                    myRigidBody.AddForce(new Vector2(-force, 0f));
                }
            }
            if (myRigidBody.velocity.y > -2 && myRigidBody.velocity.y < 2)
            {
                if (Mathf.Sign(myRigidBody.velocity.y) == 1)
                {
                    myRigidBody.AddForce(new Vector2(0f, force));
                }
                else
                {
                    myRigidBody.AddForce(new Vector2(0f, -force));
                }

            }
            
        }

        //       if ((rigidbody2D.velocity.y < min_y_velocity) &&
        //(Mathf.Sign(rigidbody2D.velocity.y) == 1))
        //       {
        //           rigidbody2D.AddForce(new Vector2(0, 5f));
        //       }
        //       else if ((rigidbody2D.velocity.y > -min_y_velocity) &&
        //       (Mathf.Sign(rigidbody2D.velocity.y) == -1))
        //       {
        //           rigidbody2D.AddForce(new Vector2(0, -5f));
        //       }

        //if (Input.GetMouseButtonUp(0) && !gameStart)
        //{
        //    myRigidBody.isKinematic = false;
        //    transform.SetParent(null);
        //    myRigidBody.AddForce(new Vector2(force, force));
        //    gameStart = true;
        //}
    }
}
