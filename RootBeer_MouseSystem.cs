using System;
using SDL3;

namespace RootBeer_CS;
public class RootBeer_MouseSystem
{
    // Return the Global mouse position relative to the Window
    public static void GetWindowMousePosition(nint _Window, out float _MousePositionX, out float _MousePositionY, out bool _IsMouseOutside)
    {
        int GlobalWindowPositionX;
        int GlobalWindowPositionY;
        int GlobalWindowWidth;
        int GlobalWindowHeight;

        float GlobalMousePositionX;
        float GlobalMousePositionY;

        SDL.GetGlobalMouseState(out GlobalMousePositionX, out GlobalMousePositionY);
        
        SDL.GetWindowPosition(_Window, out GlobalWindowPositionX, out GlobalWindowPositionY);
        SDL.GetWindowSize(_Window, out GlobalWindowWidth, out GlobalWindowHeight);

        float RelativeToWindowMousePositionX = GlobalMousePositionX - GlobalWindowPositionX;
        float RelativeToWindowMousePositionY = GlobalMousePositionY - GlobalWindowPositionY;

        _IsMouseOutside = false;
        if (RelativeToWindowMousePositionX < 0 || RelativeToWindowMousePositionX > GlobalWindowWidth)
        {
            _IsMouseOutside = true;
        }
        if (RelativeToWindowMousePositionY < 0 || RelativeToWindowMousePositionY > GlobalWindowHeight)
        {
            _IsMouseOutside = true;
        }

        _MousePositionX = RelativeToWindowMousePositionX;
        _MousePositionY = RelativeToWindowMousePositionY;
    }

    public static bool IsMouseButtonHolded(byte _MouseButtonID)
    {
        if (RootBeer_MainSystem.MouseButtonPressingStates[_MouseButtonID] == RootBeer_MouseButtonsConstants.BUTTON_PRESSED_NUM ||
            RootBeer_MainSystem.MouseButtonPressingStates[_MouseButtonID] == RootBeer_MouseButtonsConstants.BUTTON_HOLDED_NUM ||
            RootBeer_MainSystem.MouseButtonPressingStates[_MouseButtonID] == RootBeer_MouseButtonsConstants.BUTTON_RELEASED_NUM)
        {
            return true;
        }

        return false;
    }
    public static bool IsMouseButtonPressed(byte _MouseButtonID)
    {
        if (RootBeer_MainSystem.MouseButtonPressingStates[_MouseButtonID] == RootBeer_MouseButtonsConstants.BUTTON_PRESSED_NUM)
        {
            return true;
        }

        return false;
    }
    public static bool IsMouseButtonReleased(byte _MouseButtonID)
    {
        if (RootBeer_MainSystem.MouseButtonPressingStates[_MouseButtonID] == RootBeer_MouseButtonsConstants.BUTTON_RELEASED_NUM)
        {
            return true;
        }

        return false;
    }
}