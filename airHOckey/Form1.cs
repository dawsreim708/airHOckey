using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace airHOckey
{
    public partial class Form1 : Form
    {
        int paddle1X = 50;
        int paddle1Y = 200;
        int player1Score = 0;
        int player1XSpeed;
        int player1YSpeed;

        int paddle2X = 750;
        int paddle2Y = 200;
        int player2Score = 0;
        int player2YSpeed;
        int player2XSpeed;

        int paddleWidth = 40;
        int paddleHeight = 40;
        int paddleSpeed = 5;

        int ballX = 400;
        int ballY = 195;
        int ballXSpeed = 0;
        int ballYSpeed = 0;
        int ballWidth = 20;
        int ballHeight = 20;
        
        int netLength = 100;
        int count = 0;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        int tick;
        SoundPlayer hit = new SoundPlayer(Properties.Resources.Bir_Poop_Splat_SoundBible_com_157212383);
        
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Font screenFont = new Font("Consolas", 12);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ballX += ballXSpeed;
            ballY += ballYSpeed;

            player1YSpeed = 0;
            player1XSpeed = 0;
            player2YSpeed = 0;
            player2XSpeed = 0;

            if (wDown == true && paddle1Y > 0)
            {
                paddle1Y -= paddleSpeed;
                player1YSpeed = -6;
            }
            if (sDown == true && paddle1Y < this.Height - paddleHeight)
            {
                paddle1Y += paddleSpeed;
                player1YSpeed = 6;
            }
            if (aDown == true && paddle1X > 0)
            {
                paddle1X -= paddleSpeed;
                player1XSpeed = -6;
            }
            if (dDown == true && paddle1X < this.Width - paddleWidth)
            {
                paddle1X += paddleSpeed;
                player1XSpeed = 6;
            }


            
            if (upArrowDown == true && paddle2Y > 0)
            {
                paddle2Y -= paddleSpeed;
                player2YSpeed = -6;
            }
            if (downArrowDown == true && paddle2Y < this.Height - paddleHeight)
            {
                paddle2Y += paddleSpeed;
                player2YSpeed = 6;
            }
            if (leftArrowDown == true && paddle2X > 0)
            {
                paddle2X -= paddleSpeed;
                player2XSpeed = -6;
            }
            if (rightArrowDown == true && paddle2X < this.Width - paddleWidth)
            {
                paddle2X += paddleSpeed;
                player2XSpeed = 6;
            }

            
            if (ballY < 0 || ballY > this.Height - ballHeight)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed;
                hit.Play();
            }
            if (ballX > this.Width - ballWidth || ballX < 0)
            {
                ballXSpeed *= -1;
                hit.Play();
            }

            Rectangle player1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle player2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);

            if (player1Rec.IntersectsWith(ballRec))
            {
                hit.Play();
                if (player1XSpeed == 0)
                {
                    ballXSpeed *= -1;
                    
                }
                if (player1YSpeed == 0)
                {
                    ballYSpeed *= -1;
                }
                if (player1XSpeed > 0 && ballXSpeed > 0 || player1XSpeed < 0 && ballXSpeed < 0)
                {
                    ballXSpeed *= -1;
                    ballXSpeed += player1XSpeed;
                    ballX += player1XSpeed;
                }
                else if (player1XSpeed > 0 || player1XSpeed < 0)
                {
                    ballXSpeed *= -1;
                    ballXSpeed += player1XSpeed;
                    ballX += player1XSpeed;
                    
                }
                if (player1YSpeed > 0 && ballYSpeed > 0 || player1YSpeed < 0 && ballYSpeed < 0)
                {
                    ballYSpeed *= -1;
                    ballYSpeed += player1YSpeed;
                    ballY += player1YSpeed;
                }
                else if (player1YSpeed > 0 || player1YSpeed < 0)
                {
                    ballYSpeed *= -1;
                    ballYSpeed += player1YSpeed;
                    ballY += player1YSpeed;
                }

                //ballYSpeed *= -1;
                //ballX = paddle1X + paddleWidth + 1;
                //ballXSpeed += player1XSpeed;
                //ballYSpeed += player1YSpeed;
                
            }
            if (player2Rec.IntersectsWith(ballRec))
            {
                hit.Play();
                if (player2XSpeed == 0)
                {
                    ballXSpeed *= -1;

                }
                if (player2YSpeed == 0)
                {
                    ballYSpeed *= -1;
                }
                if (player2XSpeed > 0 && ballXSpeed > 0 || player2XSpeed < 0 && ballXSpeed < 0)
                {
                    ballXSpeed *= -1;
                    ballXSpeed += player2XSpeed;
                    ballX += player2XSpeed;
                }
                else if (player2XSpeed > 0 || player2XSpeed < 0)
                {
                    ballXSpeed *= -1;
                    ballXSpeed += player2XSpeed;
                    ballX += player2XSpeed;
                    
                }
                if (player2YSpeed > 0 && ballYSpeed > 0 || player2YSpeed < 0 && ballYSpeed < 0)
                {
                    ballYSpeed *= -1;
                    ballYSpeed += player2YSpeed;
                    ballY += player2YSpeed;
                }
                else if (player2YSpeed > 0 || player2YSpeed < 0)
                {
                    ballYSpeed *= -1;
                    ballYSpeed += player2YSpeed;
                    ballY += player2YSpeed;
                }
            }
            Rectangle player1Net = new Rectangle(0, 150, 2, netLength);
            Rectangle player2Net = new Rectangle(this.Width - 2, 150, 2, netLength);

            if (ballRec.IntersectsWith(player1Net))
            {
                player1Score++;

                paddle1X = 50;
                paddle1Y = 200;

                paddle2X = 750;
                paddle2Y = 200;

                ballX = 400;
                ballY = 195;
                ballXSpeed = 0;
                ballYSpeed = 0;

            }
            if (ballRec.IntersectsWith(player2Net))
            {
                player2Score++;

                paddle1X = 50;
                paddle1Y = 200;

                paddle2X = 750;
                paddle2Y = 200;

                ballX = 400;
                ballY = 195;
                ballXSpeed = 0;
                ballYSpeed = 0;
            }

            if(count >= 20)
            {
                count = 0;
                if(ballXSpeed < 0)
                {
                    ballXSpeed++;
                }
                else if (ballXSpeed > 0)
                {
                    ballXSpeed--;
                }
     
                if (ballYSpeed < 0)
                {
                    ballYSpeed++;
                }
                else if(ballYSpeed > 0)
                {
                    ballYSpeed--;
                }
                
            }
            else
            {
                count++;
            }
            if(player1Score >= 3)
            {
                timer.Enabled = false;
            }
            else if (player2Score >= 3)
            {
                timer.Enabled = false;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(blueBrush, paddle1X, paddle1Y, paddleWidth, paddleHeight);
            e.Graphics.FillEllipse(blueBrush, paddle2X, paddle2Y, paddleWidth, paddleHeight);

            e.Graphics.FillEllipse(whiteBrush, ballX, ballY, ballWidth, ballHeight);

            e.Graphics.FillRectangle(whiteBrush, 0, 150, 5, netLength);
            e.Graphics.FillRectangle(whiteBrush, this.Width - 5, 150, 5, netLength);

            e.Graphics.DrawString($"{player2Score}", screenFont, whiteBrush, 380, 10);
            e.Graphics.DrawString($"{player1Score}", screenFont, whiteBrush, 420, 10);
        }
    }
}
