using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMovementSpeed = 1;
    [SerializeField] BoxCollider2D footballPitchCollider;


    [SerializeField] Transform kickPosition;
    [SerializeField] GameObject footballPrefab;

    [SerializeField] float maxTimeToKick = 2f;
    float kickTime = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            kickTime += Time.deltaTime;

            if (kickTime >= maxTimeToKick)
            {
                kickTime = kickTime - maxTimeToKick;

                ShootFootball();
            }
            
        }

        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerMovementSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, footballPitchCollider.bounds.min.x + 1, footballPitchCollider.bounds.max.x - 1), Mathf.Clamp(transform.position.y, footballPitchCollider.bounds.min.y + 2, footballPitchCollider.bounds.max.y - 2));

    }

    void ShootFootball()
    {
        Instantiate(footballPrefab, kickPosition.position, Quaternion.identity);
    }

}
