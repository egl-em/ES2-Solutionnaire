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
        Vector2 tempInputOriginal = inputMove.Get<Vector2>();
        _directionDesiree.x = 0;
        _directionDesiree.y = tempInputOriginal.y;
        _directionDesiree.z = tempInputOriginal.x;
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
        Vector3 vitesseEtDirectionFinale = _directionDesiree * _vitesse;
        _rb.AddRelativeForce(vitesseEtDirectionFinale, ForceMode.VelocityChange);
        
        _animator.SetFloat("VitesseHorizontale", vitesseEtDirectionFinale.z);
        _animator.SetFloat("VitesseVerticale", vitesseEtDirectionFinale.y);
        
        bool enMouvementZ = vitesseEtDirectionFinale.z != 0;
        _animator.SetBool("EnMouvementHorizontale", enMouvementZ);

        bool enMouvementY = vitesseEtDirectionFinale.y != 0;
        _animator.SetBool("EnMouvementVerticale", enMouvementY);
    }
}
