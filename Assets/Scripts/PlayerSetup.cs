using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    public Behaviour[] componentsToDisable;

    private Camera mainCam;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (Behaviour comp in componentsToDisable)
                comp.enabled = false;
        }
        else
        {
            // TODO move somewhere else
            mainCam = Camera.main;
            if (mainCam != null)
                mainCam.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (mainCam != null)
            mainCam.gameObject.SetActive(true);
    }
}