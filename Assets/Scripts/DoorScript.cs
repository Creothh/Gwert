using System;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject target;

    public float teleportationRange = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        Vector2 direction = rb.linearVelocity.normalized;

        player.transform.position = (Vector2)target.transform.position + direction * teleportationRange;

        Debug.Log("TP!");
    }

}
