using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events.objects
{
 
    class GreenCircle : BaseObject
    {
        public int timeLeft = 60;
        public event Action<GreenCircle> OnTimeOut;
        
        public GreenCircle(float x, float y, float angle) : base(x, y, angle)
        {
        }
        
        public void DecreaseTime()
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                if (timeLeft <= 0)
                {
                    OnTimeOut(this);
                }
            }
        }
        
        public void ResetTimer()
        {
            timeLeft = 60;
        }
        
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.Green, 2), -15, -15, 30, 30);
            string timerText = timeLeft.ToString();
            g.DrawString(timerText, new Font("Arial", 8), new SolidBrush(Color.Green), 20, -8);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
    }
}


