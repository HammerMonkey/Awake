using System.Runtime.InteropServices;

public class MouseMover
{
    private const int MOUSEEVENTF_MOVE = 0x0001;
    private const int MOUSE_MOVE_DISTANCE = 1;

    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

    public async Task Start()
    {
        await MoveMouseLeftAndRightAsync();
    }

    private async Task MoveMouseLeftAndRightAsync()
    {
        while (true)
        {
            MoveMouse(-MOUSE_MOVE_DISTANCE, 0); // Move left
            await Task.Delay(10); // 10 milliseconds delay
            MoveMouse(MOUSE_MOVE_DISTANCE, 0); // Move right
            await Task.Delay(1000); // 1 second delay
        }
    }

    private static void MoveMouse(int deltaX, int deltaY)
    {
        mouse_event(MOUSEEVENTF_MOVE, deltaX, deltaY, 0, 0);
    }
}