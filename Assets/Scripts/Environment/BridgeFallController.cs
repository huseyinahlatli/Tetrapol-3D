using System.Collections;
using UnityEngine;

public class BridgeFallController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator SetRigidbodyValues()
    {
        yield return new WaitForSeconds(0.4f);
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(SetRigidbodyValues());
        
        AudioSource.PlayClipAtPoint(GameManager.gameManager.bridgeWalk, GameManager.gameManager.player.transform.position);
    }
}
