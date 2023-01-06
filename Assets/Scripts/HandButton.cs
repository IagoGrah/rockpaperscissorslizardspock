using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandButton : MonoBehaviour
{
    public Hand hand;

    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = .1f;
    }

    public void Play()
    {
        GameManager.playerHand = hand;
        SceneManager.LoadScene("EndScreen");
    }
}
