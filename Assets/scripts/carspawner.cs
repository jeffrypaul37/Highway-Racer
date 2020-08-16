using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour
{
    public GameObject[] cars;
    int carno;
    public float maxpos=2.1f;
    public float delaytimer = 1f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = delaytimer;
       
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carpos = new Vector3(Random.Range(-2.1f, 2.1f), transform.position.y, transform.position.z);
            carno = Random.Range(0, 5);
            Instantiate(cars[carno], carpos, transform.rotation);
            timer = delaytimer;
        }

    }
}
