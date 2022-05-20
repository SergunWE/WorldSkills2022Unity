using UnityEngine;
using UnityEngine.InputSystem;

public class TankMachine : MonoBehaviour, IControlble
{
    private GameObject[] _playerObjects;
    [SerializeField] private GameObject tankCamera;
    [SerializeField] private PlayerInput playerInput;

    public void EnterInMachine(GameObject[] playerObjects)
    {
        _playerObjects = playerObjects;
        foreach (GameObject playerObject in _playerObjects)
        {
            playerObject.SetActive(false);
        }
        tankCamera.SetActive(true);
        playerInput.actions.FindActionMap("PlayerControl").Disable();
        playerInput.actions.FindActionMap("MachineControl").Enable();
    }

    public void ExitInMachine()
    {
        foreach (GameObject playerObject in _playerObjects)
        {
            playerObject.transform.position = Vector3.up * 5f + transform.position;
            playerObject.SetActive(true);
        }
        playerInput.actions.FindActionMap("MachineControl").Disable();
        playerInput.actions.FindActionMap("PlayerControl").Enable();
        tankCamera.SetActive(false);
    }
}
