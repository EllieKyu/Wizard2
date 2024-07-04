using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerReticle : MonoBehaviour
{
    InputAction aimAction;
    public float reticleDistance = 1f;
    public GameObject reticle;

    private void Start()
    {
        aimAction = InputSystem.actions.FindAction("StickAim");
    }

    // Update is called once per frame
    void Update()
    {
        if (!InputDeciveHelper.Instance.IsUsingGamepad())
        {
            reticle.SetActive(false);
            return;
        }

        reticle.SetActive(true);
        var aim = aimAction.ReadValue<Vector2>().normalized * reticleDistance;
        reticle.transform.localPosition = aim;
    }
}
