using HarmonyLib;
using UnityEngine;

namespace ToggleEnemies.Patches
{
    [HarmonyPatch(typeof(RadMechAI))]
    internal class OldBirdPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PatchUpdate()
        {
            if (!ToggleEnemiesBase.RemoveOldBird.Value) { return; }
            if (!GameNetworkManager.Instance.isHostingGame) { return; }

            var obj = UnityEngine.Object.FindObjectOfType<RadMechAI>();
            obj.serverPosition = new Vector3(0, -1000, 0);
            obj.SyncPositionToClients();
            obj.enemyType.canDie = true;
            obj.KillEnemyClientRpc(true);
            obj.KillEnemyOnOwnerClient(true);
            ToggleEnemiesBase.logger.LogInfo("An old bird has been deleted.");
            GameNetworkManager.DestroyImmediate(obj);
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
}
