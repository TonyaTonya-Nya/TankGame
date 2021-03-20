using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public ParticleSystem ex;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + GetComponent<Rigidbody>().velocity, transform.up);

    }

    void OnCollisionEnter(Collision collision)
    {
        a();
       
    }

    void a()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
        ex.gameObject.SetActive(true);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(this.gameObject, 1.2f);
    }
}
