using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    public int poop;


    // Update is called once per frame
    void Update()
    {
        text.text = "score" + poop;
    }
}
