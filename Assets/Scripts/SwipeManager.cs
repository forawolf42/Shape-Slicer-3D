using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{

    Rigidbody rigid;

    private void OnEnable()
    {
        StartCoroutine("Continue");

    }
   

    // Update is called once per frame
    void Update()
    {
        DetectSwipe();
        rigid = gameObject.GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezeRotationX;

    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
           
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

           
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            
            currentSwipe.Normalize();

            //YUKARI
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                rigid.velocity = new Vector3(-20, 0, 0);
            }
            //AÞAÐI
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                rigid.velocity = new Vector3(15, 0,0 );

            }
            //SOL
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
                rigid.velocity = new Vector3(0, 0, -25);
            }
            //SAÐ
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                rigid.velocity = new Vector3(0, 0, 25);

            }
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    int dongu = 0;
    IEnumerator Continue() {
        
        
        if (gameObject.tag != "Player")
        {
            rigid = gameObject.GetComponent<Rigidbody>();
            rigid.AddForce(Vector3.back*100);
            yield return new WaitForSeconds(0.05f);
            dongu++;
            if (dongu > 10)
            {
                yield break;
            }
            else
            {
                StartCoroutine("Continue");

            }

        }
       
    }

}
