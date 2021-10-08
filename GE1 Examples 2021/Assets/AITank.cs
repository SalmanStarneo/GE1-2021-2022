using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public float rotationSpd = 180f;
    public Transform player;    

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using
            float theta = (2.0f*Mathf.PI)/(float)numWaypoints;
            // Gizmos.color = Color.green;
            // Gizmos.DrawWireSphere(pos, 1);
            
            
            for(int i = 0; i < numWaypoints; i++)
            {
                float angle = theta * i;
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;
                waypoints.Clear();
            
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(new Vector3(x,0,z), 1);
            }
        }
    }

    // Use this for initialization
    void Awake () {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List
             float theta = (2.0f*Mathf.PI)/(float)numWaypoints;


            // List<Vector3>wayPointCordinet= new List;

              for(int i = 0; i < numWaypoints; i++)
            {
                float angle = theta * i;
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;
                // waypoints.Clear();
                waypoints.Add(new Vector3(x,0,z));
                // wayPointCordinet.Add(new Vector3(x,0,z));

                
            }
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        Quaternion rotTarget = Quaternion.LookRotation(waypoints[current] - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, (rotationSpd * Time.deltaTime));

        if(transform.rotation == rotTarget)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(Vector3.Distance(waypoints[current],transform.position) < 1f)
        {
            current+=1;
        }
        if(current == waypoints.Count)
        {
            current=0;
        }
        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toOther = player.position - transform.position;

        if((Vector3.Dot(forward, toOther)) < 0)
        {
            GameManager.Log("Enemy spotted at 6 O'Clock!");
        }
        else if(Vector3.Dot(forward, toOther) > 0)
        {
            GameManager.Log("Enemy Spotted at 12 O'Clock!");
        }
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        float angle =Mathf.Acos(Vector3.Dot(transform.forward,toOther)/toOther.magnitude)*Mathf.Rad2Deg;

        if(angle < 45)
        {
            if(Vector3.Distance(player.position,transform.position)< 10f)
            {
                GameManager.Log("Enemy! has been Found!");
            }
            else
            {
                GameManager.Log("Must have scared them!");
            }
        }
        else
        {
            GameManager.Log("I guess I was just Imagining things");
        }
    }
}
