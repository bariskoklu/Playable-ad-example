using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovementScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool shouldKnifeMove = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldKnifeMove && GameManagerScript.Instance.currentGameState == GameState.Playing)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Target":
                HandleTargetCollision(collision);
                break;
            case "Knife":
                HandleKnifeCollision(collision);
                break;
            default:
                Debug.Log("Collided with something weird : " + collision.name);
                break;
        }
    }
    private void HandleTargetCollision(Collider2D collision)
    {
        shouldKnifeMove = false;
        transform.parent = collision.transform;
        AudioManagerScript.Instance.Play("KnifeHitOnTarget");
        if (GameManagerScript.Instance.numberOfKnivesRemaining == 0)
        {
            GameManagerScript.Instance.ChangeGameState(GameState.GameOverVictory);
        }
    }
    private void HandleKnifeCollision(Collider2D collision)
    {
        //To prevent knife on knife collision while both in air
        if (!collision.GetComponent<KnifeMovementScript>().shouldKnifeMove)
        {
            GameManagerScript.Instance.ChangeGameState(GameState.GameOverDefeat);
            AudioManagerScript.Instance.Play("KnifeHitOnKnife");
            shouldKnifeMove = false;
        }
    }
}
