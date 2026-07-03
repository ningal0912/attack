using UnityEngine;

public static class Raycasting
{
    public static bool GetTarget(Vector3 origin, Vector3 dir, out IDamagable target) {
        target = null;

        if(Physics.Raycast(origin, dir, out RaycastHit hit,1000))
        {
            return true;
        }

        return false;
    }

    public static bool GetTargetByLine(Vector3 origin, Vector3 dir, out IDamagable target)
    {
        target = null;
        if (Physics.Raycast(origin, dir, out RaycastHit hit, 1000))
        {
            if(hit.transform is IDamagable d)
            {
                target = d;
            }
            return true;
        }
        return false;
    }
}
