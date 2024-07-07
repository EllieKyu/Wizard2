using UnityEngine;
using UnityEngine.InputSystem;

public class InputDeciveHelper : MonoBehaviour
{
    public static InputDeciveHelper Instance;
    private InputDevice currentDevice;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (!Instance)
        {
            Instance = this;
        }

        if (Instance != this)
        {
            print("Too many InputDeciveHelper, killing myself");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputSystem.onActionChange += (obj, change) =>
        {
            if (change == InputActionChange.ActionPerformed)
            {
                var inputAction = (InputAction)obj;
                var lastControl = inputAction.activeControl;
                var lastDevice = lastControl.device;
                currentDevice = lastDevice;
            }
        };
    }

    public bool IsUsingGamepad()
    {
        if (currentDevice == null)
        {
            return false;
        }

        return currentDevice.displayName != "Keyboard" && currentDevice.displayName != "Mouse";
    }
}
