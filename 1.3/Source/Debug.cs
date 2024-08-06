namespace HoldTheGrenades
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{HoldTheGrenadesMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
