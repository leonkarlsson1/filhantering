using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Ströga : MonoBehaviour
{
    public float speed = 1f;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,0, speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(0,0, -speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(-speed * Time.deltaTime,0,0);
        }

        
        if(Input.GetMouseButton((int)MouseButton.Left))
       {
            float spelareOchKameraPosDiffZ = transform.position.z - Camera.main.transform.position.z;
            Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * spelareOchKameraPosDiffZ);

            v.y=0;
            v.Normalize();
            float aimAngle = Mathf.Atan2(v.y,v.x);
            float spread = Random.Range(-0.4f,0.4f);
            aimAngle += spread;
            Vector3 direction = new Vector3(Mathf.Sin(aimAngle), 0,Mathf.Cos(aimAngle));

            GameObject b = Instantiate(bulletPrefab);
            b.transform.position = transform.position;
            
       }

       
    }
}