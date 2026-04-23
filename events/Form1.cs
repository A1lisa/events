using events.objects;

namespace events
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        List<GreenCircle> greenCircles = new();
        Random random = new Random();

        int score = 0;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            player.OnMarkerOverlap += (m) =>
            {

                objects.Remove(m);
                marker = null;
            };

            player.OnGreenCircleOverlap += (circle) =>
            {
                score += 1;
                lblScore.Text = $"Очки: {score}";
                MoveCircle(circle);
                circle.ResetTimer();

            };

            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            CreateGreenCircles(2);
            objects.Add(marker);
            objects.Add(player);
            objects.AddRange(greenCircles);
        }
        private void CreateGreenCircles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                float x = random.Next(50, pbMain.Width - 50);
                float y = random.Next(50, pbMain.Height - 50);
                GreenCircle circle = new GreenCircle(x, y, 0);
                circle.OnTimeOut += (c) =>
                {
                    MoveCircle(c);
                    c.ResetTimer();
                };
                greenCircles.Add(circle);
            }
        }
        private void MoveCircle(GreenCircle circle)
        {
            float newX = random.Next(50, pbMain.Width - 50);
            float newY = random.Next(50, pbMain.Height - 50);
            circle.X = newX;
            circle.Y = newY;
        }

        private void pbMain_paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            updatePlayer();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                }
            }
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbMain.Invalidate();
        }

        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            player.X += player.vX;
            player.Y += player.vY;

            player.X = Math.Clamp(player.X, 15, pbMain.Width - 15);
            player.Y = Math.Clamp(player.Y, 15, pbMain.Height - 15);
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbMain_Click(object sender, EventArgs e)
        {

        }

        private void coutdownTimer_Tick(object sender, EventArgs e)
        {
            foreach (var circle in greenCircles)
            {
                circle.DecreaseTime();
            }
        }
    }
}
