using UnityEngine;

namespace CodeBase.HelpTools
{
   public static class PhysicsDebug
   {
      public static void DrawBox(Vector3 center, Vector3 halfSize, float duration)
      {
         Debug.DrawLine(center - halfSize, new Vector3(center.x + halfSize.x, center.y - halfSize.y, center.z - halfSize.z), Color.green, duration);
         Debug.DrawLine(center - halfSize, new Vector3(center.x - halfSize.x, center.y + halfSize.y, center.z - halfSize.z), Color.green, duration);
         Debug.DrawLine(center - halfSize, new Vector3(center.x - halfSize.x, center.y - halfSize.y, center.z + halfSize.z), Color.green, duration);
         
         Debug.DrawLine(center + halfSize, new Vector3(center.x - halfSize.x, center.y + halfSize.y, center.z + halfSize.z), Color.green, duration);
         Debug.DrawLine(center + halfSize, new Vector3(center.x + halfSize.x, center.y - halfSize.y, center.z + halfSize.z), Color.green, duration);
         Debug.DrawLine(center + halfSize, new Vector3(center.x + halfSize.x, center.y + halfSize.y, center.z - halfSize.z), Color.green, duration);
         
         Debug.DrawLine(
            new Vector3(center.x + halfSize.x, center.y - halfSize.y, center.z + halfSize.z), 
            new Vector3(center.x + halfSize.x, center.y - halfSize.y, center.z - halfSize.z), Color.green, duration);
         
         Debug.DrawLine(
            new Vector3(center.x + halfSize.x, center.y - halfSize.y, center.z + halfSize.z), 
            new Vector3(center.x - halfSize.x, center.y - halfSize.y, center.z + halfSize.z), Color.green, duration);
         
         Debug.DrawLine(
            new Vector3(center.x - halfSize.x, center.y + halfSize.y, center.z - halfSize.z), 
            new Vector3(center.x - halfSize.x, center.y + halfSize.y, center.z + halfSize.z), Color.green, duration);
         
         Debug.DrawLine(
            new Vector3(center.x - halfSize.x, center.y + halfSize.y, center.z - halfSize.z), 
            new Vector3(center.x + halfSize.x, center.y + halfSize.y, center.z - halfSize.z), Color.green, duration);
         
         Debug.DrawLine(
            new Vector3(center.x - halfSize.x, center.y - halfSize.y, center.z + halfSize.z), 
            new Vector3(center.x - halfSize.x, center.y + halfSize.y, center.z + halfSize.z), Color.green, duration);
         
         Debug.DrawLine(
            new Vector3(center.x + halfSize.x, center.y - halfSize.y, center.z - halfSize.z), 
            new Vector3(center.x + halfSize.x, center.y + halfSize.y, center.z - halfSize.z), Color.green, duration);
      }
   }
}