using BepInEx;
using HarmonyLib;


namespace EdoAkse.Cheat.NewGamePoints
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "edoakse.starvalor.cheat.newgamepoints";
        public const string pluginName = "EdoAkse Cheat: Infinite points for new game.";
        public const string pluginVersion = "1.0.0";


        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Main));
        }

        [HarmonyPatch(typeof(NewGameSetupControl), "CalculateTotalStartingPoints")]
        [HarmonyPrefix]
        public static bool FixPoints(ref int __result, ref int ___startingPoints)
        {
            ___startingPoints = 0;
            __result = 0;
            return false;
        }
    }
}
