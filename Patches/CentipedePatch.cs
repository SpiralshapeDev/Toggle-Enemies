using HarmonyLib;
using UnityEngine;

namespace ToggleEnemies.Patches
{
    [HarmonyPatch(typeof(CentipedeAI))]
    internal class CentipedePatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PatchUpdate()
        {
            if (!ToggleEnemiesBase.RemoveSnareFlea.Value) { return; }
            if (!GameNetworkManager.Instance.isHostingGame) { return; }

            var obj = UnityEngine.Object.FindObjectOfType<CentipedeAI>();
            obj.serverPosition = new Vector3(0, -1000, 0);
            obj.SyncPositionToClients();
            obj.enemyType.canDie = true;
            obj.KillEnemyClientRpc(true);
            obj.KillEnemyOnOwnerClient(true);
            ToggleEnemiesBase.logger.LogInfo("A snare flea has been deleted.");
            GameNetworkManager.DestroyImmediate(obj);
            UnityEngine.Object.DestroyImmediate(obj);
        }
    }
}
