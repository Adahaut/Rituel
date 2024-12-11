using UnityEngine;

[CreateAssetMenu(fileName = "SuccessData", menuName = "Success/SuccessData")]
public class SuccessData : ScriptableObject
{
   private bool unlock = false;
   public string _successName;
   public string _description;
   public Sprite _succesImage;

   public void UnlockSuccess()
   {
      unlock = true;
   }

   public bool GetUnlock()
   {
      return unlock;
   }
}
