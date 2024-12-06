using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Partitions", menuName = "PartitionsData/Partitions")]
public class Partition : ScriptableObject
{
    public List<string> partitionKeys;
}
