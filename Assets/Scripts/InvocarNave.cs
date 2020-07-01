using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocarNave : MonoBehaviour
{
    public float frequencia = 1f;
    public int fibonacciAtual = 1;
    public int fibonacciLimite = 6;

    private Vector2 screenBounds;

    SpaceshipCounterScript spaceshipScript;
    GameObject labelText;


    // Start is called before the first frame update
    void Start()
    {
        labelText = GameObject.Find("labelText");
        spaceshipScript = labelText.GetComponent<SpaceshipCounterScript>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        InvokeRepeating("FlySequence", frequencia, frequencia);

    }

    void FlySequence()
    {
        Fly(Fib(fibonacciAtual));

        if(fibonacciAtual < fibonacciLimite)
            fibonacciAtual++;
    }

    void Fly(int cont)
    {
        GameObject obj = NewObjectPoolerScript.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = new Vector2(transform.position.x, Random.Range(-screenBounds.y, screenBounds.y));
        obj.SetActive(true);
        spaceshipScript.LabelScore++;

        if (cont > 1)
        {
            cont--;
            Fly(cont);
        }

    }

    int Fib(int n) 
    {
        if(n <= 0)
            return 0;

        if(n == 1)
            return 1;

        return Fib(n-1) + Fib(n-2); 
    }

}
