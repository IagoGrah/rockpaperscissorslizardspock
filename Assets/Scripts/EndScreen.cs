using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    Hand playerHand;
    Hand oppHand;

    public TMP_Text resultText;
    public TMP_Text operatorText;
    public TMP_Text scoreText;
    public Image playerHandImage;
    public Image oppHandImage;

    public Sprite[] handSprites = new Sprite[5];

    void Start()
    {
        playerHand = GameManager.playerHand;
        oppHand = (Hand)Random.Range(0, 5);

        playerHandImage.sprite = handSprites[(int)playerHand];
        oppHandImage.sprite = handSprites[(int)oppHand];

        if (CheckVictory(playerHand, oppHand))
        {
            resultText.text = "you win";
            operatorText.text = ">";
            GameManager.playerScore++;
        }
        else if (playerHand == oppHand)
        {
            resultText.text = "draw";
            operatorText.text = "=";
        }
        else
        {
            resultText.text = "you lose";
            operatorText.text = "<";
            GameManager.oppScore++;
        }

        scoreText.text = $"{GameManager.playerScore} x {GameManager.oppScore}";
    }

    public bool CheckVictory(Hand player, Hand opponent)
    {
        switch (player)
        {
            case Hand.Rock:
                if (opponent == Hand.Scissors || opponent == Hand.Lizard)
                    return true;
                break;

            case Hand.Paper:
                if (opponent == Hand.Rock || opponent == Hand.Spock)
                    return true;
                break;

            case Hand.Scissors:
                if (opponent == Hand.Paper || opponent == Hand.Lizard)
                    return true;
                break;

            case Hand.Lizard:
                if (opponent == Hand.Spock || opponent == Hand.Paper)
                    return true;
                break;

            case Hand.Spock:
                if (opponent == Hand.Scissors || opponent == Hand.Rock)
                    return true;
                break;
        }

        return false;
    }
}
