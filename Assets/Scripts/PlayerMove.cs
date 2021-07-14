using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed; //Скорость движения, а в дальнейшем и ускорение
    
    public GameObject _Lemon;
    public GameObject _dynamite;
    public Transform _dynamitPoint;
    public Rigidbody _dynamiteRB;
    public int Force=3;

    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
               
        Dynamite_Lenon dynamite_Lenon = _Lemon.GetComponent<Dynamite_Lenon>();
        if (dynamite_Lenon.count_dyna!=0 && Input.GetKeyDown(KeyCode.G))
        {
            GameObject temp = Instantiate(_dynamite, _dynamitPoint.position, Quaternion.identity);
            temp.name = "dynamite";
            _dynamiteRB = temp.GetComponent<Rigidbody>();
            _dynamiteRB.AddForce(Vector3.forward * Force, ForceMode.Impulse);
            dynamite_Lenon.count_dyna -= 1;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
