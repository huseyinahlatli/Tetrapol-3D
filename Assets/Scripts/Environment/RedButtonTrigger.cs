using UnityEngine;

public class RedButtonTrigger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(GameManager.gameManager.collectSound, GameManager.gameManager.player.transform.position);
            GameManager.gameManager.collectableObject += 1;
            _meshRenderer.enabled = false;
            _boxCollider.enabled = false;
        }
    }
}
