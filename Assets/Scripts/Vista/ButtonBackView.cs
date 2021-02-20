using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBackView : MonoBehaviour
{
    [SerializeField] private Button button;
    private LogicButtonBack logic;
    [SerializeField] private int esceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        logic = new LogicButtonBack();
        button.onClick.AddListener(delegate { logic.GoToBack(esceneNumber); });
    }
}
