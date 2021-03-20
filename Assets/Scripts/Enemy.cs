using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public GameObject bulletPrefab;

    private float t = 10;
    private float y = 10;
    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Tank");
    }



    // Update is called once per frame
    void Update()
    {
        if (nav == null)
        {
            nav = GetComponent<NavMeshAgent>();
        }
        if (nav != null && player != null && y < 0)
        {

            nav.SetDestination(player.transform.position);
        }

        if (y >= 0)
        {
            y -= Time.deltaTime;
        }


        if (t >= 0)
        {
            t -= Time.deltaTime;
        }

        if (transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }

        if (t < 0)
        {
            t = 2;
            //砲管前方
            Vector3 vec = transform.position + transform.forward * 2 + transform.up * 2;

            //滑鼠射線
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //創造子彈
            GameObject bullet = GameObject.Instantiate(bulletPrefab, vec, transform.rotation) as GameObject;

            //新增力
            bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 5000);

            bullet.transform.LookAt(bullet.transform.position + ray.direction, bullet.transform.up);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 5)
        {
            Destroy(this.gameObject);
        }

    }
}
