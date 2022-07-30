using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _grounded;

    [SerializeField] private Transform _gunPosition;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private AudioSource audio;

    public Manager manager;

    public Animator Animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigidbody2D.AddForce(new Vector2(0,_jumpForce),ForceMode2D.Impulse);
            audio.Play();
        }
        Animator.SetBool("Grounded",_grounded);
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") 
        {
            _grounded = true;
        }
        if (collision.collider.GetComponent<Enemy>()) 
        {
            manager.EndGame();
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _grounded=false;
    }
    private void Shoot() 
    {
        Instantiate(_bullet,_gunPosition.position,_gunPosition.rotation);
    }
}
