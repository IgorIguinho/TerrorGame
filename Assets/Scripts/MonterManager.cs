using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.AI;

public class MonterManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject playerObj;
    public GameObject jumpScareObj;
    public GameObject endGameScreenObj;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<NavMeshAgent>().destination = playerObj.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jumpScareObj.SetActive(true);
            endGameScreenObj.SetActive(true);
            playerObj.GetComponent<CharacterController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Destroy(this.gameObject, 1);
        }
    }

}
