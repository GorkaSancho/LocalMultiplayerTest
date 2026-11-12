using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerSpawner : MonoBehaviour
{
    [SerializeField] InputActionReference respawnAction;
    [SerializeField] public List<GameObject> players;
    [SerializeField] public List<Transform> spawnPoints;
    private bool keyboardJoined = false;
    private bool controllerJoined = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        respawnAction.action.Enable();
        respawnAction.action.performed += OnRespawn;
    }
    void OnDisable()
    {
        respawnAction.action.performed -= OnRespawn;
        respawnAction.action.Disable();       
    }
    // Update is called once per frame
    void Update()
    {
    }

    void OnRespawn(InputAction.CallbackContext context)
    {
        if(!keyboardJoined && context.control.device is Keyboard)
        {
            var player = PlayerInput.Instantiate(players[0],pairWithDevice: context.control.device);
            player.transform.position = spawnPoints[0].position;
            keyboardJoined = true;
        }
        else if(!controllerJoined && context.control.device is Gamepad)
        {
            var player = PlayerInput.Instantiate(players[1],pairWithDevice: context.control.device);
            player.transform.position = spawnPoints[1].position;
            controllerJoined = true;
        }
    }
}
