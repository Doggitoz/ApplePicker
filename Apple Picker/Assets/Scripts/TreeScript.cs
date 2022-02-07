/***
 * Created By: Coleton Wheeler
 * Date Created: 1/31/22
 * 
 * Last Edited By: 2/7/22
 * Date Edited: 1/31/22
 * 
 * Description: Controls apple tree and movement
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float leftAndRightEdge = 16f;
    [SerializeField] private float chanceToChangeDirections = 0.02f;
    [SerializeField] private float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        Vector3 applePos = transform.position;
        float random = Random.Range(0.8f, 1.2f);
        Vector3 randomAppleSize = new Vector3(random, random, random);
        applePos.y += 3; //My tree was weird and spawned them below
        apple.transform.position = applePos;
        apple.transform.localScale = randomAppleSize;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        //Move tree every frame
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
