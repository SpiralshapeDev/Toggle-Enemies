using HarmonyLib;
using UnityEngine;

namespace ToggleEnemies.Patches
{
    [HarmonyPatch(typeof(SandSpiderAI))]
    internal class SandSpiderPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PatchUpdate()
        {
            if (!ToggleEnemiesBase.RemoveBunkerSpider.Value) { return; }
            if (!GameNetworkManager.Instance.isHostingGame) { return; }

            var obj = UnityEngine.Object.FindObjectOfType<SandSpiderAI>();
            obj.serverPosition = new Vector3(0, -1000, 0);
            obj.SyncPositionToClients();
            obj.enemyType.canDie = true;
            obj.KillEnemyClientRpc(true);
            obj.KillEnemyOnOwnerClient(true);
            ToggleEnemiesBase.logger.LogInfo("A bunker spider has been deleted.");
            GameNetworkManager.DestroyImmediate(obj);
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
}
