using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + GetComponent<Rigidbody>().velocity, transform.up);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
