using System;
using System.Collections.Generic;
using GameClasses;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

class TheGame
{
    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight = 35;
        Console.BufferWidth = Console.WindowWidth = 55;

        int[] shipSizes = { 2, 3, 3, 4, 5 };
        string[] shipRanks = { "Scout", "U-Boat", "Destroyer", "BattleShip", "Aircraft Carrier" };
        char[] shipChar = { 'S', 'U', 'D', 'B', 'C' };


        StartScreen();

        List<Battleship> playerShips = new List<Battleship>();
        List<Battleship> aiShips = new List<Battleship>();
        List<Battleship> destroyedEnemyShips = new List<Battleship>();
        List<Battleship> destroyedPlayerShips = new List<Battleship>();

       

        List<string> destroyedShips = new List<string>();
        const ConsoleColor ENEMY = ConsoleColor.Red;


        Console.SetCursorPosition(10, 30 / 2);
        Console.Write("Please enter your name: ");
        string playerName = Console.ReadLine();


        Console.Clear();

        Player player = new Player(playerName);
        Player ai = new Player("CPU");
        Player emptyPlayer = new Player("CPU");

        PrintMatrix(player.Board, player.name);
        Console.ForegroundColor = ENEMY;
        PrintAIMatrix(emptyPlayer.Board, emptyPlayer.name);
        Console.ResetColor();

        // Create a separate list for The AI
        for (int i = 0; i < 5; i++)
        {
            aiShips.Add(MakeShipAI(shipRanks[i], shipSizes[i], ai, shipChar[i]));
            AddShipOnBoard(aiShips[i], ai);
            //PrintAIMatrix(ai.Board, ai.name);
        }

        //Read player ships
        for (int i = 0; i < 5; i++)
        {
            Console.SetCursorPosition(0, 30);
            Console.WriteLine("Battleship Rank: {0}, Size: {1}", shipRanks[i], shipSizes[i]);

            string input = GetValidInput(); // Get coordinates in correct format
            while (true) 
            {
                if (ValidatePosition(input, shipSizes[i], input[2], player)) // Check if coordinates are in the boundries
                {
                    break;
                }
                
                Console.SetCursorPosition(0, 31);
                Console.WriteLine("Ship cannot be placed there!");
                Thread.Sleep(1500);
                input = GetValidInput();
            }
            playerShips.Add(CreateShip(input, shipRanks[i], shipSizes[i], player, shipChar[i]));
            AddShipOnBoard(playerShips[i], player);
            Console.Clear();
            PrintMatrix(player.Board, player.name);
            Console.ForegroundColor = ENEMY;
            //if its ai.Board and not emtpyPlayer.Board its for printing the AI board once for easier testing of end-game phase etc.
            PrintAIMatrix(emptyPlayer.Board, emptyPlayer.name);
            Console.ResetColor();
        }

        
        Console.ResetColor();
        string playerLastTurnOutcome = "";
        string aiLastTurnOutcome = "";

