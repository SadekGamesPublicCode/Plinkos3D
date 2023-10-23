using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSphereSC : MonoBehaviour
{
    [SerializeField] MainMenuSC mm;
    [HideInInspector] int sphereOder;
    [HideInInspector] string sphereName;

    private void OnMouseDown()
    {
        if (mm.isPanelActive == false)
        {
            GetSphereOder();
            mm.OnShowPanel(sphereOder);
        }
    }

    private void GetSphereOder()
    {
        sphereName = gameObject.name;
        switch (sphereName)
        {
            case ("OBJ_PlayButton"):
                sphereOder = 0;
                break;
            case ("OBJ_CreditButton"):
                sphereOder = 1;
                break;
            case ("OBJ_InfoBtton"):
                sphereOder = 2;
                break;
            case ("OBJ_MarketBtton"):
                sphereOder = 3;
                break;
            case ("OBJ_LeaderButton"):
                sphereOder = 4;
                break;
            case ("OBJ_OptionButton"):
                sphereOder = 5;
                break;
        }
    }
    public void OnClosePanelEvent() => mm.isPanelActive = false;
}
