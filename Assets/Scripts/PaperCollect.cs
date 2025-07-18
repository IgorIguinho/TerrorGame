using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollect : MonoBehaviour
{

    GameObject player;
    float distancePlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
    }

    private void OnMouseOver()
    {
        if (distancePlayer < 5)
        {
           
            if (Input.GetKey(KeyCode.E))
            {
                HUDManager.Instance.textForCollectPaper.SetActive(false);
                HUDManager.Instance.AddPaperCount();
                Destroy(this.gameObject);

            }
            else { HUDManager.Instance.textForCollectPaper.SetActive(true); }
        }
        else
        {
            HUDManager.Instance.textForCollectPaper.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        HUDManager.Instance.textForCollectPaper.SetActive(false);
    }
}
