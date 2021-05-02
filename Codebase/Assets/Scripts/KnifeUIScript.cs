using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This populates the knives in UI. AKA number of knives remaining.
public class KnifeUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject knifeUIPrefab;
    private void Start()
    {
        for (int i = 0; i < GameManagerScript.Instance.totalNumberOfKnives; i++)
        {
            Instantiate(knifeUIPrefab, transform);
        }
    }
    public void UpdateKnifeUI()
    {
        transform.GetChild(GameManagerScript.Instance.numberOfKnivesRemaining).gameObject.SetActive(false);
    }
}
