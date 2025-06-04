namespace HoldTheGrenades
{
    public static class Debug
    {
        public static void Log(object message)
        {
#if DEBUG
            Verse.Log.Message($"[{HoldTheGrenadesMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
