using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_sr.flipX == true)
        {
            _rb.velocity = new Vector2(Velocity*-1, _rb.velocity.y);
        }
    }
}
