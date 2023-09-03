using Uniwander.Scripts.Core;
using Uniwander.Scripts.Enums;

namespace Uniwander.Scripts;

public static class Global
{
    public static GameScene GameScene { get; set; }
    
    public static GameSession CurrentGameSession { get; private set; }

    public static void CreateGameSession() => CurrentGameSession = new GameSession();
}