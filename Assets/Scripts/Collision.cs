using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            CutScript.Cut(collision.transform, transform.position);
        }

    }

}
