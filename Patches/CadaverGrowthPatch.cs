using HarmonyLib;
using UnityEngine;

namespace ToggleEnemies.Patches
{
    [HarmonyPatch(typeof(CadaverGrowthAI))]
    internal class CadaverGrowthPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PatchUpdate()
        {
            if (!ToggleEnemiesBase.RemoveCadaver.Value) { return; }
            if (!GameNetworkManager.Instance.isHostingGame) { return; }

            var obj = UnityEngine.Object.FindObjectOfType<CadaverGrowthAI>();
            obj.serverPosition = new Vector3(0, -1000, 0);
            obj.SyncPositionToClients();
            obj.enemyType.canDie = true;
            obj.KillEnemyClientRpc(true);
            obj.KillEnemyOnOwnerClient(true);
            ToggleEnemiesBase.logger.LogInfo("A cadaver growth has been deleted.");
            GameNetworkManager.DestroyImmediate(obj);
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
}
