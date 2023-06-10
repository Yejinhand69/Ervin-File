using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    Vector2 targetPoint;



    // Start is called before the first frame update
    void Start()
    {
        targetPoint = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < .1f) targetPoint = pointB.position;

        if (Vector2.Distance(transform.position, pointB.position) < .1f) targetPoint = pointA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }


}
