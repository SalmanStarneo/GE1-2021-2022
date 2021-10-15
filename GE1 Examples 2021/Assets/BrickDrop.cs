using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDrop : MonoBehaviour
{
    System.Collections.IEnumerator Drop()
    {
        while(true)
        {
            GameObject block = GameObject.creatPrimitive(PrimitiveTr);
            block.transform.position= new Vector3(0,20,0);
            block.Addcomponent<Rigidbody>();
            yield return new WaitForSeconds(1);
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
