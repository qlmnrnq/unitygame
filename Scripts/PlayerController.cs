using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	Rigidbody rb, rbClone;
    public GameObject bullet;
    GameObject bulletClone;
    float x, y, z;

    int hp = 100;
    public Text hpText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * moveVertical * 50f); 

        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(transform.right * moveHorizontal * 50f); 

        if(Input.GetKeyDown("space")){
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
            //making new object - clone of bullet
            bulletClone = Instantiate(bullet, new Vector3(x, y, z), Quaternion.identity);
            rbClone = bulletClone.GetComponent<Rigidbody>();
            rbClone.AddForce(transform.forward * 2500f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            hp = hp - 10;
            hpText.text = "HP: " + hp;
            Debug.Log("HP: " + hp);
            if(hp <= 0){
                SceneManager.LoadScene(1);
            };
        };
    }
}
