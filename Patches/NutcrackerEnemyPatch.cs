using HarmonyLib;
using UnityEngine;

namespace ToggleEnemies.Patches
{
    [HarmonyPatch(typeof(NutcrackerEnemyAI))]
    internal class NutcrackerEnemyPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PatchUpdate()
        {
            if (!ToggleEnemiesBase.RemoveNutcracker.Value) { return; }
            if (!GameNetworkManager.Instance.isHostingGame) { return; }

            var obj = UnityEngine.Object.FindObjectOfType<NutcrackerEnemyAI>();
            obj.serverPosition = new Vector3(0, -1000, 0);
            obj.SyncPositionToClients();
            obj.enemyType.canDie = true;
            obj.KillEnemyClientRpc(true);
            obj.KillEnemyOnOwnerClient(true);
            ToggleEnemiesBase.logger.LogInfo("A nutcracker has been deleted.");
            GameNetworkManager.DestroyImmediate(obj);
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
}
