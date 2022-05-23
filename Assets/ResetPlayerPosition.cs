using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : ResetPosition
{

    StarterAssets.FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<StarterAssets.FirstPersonController>();
    }

    public override void DoReset()
    {
        controller.enabled = false;
        base.DoReset();
        controller.enabled = true;
    }
}
