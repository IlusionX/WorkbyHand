using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Particle : MonoBehaviour
{
    [SerializeField]
    GameObject p;
    int speed = 2;
    Camera c;

    void Start()
    {
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Boundaries();
        Particle();
    }
    void Boundaries() {
        if (this.transform.position.x > 5) this.transform.position = new Vector3(5, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x < -5) this.transform.position = new Vector3(-5, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.z > 5) this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,5);
        if (this.transform.position.z < -5) this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,-5);
    }

    void Move() {
        if (Input.GetKey(KeyCode.A)) this.transform.position += Vector3.left * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.W)) this.transform.position += Vector3.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.S)) this.transform.position += Vector3.back * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.D)) this.transform.position += Vector3.right * Time.deltaTime * speed;

    }

    void Particle() {
        Vector3 offset = new Vector3(Random.Range(-100,100), Random.Range(-100, 100), Random.Range(-100, 100));
        Instantiate(p, this.transform.position + offset/100,c.transform.rotation);
    }
}
