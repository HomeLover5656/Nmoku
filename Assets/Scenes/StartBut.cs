using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBut : MonoBehaviour
{
    public Dropdown Level,CubeScale,Starter;
    public Toggle NonCenter;
    public static int lvl, n,starter;
    public static bool noncenter;
    public void Startbutton()
    {
        lvl = Level.value;
        n = CubeScale.value + 3;
        starter = Starter.value+1;
        noncenter = NonCenter.isOn;
        SceneManager.LoadScene("SanmokuScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
