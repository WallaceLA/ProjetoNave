using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class SpaceshipCounterScript : MonoBehaviour
{
    public Text labelTxt;
    public int LabelScore { get; set; }


    // Use this for initialization
    void Start()
    {

        labelTxt.text = "Naves criadas: 0";
        LabelScore = 0;

    }


    // Update is called once per frame
    void Update()
    {

        labelTxt.text = "Naves criadas: " + LabelScore;

    }
}