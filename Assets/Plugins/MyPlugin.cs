using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]



public class MyPlugin
{


    [DllImport("Game_engines_pain")]
    private static extern IntPtr GetLevel0Name();

    public static string Level0Name =>
        Marshal.PtrToStringAnsi(GetLevel0Name());



    [DllImport("Game_engines_pain")]
    private static extern IntPtr GetLevel1Name();

    public static string Level1Name =>
        Marshal.PtrToStringAnsi(GetLevel1Name());



    [DllImport("Game_engines_pain")]
    private static extern IntPtr GetLevel2Name();

    public static string Level2Name =>
        Marshal.PtrToStringAnsi(GetLevel2Name());



    [DllImport("Game_engines_pain")]
    private static extern IntPtr GetLevel3Name();

    public static string Level3Name =>
        Marshal.PtrToStringAnsi(GetLevel3Name());







    [DllImport("Game_engines_pain")]
    private static extern IntPtr GetLevel4Name();

    public static string Level4Name =>
        Marshal.PtrToStringAnsi(GetLevel4Name());


}


