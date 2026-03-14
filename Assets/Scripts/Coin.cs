using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin();
            Destroy(gameObject);
            collision.GetComponent<PlayerController>().PlayAudio(clip);
        }
    }
}
