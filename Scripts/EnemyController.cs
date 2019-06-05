using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	public Transform player;
	public NavMeshAgent agent;

    public Text scoreText;
    static int score = 0;

    public int hp = 100;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.tag == "Bullet"){
    		score = score + 1;
            Debug.Log("Score: " + score);
            scoreText.text = "Score: " + score;
            Destroy(gameObject);
            if(score >= 4){
                SceneManager.LoadScene(0);
                score = 0;
            }
    	}
    }

}
