using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CattleSpawnpoint : MonoBehaviour
{
    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 movementDirection = Random.insideUnitCircle.normalized;
        Vector2 newPosition = rb.position + 20f * Time.fixedDeltaTime * movementDirection;
        rb.MovePosition(newPosition);
    }
}
