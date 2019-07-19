using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSetController : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Detector")
        {
            var manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            manager.Spawn();
        }else if (other.tag == "Deleter")
        {
            Destroy(gameObject);
        }
    }

}
