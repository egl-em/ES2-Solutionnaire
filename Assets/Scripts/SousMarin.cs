using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SousMarin : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;

    private Vector3 _directionDesiree;
    private float _vitesse = 0.25f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnMove(InputValue inputMove)
    {
        Vector2 tempDirection = inputMove.Get<Vector2>();

        _directionDesiree.x = 0;
        _directionDesiree.y = tempDirection.y;
        _directionDesiree.z = tempDirection.x;
    }

    void OnBoost(InputValue inputBoost)
    {
        if(inputBoost.isPressed)
        {
            _vitesse = 0.5f;
        }
        else
        {
            _vitesse = 0.25f;
        }
    }

    void FixedUpdate()
    {
        Vector3 vitesseFinale = _directionDesiree * _vitesse;
        _rb.AddRelativeForce(vitesseFinale, ForceMode.VelocityChange);
        
        _animator.SetFloat("VitesseHorizontale", vitesseFinale.z);
        _animator.SetFloat("VitesseVerticale", vitesseFinale.y);
        
        bool enMouvementZ = Mathf.Abs(vitesseFinale.z) > 0;
        _animator.SetBool("EnMouvementHorizontale", enMouvementZ);

        bool enMouvementY = Mathf.Abs(vitesseFinale.y) > 0;
        _animator.SetBool("EnMouvementVerticale", enMouvementY);
    }
}
