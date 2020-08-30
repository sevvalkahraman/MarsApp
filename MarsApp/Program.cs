using System;
using System.Collections.Generic;

//This class represents Rover.
public class Rover
{
    public Rover(int x, int y, string rotation)
    {
        PositionX = x;
        PositionY = y;
        Rotation = rotation;
    }

    //For to move Rover.
    public void Move(string action, int rangeX, int rangeY)
    {
        if (action == "M")
        {
            if (this.Rotation == "N" && this.PositionY + 1 <= rangeY)  
            {
                this.PositionY = this.PositionY + 1;
            }
            else if (this.Rotation == "W" && this.PositionX - 1 >= 0)
            {
                this.PositionX = this.PositionX - 1;
            }
            else if(this.Rotation == "E" && this.PositionX + 1 <= rangeX)
            {
                this.PositionX = this.PositionX + 1;
            }
            else if(this.Rotation == "S" && this.PositionY - 1 >= 0)
            {
                this.PositionY = this.PositionY - 1;
            }
        }
        else if (action == "L")
        {
            if (this.Rotation == "N")
            {
                this.Rotation = "W";
            }
            else if (this.Rotation == "W")
            {
                this.Rotation = "S";
            }
            else if(this.Rotation == "E")
            {
                this.Rotation = "N";
            }
            else if(this.Rotation == "S")
            {
                this.Rotation = "E";
            }
        }
        else if (action == "R")
        {
            if (this.Rotation == "N")
            {
                this.Rotation = "E";
            }
            else if (this.Rotation == "W")
            {
                this.Rotation = "N";
            }
            else if(this.Rotation == "E")
            {
                this.Rotation = "S";
            }
            else if(this.Rotation == "S")
            {
                this.Rotation = "W";
            }
        }
    }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string Rotation { get; set; }
}


class MarsApp
{
    static void Main()
    {
        int rangeX = 0;
        int rangeY = 0;
        List<Rover> rovers = new List<Rover>();

        //Reading the input file.
        try
        {
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                {
                    rangeX = Convert.ToInt32(lines[i][0].ToString());
                    rangeY = Convert.ToInt32(lines[i][2].ToString());
                }
                else if (i % 2 == 1) //rover
                {
                    var rover = new Rover(Convert.ToInt32(lines[i][0].ToString()), Convert.ToInt32(lines[i][2].ToString()), lines[i][4].ToString());
                    rovers.Add(rover);
                }
                else if (i % 2 == 0) //rover move
                {
                    foreach (var action in lines[i])
                    {
                        rovers[rovers.Count - 1].Move(action.ToString(), rangeX, rangeY);
                    }
                    Console.WriteLine(rovers[rovers.Count - 1].PositionX + " " + rovers[rovers.Count - 1].PositionY + " " + rovers[rovers.Count - 1].Rotation);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("enter for exit");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            keyInfo = Console.ReadKey();
        }
    }
}



