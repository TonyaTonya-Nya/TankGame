using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{
    private float rotateSpeed = 5f;
    private float moveSpeed = 5f;

    public Camera mainCamera;
    public Camera sniperCamera;
    public GameObject tank;
    public GameObject bulletPrefab;
    public Image sniper;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        tank.GetComponent<Rigidbody>().velocity = tank.transform.forward * v * moveSpeed;

        float h = Input.GetAxis("Horizontal");
        tank.GetComponent<Rigidbody>().angularVelocity = tank.transform.up * h * rotateSpeed;


        Attack();
    }

    void Attack()
    {

        //發射鍵_keyCode可以在Inspector面板設定
        if (Input.GetMouseButtonDown(0))
        {
            //砲管前方
            Vector3 vec = tank.transform.position + tank.transform.forward * 2 + tank.transform.up * 2;

            //滑鼠射線
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //創造子彈
            GameObject bullet = GameObject.Instantiate(bulletPrefab, vec, tank.transform.rotation) as GameObject;

            //新增力
            bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 3000);

            bullet.transform.LookAt(bullet.transform.position + ray.direction, bullet.transform.up);
        }

        if (Input.GetMouseButtonDown(1))
        {
            mainCamera.gameObject.SetActive(!mainCamera.gameObject.activeSelf);
            sniperCamera.gameObject.SetActive(!sniperCamera.gameObject.activeSelf);
            sniper.gameObject.SetActive(sniperCamera.gameObject.activeSelf);

            if (sniperCamera.gameObject.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }



}