using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent (typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float tiltAmount = 15f;
    [SerializeField] private AudioSource audioSource;

    private int currentPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && currentPosition < 1)
        {
            currentPosition++;
            targetPosition.x += moveDistance;
        }
        else if (Input.GetKeyDown(KeyCode.A) && currentPosition > -1)
        {
            currentPosition--;
            targetPosition.x -= moveDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        float currentX = transform.position.x;
        float diff = targetPosition.x - currentX;

        float tiltZ = Mathf.LerpAngle(transform.localEulerAngles.z, -diff * tiltAmount, moveSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0, 0, tiltZ);
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}