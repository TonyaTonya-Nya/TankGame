using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reborn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    private float t = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (t >= 0)
        {
            t -= Time.deltaTime;
        }

        if (t < 0)
        {
            int k = Random.Range(280, 350);
            int l = Random.Range(280, 350);
            t = 2;

            //創造敵人
            GameObject e = GameObject.Instantiate(enemy, new Vector3(k, -23, l), Quaternion.identity) as GameObject;
        }
    }
}
