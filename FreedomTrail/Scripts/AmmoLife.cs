using UnityEngine;

public class AmmoLife : MonoBehaviour
{
    public int lifeTime = 2;
    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }
}
