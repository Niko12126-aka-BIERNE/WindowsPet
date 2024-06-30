namespace WindowsPet
{
    public partial class HomeForm : Form
    {
        public Point CurrentLocation { get; private set; }
        private bool mouseDown;
        private Point lastLocation;
        public static bool StayAtHome { get; private set; }

        public HomeForm(Bitmap homeSprite, Point startLocation, Pet windowsPet)
        {
            CurrentLocation = new Point(Location.X + homeSprite.Width / 2, Location.Y + homeSprite.Height);
            mouseDown = false;
            StayAtHome = false;

            InitializeComponent();

            pictureBox.Image = homeSprite;
            Location = startLocation;

            IntPtr handle = Handle;
            new Thread(() => Application.Run(new PetForm(windowsPet, handle))).Start();
        }

        private void HomeMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!Size.Equals(pictureBox.Image.Size))
                {
                    Size = pictureBox.Image.Size;
                }

                StayAtHome = !StayAtHome;
            }
        }

        private void HomeMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                CurrentLocation = new Point(Location.X + pictureBox.Image.Width / 2, Location.Y + pictureBox.Image.Height);
            }
        }

        private void HomeMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
