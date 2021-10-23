using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderBody : MonoBehaviour
{
    // System.Collections.IEnumerator Drop()
    // {

    //     while(true)
    //     {   
            
    //         if(col.gameObject.tag == "bullet")
    //         {
               
    //             yield return new WaitForSeconds(1);
    //        }
    //        else
    //        {
    //             yield return null;
    //        }
    //     }
    // }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnCollisionEnter(Collision col)
   {
    if (col.gameObject.tag == "bullet")
    {
        // a rigidbody tagged as "bullet" hit the enemies
        transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = transform.up*5;
    }
   }
}
