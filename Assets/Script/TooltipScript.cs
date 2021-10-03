 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void ShowTooltip()
    {
        gameObject.SetActive(true);   
    }

    // Update is called once per frame
    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
