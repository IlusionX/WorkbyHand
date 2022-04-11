using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_p : MonoBehaviour
{
    Color c;
    SpriteRenderer sr;
    int state = 0;
    float contador = 0;
    float flutuarSpeed;

    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        c = sr.color;
        flutuarSpeed = Random.RandomRange(1, 3);
    }
    
    void Update()
    {
        switch (state) {
            case 0:
                Ignite();
                break;
            case 1:
                CoolUp();
                break;
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = c;
        contador += Time.deltaTime;
    }

    void Ignite() {
        this.transform.localScale += Vector3.one * Time.deltaTime;
        c.g += 0.4f * Time.deltaTime;
        if (contador > 1) {state = 1;contador = 0; }

        transform.position += Vector3.up * Time.deltaTime * flutuarSpeed;
    }

    void CoolUp() {
        this.transform.localScale -= Vector3.one * Time.deltaTime;
        c.r -= 0.5f * Time.deltaTime;
        c.g -= 0.5f * Time.deltaTime;
        c.b -= 0.5f * Time.deltaTime;
        if (contador > 2) { Destroy(this.gameObject); }

        transform.position += Vector3.up * Time.deltaTime * flutuarSpeed/3;
    }
}
