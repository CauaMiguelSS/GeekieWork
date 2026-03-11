using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public CloneBoss[] clones;
    public float delayBetweenClones = 1f;

    void Start()
    {
        StartCoroutine(BossLoop());
    }

    IEnumerator BossLoop()
    {
        while (true)
        {
            foreach (CloneBoss clone in clones)
            {
                if (clone != null)
                {
                    clone.StartAttack();

                    yield return new WaitForSeconds(clone.attackDuration + delayBetweenClones);
                }
            }
        }
    }
}
