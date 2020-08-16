using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public float carspeed;
    public float maxpos=2.1f;
    Vector3 position;
    public UImanager ui;
    public audiomanager am;
    bool currentPlatformAndroid = false;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
        //ui = GetComponent<UImanager>();

        am.Engine.Play();
        position = transform.position;
        if (currentPlatformAndroid)
            System.Diagnostics.Debug.Print("Android");
        else
            System.Diagnostics.Debug.Print("Windows");

    }

    // Update is called once per frame
    void Update()
    {if (currentPlatformAndroid == true)
        { //TouchMove();
            AccelerometerMove();
        }
        else
        {
            position.x += Input.GetAxis("Horizontal") * carspeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -2.1f, 2.1f);
            transform.position = position;
            
        }
        position = transform.position;
        position.x = Mathf.Clamp(position.x, -2.1f, 2.1f);
        transform.position = position;
      
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="enemycar")
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
            ui.gameoveractivate();
            am.Engine.Stop();
        }
    }
    void AccelerometerMove()
    {
        float x = Input.acceleration.x;
        if (x < -0.1f)
        {
            MoveLeft();

        }
        else if(x>0.1f)
        {
            MoveRight();

        }
        else
        {
            SetVelocityZero();
        }
    }
    void TouchMove()
    {
if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if(touch.position.x<middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }
            else
            {
                SetVelocityZero();
            }
        }
    }
    public void MoveLeft() {
        rb.velocity = new Vector2(-carspeed, 0);
    }
    public void MoveRight() {
        rb.velocity = new Vector2(carspeed, 0);
    }
    public void SetVelocityZero() {
        rb.velocity = Vector2.zero;
    }
}
