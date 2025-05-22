using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] Vector3 force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NavmeshMovement movement))
        {
            if (movement.NeedActivation())
            {
                movement.EnableAgentMovement();
            }
            else
            {
                movement.Jump(force);
            }
        }
    }
}
