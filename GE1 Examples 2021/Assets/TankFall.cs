using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFall : MonoBehaviour
{
    public GameObject tankrain;
    System.Collections.IEnumerator Drop()
    {
        int maxCount = 5;
        int count =0;
        while(true)
        {   
            if(count<maxCount)
            {
            
                GameObject tank = GameObject.Instantiate(tankrain);
                tank.transform.position = new Vector3(0, 20, 0);
                tank.AddComponent<Rigidbody>();
                tank.tag = "tankrain";
                count++;
                
                yield return new WaitForSeconds(1);
           }
           else
           {
                yield return null;
           }
        }
    }

    public void OnEnable()
    {
        StartCoroutine(Drop());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
