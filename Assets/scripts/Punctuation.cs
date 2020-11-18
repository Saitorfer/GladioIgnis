using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punctuation : MonoBehaviour
{
    public Text txtEn;
    public Text txtRo;
    public Text txtDa;

    private static int en;
    private static int ro;
    private static float da;

    public static int En { get => en; set => en = value; }
    public static int Ro { get => ro; set => ro = value; }
    public static float Da { get => da; set => da = value; }


    // Start is called before the first frame update
    void Start()
    {
        txtEn.text = "KILLED ENEMIES: " + en;
        txtRo.text = "SURVIVED ROUNDS: " + ro;
        txtDa.text = "RECEIVED DAMAGE: " + da;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
