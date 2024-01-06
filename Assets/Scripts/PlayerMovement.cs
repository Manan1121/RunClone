using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 12.0f;
    Rigidbody rigidbody1;
    bool onGround = true;
    //on the top side
    bool top = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20.0f;
        rigidbody1 = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10 || transform.position.y < -3)
            SceneManager.LoadScene("LoseScreen");

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            if (!top)
                rigidbody1.AddForce(Vector3.up * 4f, ForceMode.Impulse);
            else if (top)
                rigidbody1.AddForce(Vector3.down * 4f, ForceMode.Impulse);
            //so you cant jump while in mid air
            onGround = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            //changes gravity depending on wether it is on the top or the bottom
            onGround = false;
            if (!top)
            {
                Physics.gravity = new Vector3(0, 9.81f, 0);
                rigidbody1.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                top = true;
            }
            else if (top)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
                rigidbody1.AddForce(Vector3.down * 5f, ForceMode.Impulse);
                top = false;
            }
        }
        Debug.Log(onGround);
    }
    private void FixedUpdate()
    {
        //auto move forward
        //left and right
        rigidbody1.AddForce(Vector3.forward * Time.deltaTime * speed *2, ForceMode.Force);
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody1.AddForce(Vector3.left * Time.deltaTime * speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody1.AddForce(Vector3.right * Time.deltaTime *speed, ForceMode.Force);
        }
        
    }
    void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
    void onCollisionEnter(Collision collision)
    {
        onGround = true;
        if (collision.gameObject.name.Contains("obs1") || collision.gameObject.name.Contains("obs2"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }
}

