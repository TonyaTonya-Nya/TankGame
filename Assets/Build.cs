using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Build : MonoBehaviour
{
   public  int hp = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void c()
    {
        SceneManager.LoadScene(1);
    }
    void OnCollisionEnter(Collision collision)
    {
        hp--;

    }
}
