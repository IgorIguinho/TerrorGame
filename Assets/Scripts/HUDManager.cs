using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    GameObject playerObj;
    public Slider sliderStamina;
    public Image imageColoroStamina;

    public GameObject textForCollectPaper;
    public TextMeshProUGUI countPaperText;
    public GameObject monsterObj;
    public GameObject winGameScreen;
    int countPaper;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PaperCount();
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPaperCount()
    {
        countPaper++;
        PaperCount();
        monsterObj.SetActive(true);
        monsterObj.GetComponent<NavMeshAgent>().speed += 1;

        if (countPaper == 5)
        {
            winGameScreen.SetActive(true);
            playerObj.GetComponent<CharacterController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PaperCount()
    {
        countPaperText.text = countPaper.ToString() + "/" + 5;
    }
}
