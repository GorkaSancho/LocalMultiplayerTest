using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    Vector2 moveInput;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(moveInput * speed * Time.deltaTime);
    }
    
    public void OnJump()
    {
        
    }
    public void OnMove(InputValue value) //Haurem de mirar si es adalt aball dreta esquerra
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnRespawn()
    {
        
    }
}
