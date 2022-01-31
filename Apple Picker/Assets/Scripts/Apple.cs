/***
 * Created By: Coleton Wheeler
 * Date Created: 1/31/22
 * 
 * Last Edited By: N/A
 * Date Edited: 1/31/22
 * 
 * Description: Despawns apples
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        //transform.localScale += Vector3.one * 0.2f;
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
