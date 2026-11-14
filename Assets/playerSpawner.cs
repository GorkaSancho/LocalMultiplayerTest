using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerSpawner : MonoBehaviour
{
    [SerializeField] InputAction respawnAction;
    [SerializeField] public List<GameObject> players;
    [SerializeField] public List<Transform> spawnPoints;
    private bool keyboardJoined = false;
    private bool controllerJoined = false;
    private int nPlayer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        respawnAction = new InputAction("Respawn", InputActionType.Button);
        respawnAction.AddBinding("<Keyboard>/enter");
        respawnAction.AddBinding("<Gamepad>/buttonNorth");
    }
    
    void OnEnable()
    {
        respawnAction.performed += OnRespawn;
        respawnAction.Enable();
    }
    void OnDisable()
    {      
        respawnAction.performed -= OnRespawn;
        respawnAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRespawn(InputAction.CallbackContext context)
    {
        if(!keyboardJoined && context.control.device is Keyboard)
        {
            PlayerInput player = PlayerInput.Instantiate(players[0],pairWithDevice: context.control.device);
            player.transform.position = spawnPoints[0].position;
            keyboardJoined = true;
        }
        else if(!controllerJoined && context.control.device is Gamepad)
        {
            PlayerInput player = PlayerInput.Instantiate(players[1],pairWithDevice: context.control.device);
            player.transform.position = spawnPoints[1].position;
            controllerJoined = true;
        }
    }
}
