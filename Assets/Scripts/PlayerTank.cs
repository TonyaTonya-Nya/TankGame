using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    private float rotateSpeed = 5f;
    private float moveSpeed = 5f;

    public Camera mainCamera;
    public GameObject tank;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        transform.GetComponent<Rigidbody>().velocity = transform.forward * v * moveSpeed;

        float h = Input.GetAxis("Horizontal");
        transform.GetComponent<Rigidbody>().angularVelocity = transform.up * h * rotateSpeed;

        Attack();
    }

    void Attack()
    {
        //發射鍵_keyCode可以在Inspector面板設定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //在發射位置ShootPos例項化子彈
            GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;

            //方法二：可以給物體新增一個方向的力
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 30);
        }
    }



}