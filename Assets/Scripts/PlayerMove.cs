using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed; //Скорость движения, а в дальнейшем и ускорение
    
    public GameObject _Lemon;
    public GameObject _dynamite;
    public Transform _dynamitPoint;
    public Rigidbody _dynamiteRB;
    public int Force=3;
    public Vector3 _startPos;
    public float _step = 0.02f;
    public float turnSpeed = 20f;
    public Text _PlayerName;
    public Camera _mainCamera;
    public Vector3 _direction;
    public int _Health = 100;
    public int _Lives = 3;
    public Panel _panel;


    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    private void Awake()
    {
        _PlayerName.text = PlayerPrefs.GetString("PlayerName");
        _mainCamera = Camera.main;
        _panel = FindObjectOfType<Panel>();

    }

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        RaycastHit _hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit))
        {
            _direction = _hit.transform.position - transform.position;

        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_direction), 10 * Time.deltaTime);
        Dynamite_Lenon dynamite_Lenon = _Lemon.GetComponent<Dynamite_Lenon>();
        if (dynamite_Lenon.count_dyna >= 0 && Input.GetMouseButton(0))
        {
            GameObject temp = Instantiate(_dynamite, _dynamitPoint.position, Quaternion.identity);
            temp.name = "dynamite";
            _dynamiteRB = temp.GetComponent<Rigidbody>();
            
            _dynamiteRB.AddForce(_direction.normalized * Force, ForceMode.Impulse);
            dynamite_Lenon.count_dyna -= 1;
        }

        if (_Health <= 0)
        {
            _Lives--;
            _panel.Refresh();
            _Health = 100;

        }
        if (_Lives <= 0)
        {
            SceneManager.LoadScene(0);
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject temp = collision.gameObject;
    //    if (temp.tag == "MoveBlock")
    //    {
    //        Debug.Log("Enter");
    //        temp.GetComponent<Rigidbody>().isKinematic = false;
            
    //        if (Input.GetKeyDown(KeyCode.S))
    //        {
    //            temp.transform.position = Vector3.Lerp(_startPos, _Lemon.transform.position, 0.02f);
    //        }
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    GameObject temp = collision.gameObject;
    //    if (temp.tag == "MoveBlock" && Input.GetKeyDown(KeyCode.E))
    //    {
    //        temp.GetComponent<Rigidbody>().isKinematic = true;
    //        //if (Input.GetKeyDown(KeyCode.S))
    //        //{ && Input.GetKeyDown(KeyCode.V)
    //        //    temp.transform.Translate(-Vector3.forward - m_Movement * Time.deltaTime);
    //        //}
    //    }
    //}
}
