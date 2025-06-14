using UnityEngine;
using UnityEngine.UI;

public class TennisGameManager : GameManager
{

    // - Atributi klase - //
    [Header("Player Stats")]
    int player1Points;
    int player2Points;
    public string imeIgraca1 = "Nepoznato";
    public string imeIgraca2 = "Nepoznato";

    [Header("UI Elements")]
    public TennisSettingsUI gameSettingsUI;
    public Text score;

    [Header("Prefabs")]
    public GameObject ball;

    [Header("Reference")]
    public Transform player1;
    public Transform player2;

    [Header("Game Properties")]
    public Vector3 initialBallPos = new Vector3(0f, 0f, -1f);
    public Vector3 initialPlayer1Pos = new Vector3(-6f, 0f, -1f);
    public Vector3 initialPlayer2Pos = new Vector3(6f, 0f, -1f);
    public float player1Height = 2f;
    public float player2Height = 2f;
    public float brzinaLoptice = 5f;

    GameObject instanciranaLopta; //instanca lopte


    // - Metode klase - //
    void Start()
    {
        //Reset poena
        player1Points = 0;
        player2Points = 0;

        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        score.gameObject.SetActive(false);

        gameSettingsUI.gameObject.SetActive(true);
    }

    void Update()
    {
        score.text = player1Points + "-" + player2Points; //Update score text-a
    }

    public void IncreasePlayerPoints(int player)
    {
        if(player == 1) //Uvecanje igracu 1
        {
            player1Points++;
            if (player1Points >= pointsToWin) WinGame(1);
        }
        else if(player == 2) //Uvecanje igracu 2
        {
            player2Points++;
            if (player2Points >= pointsToWin) WinGame(2);
        }
        ResetBall();
    }

    public void ResetBall()
    {
        //Brisanje lopte ukoliko vec postoji
        if(instanciranaLopta != null)
        {
            Destroy(instanciranaLopta);
        }

        // Instanciranje lopte
        instanciranaLopta = Instantiate(ball, initialBallPos, Quaternion.Euler(0f, 0f, 0f));

        // Podesavanje pozicije i visine reketa (igraca)
        player1.position = initialPlayer1Pos;
        player2.position = initialPlayer2Pos;
        player1.transform.localScale = new Vector3(0.4f, player1Height, 1f);
        player2.transform.localScale = new Vector3(0.4f, player2Height, 1f);
    }

    public void ConfirmSettings()
    {
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);

        player1.gameObject.GetComponent<TennisPlayerScript>().controlable = true;
        player2.gameObject.GetComponent<TennisPlayerScript>().controlable = true;

        score.gameObject.SetActive(true);

        pointsToWin = gameSettingsUI.poeniZaPobedu;
        player1Height = gameSettingsUI.visinaReketa1;
        player2Height = gameSettingsUI.visinaReketa2;
        brzinaLoptice = gameSettingsUI.brzinaLopte;
        imeIgraca1 = gameSettingsUI.imeIgraca1.text;
        imeIgraca2 = gameSettingsUI.imeIgraca2.text;

        gameSettingsUI.gameObject.SetActive(false);

        ResetBall();
    }

    public void WinGame()
    {

    }
}
