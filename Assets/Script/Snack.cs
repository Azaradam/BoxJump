using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    public GameObject Particle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            var manager = GameObject.Find("SpawnManager").GetComponent<ScoreController>();
            manager.ScoreUp(5);
            var part = Instantiate(Particle, other.transform.position, Quaternion.identity);
            Destroy(part, 2);
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Magnet"))
        {
            float step = 2 * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, other.transform.position, step);
        }
    }


}
