using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace ToggleEnemies
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class ToggleEnemiesBase : BaseUnityPlugin
    {
        private const string ModGuid = "SpiralMods." + ModName;
        private const string ModName = "ToggleEnemies";
        private const string ModVersion = "1.0.8";

        private readonly Harmony _harmony = new Harmony(ModGuid);

        private static ToggleEnemiesBase _instance;
        
        public static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource(ModGuid);
        

        public static BepInEx.Configuration.ConfigEntry<bool> RemoveSnareFlea, RemoveBunkerSpider, RemoveLootBug, RemoveBracken, RemoveThumper, RemoveSlime, RemoveDressGirl, RemovePuffer, RemoveNutcracker, RemoveCoilHead, RemoveJester, RemoveMasked, RemoveMouthDog, RemoveGiant, RemoveWorm, RemoveBaboonHawk, RemoveOldBird, RemoveButler, RemoveFlowerSnake, RemoveBarber, RemoveFox, RemoveLasso, RemoveCadaver;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            logger = BepInEx.Logging.Logger.CreateLogSource(ModGuid);

            logger.LogInfo( ModName + " has loaded (ModVersion: " + ModVersion + ", ModGUID: " + ModGuid + ")!");

            this.SetBindings();
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

        }
        private void SetBindings()
        {
            ToggleEnemiesBase.RemoveSnareFlea = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Snare Fleas", false, "If true, snare fleas won't ever spawn!");
            ToggleEnemiesBase.RemoveBunkerSpider = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Bunker Spiders", false, "If true, bunker spiders won't ever spawn!");
            ToggleEnemiesBase.RemoveLootBug = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Loot Bugs", false, "If true, loot bugs won't ever spawn!");
            ToggleEnemiesBase.RemoveBracken = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Brackens", false, "If true, brackens won't ever spawn!");
            ToggleEnemiesBase.RemoveThumper = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Thumpers", false, "If true, thumpers won't ever spawn!");
            ToggleEnemiesBase.RemoveSlime = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Slimes", false, "If true, slimes won't ever spawn!");
            ToggleEnemiesBase.RemoveDressGirl = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Ghost Girls", false, "If true, the ghost girl won't ever spawn!");
            ToggleEnemiesBase.RemovePuffer = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Spore Lizards", false, "If true, spore lizards won't ever spawn!");
            ToggleEnemiesBase.RemoveNutcracker = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Nutcrackers", false, "If true, nutcrackers won't ever spawn!");
            ToggleEnemiesBase.RemoveCoilHead = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Coil Heads", false, "If true, coil heads won't ever spawn!");
            ToggleEnemiesBase.RemoveJester = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Jesters", false, "If true, jesters won't ever spawn!");
            ToggleEnemiesBase.RemoveMasked = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Masked Players", false, "If true, masked players won't ever spawn!");
            ToggleEnemiesBase.RemoveMouthDog = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Eyeless Dogs", false, "If true, eyeless dogs won't ever spawn!");
            ToggleEnemiesBase.RemoveGiant = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Giants", false, "If true, giants won't ever spawn!");
            ToggleEnemiesBase.RemoveWorm = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Worms", false, "If true, worms won't ever spawn!");
            ToggleEnemiesBase.RemoveBaboonHawk = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Baboon Hawks", false, "If true, baboon hawks won't ever spawn!");
            ToggleEnemiesBase.RemoveButler = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Butlers", false, "If true, butlers won't ever spawn!");
            ToggleEnemiesBase.RemoveOldBird = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Old Birds", false, "If true, old birds won't ever spawn!");
            ToggleEnemiesBase.RemoveFlowerSnake = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Flower Snakes", false, "If true, flower snakes won't ever spawn!");
            ToggleEnemiesBase.RemoveBarber = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Barbers", false, "If true, barbers won't ever spawn!");
            ToggleEnemiesBase.RemoveFox = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Kidnapper Foxes", false, "If true, foxes won't ever spawn!");
            ToggleEnemiesBase.RemoveLasso = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Lasso Man", false, "If true, lasso Man won't spawn during modded!");
            ToggleEnemiesBase.RemoveCadaver = this.Config.Bind<bool>("Settings (Restart Required)", "Disable Lasso Man", false, "If true, cadavers won't ever spawn!");
        }
    }
}
