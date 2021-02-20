using System;

public class LogicButtonBack
{
    public LogicButtonBack()
    {
    }

    public void GoToBack(int esceneNumber)
    {
        ServiceLocator.Instance.GetService<IPlaySoundEfect>().PlayOneShot("Click");
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(esceneNumber);
    }
}