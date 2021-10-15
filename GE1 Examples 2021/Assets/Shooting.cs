using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int fireRate = 5;

    public GameObject bulletPrefab;

    public Transform bulletspawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Fire1")>0)
        {
            GameObject b = GameObject.Instantiate<GameObject>(bullet);
            b.transform.position=bulletspawn.transform.position;
            b.transform.rotation=bulletspawn.rotation;
        }        
    }
}
