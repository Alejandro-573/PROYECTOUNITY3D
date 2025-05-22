using Unity.VisualScripting;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public delegate void InputEventsDelegate(RaycastHit hit);
    public InputEventsDelegate CollisionDetectedEvent;

    [SerializeField] Camera currentCamera;
    [SerializeField] LayerMask detectionLayers;
    RaycastHit hit;

    public static InputController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, detectionLayers))
            {
                CollisionDetectedEvent?.Invoke(hit);
            }
        }
    }


}
