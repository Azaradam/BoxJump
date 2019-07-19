using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            var manager = GameObject.Find("SpawnManager").GetComponent<ScoreController>();
            manager.ScoreUp(5);
            Destroy(gameObject);
        }
        
    }
}
