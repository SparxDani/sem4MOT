using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform platform;
    private Vector3 leftLimit;
    private Vector3 rightLimit;
    public float speed = 2.0f;
    private Vector3 direction;

    void Start()
    {
        float halfPlatformWidth = platform.localScale.x / 2.0f;
        leftLimit = platform.position + new Vector3(-halfPlatformWidth, 0, 0);
        rightLimit = platform.position + new Vector3(halfPlatformWidth, 0, 0);
        direction = GetRandomDirection();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < leftLimit.x || transform.position.x > rightLimit.x)
        {
            ChangeDirectionAndRotate();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit.x, rightLimit.x), transform.position.y, transform.position.z);
    }

    void ChangeDirectionAndRotate()
    {
        direction *= -1;
        transform.Rotate(Vector3.up, 15f);
    }

    Vector3 GetRandomDirection()
    {
        return Random.Range(0, 2) == 0 ? Vector3.left : Vector3.right;
    }
}
