using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]




public struct Vector2D { 



    public float x;
    public float y;

}


public class MyPlugin
{

    [DllImport("game_engines_pain")]
    private static extern int GetID();


    [DllImport("game_engines_pain")]
    private static extern void SetId(int id);

    [DllImport("game_engines_pain")]
    private static extern Vector2D GetPosition();

    [DllImport("game_engines_pain")]
    private static extern void SetPosition(float x, float y);




    public static int ID
    {


        get { return GetID(); }

       
        set { SetId(value); }

    }


    public static Vector2D Position
    {

        get { return GetPosition(); }
        set { SetPosition(value.x, value.y); }

    }





}


