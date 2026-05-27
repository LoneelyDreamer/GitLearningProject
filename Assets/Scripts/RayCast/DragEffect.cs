using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public class DragEffect : IRayCastEffect
    {
        public void Exsecute(Vector3 point, Collider collider)
        {
            IDragable dragable = collider.GetComponent<IDragable>();

            if (dragable != null)
            {
                dragable.Drag(point);
            }
            //collider.gameObject.transform.position = new Vector3(point.x, collider.gameObject.transform.position.y, point.z);
        }
    }
}
