using System.Security.Cryptography;
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
    public GameObject winUI;
    public Text winner;
    public Text player1NameText;
    public Text player1PointsText;
    public Text player1HeightText;
    public Text player2NameText;
    public Text player2PointsText;
    public Text player2HeightText;

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
        winUI.SetActive(false);

        igraPocela = false;
    }

    void Update()
    {
        score.text = player1Points + "-" + player2Points; //Update score text-a
    }

    public void PrikaziSettings()
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        score.gameObject.SetActive(false);

        gameSettingsUI.gameObject.SetActive(true);
        winUI.SetActive(false);

        igraPocela = false;
    }

    public void IncreasePlayerPoints(int player)
    {
        if(player == 1) //Uvecanje igracu 1
        {
            player1Points++;
            if (player1Points >= pointsToWin)
            {
                WinGame(1);
                return;
            }
        }
        else if(player == 2) //Uvecanje igracu 2
        {
            player2Points++;
            if (player2Points >= pointsToWin)
            {
                WinGame(2);
                return;
            }
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
        //Reset igre
        ResetGame();

        //Deaktivacija settings UI
        gameSettingsUI.gameObject.SetActive(false);

        //Spawn lopte
        ResetBall();

        igraPocela = true;
    }

    public void ResetGame()
    {
        //Aktiviranje reketa
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);

        //Omogucavanje kontrole reketa
        player1.gameObject.GetComponent<TennisPlayerScript>().controlable = true;
        player2.gameObject.GetComponent<TennisPlayerScript>().controlable = true;

        //Prikazivanje score-a
        score.gameObject.SetActive(true);

        pointsToWin = gameSettingsUI.poeniZaPobedu;

        player1Height = gameSettingsUI.visinaReketa1;
        player2Height = gameSettingsUI.visinaReketa2;

        brzinaLoptice = gameSettingsUI.brzinaLopte;

        if (gameSettingsUI.imeIgraca1.text.Length != 0) imeIgraca1 = gameSettingsUI.imeIgraca1.text;
        if (gameSettingsUI.imeIgraca2.text.Length != 0) imeIgraca2 = gameSettingsUI.imeIgraca2.text;

        player1Points = 0;
        player2Points = 0;
    }

    public override void WinGame(int igrac)
    {
        //Aktiviranje UI-a
        winUI.SetActive(true);

        //Reset animacije
        Animator anim = winUI.GetComponent<Animator>();
        if(anim != null)
        {
            anim.Rebind();
            anim.Update(0f);
        }

        //Sync textova
        if (igrac == 1)
            winner.text = imeIgraca1 + " je pobedio/la!";
        else
            winner.text = imeIgraca2 + " je pobedio/la!";

        player1NameText.text = imeIgraca1;
        player1PointsText.text = "Poeni: " + player1Points;
        player1HeightText.text = "Visina reketa: " + player1Height;

        player2NameText.text = imeIgraca2;
        player2PointsText.text = "Poeni: " + player2Points;
        player2HeightText.text = "Visina reketa: " + player2Height;
    }
}
