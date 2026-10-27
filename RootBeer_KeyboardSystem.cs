using System;
using SDL3;

namespace RootBeer_CS;

public class RootBeer_KeyboardSystem
{
    public static bool IsKeyHolded(UInt16 _Key)
    {
        if (RootBeer_MainSystem.KeysPressingStates[_Key] == RootBeer_KeyboardConstants.KEY_PRESSED_NUM ||
            RootBeer_MainSystem.KeysPressingStates[_Key] == RootBeer_KeyboardConstants.KEY_HOLDED_NUM ||
            RootBeer_MainSystem.KeysPressingStates[_Key] == RootBeer_KeyboardConstants.KEY_RELEASED_NUM)
        {
            return true;
        }

        return false;
    }
    public static bool IsKeyPressed(UInt16 _Key)
    {
        if (RootBeer_MainSystem.KeysPressingStates[_Key] == RootBeer_KeyboardConstants.KEY_PRESSED_NUM)
        {
            return true;
        }

        return false;
    }
    public static bool IsKeyReleased(UInt16 _Key)
    {
        if (RootBeer_MainSystem.KeysPressingStates[_Key] == RootBeer_KeyboardConstants.KEY_RELEASED_NUM)
        {
            return true;
        }

        return false;
    }
}