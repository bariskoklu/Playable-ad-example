using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField]
    private GameObject knifePrefab;
    [SerializeField]
    private GameObject knifeSpawn;
    [SerializeField]
    private GameObject KnifeUI;
    void Start()
    {
        GameManagerScript.Instance.numberOfKnivesRemaining = GameManagerScript.Instance.totalNumberOfKnives;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.Instance.currentGameState == GameState.Playing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ThrowKnife();
            }
        }
    }

    private void ThrowKnife()
    {
        if (GameManagerScript.Instance.numberOfKnivesRemaining > 0)
        {
            Instantiate(knifePrefab, knifeSpawn.transform.position, knifeSpawn.transform.rotation, transform);
            GameManagerScript.Instance.numberOfKnivesRemaining--;
            KnifeUI.GetComponent<KnifeUIScript>().UpdateKnifeUI();
            AudioManagerScript.Instance.Play("KnifeThrow");
        }
        
    }
}
