using System;
using SDL3;

namespace RootBeer_CS;
public class RootBeer_MainSystem
{
    // Variable declarations
    public static List<RenderingWindow> RenderingWindows;
    
    private static bool WindowExitTryed;

    private static double MeasurementTimeStart;
    private static double MeasurementTimeEnd;
    public static double DeltaTime;

    public static byte[] KeysPressingStates = new byte[512];
    public static byte[] MouseButtonPressingStates = new byte[16];

    // Function declarations
    public static void InitInstance()
    {
        RenderingWindows = new List<RenderingWindow>();

        // Try to init all of the SDL functions
        if (!SDL.Init(0))
        {
            Console.WriteLine("Error while initializing SDL3!.");
            
            return;
        }

        if (!SDL3.TTF.Init())
        {
            Console.WriteLine("Error while initializing SDL3 Font system!.");
        }
    }

    public static void CloseInstance()
    {
        //SDL.DestroyRenderer(MainRenderer);
        //SDL.DestroyWindow(MainWindow);

        SDL3.TTF.Quit();
        SDL.Quit();
    }

    public static RenderingWindow CreateNewWindow(string _WindowTitle, int _WindowWidth, int _WindowHeight)
    {
        RenderingWindow NewRenderingWindow = new RenderingWindow();
        
        if (!SDL.CreateWindowAndRenderer(_WindowTitle, _WindowWidth, _WindowHeight, SDL.WindowFlags.Resizable, out NewRenderingWindow.Window, out NewRenderingWindow.Renderer))
        {
            Console.WriteLine("Error while initializing the Window and Renderer!.");

            return null;
        }

        RenderingWindows.Add(NewRenderingWindow);

        return NewRenderingWindow;
    }

    public static void CloseWindow(RenderingWindow _Window)
    {
        SDL.DestroyRenderer(_Window.Renderer);
        SDL.DestroyWindow(_Window.Window);
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
        SDL.Event GlobalEvent;

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
        while (SDL.PollEvent(out GlobalEvent))
        {
            //GlobalEvent.Window


            switch (GlobalEvent.Window.Type)
            {
                case SDL.EventType.WindowCloseRequested:
                    WindowExitTryed = true;

                    break;
                
                // Keyboard keys events
                case SDL.EventType.KeyDown:
                    if (GlobalEvent.Key.Repeat == false)
                    {
                        KeysPressingStates[(UInt16)GlobalEvent.Key.Scancode] = RootBeer_KeyboardConstants.KEY_PRESSED_NUM;
                    }

                    break;
                case SDL.EventType.KeyUp:
                    KeysPressingStates[(UInt16)GlobalEvent.Key.Scancode] = RootBeer_KeyboardConstants.KEY_RELEASED_NUM;

                    break;

                // Mouse buttons events
                case SDL.EventType.MouseButtonDown:
                    MouseButtonPressingStates[GlobalEvent.Button.Button] = RootBeer_MouseButtonsConstants.BUTTON_PRESSED_NUM;

                    break;
                case SDL.EventType.MouseButtonUp:
                    MouseButtonPressingStates[GlobalEvent.Button.Button] = RootBeer_MouseButtonsConstants.BUTTON_RELEASED_NUM;

                    break;
            }
        }
    }

    public static bool GetWindowQuitAttempt()
    {
        return WindowExitTryed;
    }
}