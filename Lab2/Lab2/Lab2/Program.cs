//Remar Bacadon
//Lab 2
/* Psuedocode

// Game Variables
window size (160x120 scaled pixels)
ball size (iBallSize = 2 (2x2 pixels)
paddle size (iPThickness, iPLength) = (10, length proportional to screen height)
ball position (iYPos, iYPos)
ball velocity (iXVel, iYVel)
paddle position (iYPaddlePos)
score (iScore = 0)
game state (bGameRunning = false)
delay (20 ms)
mouse position (iMouseX, iMouseY)

// Draw background (3-walled court)
Draw background (left wall, right wall, top wall)

// Game Start Procedure
On Mouse Left Button Click:
If click is within game board:
Set bGameRunning = true
Set initial ball position on the left side of the screen
Set initial random iXVel and iYVel (small random value to create randomness)
Start game loop

// Main Game Loop (runs while bGameRunning is true)
While bGameRunning:
Read iMouseY from mouse position
Set paddle position (iYPaddlePos) based on iMouseY, but prevent it from going out of bounds (within top and bottom of window)
    
// Update Ball Position
Update ball position:
iXPos = iXPos + iXVel
iYPos = iYPos + iYVel
    
// Ball Collision with Walls (Top and Bottom)
If ball hits top wall or bottom wall:
Reverse iYVel (ball bounces vertically)
    
// Ball Collision with Paddle (Check if ball is near paddle on the left side)
If iXPos is near left side of the window:
If iYPos is within paddle's y position:
Reverse iXVel (ball bounces horizontally)
Increment score by 1
Play sound(ominous)
    
// Ball Exiting Game (When it goes beyond the left side of the screen)
If iXPos is less than 0:
End game (bGameRunning = false)
Display final score

// Pause for a short time
Wait for a short duration

// Show Play Again and Quit Buttons
Draw Play Again button and Quit button
        
On Mouse Left Button Click:
If click is on Play Again button:
Reset all game variables and restart the game
Else If click is on Quit button:
End the game and close the window
Add delay to manage speed (20 ms)
End Game Loop
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using GDIDrawer;
using System.Collections;
using System.Net.NetworkInformation;
using System.Security.Policy;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Var Declaration
            Random random = new Random();

            int iCanvasHeight = 800;
            int iCanvasWidth = 1200;
            CDrawer canvas = new CDrawer(iCanvasWidth, iCanvasHeight);
            canvas.Scale = 5;

            Point pointHolder;
            int iBallSize = 2;
            int iXPos;
            int iYPos;
            int iXVel;
            int iYVel;

            int iPThickness = canvas.ScaledWidth/16;
            int iPLength = canvas.ScaledHeight / 2;
            int iYPaddlePos = canvas.ScaledHeight / 2;
            int iXPaddlePos = canvas.ScaledWidth / 16;

            int iScore = 0;

            bool bGameRunning = false;
            bool bClicked = false;
            bool bMenu = false;
            bool bAgain = true;
            bool bCleared = false;

            var colorAgain = Color.White;
            var colorQuit = Color.White;

            Console.WriteLine($"{canvas.ScaledHeight-1}  {canvas.ScaledWidth}  {canvas.Scale}");
            //Draw Background 3 walled court
            for (int i = 1; i < canvas.ScaledWidth; i++)
            {
                canvas.SetBBScaledPixel(i, 0, Color.Blue);
                canvas.SetBBScaledPixel(i, (canvas.ScaledHeight-1), Color.Blue);
            }
            for (int i = 1; i < canvas.ScaledHeight; i++)
            {
                canvas.SetBBScaledPixel((canvas.ScaledWidth - 1), i, Color.Blue);
            }
            // Game Start Procedure
            while (bAgain)
            {
                canvas.Clear();
                canvas.AddText($"CLick to Start", (canvas.ScaledWidth + canvas.ScaledHeight) / 32);
                Thread.Sleep(20);
                bClicked = canvas.GetLastMouseLeftClick(out pointHolder);
                if (bClicked == true) //&& pointHolder.X >= 1 && pointHolder.X <= iCanvasWidth - 1 && pointHolder.Y >= 1 && pointHolder.Y <= canvas.ScaledHeight - 1)
                {

                    canvas.Scale = 1;
                    bGameRunning = true;
                    iXPos = iCanvasWidth / 3;
                    iYPos = canvas.ScaledHeight / 2;
                    iXVel = 2;
                    iYVel = random.Next(2, 8);
                    //iYVel = 10;
                    // Main Game Loop (runs while bGameRunning is true)
                    while (bGameRunning)
                    {
                        Thread.Sleep(10);
                        canvas.Clear();
                        // Update Paddle position
                        canvas.GetLastMousePosition(out pointHolder);
                        if (pointHolder.Y > 0 && pointHolder.Y < canvas.ScaledHeight)
                        {
                            iYPaddlePos = pointHolder.Y;
                        }

                        // Update Ball Position
                        iXPos = iXPos + iXVel;
                        iYPos = iYPos + iYVel;

                        // Ball Collision with Walls
                        if (iXPos >= (iCanvasWidth - (canvas.Scale + iBallSize)))
                        {
                            
                            iXPos = iCanvasWidth - (canvas.Scale + iBallSize);
                            iXVel = -iXVel;
                        }
                        if (iYPos >= (iCanvasHeight - (canvas.Scale + iBallSize)))
                        {
                            
                            iYPos = iCanvasHeight - (canvas.Scale + iBallSize);
                            iYVel = -iYVel;
                        }
                        if (iYPos <= (canvas.Scale + iBallSize))
                        {
                            
                            iYPos = (canvas.Scale + iBallSize);
                            iYVel = -iYVel;
                        }
                        // Ball Collision with Paddle (Check if ball is near paddle on the left side)
                        if (iXPos <= (iXPaddlePos + (iPThickness / 2)))
                        {
                            if (iXPos > (iXPaddlePos - (iPThickness / 2)) && iYPos <= (iYPaddlePos + (iPLength / 2)) && iYPos >= (iYPaddlePos - (iPLength / 2)))
                            {
                                iXVel = -2*iXVel;
                                iXPos = iXPaddlePos + (iPThickness / 2) + iBallSize;
                                iScore++;
                            }
                            else
                            {
                                Console.Beep(2000, 2000);
                                // Ball Exiting Game (When it goes beyond the left side of the screen)
                                bMenu = true;
                                bGameRunning = false;
                            }
                        }
                        // Render
                        pointHolder = new Point(iXPos, iYPos);
                        canvas.AddCenteredRectangle(pointHolder, iBallSize, iBallSize, Color.Yellow);
                        pointHolder = new Point(iXPaddlePos, iYPaddlePos);
                        canvas.AddCenteredRectangle(pointHolder, iPThickness, iPLength, Color.Green);
                    }
                    // Show Play Again and Quit Buttons
                    while (bMenu)
                    {
                        
                        canvas.Clear();
                        bCleared = true;
                        
                        bClicked = false;
                        canvas.AddText($"Final Score:{iScore}", (canvas.ScaledWidth + canvas.ScaledHeight) / 32);
                        //canvas.AddRectangle((canvas.ScaledWidth / 5), 4 * (canvas.ScaledHeight / 5), canvas.ScaledWidth / 5, canvas.ScaledHeight / 5, colorAgain);
                        canvas.AddText("Play Again", ((canvas.ScaledWidth + canvas.ScaledHeight) / 64), 0, 4 * (canvas.ScaledHeight / 5), canvas.ScaledWidth / 5, canvas.ScaledHeight / 5, colorAgain);
                        //canvas.AddRectangle(4 * (canvas.ScaledWidth / 5), 4 * (canvas.ScaledHeight / 5), canvas.ScaledWidth / 5, canvas.ScaledHeight / 5, colorQuit);
                        canvas.AddText("Quit", ( (canvas.ScaledWidth + canvas.ScaledHeight) / 32), (4 * (canvas.ScaledWidth / 5)), 4 * (canvas.ScaledHeight / 5), canvas.ScaledWidth / 5, canvas.ScaledHeight / 5, colorQuit);
                        canvas.GetLastMousePosition(out pointHolder);
                        //Play Again
                        if (pointHolder.X >= 0 && pointHolder.X <= (canvas.ScaledWidth / 5) && pointHolder.Y >= 4 * (canvas.ScaledHeight / 5) && pointHolder.Y <= canvas.ScaledHeight)
                        {
                            colorAgain = RandColor.GetColor();
                            bClicked = canvas.GetLastMouseLeftClick(out pointHolder);
                            if (bClicked == true )
                            {
                                bMenu = false;
                                
                            }
                            bCleared = false;
                        }
                        //Quit
                        else if (pointHolder.X >= (4 * (canvas.ScaledWidth / 5)) && pointHolder.X <= canvas.ScaledWidth && pointHolder.Y >= 4 * (canvas.ScaledHeight / 5) && pointHolder.Y <= canvas.ScaledHeight)
                        {
                            colorQuit = RandColor.GetColor();
                            bClicked = canvas.GetLastMouseLeftClick(out pointHolder);
                            if (bClicked == true )
                            { 
                                bAgain = false;
                                bMenu = false;
                            }
                            bCleared = false;
                        }
                        else
                        {
                            if (bCleared == true )
                            {
                                colorAgain = Color.White;
                                colorQuit = Color.White;
                                bCleared = false;
                                bColorChanged = false;
                            }
                        }
                        Thread.Sleep(20);
                    }
                }
            }
        }
    }
}