        while (true)
        {
            // Printing
            Console.SetCursorPosition(0, 13);
            Console.WriteLine(playerLastTurnOutcome);
            Console.SetCursorPosition(35, 13);
            Console.WriteLine(aiLastTurnOutcome);
            
            DestroyedShipsByPlayer(destroyedEnemyShips, player.name);
            DestroyedShipsByAI(destroyedPlayerShips, ai.name);

            //Player shooting

            string shootCoordsPlayer = ShootInputForPlayer(emptyPlayer);

            if (CollisionCheckForPlayer(aiShips, ai, shootCoordsPlayer, emptyPlayer, destroyedEnemyShips))
            {
                Console.Beep();
                playerLastTurnOutcome = "Direct hit! " + "- " + shootCoordsPlayer.ToUpper();
                
                Thread.Sleep(1000);
                if (destroyedEnemyShips.Count == aiShips.Count)
                {
                    PrintScreen(player, emptyPlayer);
                    string winner = "WE'VE SUNKEN THE ENTIRE ENEMY FLEET!";
                    string winner2 = "THE DAY IS OURS!";
                    Console.WriteLine();
                    Console.WriteLine(new string(' ', (55 / 2) - (winner.Length / 2)) + winner);
                    Console.WriteLine(new string(' ', (55/2) - (winner2.Length/2))+ winner2);
                    break;
                }

            }
            else
            {
                playerLastTurnOutcome = "We missed! " + "- " + shootCoordsPlayer.ToUpper();
                Thread.Sleep(1000);
            } 
            // End of player shooting

            // AI shooting
            

            Random rnd = new Random(); // Getting the row and col for ai to shoot
            int rowShoot = rnd.Next(0, 10);
            int colShoot = rnd.Next(0, 10);
            while (player.Board[rowShoot, colShoot] == '$' || player.board[rowShoot, colShoot] == 'X')
            {
                rnd = new Random();
                rowShoot = rnd.Next(0, 10);
                colShoot = rnd.Next(0, 10);
            }

            if (CollisionCheckForAI(playerShips, player, rowShoot, colShoot, destroyedPlayerShips))
            {
                Console.Beep(); ;
                aiLastTurnOutcome = "Direct hit! " + "- " + GetRowChar(rowShoot) + (colShoot);
                if (destroyedPlayerShips.Count == playerShips.Count)
                {
                    PrintScreen(player, emptyPlayer);
                    string loser = "YOU LOSE";
                    Console.WriteLine(new string(' ', (55 / 2) - (loser.Length / 2)) + loser);
                    break;

                }
                Thread.Sleep(1000);

            }
            else
            {
                aiLastTurnOutcome = "The AI missed! " + "- " + GetRowChar(rowShoot) + (colShoot);
                Thread.Sleep(1000);
            }
            //reprint the console
            PrintScreen(player, emptyPlayer);
        }
    }
    static void DestroyedShipsByPlayer(List<Battleship> destroyedShips, string name)
    {
        Console.SetCursorPosition(0, 20);
        Console.WriteLine("Ships sunken by {0}", name);
        foreach (var destroyedShip in destroyedShips)
        {
            Console.WriteLine("-{0}",destroyedShip.rank);
        }
        
    }
    static void DestroyedShipsByAI(List<Battleship> AiDestroyedShips, string aiName)
    {
        Console.SetCursorPosition(35, 20);
        Console.WriteLine("Ships sunken by {0}", aiName);
        foreach (var destroyedShip in AiDestroyedShips)
        {
            Console.WriteLine("-{0}",destroyedShip.rank);
        }
    }
    private static void PrintScreen(Player player, Player emptyPlayer)
    {
        Console.Clear();
        PrintMatrix(player.Board, player.name);
        Console.ForegroundColor = ConsoleColor.Red;
        PrintAIMatrix(emptyPlayer.Board, emptyPlayer.name);
        Console.ResetColor();
    }
    static Battleship CreateShip(string input, string rank, int size, Player player, char sign)
    {
        // Create an object of class Battleship for the given player
        int coordinatesX = ConvertToInt(input[0].ToString());
        int coordinatesY = int.Parse(input[1].ToString());
        Battleship ship = new Battleship(rank, coordinatesX, coordinatesY, size, input[2], sign);
        return ship;
    }
    static Battleship MakeShipAI(string rank, int size, Player player, char sign)
    {
        // Create an object of class Battleship for the AI
        Random rnd = new Random();
        int coordinatesX = rnd.Next(0,10);
        int coordinatesY = rnd.Next(0, 10);
        int intDirection = rnd.Next(1, 5);
        char direction = ' ';
        switch (intDirection)
        {
            case 1: direction = 'r'; break;
            case 2: direction = 'd'; break;
            case 3: direction = 'l'; break;
            case 4: direction = 'u'; break;
            default: break;
        }

        string aiCoordinates = coordinatesX.ToString() + coordinatesY.ToString();
        bool validPosition = ValidatePositionAI(aiCoordinates, size, direction, player);
        while (validPosition == false)
        {
            coordinatesX = rnd.Next(0,10);
            coordinatesY = rnd.Next(0, 10);
            intDirection = rnd.Next(1, 5);
            direction = ' ';
            switch (intDirection)
            {
                case 1: direction = 'r'; break;
                case 2: direction = 'd'; break;
                case 3: direction = 'l'; break;
                case 4: direction = 'u'; break;
                default: break;
            }
            aiCoordinates = coordinatesX.ToString() +coordinatesY.ToString();
            validPosition = ValidatePositionAI(aiCoordinates, size, direction, player);
        }
        Battleship ship = new Battleship(rank, coordinatesX, coordinatesY, size, direction, sign);
        return ship;
    }

    static void PrintMatrix(char[,] matrix, string playerName)
    {
        // Print player name
        Console.SetCursorPosition(26 / 2 - playerName.Length / 2, 0);
        Console.WriteLine(playerName);

        // Print matrix
        Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("    " + new string('-', (matrix.GetLength(0) * 2) - 1));
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == 0)
                {
                    Console.Write("{0} |", GetRowChar(i));
                }
                if (matrix[i, j] != 'O')
                {
                    Console.Write("{0}".PadLeft(4), matrix[i, j]);
                }
                else
                {
                    Console.Write("{0}".PadLeft(4), ".");
                }
            }
            Console.WriteLine();
        }
    }
    static bool ValidatePositionAI(string input, int shipLength, char shipDirection, Player player)
    {
        // Validation of the random generated coordinates for the AI
        int shipX = int.Parse(input[0].ToString());
        int shipY = int.Parse(input[1].ToString());
        bool shipPlaced = true;

        for (int i = 0; i < shipLength; i++)
        {
            if (shipX < 0 || shipY < 0 || shipX >= player.board.GetLength(0) || shipY >= player.board.GetLength(1) || player.board[shipX, shipY] != 'O')
            {
                shipPlaced = false;
                break;
            }
            switch (shipDirection)
            {
                case 'r': shipY++; break;
                case 'd': shipX++; break;
                case 'l': shipY--; break;
                case 'u': shipX--; break;
                default: break;
            }
            if (shipX < 0 || shipY < 0 || shipX >= player.board.GetLength(0) || shipY >= player.board.GetLength(1) || player.board[shipX, shipY] != 'O')
            {
                shipPlaced = false;
                break;
            }
        }
        return shipPlaced;
    }
    static bool ValidatePosition(string input, int shipLength, char shipDirection, Player player)
    {
        int shipX = ConvertToInt(input[0].ToString());
        int shipY = int.Parse(input[1].ToString());
        bool shipPlaced = true;

        for (int i = 0; i < shipLength; i++)
        {
            if (shipX < 0 || shipY < 0 || shipX >= player.board.GetLength(0) || shipY >= player.board.GetLength(1) || player.board[shipX, shipY] != 'O')
            {
                shipPlaced = false;
                break;
            }
            switch (shipDirection)
            {
                case 'r': shipY++; break;
                case 'd': shipX++; break;
                case 'l': shipY--; break;
                case 'u': shipX--; break;
                default: break;
            }
            if (shipX < 0 || shipY < 0 || shipX >= player.board.GetLength(0) || shipY >= player.board.GetLength(1) || player.board[shipX, shipY] != 'O')
            {
                shipPlaced = false;
                break;
            }
        }
        return shipPlaced;
    }

    static void AddShipOnBoard(Battleship ship, Player player)
    {
        for (int i = 0; i < ship.Size; i++)
        {
            player.board[ship.CurrentX, ship.CurrentY] = ship.signature;
            switch (ship.Direction)
            {
                case 'r': ship.y++; break;
                case 'd': ship.x++; break;
                case 'l': ship.y--; break;
                case 'u': ship.x--; break;
                default: break;
            }
        }
    }
    static bool CollisionCheckForPlayer(List<Battleship> shiplist, Player ai, string coordinates, Player emptyPlayer, List<Battleship> destroyedShips)
    {
        int row = ConvertToInt(coordinates[0].ToString());
        int col = int.Parse(coordinates[1].ToString());

        bool collision = false;

        for (int i = 0; i < shiplist.Count; i++)
        {
            if (ai.board[row, col] == shiplist[i].signature)
            {
                collision = true;
                ai.board[row, col] = 'X'; //Put X sign if hit on the ai table
                emptyPlayer.board[row, col] = 'X'; //Put X sign if hit on the empty table
                shiplist[i].health--;
                if (shiplist[i].health == 0)
                {
                    destroyedShips.Add(shiplist[i]);
                }
                break;
            }
            if (i == shiplist.Count - 1 && ai.board[row, col] != shiplist[i].signature)
            {
                ai.board[row, col] = '$'; //Put $ sign of miss on the ai table
                emptyPlayer.board[row, col] = '$'; //Put $ sign of miss on the empty table
            }
        }

        return collision;
    }
    static bool CollisionCheckForAI(List<Battleship> shiplist, Player player, int row, int col, List<Battleship> destroyedShips)
    {
        bool collision = false;

        for (int i = 0; i < shiplist.Count; i++)
        {
            if (player.board[row, col] == shiplist[i].signature)
            {
                collision = true;
                player.board[row, col] = 'X';
                player.board[row, col] = 'X'; //Put X sign if hit

                shiplist[i].health--;
                if (shiplist[i].health == 0)
                {
                    destroyedShips.Add(shiplist[i]);
                }
                break;
            }
            if (i == shiplist.Count - 1 && player.board[row, col] != shiplist[i].signature)
            {
                player.board[row, col] = '$'; //Put $ sign if miss
            }

        }

        return collision;
    }

    static void StartScreen()
    {
        string gameName = "L'Attaque";
        Console.SetCursorPosition((55 / 2) - (gameName.Length / 2), 3);

        Console.WriteLine("L'Attaque");

        StreamReader reader = new StreamReader("../../Instuctions.txt");

        using (reader)
        {
            int counter = 3;
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.SetCursorPosition((55 / 2) - (line.Length / 2), counter);
                Console.WriteLine(line);
                line = reader.ReadLine();
                counter++;
            }
        }
        Console.SetCursorPosition((55 / 2) - ("Press Enter".Length / 2), 23);
        Console.Write("Press Enter");
        Console.ReadLine();
        Console.Clear();

    }
    static void PrintAIMatrix(char[,] matrix, string aiName)
    {
        //Print player name
        Console.SetCursorPosition(40, 0);
        Console.WriteLine(aiName);

        Console.SetCursorPosition(30, 1);
        Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
        Console.SetCursorPosition(30, 2);
        Console.WriteLine("    " + new string('-', (matrix.GetLength(0) * 2) - 1));
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.SetCursorPosition(30, i + 3);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == 0)
                {
                    Console.Write("{0} |", GetRowChar(i));
                }
                if (matrix[i, j] != 'O')
                {
                    Console.Write("{0}".PadLeft(4), matrix[i, j]);
                }
                else
                {
                    Console.Write("{0}".PadLeft(4), ".");
                }
            }
            Console.WriteLine();
        }
    }
    static char GetRowChar(int i)
    {
        char[] charToReturn = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', };
        return charToReturn[i];
    }
    static int ConvertToInt(string input)
    {
        int row = 0;
        switch (input)
        {
            case "a": row = 0; break;
            case "b": row = 1; break;
            case "c": row = 2; break;
            case "d": row = 3; break;
            case "e": row = 4; break;
            case "f": row = 5; break;
            case "g": row = 6; break;
            case "h": row = 7; break;
            case "i": row = 8; break;
            case "j": row = 9; break;
            default: break;
        }
        return row;
    }
    static string ShootInputForPlayer(Player ai)
    {
        // Method works with lowercase and uppercase characters from a-j, 
        // including whitespaces in the beginning, middle or end
        Regex shootRGX = new Regex(@"^\s*[a-jA-J]\s*[\d]\s*$");
        Regex whitespace = new Regex(@"\s*");

        // Start of player shooting again
        Console.SetCursorPosition(0, 30);
        Console.WriteLine("Enter target coordinates, admiral!");
        Console.Write("Target coordinates: ");
        string command = Console.ReadLine();

        while (true)
        {
            if (shootRGX.Match(command).Success)
            {
                //command = command.Replace(@"\s*", "").ToLower();
                command = whitespace.Replace(command, "").ToLower();

                int rowShoot = ConvertToInt(command[0].ToString());
                int colShoot = int.Parse(command[1].ToString());

                while (ai.Board[rowShoot, colShoot] == '$' || ai.Board[rowShoot, colShoot] == 'X')
                {
                    
                    Console.SetCursorPosition(0, 30);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, 30);
                    Console.WriteLine("Invalid input! Try again. ");
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, 31);
                    Console.Write("Target coordinates: ");
                    command = Console.ReadLine();
                    command = whitespace.Replace(command, "").ToLower();

                    if (shootRGX.Match(command).Success)
                    {
                        rowShoot = ConvertToInt(command[0].ToString());
                        colShoot = int.Parse(command[1].ToString());
                    }
                }
                break;
            }
            Console.SetCursorPosition(0, 30);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 30);
            Console.WriteLine("Put the rum away and focus, admiral!");
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 31);
            Console.Write("Target coordinates: ");
            command = Console.ReadLine();
        }
        return command;
    }
    static string GetValidInput()
    {
        // Method works with lowercase and uppercase characters from a-j, 
        // including whitespaces in the beginning, middle or end
        Regex withDirectionRGX = new Regex(@"^\s*[a-jA-J]\s*[\d]\s*[udlrUDLR]\s*$");
        Regex withoutDirectionRGX = new Regex(@"^[a-jA-J]\s*[\d]\s*$");
        Regex directionRGX = new Regex(@"^\s*[udlrUDLR]\s*$");
        Regex whitespace = new Regex(@"\s*");

        Console.SetCursorPosition(0, 31);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 31);
        Console.Write("Place your ship!(A-J,0-9,R/D/U/L): ");
        while (true)
        {
            string command = Console.ReadLine();
            if (withDirectionRGX.Match(command).Success)
            {

                command = command.Replace(@"\s*", "").ToLower();

                command = whitespace.Replace(command, "");

                return command;
            }
            //else if (withoutDirectionRGX.Match(command).Success)
            //{
            //    Console.SetCursorPosition(0, 32);
            //    Console.Write("Give me direction!: ");
            //    while (true)
            //    {
            //        string direction = Console.ReadLine();
            //        if (directionRGX.Match(direction).Success)
            //        {

            //            command = command.Replace(@"\s*", "").ToLower();
            //            direction = direction.Replace(@"\s*", "").ToLower();

            //            command = whitespace.Replace(command, "").ToLower();
            //            direction = whitespace.Replace(direction, "").ToLower();

            //            return command + direction;
            //        }


            //        Console.SetCursorPosition(0, 32);
            //        Console.Write(new string(' ', Console.WindowWidth));
            //        Console.SetCursorPosition(0, 32);
            //        Console.Write("Ughh, can you repeat the directions?: ");
            //    }
            //}

            Console.SetCursorPosition(0, 31);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 31);

            Console.Write("Arrgh! I didnt get that..: ");
            

        }
    }
}