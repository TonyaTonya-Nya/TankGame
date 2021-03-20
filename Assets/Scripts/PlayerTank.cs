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
    public ConGUI gui;
    public GameObject[] effectObj;

    public AudioSource shootSource;

    public Text kill;
    public Text hp;
    public Text my;

    public int score=0;
    public int mp = 800;
    private float t = 0;
    public Build bu;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("b",8,2);
        
    }

    void b()
    {
        mp -= Random.Range(0, 5);
    }
    // Update is called once per frame
    void Update()
    {
        kill.text = score.ToString();
        hp.text = bu.hp.ToString();
        my.text = mp.ToString();
        float v = Input.GetAxis("Vertical");
        tank.GetComponent<Rigidbody>().velocity = tank.transform.forward * v * moveSpeed + new Vector3(0, tank.GetComponent<Rigidbody>().velocity.y, 0);

        float h = Input.GetAxis("Horizontal");
        tank.GetComponent<Rigidbody>().angularVelocity = tank.transform.up * h * rotateSpeed;

        if (tank.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }

        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
      
        Attack();
    }

    void Attack()
    {

        //發射鍵_keyCode可以在Inspector面板設定
        if (Input.GetMouseButtonDown(0))
        {
            shootSource.Play();
            //砲管前方
            Vector3 vec = tank.transform.position + tank.transform.forward * 2 + tank.transform.up * 2;

            //滑鼠射線
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (gui.nowBullet() == 0)
            {
                //創造子彈
                GameObject bullet = GameObject.Instantiate(effectObj[gui.nowBullet()], vec, tank.transform.rotation) as GameObject;

                //新增力
                bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 5000);

                bullet.transform.LookAt(bullet.transform.position + ray.direction, bullet.transform.up);
            }
            else if (gui.nowBullet() == 1)
            {

                //創造子彈
                GameObject bullet = GameObject.Instantiate(effectObj[gui.nowBullet()], vec, tank.transform.rotation) as GameObject;
                //創造子彈
                GameObject bulletL = GameObject.Instantiate(effectObj[gui.nowBullet()], vec - new Vector3(1, 0, 0), tank.transform.rotation) as GameObject;
                //創造子彈
                GameObject bulletR = GameObject.Instantiate(effectObj[gui.nowBullet()], vec + new Vector3(1, 0, 0), tank.transform.rotation) as GameObject;


                Vector3 vecL = ray.direction;
                vecL.x -= 0.2f;
                // vecL.z -= 0.2f;
                Vector3 vecR = ray.direction;
                vecR.x += 0.2f;
                // vecR.z += 0.2f;
                //新增力
                bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 2500);
                //新增力
                bulletL.GetComponent<Rigidbody>().AddForce(vecL * 2500);
                //新增力
                bulletR.GetComponent<Rigidbody>().AddForce(vecR * 2500);

            }
            else if (gui.nowBullet() == 2)
            {
                //創造子彈
                GameObject bullet = GameObject.Instantiate(effectObj[gui.nowBullet()], vec, tank.transform.rotation) as GameObject;

                //新增力
                bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 3000);

                bullet.transform.LookAt(bullet.transform.position + ray.direction, bullet.transform.up);
            }

        }

        if (t >= 0)
        {
            t -= Time.deltaTime;

           
        }

 

        //發射鍵_keyCode可以在Inspector面板設定
        if (Input.GetMouseButton(0) && t < 0 && gui.nowBullet() == 3)
        {

            shootSource.Play();

            //GetComponent<AudioSource>().Play(shoot);
            t = 0.1f;
            //砲管前方
            Vector3 vec = tank.transform.position + tank.transform.forward * 2 + tank.transform.up * 2;

            //滑鼠射線
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);



            //創造子彈
            GameObject bullet = GameObject.Instantiate(effectObj[gui.nowBullet()], vec, tank.transform.rotation) as GameObject;

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