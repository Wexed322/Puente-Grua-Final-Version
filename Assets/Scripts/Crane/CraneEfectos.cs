using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneEfectos : MonoBehaviour
{
    CraneController_ myCraneController;

    [Header("---- Audio ----")]
    public AudioClip cableEnrollado;
    public float volume;
    public AudioClip puenteGruaMovimiento;
    void Start()
    {
        myCraneController = GetComponent<CraneController_>();
        GameManager.GameManagerInstance.soundManagerInstance.playDifferentSounds(new List<AudioClip>() { cableEnrollado, puenteGruaMovimiento });
    }

    void Update()
    {
        if (myCraneController.cuerdaEnrollando)
        {
            GameManager.GameManagerInstance.soundManagerInstance.activeSound(0);
        }
        else 
        {
            GameManager.GameManagerInstance.soundManagerInstance.desactiveSound(0);
        }


        if (myCraneController.puenteGruaMoviendose) 
        {
            GameManager.GameManagerInstance.soundManagerInstance.activeSound(1);
        }

        else
        {
            GameManager.GameManagerInstance.soundManagerInstance.desactiveSound(1);
        }
    }
}
