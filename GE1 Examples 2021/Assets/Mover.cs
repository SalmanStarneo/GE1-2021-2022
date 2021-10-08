using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Mover : MonoBehaviour
{
    private static StringBuilder message = new StringBuilder();

    public Transform target;

    public float spd;

    public void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "" + message);
        if (Event.current.type == EventType.Repaint)
        {
            message.Length = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      float distance = Vector3.Distance(target.position,transform.position);
      spd=distance/Time;   
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position,transform.position);
        Vector3 toTarget = target.position - transform.position;
        float distance1 = toTarget.magnitude;

        message.Append("Distance: "+distance+"\n");
        message.Append("Distnace1: "+distance1);

        // toTarget=Vector3.Normalize(toTarget);
        // // message.Append("");

        // if(distance1>0.1f)
        // {
        //     // spd = distance/Time;
        //     transform.position=transform.position+(toTarget+spd*Time.deltaTime);
        // }        
        // message.Append("Time taken: "+Time.TimeSinceLevelLoad);
        
    }
}
