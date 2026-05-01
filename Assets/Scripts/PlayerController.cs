using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalThrow, verticalThrow;
    [Header("SPACESHIP CONTROL SETTINGS")]
    [Tooltip("how fast the ship moves")]public float speed;
    [Tooltip("the max moving range on the screen")]public float xRange, yRange;
    [Tooltip("starship lasers")]public GameObject[] lasers;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFireing();
    }

    void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");
        
        float xOffset = horizontalThrow * Time.deltaTime * speed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = verticalThrow * Time.deltaTime * speed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        float newZPos = transform.localPosition.z;

        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, newZPos);
    }

    float pitchPosValue = -2, pitchControlValue = -15;
    float yawPosValue = 2;
    float rollControlValue = -20;
    void ProcessRotation()
    { 
        float pitchPos = transform.localPosition.y * pitchPosValue;
        float pitchControl = verticalThrow * pitchControlValue;

        float yawPos = transform.localPosition.x * yawPosValue;
        float yawControl = 0;

        float rollPos = 0;
        float rollControl = horizontalThrow * rollControlValue;

        float pitch = pitchPos + pitchControl;
        float yaw = yawPos + yawControl;
        float roll = rollPos + rollControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    [Tooltip("particle system for lasers")]public ParticleSystem rightLaser, leftLaser;
    void ProcessFireing()
    {
        if(Input.GetButton("Fire1")) 
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }

    void SetLaserActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}