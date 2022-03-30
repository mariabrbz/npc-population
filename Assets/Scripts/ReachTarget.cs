using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachTarget : MonoBehaviour
{
    public GameObject[] foodAreas;
    public GameObject[] dropAreas;
    public float minSpeed;
    public float maxSpeed;

    private float speed;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed + 1);
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // handle step from ant to target
        // Vector3 dist = foodAreas[0].transform.position - transform.position;
        // Vector3 step = dist.normalized * speed * Time.deltaTime;
        // if (step.magnitude > dist.magnitude) {
        //     step = dist;
        // }

        // // move ant
        // controller.Move(step);
        //gameObject.GetComponent<Rigidbody2D>().AddForce((foodAreas[0].transform.position - transform.position) * speed);
        transform.position = Vector3.MoveTowards(transform.position, foodAreas[0].transform.position, speed * Time.deltaTime);
    }
}
