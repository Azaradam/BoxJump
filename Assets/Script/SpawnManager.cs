using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float speed;

    public GameObject[] platformSet;
    public Transform spawnPosition;


    bool gameOver;

    private void Start()
    {
        speed = 4f;
        StartCoroutine("SpeedUp");
    }

    public void Spawn()
    {
        var set = Random.Range(0,platformSet.Length);
        var child = Instantiate(platformSet[set], spawnPosition.position, Quaternion.identity, gameObject.transform);
        child.GetComponent<PlatformSetController>().speed = speed;
    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(10);
        speed = speed + 0.2f;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<PlatformSetController>().speed = speed;
        }

        StartCoroutine("SpeedUp");
    }

    private void Update()
    {
        if (gameOver && speed >= 0)
        {
            speed -= Time.deltaTime * 2;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<PlatformSetController>().speed = speed;
            }
        }
    }

    public void SpeedDown()
    {
        StopCoroutine("SpeedUp");
        gameOver = true;
    }


}
