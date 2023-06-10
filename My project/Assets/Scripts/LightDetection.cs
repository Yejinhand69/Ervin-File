using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    public Transform player;
    public LayerMask shadowLayer;

    private Light2D lightSource;
    private bool isPlayerDetected;

    private void Start()
    {
        lightSource = GetComponent<Light2D>();
        isPlayerDetected = false;
    }

    private void Update()
    {
        // Check if the player is within the light's radius and not in the shadow layer
        bool isPlayerInLight = Physics2D.OverlapCircle(transform.position, lightSource.pointLightOuterRadius, ~shadowLayer) && player != null;

        // Destroy the player if detected
        if (isPlayerInLight)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }

        if (isPlayerDetected)
        {
            Destroy(player.gameObject);
        }
    }
}
