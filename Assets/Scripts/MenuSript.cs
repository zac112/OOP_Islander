using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSript : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject exitButton;

    private void OnMouseDown() {
        if (gameObject == exitButton) {
            Application.Quit();
        }
        if (gameObject == playButton) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }
}
