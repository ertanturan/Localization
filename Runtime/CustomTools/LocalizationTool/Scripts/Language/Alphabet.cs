using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReadOrder { RTL, LTR }
[CreateAssetMenu(
    fileName = "New Alphabet",
    menuName = "Localization/Alphabet")]
public class Alphabet : ScriptableObject
{
    public ReadOrder ReadOrder;
}
