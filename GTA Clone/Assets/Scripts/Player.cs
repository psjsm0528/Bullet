using System.Runtime.InteropServices;
using UnityEngine;

public class player : MonoBehaviour
{
    private Controls controls; // Input Action Class�� ������ ����
    private Rigidbody2D rigidbody2D;
    [Header("�̵��� �ʿ��� �Ӽ�")]
    [SerializeField] private float moveSpeed;
    private void Awake()
    {
        controls = new Controls(); // controls�� Controls ������ ������ ���� �� ����

        controls.Player.Enable();  // controls�ȿ� �ִ� Player Action�� Ȱ��ȭ

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dir = controls.Player.Move.ReadValue<Vector2>();
        rigidbody2D.linearVelocity = dir * moveSpeed;
    }
}
