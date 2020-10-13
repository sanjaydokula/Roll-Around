using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float movementSpeed = 50.0f;
    [SerializeField]
    private GameObject bulletPrefab;
    public Transform target;
    private Vector3 relativePos;
    private float firerate = 15f;
    private float timeToFire;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space))
            if (Time.time > timeToFire)
            {
                Shoot();
                timeToFire = Time.time + 1/firerate;
            }
        relativePos = target.position - transform.position;
        transform.RotateAround(target.position, Vector3.forward, -movement * Time.deltaTime * movementSpeed);
        Debug.Log("Player Position = " + transform.position);
        Debug.Log("Land Position = " + target.position);
        Debug.Log("relative position = " + relativePos);
    }

    public void Shoot()
    {
        GameObject pref = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        pref.GetComponent<Rigidbody2D>().AddForce(-relativePos * 400f);
        Destroy(pref, 3.0f);
    }
}
