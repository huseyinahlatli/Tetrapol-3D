using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TransportManager : MonoBehaviour
{
    [SerializeField] private List<Transform> transportCapsule;
    private int _randomValue;
    private int _transportValue;
    
    #region Singleton Class: Transport Manager | Instance
    public static TransportManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    
    private void OnTriggerEnter(Collider other)
    {
        FindWayPointName();
        
        if (other.gameObject.CompareTag("Player"))
        {
            BoxColliderDisable();

            _randomValue = Random.Range(0, transportCapsule.Count);
            while (_transportValue == _randomValue)
                _randomValue = Random.Range(0, transportCapsule.Count);
            
            AudioSource.PlayClipAtPoint(GameManager.gameManager.transportSound, GameManager.gameManager.player.transform.position);
            other.transform.position = transportCapsule[_randomValue].transform.position;
            Invoke(nameof(BoxColliderEnable), 3f);
        }
    }

    private void BoxColliderDisable()
    {
        foreach (var capsules in transportCapsule)
            capsules.GetComponent<BoxCollider>().enabled = false;
    }
    
    public void BoxColliderEnable()
    {
        foreach (var capsules in transportCapsule)
            capsules.GetComponent<BoxCollider>().enabled = true;
    }

    private void FindWayPointName()
    {
        if (gameObject.name == "Waypoint 0")
            _transportValue = 0;
        if (gameObject.name == "Waypoint 1")
            _transportValue = 1;
        if (gameObject.name == "Waypoint 2")
            _transportValue = 2;
        if (gameObject.name == "Waypoint 3")
            _transportValue = 3;
        if (gameObject.name == "Waypoint 4")
            _transportValue = 4;
        if (gameObject.name == "Waypoint 5")
            _transportValue = 5;
    }
}

