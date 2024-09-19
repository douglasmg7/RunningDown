using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange;
    public GameObject projectilePrefab;

    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        if (ReachRightHorizontalRange())
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (ReachLeftHorizontalRange())
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    bool ReachRightHorizontalRange()
    {
        if (transform.position.x > xRange) return true;
        return false;
    }

    bool ReachLeftHorizontalRange()
    {
        if (transform.position.x < -xRange) return true;
        return false;
    }
}
