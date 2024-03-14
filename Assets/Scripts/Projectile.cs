using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is responsible for instantiating and firing new physics objects into the scene on button presses
// This script will set the velocity of object it fires at the moment it fires them, and then has no further effect
public class Projectile : MonoBehaviour
{
    public float launchSpeed = 15.0f; // Slingshot power
    //public float launchAngle = 0.0f;
    //public float launchHeight;
    private Vector3 launchVelocity; // Initial velocity
    private bool capped;

    // For mouse input
    public float maxDistance = 5.0f;
    private float distance;
    private Vector3 direction; // Use for launch angle
    private Vector3 mousePos;
    private Vector3 XYPos;
    private Vector3 worldPos;

    private Rigidbody projectile;

    // WEEK 5
    public GameObject projectileToClone;
    //public GameObject targetToClone;

    void LaunchBall()
    {
        ////Debug.Log("Launch!");
        //// 1. Update velX and velY based on horizontal and vertical components of launch velocity & launch angle
        //// Sin(angle) = O/H
        //// Cos(angle) = A/H
        //// O = Sin(angle) * H
        //// A = Cos(Angle) * H
        //velX = Mathf.Cos((launchAngle) * (3.14f / 180)) * launchSpeed;
        //velY = Mathf.Sin((launchAngle) * (3.14f / 180)) * launchSpeed;
        //// 2. Assign position to new launch height and re-launch the ball!

        //// WEEK FIVE LESSON
        //// 1. spawn new object
        //GameObject newObject = Instantiate(projectileToClone);

        //// Set new projectile's position to the postion of the gameobject containing this launcher script
        //newObject.transform.position = transform.position;

        //TheBodies body = newObject.GetComponent<TheBodies>();

        if (capped)
        {
            launchVelocity = (-maxDistance * launchSpeed / projectile.mass) * direction;
        }
        else
        {
            launchVelocity = (-distance * launchSpeed / projectile.mass) * direction;
        }

        projectile.velocity = launchVelocity;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(1)) // Happens only once when right click is pressed :)
        //{
        //    mousePos = Input.mousePosition;
        //    XYPos = new Vector3(mousePos.x, mousePos.y, transform.position.z + 5);
        //    worldPos = Camera.main.ScreenToWorldPoint(XYPos);

        //    GameObject newObject = Instantiate(targetToClone);
        //    newObject.transform.position = worldPos;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newObject = Instantiate(projectileToClone);
            projectile = newObject.GetComponent<Rigidbody>();
        }

        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            XYPos = new Vector3(mousePos.x, mousePos.y, transform.position.z +5);
            worldPos = Camera.main.ScreenToWorldPoint(XYPos);

            Vector3 displacement = worldPos - transform.position;
            direction = Vector3.Normalize(displacement);
            distance = Vector3.Magnitude(displacement);

            if (distance > maxDistance)
            {
                Debug.DrawLine(worldPos, transform.position, Color.cyan, 0, false);

                // Normalize the direction and multiply by maxDistance to get the capped vector
                Vector3 cappedVec = transform.position + direction * maxDistance;

                Debug.DrawLine(transform.position, cappedVec, Color.blue, 0, false);

                projectile.transform.position = cappedVec;

                capped = true;
            }
            else
            {
                Debug.DrawLine(worldPos, transform.position, Color.blue, 0, false);

                projectile.transform.position = worldPos;

                capped = false;
            }
            //Debug.Log(capped);
        }

        if(Input.GetMouseButtonUp(0))
        {
            LaunchBall();
        }

    }

}
