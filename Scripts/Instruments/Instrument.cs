using System;
using Godot;

namespace Uniwander.Scripts.Instruments;

public partial class Instrument : Node
{
    public event EventHandler? ActivatingWhenClickInWorld;
    
    public event EventHandler? ActivatingWhenClickInPanel;
    

    virtual public void OnActivatingWhenClickInWorld()
    {
        ActivatingWhenClickInWorld?.Invoke(this, EventArgs.Empty);
    }

    virtual public void OnActivatingWhenClickInPanel()
    {
        ActivatingWhenClickInPanel?.Invoke(this, EventArgs.Empty);
    }
}