using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float animationSpeed = 100;

    BeatEmUpMovement movement;
    Transform spriteTransform;
    bool rockingActive;
    bool right = true;
    float rockingMax = 15;

    private void Start()
    {
        movement = GetComponent<BeatEmUpMovement>();
        spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
    }

    private void Update()
    {
        if (movement.GetMovementVector2().magnitude > 0 && !rockingActive)
        {
            rockingActive = true;
            StartCoroutine(Move());
        }
        else if (movement.GetMovementVector2().magnitude <= 0)
        {
            rockingActive = false;
        }

        Debug.Log(spriteTransform.rotation.eulerAngles.z);
    }

    IEnumerator Move()
    {
        if (right)
        {
            while (spriteTransform.rotation.eulerAngles.z < rockingMax)
            {
                spriteTransform.Rotate(0, 0, animationSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (spriteTransform.rotation.eulerAngles.z < rockingMax + 1 || spriteTransform.rotation.eulerAngles.z > 360 - rockingMax)
            {
                spriteTransform.Rotate(0, 0, -animationSpeed * Time.deltaTime);
                yield return null;
            }
        }

        right = !right;
        // reset
    }

    IEnumerator ResetRotation()
    {
        yield return null;
    }
}
