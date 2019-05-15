using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCat : MonoBehaviour
{
    public void SetWinAnimation() {
        GetComponent<Animator>().SetBool("Game Win", true);
    }
}
