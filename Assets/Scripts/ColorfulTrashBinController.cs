using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorfulTrashBinController : MonoBehaviour
{
    private ScoreController scoreController;
    private int toplamCopKutulari = 0;
    private int toplanacakCopKutusu = 12;
    private SoundController soundController;
    public GameObject trashBin;

    private void Start()
    {
        soundController = GameObject.Find("ClickSound").GetComponent<SoundController>();
        scoreController = FindObjectOfType<ScoreController>();
    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        scoreController.IncrementScore(20);
        scoreController.SecondSceneTrashBinPicked();
    }
}
