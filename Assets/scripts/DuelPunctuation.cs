using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelPunctuation : MonoBehaviour
{
    public Text txtWin;
    public Text txtDam;
    public Text txtTime;

    public Text TxtWin { get => txtWin; set => txtWin = value; }
    public Text TxtDam { get => txtDam; set => txtDam = value; }
    public Text TxtTime { get => txtTime; set => txtTime = value; }
    public static string Win { get => win; set => win = value; }
    public static float Dam { get => dam; set => dam = value; }
    public static float Time { get => time; set => time = value; }

    private static string win;
    private static float dam;
    private static float time;


    // Start is called before the first frame update
    void Start()
    {
        txtWin.text = "WINNER: " + Win;
        txtDam.text = "TOTAL DAMAGE: " + Dam;
        txtTime.text = "TIME: " + Time +" sec";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
