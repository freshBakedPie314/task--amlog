using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().PlayAudio(clip);
            GameManager.Instance.GameOver();
        }
    }
}
