using System.Diagnostics;

namespace WindowsPet
{
    public partial class PetForm : Form
    {
        private Pet WindowsPet { get; init; }
        private IntPtr HomeHandle { get; init; }

        public PetForm(Pet windowsPet, IntPtr homeHandle)
        {
            WindowsPet = windowsPet;
            HomeHandle = homeHandle;
            InitializeComponent();

            new Thread(AnimationController).Start();
            new Thread(MovementController).Start();

            new Thread(BehaviorController).Start();
        }

        private void BehaviorController()
        {
            Random random = new();
            Array movementStates = Enum.GetValues(typeof(MovementState));
            MovementState newMovementState;

            while (true)
            {
                newMovementState = (MovementState)movementStates.GetValue(random.Next(movementStates.Length))!;

                if (newMovementState == MovementState.TowardsRandomLocation)
                {
                    ScreenLocationManager.NewRandomLocation();
                }

                WindowsPet.MovementState = newMovementState;

                Thread.Sleep(random.Next(7000, 20000 + 1));
            }
        }

        private void AnimationController()
        {
            Animation animationRunning = WindowsPet.IdleAnimation;
            Stopwatch animationTimer = new();

            while (true)
            {
                if (WindowsPet.AnimationState == AnimationState.Idle && animationRunning != WindowsPet.IdleAnimation)
                {
                    animationRunning.Reset();
                    animationRunning = WindowsPet.IdleAnimation;
                }
                else if (WindowsPet.AnimationState == AnimationState.Moving && animationRunning != WindowsPet.WalkAnimation)
                {
                    animationRunning.Reset();
                    animationRunning = WindowsPet.WalkAnimation;
                }

                if (animationTimer.ElapsedMilliseconds >= animationRunning.FrameDelayInMilliseconds)
                {
                    SetFrame(animationRunning.NextFrame(WindowsPet.Direction));
                    animationTimer.Restart();
                }
                else if (!animationTimer.IsRunning)
                {
                    SetFrame(animationRunning.NextFrame(WindowsPet.Direction));
                    animationTimer.Start();

                    SetSizeToFit();
                }
            }
        }

        private void MovementController()
        {
            int speedInPixelsPerSec = 1000;

            while (true)
            {
                Thread.Sleep(5);

                if (HomeForm.StayAtHome)
                {
                    GoTowardsHome(speedInPixelsPerSec);
                    continue;
                }

                switch (WindowsPet.MovementState)
                {
                    case MovementState.Nowhere:
                        WindowsPet.AnimationState = AnimationState.Idle;
                        break;

                    case MovementState.TowardsMouse:
                        GoTowardsMouse(speedInPixelsPerSec);
                        break;

                    case MovementState.TowardsFocusedWindow:
                        GoTowardsFocusedWindow(speedInPixelsPerSec);
                        break;

                    case MovementState.TowardsRandomLocation:
                        GoTowardsRandomLocation(speedInPixelsPerSec);
                        break;
                }
            }
        }

        private void GoTowardsMouse(int pixelsPerSec)
        {
            Point mouseLocation = MouseManager.GetMouseLocation();
            GoTowardsLocation(mouseLocation, pixelsPerSec);
        }

        private void GoTowardsFocusedWindow(int pixelsPerSec)
        {
            WindowManager.RECT? rect = WindowManager.GetFocusedWindowRectangle(GetPetHandle(), HomeHandle);
            if (rect is not null)
            {
                GoTowardsLocation(new Point((rect.Value.Left + rect.Value.Right) / 2, rect.Value.Top), pixelsPerSec);
            }
        }

        private void GoTowardsHome(int pixelsPerSec)
        {
            WindowManager.RECT rect = WindowManager.GetWindowRectangle(HomeHandle);
            GoTowardsLocation(new Point((rect.Left + rect.Right) / 2, rect.Top), pixelsPerSec);
        }

        private void GoTowardsRandomLocation(int pixelsPerSec)
        {
            GoTowardsLocation(ScreenLocationManager.RandomLocation, pixelsPerSec);
        }

        private void GoTowardsLocation(Point location, int pixelsPerSec)
        {
            if (location.Equals(GetLocation()))
            {
                WindowsPet.AnimationState = AnimationState.Idle;
                return;
            }

            WindowsPet.AnimationState = AnimationState.Moving;
            WindowsPet.Direction = GetLocation().X > location.X ? Direction.Left : Direction.Right;

            int speed = pixelsPerSec / 200;

            Point directionVector = new(location.X - GetLocation().X, location.Y - GetLocation().Y);
            double magnitude = Math.Sqrt(Math.Pow(directionVector.X, 2) + Math.Pow(directionVector.Y, 2));

            if (magnitude <= speed)
            {
                SetLocation(location);
                return;
            }

            (double normalizedX, double normalizedY) = (directionVector.X / magnitude, directionVector.Y / magnitude);

            Point newLocation = new(GetLocation().X + (normalizedX * speed).Round(), GetLocation().Y + (normalizedY * speed).Round());

            SetLocation(newLocation);
        }

        private Point GetLocation()
        {
            return new Point(Location.X + WindowsPet.Size.Width / 2, Location.Y + WindowsPet.Size.Height);
        }

        private void SetFrame(Bitmap frame)
        {
            if (pictureBox.InvokeRequired)
            {
                Invoke(() => {
                    pictureBox.Image = frame;
                });
            }
            else
            {
                pictureBox.Image = frame;
            }
        }

        private void SetLocation(Point location)
        {
            if (InvokeRequired)
            {
                Invoke(() => { Location = new Point(location.X - 32 * 3 / 2, location.Y - 32 * 3); });
            }
            else
            {
                Location = new Point(location.X - 32 * 3 / 2, location.Y - 32 * 3);
            }
        }

        private void SetSizeToFit()
        {
            if (InvokeRequired)
            {
                Invoke(() => { Size = pictureBox.Image.Size; });
            }
            else
            {
                Size = pictureBox.Image.Size;
            }
        }

        private IntPtr GetPetHandle()
        {
            if (InvokeRequired)
            {
                return Invoke(() => {
                    return Handle;
                });
            }

            return Handle;
        }
    }

    public static class RoundableDouble
    {
        public static int Round(this double number)
        {
            return number - Math.Round(number) == 0.5 ? (int)Math.Ceiling(number) : (int)Math.Round(number);
        }
    }
}
