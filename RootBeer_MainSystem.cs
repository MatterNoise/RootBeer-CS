using System;
using SDL3;

namespace RootBeer_CS;
public class RootBeer_MainSystem
{
    // Variable declarations
    public static nint MainWindow;
    public static nint MainRenderer;

    private static bool WindowExitTryed;

    private static double MeasurementTimeStart;
    private static double MeasurementTimeEnd;
    public static double DeltaTime;

    public static byte[] KeysPressingStates = new byte[512];
    public static byte[] MouseButtonPressingStates = new byte[16];

    // Function declarations
    public static void InitInstance(string _WindowTitle, int _WindowWidth, int _WindowHeight)
    {
        // Try to init all of the SDL functions
        if (!SDL.Init(0))
        {
            Console.WriteLine("Error while initializing SDL3!.");
            
            return;
        }

        if (!SDL.CreateWindowAndRenderer(_WindowTitle, _WindowWidth, _WindowHeight, 0, out MainWindow, out MainRenderer))
        {
            Console.WriteLine("Error while initializing the Window and Renderer!.");
        }
    }
    public static void CloseInstance()
    {
        SDL.DestroyRenderer(MainRenderer);
        SDL.DestroyWindow(MainWindow);

        SDL.Quit();
    }

    public static void GetDeltaTimeMeasurement()
    {
        MeasurementTimeEnd = ((double)SDL.GetTicks());

        DeltaTime = (MeasurementTimeEnd - MeasurementTimeStart) / 1000;
        //Console.WriteLine($"{DeltaTime}");

        MeasurementTimeStart = ((double)SDL.GetTicks());
    }

    public static void PollEvents()
    {
        SDL.Event WindowEvent;

        WindowExitTryed = false;

        int IKey = 0;
        while (IKey < 512)
        {
            if (KeysPressingStates[IKey] == RootBeer_KeyboardConstants.KEY_PRESSED_NUM)
            {
                KeysPressingStates[IKey] = RootBeer_KeyboardConstants.KEY_HOLDED_NUM;
            } else if (KeysPressingStates[IKey] == RootBeer_KeyboardConstants.KEY_RELEASED_NUM)
            {
                KeysPressingStates[IKey] = RootBeer_KeyboardConstants.KEY_UNPRESSED_NUM;
            }
            
            IKey = IKey + 1;
        }

        int IMouseButton = 0;
        while (IMouseButton < 16)
        {
            if (MouseButtonPressingStates[IMouseButton] == RootBeer_MouseButtonsConstants.BUTTON_PRESSED_NUM)
            {
                MouseButtonPressingStates[IMouseButton] = RootBeer_MouseButtonsConstants.BUTTON_HOLDED_NUM;
            }
            else if (MouseButtonPressingStates[IMouseButton] == RootBeer_MouseButtonsConstants.BUTTON_RELEASED_NUM)
            {
                MouseButtonPressingStates[IMouseButton] = RootBeer_MouseButtonsConstants.BUTTON_UNPRESSED_NUM;
            }

            IMouseButton = IMouseButton + 1;
        }

        // Fetch the events ocurred on the Main window
        while (SDL.PollEvent(out WindowEvent))
        {
            switch (WindowEvent.Type)
            {
                case (uint)SDL.EventType.Quit:
                    WindowExitTryed = true;

                    break;
                
                // Keyboard keys events
                case (uint)SDL.EventType.KeyDown:
                    if (WindowEvent.Key.Repeat == false)
                    {
                        KeysPressingStates[(UInt16)WindowEvent.Key.Scancode] = RootBeer_KeyboardConstants.KEY_PRESSED_NUM;
                    }

                    break;
                case (uint)SDL.EventType.KeyUp:
                    KeysPressingStates[(UInt16)WindowEvent.Key.Scancode] = RootBeer_KeyboardConstants.KEY_RELEASED_NUM;

                    break;

                // Mouse buttons events
                case (uint)SDL.EventType.MouseButtonDown:
                    MouseButtonPressingStates[WindowEvent.Button.Button] = RootBeer_MouseButtonsConstants.BUTTON_PRESSED_NUM;

                    break;
                case (uint)SDL.EventType.MouseButtonUp:
                    MouseButtonPressingStates[WindowEvent.Button.Button] = RootBeer_MouseButtonsConstants.BUTTON_RELEASED_NUM;

                    break;
            }
        }
    }

    public static bool IsMouseButtonJustPressed()
    {
        
        
        return false;
    }

    public static bool GetWindowQuitAttempt()
    {
        return WindowExitTryed;
    }
}