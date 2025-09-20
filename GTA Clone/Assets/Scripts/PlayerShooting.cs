using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Controls controls;
    [SerializeField] private GameObject projectilPrefab; // �߻��� �Ѿ� ������
    [SerializeField] private float fireRate = 2; // �Ѿ� �߻� �ֱ�
    [SerializeField] private float shootSpeed = 5; // �Ѿ� �ӵ�
    private float previousFireTime;
    private bool shouldFire;
    private void Awake()
    {
        controls = new Controls();
        controls.Player.Enable();
    }

    private void OnEnable()
    {
        controls.Player.Fire.performed += (callbacks) => shouldFire = true;
        controls.Player.Fire.canceled += (callbacks) => shouldFire = false;
    }

    private void OnDisable()
    {
        controls.Player.Fire.performed -= (callbacks) => shouldFire = true;
        controls.Player.Fire.canceled -= (callbacks) => shouldFire = false;
    }
    private void Update()
    {
        if (!shouldFire) { return; }
        if (Time.time < previousFireTime + (1 / fireRate)) { return; }

        Rigidbody rb = Instantiate(projectilPrefab, transform.position,
    Quaternion.identity).GetComponent<Rigidbody>();
        rb.linearVelocity = transform.up * shootSpeed;
        previousFireTime = Time.time;
    }
}

