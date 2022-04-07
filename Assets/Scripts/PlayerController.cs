using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;
    public int pasados = 0;


    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;

    //private bool PuedeElminar = false;

    private bool vivo = true;


    private static readonly string ANIMATOR_STATE = "Estado";
    private static readonly int ANIMATOR_P_IDLE = 0;
    private static readonly int ANIMATOR_P_RUN = 1;
    private static readonly int ANIMATOR_P_JUMP = 2;
    private static readonly int ANIMATOR_P_SLIDE = 3;
    private static readonly int ANIMATOR_P_DEAD = 4;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(vivo == true)
        {
            Caminar();
        }
        if(vivo == false)
        {
            Muerte();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Saltar();

        }
        if (Input.GetKey(KeyCode.C))
        {
            Deslizarse();
        }
        if (pasados == 20)
        {
            Ganar();
        }
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }

    private void Caminar()
    {
        _rb.velocity = new Vector2(Velocity, _rb.velocity.y);
        ChangeAnimation(ANIMATOR_P_RUN);
    }
    private void Deslizarse()
    {
        ChangeAnimation(ANIMATOR_P_SLIDE);
    }
    private void Saltar()
    {
        _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        ChangeAnimation(ANIMATOR_P_JUMP);
    }
    private void Muerte()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeAnimation(ANIMATOR_P_DEAD);
    }
    private void Ganar()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeAnimation(ANIMATOR_P_IDLE);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Enemy")
        {
            vivo = false;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Verificador alto"){
            double aumento = 0.05;
            Velocity = (float)(Velocity + aumento);
            Debug.Log("Entrar en: " + other.gameObject.tag);
            pasados += 2;
            Debug.Log("Pasados: " + pasados);
        }
        if (tag == "Verificador bajo")
        {
            double aumento = 0.05;
            Velocity = (float)(Velocity + aumento);
            Debug.Log("Entrar en: " + other.gameObject.tag);
            pasados += 1;
            Debug.Log("Pasados: " + pasados);
        }
    }


}
