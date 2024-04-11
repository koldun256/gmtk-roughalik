using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootBehaviour : MonoBehaviour
{
    public abstract void OnPickUp(Player player);
}
