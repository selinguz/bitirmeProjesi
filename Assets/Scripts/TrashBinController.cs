using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrashBinController : MonoBehaviour
{
    public int trashBinID;
    private ScoreController scoreController;
    private SoundController soundController;

    private void Start()
    {
        soundController = GameObject.Find("ClickSound").GetComponent<SoundController>();
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void OnMouseDown()
    {
        if (TruckController.isInStop && trashBinID == TruckController.stop_index)
        {
            if (soundController != null)
            {
                soundController.PlaySound();
            }
            Destroy(gameObject);
            scoreController.IncrementScore(10);
            scoreController.TrashBinPicked();
        }
    }
}
