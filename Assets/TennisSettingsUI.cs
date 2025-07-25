using UnityEngine;
using UnityEngine.UI;

public class TennisSettingsUI : MonoBehaviour
{
    // - Atributi klase - //
    [Header("GameManager")]
    public TennisGameManager manager;

    [Header("Properties")]
    public float visinaReketa1 = 2;
    public float visinaReketa2 = 2;
    public float brzinaLopte = 7f;
    public int poeniZaPobedu = 10;

    [Header("UI Elements")]
    public Text poeniZaPobeduText;
    public Text brzinaLopteText;
    public Text visinaText1;
    public Text visinaText2;
    public InputField imeIgraca1;
    public InputField imeIgraca2;
    public Text errorText;

    public Button uvecajReket1;
    public Button smanjiReket1;
    public Button uvecajReket2;
    public Button smanjiReket2;
    public Button uvecajBrzinuLopte;
    public Button smanjiBrzinuLopte;
    public Button uvecajPoeneZaPobedu;
    public Button smanjiPoeneZaPobedu;

    // - Metode klase - //
    void Update()
    {
        poeniZaPobeduText.text = (Mathf.Round(poeniZaPobedu * 100) / 100f).ToString();
        brzinaLopteText.text = (Mathf.Round(brzinaLopte * 100) / 100f).ToString();
        visinaText1.text = (Mathf.Round(visinaReketa1 * 100) / 100f).ToString();
        visinaText2.text = (Mathf.Round(visinaReketa2 * 100) / 100f).ToString();
    }

    void UpdateButtons()
    {
        if (visinaReketa1 >= 2.49f) { uvecajReket1.interactable = false; } else { uvecajReket1.interactable = true; }
        if (visinaReketa2 >= 2.49f) { uvecajReket2.interactable = false; } else { uvecajReket2.interactable = true; }

        if (visinaReketa1 <= 1.5f) { smanjiReket1.interactable = false; } else { smanjiReket1.interactable = true; }
        if (visinaReketa2 <= 1.5f) { smanjiReket2.interactable = false; } else { smanjiReket2.interactable = true; }

        if (brzinaLopte >= 7.99f) { uvecajBrzinuLopte.interactable = false; } else { uvecajBrzinuLopte.interactable = true; }
        if (brzinaLopte <= 5.01f) { smanjiBrzinuLopte.interactable = false; } else { smanjiBrzinuLopte.interactable = true; }

        if (poeniZaPobedu >= 25) { uvecajPoeneZaPobedu.interactable = false; } else { uvecajPoeneZaPobedu.interactable = true; }
        if (poeniZaPobedu <= 4) { smanjiPoeneZaPobedu.interactable = false; } else { smanjiPoeneZaPobedu.interactable = true; }
    }

    public void ResetPodesavanja()
    {
        visinaReketa1 = 2;
        visinaReketa2 = 2;
        brzinaLopte = 7f;
        poeniZaPobedu = 10;
    }

    public void PovecajReket(int i)
    {
        if (i == 1) visinaReketa1 += 0.1f;
        else visinaReketa2 += 0.1f;

        UpdateButtons();
    }
    public void SmanjiReket(int i)
    {
        if (i == 1) visinaReketa1 -= 0.1f;
        else visinaReketa2 -= 0.1f;

        UpdateButtons();
    }
    public void PromeniBrzinuLopte(bool uvecavanje)
    {
        if (uvecavanje) brzinaLopte += 0.1f;
        else brzinaLopte -= 0.1f;

        UpdateButtons();
    }
    public void PromeniPoeneZaPobedu(bool uvecavanje)
    {
        if (uvecavanje) poeniZaPobedu ++;
        else poeniZaPobedu --;

        UpdateButtons();
    }

    public void ZapocniIgru()
    {
        manager.ConfirmSettings();
    }

}
