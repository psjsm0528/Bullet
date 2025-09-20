using System.Runtime.InteropServices;
using UnityEngine;

public class player : MonoBehaviour
{
    private Controls controls; // Input Action Class를 저장할 변수
    private Rigidbody2D rigidbody2D;
    [Header("이동에 필요한 속성")]
    [SerializeField] private float moveSpeed;
    private void Awake()
    {
        controls = new Controls(); // controls에 Controls 데이터 영역을 생성 후 저장

        controls.Player.Enable();  // controls안에 있는 Player Action을 활성화

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dir = controls.Player.Move.ReadValue<Vector2>();
        rigidbody2D.linearVelocity = dir * moveSpeed;
    }
}
