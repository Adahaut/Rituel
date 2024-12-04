using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Partitions", menuName = "ScriptableObjects/Partitions")]
public class Partition : ScriptableObject
{
    public List<string> partitionKeys;
}
