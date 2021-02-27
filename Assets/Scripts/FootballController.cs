using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballController : MonoBehaviour
{
    [SerializeField] float kickForce=10f;

    void Awake()
    {
        GetComponent<Rigidbody2D>().velocity=(new Vector2(Random.Range(-2,2),1)*kickForce*Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
