
using System.Windows.Input;

public class CharSelectCommand : ButtonCommand
{
    private CharSelectShowSelected CSSS;
    private int CharNum;

    public CharSelectCommand(CharSelectShowSelected CSSS2,int CharNum2)
    {
        CSSS = CSSS2;
        CharNum = CharNum2;
    }


    public void Execute()
    {
        PlayerStuffTracker.WhichCharacter = CharNum;

        CSSS.UpdateSpot(CharNum);

    }


}
