using UnityEngine;

public static class OverlapSphereAttack
{
    public static bool GetTarget(Vector3 origin, float radius, out IDamagable target)
    {
        target = null;

        Collider[] list = Physics.OverlapSphere(origin, radius);

        foreach (Collider item in list)
        {
            IDamagable d = item.GetComponent<IDamagable>();

            if (d != null)
            {
                target = d;
                return true;
            }
        }

        return false;
    }
}