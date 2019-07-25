using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random(); //generates random nums
            Boolean developermode = false; //developer mode for debugging & testing
            Boolean victory = false; //victory condition
            string name;
            /*int x = 4; //current x coordinate
            int y = 5; //current y coordinate  */     
            int room = 1; //current room number
            int randomnum = 0;
            Boolean[] events = new Boolean[10]; //list of events that can occur and affect game world, events that have occured are 'true'
            Boolean[] inventory = new Boolean[11]; //items that the player can obtain, ones that the player has are 'true'
            string[] maze = new string[8]; //path through sewer maze
            for (int a = 0; a <= 7; a++) //randomizes the path through the sewer maze
            {
                randomnum = randomizer.Next(1, 5);
                switch (randomnum)
                {
                    case 1:
                        maze[a] = "NORTH";
                    break;
                    case 2:
                    maze[a] = "SOUTH";
                    break;
                    case 3:
                    maze[a] = "EAST";
                    break;
                    case 4:
                    maze[a] = "WEST";
                    break;
                }
            }
            String[] itemlist = new String[] { "CLOTH", "ROPE", "AXE", "SEWER KEY", "MATCHES", "SAW", "TORCH", "POTION", "DRAWER KEY", "DOG FOOD", "OIL CAN"};
            //list of possible items, corresponds to 'Boolean[] inventory', shows the ones that the player has obtained when "INVENTORY" is entered
            Program p = new TheDungeon.Program();
            
            
            



            //game intro
            Console.WriteLine("You wake in a dark room. Groggily, you rise and take note of your surroundings. ");
            Console.WriteLine("You appear to be in some sort of dungeon, yet you cannot remember why you are here. ");
            Console.WriteLine("All you know is that you must escape…");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            
            if (name.ToUpper() == "DEVELOPER MODE")
            {
                Console.WriteLine("DEVELOPER MODE ACTIVATED");
                developermode = true;
            }
            

                //actual game, runs procedures until game is won



                do
            {
                Console.Clear();
                room = p.location(events, inventory, p, itemlist, room, maze, developermode); //returns a direction in which the player will move
                /*switch (direction) //moves the player
                {
                    case 1:                                                     //NOTE: CHANGE THIS IF I HAVE TIME LATER & GET RID OF X AND Y
                        x += 1;
                        break;
                    case 2:
                        x -= 1;
                        break;
                    case 3:
                        y += 1;
                        break;
                    case 4:
                        y -= 1;
                        break;
                }*/
                if (room == 19)
                {
                    victory = true; //player wins when player gets to the last room
                }
            } while (victory == false);
            Console.Clear();
            
            //victory screen
            Console.WriteLine("You leave the darkness of the dungeon behind you, and emerge into bright sunlight.");
            Console.WriteLine("Looking around, you have no idea wher you are.");
            Console.WriteLine("Despite this, you know that you will soon find your way home.");
            Console.WriteLine("\nTHANK YOU, {0}, FOR PLAYING 'THE DUNGEON'", name);
            Console.ReadKey();
        }
        







        //runs code where different things can happen depending on the player's location
        public int location(Boolean[] events, Boolean[] inventory, Program p, String[] itemlist, int room, string[] maze, Boolean developermode)
        {
            int currentroom = room;
            string input; //what the player enters into the console
            switch (room)
            {
                case 1:
                    Console.WriteLine("You are in a cell of some sort. There is an old, ratty bed in one corner.");
                            Console.WriteLine("The walls are covered in moss, and the entire room has a stench of decay.");
                            Console.WriteLine("The cell door is to the west. It may have once been locked, but it has long since rusted away.");
                break;
                case 2:
                    Console.WriteLine("You are in a hallway connecting various parts of the dungeon. ");
                            Console.WriteLine("The ground and walls are made of damp stone bricks, sending a chill through your bones.");
                            Console.WriteLine("The hallway continues to the north and south.");
                            Console.WriteLine("To the east is the cell that you woke up in. ");
                            if (events[0] == true)
                            {
                                Console.WriteLine("There is a side room to the west where the door once stood.");
                            }
                            else
                            {
                                Console.WriteLine("There is an old, moldy door in the west wall. It appears to be locked.");
                            }
                break;
                case 3:
                    Console.WriteLine("You are in a wide, open room. In the distance you can see a set of stairs. ");
                            Console.WriteLine("In the middle of the room, there is a gaping pit that stretches from wall to wall.");
                            Console.WriteLine("What remains of a bridge hangs off the side of the pit, having collapsed long ago.");
                            Console.WriteLine("To the south is the hallway to the rest of the dungeon.");
                break;
                case 4:
                    Console.WriteLine("You are at the southern end of the hallway, having come to a dead end.");
                            Console.WriteLine("There is a door in the east wall, with a skeleton lying next to it.");
                            Console.WriteLine("The skeleton was probably once a guard of this dungeon.");
                            Console.WriteLine("To the north is the rest of the hallway. ");
                break;
                case 5:
                    Console.WriteLine("You are in a small office with a map covering one wall.");
                            Console.WriteLine("Unlike the rest of the dungeon, this room has painted walls and a wooden floor.");
                            Console.WriteLine("The owner obviously wanted to give it a more homely feeling.");
                            Console.WriteLine("In one corner is a rather large desk with many drawers.");
                            Console.WriteLine("To the west is the hallway you came from.");
                break;
                case 6:
                    Console.WriteLine("You are in a room filled to the walls with beds.");
                            if (events[1] == false)
                            {
                                Console.WriteLine("There is a large rug in the centre of the room.");
                            }else
                            {
                                Console.WriteLine("The trapdoor lies open where the rug used to be.");
                            }
                            Console.WriteLine("This must be where the guards of this dungeon once lived.");
                            Console.WriteLine("The dust tells you, however, that no one has lived here in a long time.");
                            Console.WriteLine("The entrance to the room is to the east, and there is a storeroom to the west.");
                break;
                case 7:
                    Console.WriteLine("You are in a storeroom off to the side of the guard's quarters.");
                    Console.WriteLine("Boxes and shelves line the room, and a huge chest sits in the middle.");
                    Console.WriteLine("Together, they give it an old, musty kind of smell.");
                    Console.WriteLine("The exit to the storeroom is to the east.");
                break;
                case 8:
                Console.WriteLine("You are the bottom of a ladder leading up to the guard's quarters.");
                Console.WriteLine("The ground is littered with puddles, and a metal ring sticks oddly out of one of them.");
                Console.WriteLine("In front of you, the entrance to the dungeon sewers looms imposingly.\n");
                if (events[4] == true)
                {
                    Console.WriteLine("The rope showing the way through extends deeper into the sewer.");
                }else if(events[3] == true && events[9] == true){
                    Console.WriteLine("With your torch in one hand and the rope in the other, you are ready to go deeper into the sewer.");
                }
                else
                {
                    Console.WriteLine("You don't feel that you have everything you need to enter the sewer.");
                    Console.WriteLine("First, you would need a way to see into the darkness of the sewers.");
                    Console.WriteLine("Second, you would need a way to find your way back if you get lost in there.");
                    Console.WriteLine("HINT: Try collecting more items and using them on each other.");
                }
                break;
                case 9:
                    if (events[4] == false)
                    {
                        Boolean correct = true;
                        foreach (string direction in maze)
                        {
                            Console.Clear();
                            Console.WriteLine("Which way do you go?");
                            Console.Write("     >");
                            string way = Console.ReadLine();
                            way = way.ToUpper();
                            if (way != direction)
                            {
                                correct = false;
                            }
                        }
                        if (correct == true)
                        {
                            Console.Clear();
                            Console.WriteLine("After some time, you begin to see a light in the distance.");
                            Console.WriteLine("You have almost reached the other side of the maze.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            room = 10;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("After some time, your rope runs out and you can't go any further.");
                            Console.WriteLine("Sighing, you retrace your steps back to the entrance.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            room = 8;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You follow the rope into the maze.");
                        Console.WriteLine("Soon the darkness surrounds you, and the torch becomes your only source of light.");
                        Console.WriteLine("You have no idea where you are, but you trust the rope to lead your way.");
                        Console.WriteLine("You can go to the sewer grate or to the trapdoor.");
                    }
                break;
                case 10:
                    Console.WriteLine("You are at the exit to the dungeon sewers.");
                    Console.WriteLine("The rope leads deeper into the sewers and to the trapdoor at the entrance.");
                    Console.WriteLine("To your east is a circular grate that the rope is tied to.");
                    if (events[5] == false)
                    {
                        Console.WriteLine("Iron bars cover the grate, preventing you from going any further.");
                    }else
                    {
                        Console.WriteLine("The iron bars that once covered it have been sawed off, allowing you to pass through them.");
                    }
                break;
                case 11:

                break;
                case 12:

                break;
                case 13:

                break;
                case 14:

                break;
                case 15:

                break;
                case 16:

                break;
                case 17:

                break;
                case 18:

                break;
                case 19:

                break;
            }
            
            while (room == currentroom)//allows the player to enter commands until they move to a different room
            {
                Console.Write("     >");
                input = Console.ReadLine();
                input = input.ToUpper();
                
                    room = p.command(input, events, inventory, itemlist, room, maze, developermode);

            }
            //this determines which room the user is in using their coordinates
            /*switch (x) //x coordinate
            {
                case 1: 
                    switch (y) //y coordinate
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:

                            break;
                    }
                    break;
                    
                case 2:
                    switch (y) //y coordinate
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            room = 6;
                            Console.WriteLine("You are in a room filled to the walls with beds.");
                            if (events[1] == false)
                            {
                                Console.WriteLine("There is a large rug in the centre of the room.");
                            }else
                            {
                                Console.WriteLine("The trapdoor lies open where the rug used to be.");
                            }
                            Console.WriteLine("This must be where the guards of this dungeon once lived.");
                            Console.WriteLine("The dust tells you, however, that no one has lived here in a long time.");
                            Console.WriteLine("The entrance to the room is to the east, and there is a storeroom to the west.");
                            while (direction == 0) //allows the player to enter commands until they move to a different room
                            {
                                Console.Write("     >");
                                input = Console.ReadLine();
                                direction = p.command(input, events, inventory, itemlist, room, maze);
                            }
                            break;
                    }
                    break;
                
                case 3:
                    switch (y) //y coordinate
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 4:
                            room = 3;
                            Console.WriteLine("You are in a wide, open room. In the distance you can see a set of stairs. ");
                            Console.WriteLine("In the middle of the room, there is a gaping pit that stretches from wall to wall.");
                            Console.WriteLine("What remains of a bridge hangs off the side of the pit, having collapsed long ago.");
                            Console.WriteLine("To the south is the hallway to the rest of the dungeon.");
                            while (direction == 0)//allows the player to enter commands until they move to a different room
                            { 
                                Console.Write("     >");
                                input = Console.ReadLine();
                                direction = p.command(input, events, inventory, itemlist, room, maze);
                            }
                            break;
                        case 5:
                            room = 2;
                            
                            Console.WriteLine("You are in a hallway connecting various parts of the dungeon. ");
                            Console.WriteLine("The ground and walls are made of damp stone bricks, sending a chill through your bones.");
                            Console.WriteLine("The hallway continues to the north and south.");
                            Console.WriteLine("To the east is the cell that you woke up in. ");
                            if (events[0] == true)
                            {
                                Console.WriteLine("There is a side room to the west where the door once stood.");
                            }
                            else
                            {
                                Console.WriteLine("There is an old, moldy door in the west wall. It appears to be locked.");
                            }
                            while (direction == 0)//allows the player to enter commands until they move to a different room
                            {
                                Console.Write("     >");
                                input = Console.ReadLine();
                                direction = p.command(input, events, inventory, itemlist, room, maze);
                            }
                            break;
                        case 6:
                            room = 4;
                            Console.WriteLine("You are at the southern end of the hallway, having come to a dead end.");
                            Console.WriteLine("There is a door in the east wall, with a skeleton lying next to it.");
                            Console.WriteLine("The skeleton was probably once a guard of this dungeon.");
                            Console.WriteLine("To the north is the rest of the hallway. ");
                            while (direction == 0)//allows the player to enter commands until they move to a different room
                            {
                                Console.Write("     >");
                                input = Console.ReadLine();
                                direction = p.command(input, events, inventory, itemlist, room, maze);
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (y) //y coordinate
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 5:
                            room = 1;
                            Console.WriteLine("You are in a cell of some sort. There is an old, ratty bed in one corner.");
                            Console.WriteLine("The walls are covered in moss, and the entire room has a stench of decay.");
                            Console.WriteLine("The cell door is to the west. It may have once been locked, but it has long since rusted away.");
                            while (direction == 0)//allows the player to enter commands until they move to a different room
                            {
                                Console.Write("    >");
                                input = Console.ReadLine();
                                direction = p.command(input, events, inventory, itemlist, room, maze);
                            }
                            break;
                        case 6:
                            room = 5;
                            Console.WriteLine("You are in a small office with a map covering one wall.");
                            Console.WriteLine("Unlike the rest of the dungeon, this room has painted walls and a wooden floor.");
                            Console.WriteLine("The owner obviously wanted to give it a more homely feeling.");
                            Console.WriteLine("In one corner is a rather large desk with many drawers.");
                            Console.WriteLine("To the west is the hallway you came from.");
                            while (direction == 0)//allows the player to enter commands until they move to a different room
                            {
                                Console.Write("    >");
                                input = Console.ReadLine();
                                direction = p.command(input, events, inventory, itemlist, room, maze);
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (y) //y coordinate
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                    }
                    break;
            }

            */
            return (room);
        }
        
        
        
        
        
        
        
        
        
        public int command(string input, Boolean[] events, Boolean[] inventory, String[] itemlist, int room, string[] maze, Boolean developermode)
        {
            //determines what to do based on what the user enters
            
            Boolean invalid = true;
            string action = ""; //the subject of the user's command (what to do)
            string thing = ""; //the object of the user's command (what the action is being done to)

            //seperates the user's input into 'action' and 'thing'
            int space = input.IndexOf(" ");
            
            if (space != -1)
            {
                action = input.Substring(0, space);
                thing = input.Substring(space + 1, input.Length - space - 1);
            }else
            {
                action = input;
            }
            
            //if the user entered "help"
            if (action == "HELP")
            {
                Console.WriteLine("HELP: Brings up this menu.");
                Console.WriteLine("EXAMINE <ITEM>: Take a closer look at something.");
                Console.WriteLine("INVENTORY: Check what items you have.");
                Console.WriteLine("GO <DIRECTION>: Go in a certain direction.");
                Console.WriteLine("TAKE <ITEM>: Place an item in your inventory.");
                Console.WriteLine("USE <ITEM>: Use an item in your inventory. You will then be prompted for something to use it on.");
            }
            
            








            //if the user entered "inventory"
            else if(action == "INVENTORY")
            {
                
                for(int x = 0; x <= 9; x++)
                {
                    if (inventory[x] == true) //if something is 'true' in the player's inventory then...
                    {
                        Console.WriteLine(itemlist[x]); //...that thing in 'itemlist' is displayed
                        invalid = false;
                    }
                    
                }
                if (invalid == true) //if nothing is in the player's inventory then a message appears
                {
                    Console.WriteLine("You have nothing in your inventory.");
                }
            }
            
            
            









            else if (action == "TAKE") //if the user tried to take something
            {
                //checks if the user can take the item and if they are in the right room
                if (thing == "CLOTH" && inventory[0] == false && room == 1)
                {
                    Console.WriteLine("You take some cloth from the bed and put it in your inventory.");
                    inventory[0] = true;
                }else if(thing == "ROPE" && inventory[1] == false && room == 3)
                {
                    Console.WriteLine("You take some rope from the ruined bridge and put it in your inventory.");
                    inventory[1] = true;
                }
                else if (thing == "AXE" && inventory[2] == false && room == 4)
                {
                    Console.WriteLine("You take the axe from the skeleton's hands and put it in your inventory.");
                    inventory[2] = true;
                }
                else if (thing == "SEWER KEY" && inventory[3] == false && room == 5)
                {
                    Console.WriteLine("You take the key to the sewers from the drawer and put it in your inventory.");
                    inventory[3] = true;
                }
                else if (thing == "MATCHES" && inventory[4] == false && room == 6)
                {
                    Console.WriteLine("You take the matches from the drawer and put it in your inventory.");
                    inventory[4] = true;
                }
                else if (thing == "SAW" && inventory[5] == false && room == 7)
                {
                    Console.WriteLine("You take the saw from the shelves and put it in your inventory.");
                    inventory[5] = true;
                }
                else if (thing == "TORCH" && inventory[6] == false && room == 7)
                {
                    Console.WriteLine("You take the torch inside the chest and put it in your inventory.");
                    inventory[6] = true;
                }
                else if (thing == "POTION" && inventory[7] == false && room == 13)
                {
                    Console.WriteLine("You take some rope from the ruined bridge and put it in your inventory.");
                    inventory[7] = true;
                }
                else if (thing == "DRAWER KEY" && inventory[8] == false && room == 17)
                {
                    Console.WriteLine("You take the drawer key from the rack and put them in your inventory.");
                    inventory[8] = true;
                }
                else if (thing == "DOG FOOD" && inventory[9] == false && room == 16 && inventory[8] == true)
                {
                    Console.WriteLine("You take the dog food from the drawer and put it in your inventory.");
                    inventory[9] = true;
                }else if (thing == "KEY")
                {
                    if (inventory[3] == false && room == 5)
                    {
                        Console.WriteLine("You take the key to the sewers from the rack and put it in your inventory.");
                        inventory[3] = true;
                    }else if (inventory[8] == false && room == 17)
                    {
                        Console.WriteLine("You take the drawer key from the desk and put them in your inventory.");
                        inventory[8] = true;
                    }
                }
                else if (thing == "OIL CAN" && room == 7 && inventory[10] == false)
                {
                    Console.WriteLine("You take the oil can from off the shelf and put it in your inventory.");
                    inventory[10] = true;
                }else
                {
                    //if the item isn't there or can't be taken then a message appears
                    Console.WriteLine("You can't take that.");
                }

            }
            
            
            
            







            
            else if (action == "USE") //if the user tried to use something
                {
                string target;
                    for (int item = 0; item <= 9; item++) //first makes sure that the user has the item
                         {if (itemlist[item] == thing && inventory[item] == true)
                            {
                             invalid = false;
                            }
                    }

                    if (invalid == false) //then asks the user what to use the item on
                {
                    Console.WriteLine("Use " + thing + " on what?");
                    Console.Write("     >");
                    target = Console.ReadLine();
                    target = target.ToUpper();

                        //checks to see if the user can use that item on that target
                    if (thing == "CLOTH" && target == "TORCH" && inventory[6] == true && events[2] == false)
                    {
                        Console.WriteLine("You take some of the cloth and put it in the torch.");
                        Console.WriteLine("It is now ready to be lit.");
                        events[2] = true;
                    }else if(thing == "AXE" && target == "DOOR" && events[0] == false && room == 2)
                    {
                        Console.WriteLine("Using the axe, you begin to chop down the old door.");
                        Console.WriteLine("It gives way after a few swings, and you look inside.");
                        Console.WriteLine("It appears to be some sort of sleeping quarters.");
                        Console.WriteLine("You can now go west.");
                        events[0] = true;
                    }else if (thing == "SEWER KEY" && target == "TRAPDOOR" && events[1] == false && room == 6)
                    {
                        Console.WriteLine("You unlock the trapdoor underneath the carpet.");
                        Console.WriteLine("Below, a ladder extends into the darkness.");
                        Console.WriteLine("You can now go down.");
                        events[1] = true;
                    }else if (thing == "MATCHES" && target == "TORCH" && events[3] == false && events[2] == true)
                    {
                        Console.WriteLine("You take a match and ignite the torch.");
                        Console.WriteLine("It allows you to see further in the darkness.");
                        events[3] = true;
                        if (events[9] == true && room == 8)
                        {
                            Console.WriteLine("With your torch in one hand and the rope in the other, you are ready to go deeper into the sewer.");
                        }
                    }else if (thing == "SAW" && (target == "BARS" || target == "GRATE") && events[5] == false && room == 10)
                    {
                        Console.WriteLine("Using the saw, you make short work of the rusty bars.");
                        Console.WriteLine("You are now free to explore the rest of the dungeon.");
                        Console.WriteLine("You can now go east.");
                        events[5] = true;
                    }
                    /*else if (thing == "OIL CAN" && room == 13 && events[6] == false) {
                        Console.WriteLine("Using the oil in the can, you grease up the lever and pull it.");
                        Console.WriteLine("Immediately, you hear a great rumbling noise.");
                        Console.WriteLine("Looking out the window, you see that the dungeon has been partially flooded.");
                        events[6] = true;
                    }*/
                    else if (thing == "POTION" && target == "DOG FOOD" && events[7] == false && inventory[9])
                    {
                        Console.WriteLine("You mix some of the sleeping potion into the dog food.");
                        events[7] = true;
                    }
                    else if (thing == "DRAWER KEY" && target == "DRAWERS" && room == 16)
                    {
                        Console.WriteLine("Which drawer?");
                        for (int x = 1; x <= 8; x++)
                        {
                            Console.WriteLine("Drawer " + x);
                        }
                        int choice = Int32.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 5: Console.WriteLine("Inside is a box of dog food.");
                                break;
                            default: Console.WriteLine("There is nothing inside the drawer.");
                                break;
                        }

                    }
                    else if (thing == "DOG FOOD" && target == "DOG" && room == 18 && events[8] == false)
                    {
                        Console.WriteLine("You pour out some of the dog food in front of the dog.");
                        Console.WriteLine("It begins to hungrily eat it up.");
                        if (events[7] == true)
                        {
                            Console.WriteLine("Soon the sleeping potion kicks in, and the great dog falls asleep.");
                            events[8] = true;
                        }
                        else
                        {
                            Console.WriteLine("Soon the dog finishes its food, and goes back to guard the door.");
                        }
                    }
                    else if (thing == "ROPE" && target == "RING" && room == 8 && events[9] == false)
                    {
                        Console.WriteLine("You take a long piece of rope and tie it securely to the ring.");
                        Console.WriteLine("This way, you can hold on to it and return here if you get lost.");
                        events[9] = true;
                        if (events[3] == true)
                        {
                            Console.WriteLine("With your torch in one hand and the rope in the other, you are ready go deeper into the sewer.");
                        }
                    }
                    else //if the user has the item but used it on the wrong target a message appears
                    {
                        Console.WriteLine("You can't do that right now.");
                    }
                    }else
                {
                        //if the user doesn't have that item a message appears
                    Console.WriteLine("You don't have that item.");
                    Console.WriteLine("HINT: Make sure to use the exact name of the item in your INVENTORY.");
                }
                 }
            
            
            








            
            else if(action == "GO") //if the user tried to go in a certain direction
                 {
                     int currentroom = room;
                    switch (room) //checks to see if they can go that way in that room
                {
                    case 1: if (thing == "WEST")
                        {
                        room = 2;
                    }break;
                    case 2:
                        if (thing == "WEST" && events[0] == true)
                        { 
                            room = 6;
                        }
                        else if (thing == "EAST")
                        {
                            room = 1;
                        }
                        else if (thing == "NORTH")
                        {
                            room = 3;
                        }
                        else if (thing == "SOUTH")
                        {
                            room = 4;
                        }
                        break;
                    case 3:
                        if (thing == "SOUTH")
                        {
                            room = 2;
                        }
                        break;
                    case 4:
                        if (thing == "EAST")
                        {
                            room = 5;
                        }
                        else if (thing == "NORTH")
                        {
                            room = 2;
                        }
                        break;
                    case 5:
                        if (thing == "WEST")
                        {
                            room = 4;
                        }
                        break;
                    case 6:
                        if (thing == "WEST")
                        {
                            room = 7;
                        }
                        else if (thing == "EAST")
                        {
                            room = 2;
                        }
                        else if (thing == "DOWN" && events[1] == true)
                        {
                            room = 8;
                        }
                        break;
                    case 7:
                        if (thing == "EAST")
                        {
                            room = 6;
                        }
                        break;
                    case 8:
                        if (thing == "UP")
                        {
                            room = 6;
                        }else if (thing == "DEEPER" || thing == "IN")
                        {
                            if (events[3] == true && inventory[1] == true)
                            {
                                room = 9;
                            }
                            else
                            {
                                Console.WriteLine("You are not ready to go into the sewers yet.");
                            }
                        }break;
                    case 9:
                        if (thing == "GRATE" || thing == "SEWER GRATE")
                        {
                            room = 10;
                        }else if (thing == "TRAPDOOR")
                        {
                            room = 8;
                        }
                        break;
                    case 10:
                        if (thing == "DEEPER" || thing == "IN")
                        {
                            room = 9;
                        }
                        else if (thing == "EAST" && events[5] == true)
                        {
                            room = 11;
                        }
                        break;
                    case 11:
                        if (thing == "EAST")
                        {
                            room = 12;
                        }
                        else if (thing == "WEST")
                        {
                            room = 10;
                        }
                        break;
                    case 12:
                        if (thing == "EAST")
                        {
                            room = 14;
                        }
                        else if (thing == "WEST" && events[6] == false)
                        {
                            room = 11;
                        }
                        else if (thing == "SOUTH")
                        {
                            room = 13;
                        }break;
                    case 13:
                        if (thing == "NORTH")
                        {
                            room = 11;
                        }
                        break;
                    case 14:
                        if (thing == "WEST")
                        {
                            room = 13;
                        }
                        else if (thing == "NORTH" && events[6] == true)
                        {
                            room = 15;
                        }
                        break;
                    case 15:
                        if (thing == "UP")
                        {
                            room = 16;
                        }
                        else if (thing == "SOUTH")
                        {
                            room = 14;
                        }
                        break;
                    case 16:
                        if (thing == "UP")
                        {
                            room = 17;
                        }
                        else if (thing == "DOWN")
                        {
                            room = 15;
                        }
                        break;
                    case 17:
                        if (thing == "WEST")
                        {
                            room = 18;
                        }
                        else if (thing == "DOWN")
                        {
                            room = 16;
                        }
                        break;
                    case 18:
                        if (thing == "OUT" && events[8] == true)
                        {
                            room = 19;
                        }
                        else if (thing == "EAST")
                        {
                            room = 17;
                        }
                        break;
                }
                if (room == currentroom) //if the user can't go in that direction a message appears
                {
                    Console.WriteLine("You can't go that way.");
                }
                 }
            
            
            
            

                //if the user tried to look at something
            else if (action == "EXAMINE")
            {
                switch (room) //determines if the user can see that thing in the room they are in and then shows an appropriate message
                {
                    case 1:
                        if (thing == "BED")
                        {
                            Console.WriteLine("The bed looks like it hasn't been touched in years.");
                            if (inventory[0] == false) { }
                            Console.WriteLine("On the bed are some scraps of cloth, likely what remains of the blanket.");
                        }
                        else if (thing == "CLOTH" && inventory[0] == false)
                        {
                            Console.WriteLine("The cloth looks dry and rather flammable.");
                        }
                        else if (thing == "WALLS")
                        {
                            Console.WriteLine("The walls stand tall and imposing on three sides of the cell.");
                            Console.WriteLine("The moss covers much of the walls and paints them a deep green.");
                        }
                        else if (thing == "MOSS")
                        {
                            Console.WriteLine("Upon closer inspection, the moss only forms a thin layer on the walls.");
                            Console.WriteLine("It would be pointless to try and gather any of it.");
                        }
                        else if (thing == "DOOR")
                        {
                            Console.WriteLine("The door is made of rusted iron bars.");
                            Console.WriteLine("When you push it, it opens with a creak.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                        
                        break;
                    case 2:
                        if (thing == "DOOR" && events[0] == false)
                        {
                            Console.WriteLine("The door seems incredibly fragile.");
                            Console.WriteLine("If you had a heavy object, you could probably break it down.");
                        }else if (thing == "LOCK" && events[0] == false)
                        {
                            Console.WriteLine("The lock is deformed beyond recognition.");
                            Console.WriteLine("Even if you had the key, you can't find the keyhole.");
                        }else if (thing == "ROOM" && events[0] == true)
                        {
                            Console.WriteLine("Inside the room, there are what look like beds and drawers.");
                            Console.WriteLine("You need to get closer for a better look.");
                        }else if(thing == "CELL")
                        {
                            Console.WriteLine("A door made of rusted iron bars leads back into the cell.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                        break;
                    case 3:
                        if (thing == "STAIRS")
                        {
                            Console.WriteLine("You can only just make out their outline from here.");
                            Console.WriteLine("You need to get closer for a better look. ");
                        }
                        else if(thing == "PIT")
                        {
                            Console.WriteLine("Looking into the pit, all you see is inky blackness.");
                            Console.WriteLine("However, you hear what sounds like running water.");
                        }else if (thing == "BRIDGE" || thing == "REMAINS")
                        {
                            Console.WriteLine("The bridge is made up of rope and wooden planks.");
                            Console.WriteLine("Most of it is gone, but a portion sits on the edge.");
                            if (inventory[1] == false)
                            {
                                Console.WriteLine("There is some rope lying around the bridge.");
                            }
                        }else if(thing == "ROPE" && inventory[1] == false)
                        {
                            Console.WriteLine("The rope is surprisingly long.");
                            Console.WriteLine("It could be used for a variety of purposes.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 4:
                        if (thing == "SKELETON")
                        {
                            Console.WriteLine("This skeleton's clothes are in tatters. They must have died long ago.");
                            if(inventory[2] == false)
                            {
                                Console.WriteLine("There is a small, rusty axe clasped in its hands.");
                            }
                        }
                        else if (thing == "AXE" && inventory[2] == false)
                        {
                            Console.WriteLine("The axe has specks of dried blood on it.");
                            Console.WriteLine("You could use it to chop something down.");
                        }
                        else if (thing == "DOOR")
                        {
                            Console.WriteLine("A sign on the door reads 'Warden's Office'.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 5:
                        if (thing == "DESK")
                        {
                            Console.WriteLine("The desk is made of a dark-coloured wood.");
                            Console.WriteLine("It is coated in a thick layer of dust.");
                        }else if (thing == "DUST")
                        {
                            Console.WriteLine("It looks like regular old dust.");
                        }
                        else if(thing == "DRAWERS")
                        {
                            if(inventory[3] == false)
                            {
                                Console.WriteLine("Most of the drawers are empty.");
                                Console.WriteLine("However, inside one of them is a small key.");
                                Console.WriteLine("The tag on the key reads 'SEWER'.");
                            }
                            else
                            {
                                Console.WriteLine("All of the drawers are empty.");
                            }
                        }else if (thing == "KEY" && inventory[3] == false)
                        {
                            Console.WriteLine("The tag on the key reads 'SEWER'.");
                        }else if (thing == "MAP")
                        {
                            Console.WriteLine("The title of the map has long since faded.");
                            Console.WriteLine("All you can make out is the outline of some sort of maze.");
                            Console.WriteLine("To get through, it seems that you would have to go: ");
                            foreach (string move in maze)
                            {
                                Console.Write(move + " ");
                            }
                            Console.WriteLine("");
                        }
                        else if (thing == "FLOOR")
                        {
                            Console.WriteLine("Made of sandy-coloured wood and covered in dust.");
                        }
                        else if (thing == "WALLS") {
                            Console.WriteLine("Painted a once-brilliant turquoise, now faded in some areas.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 6:
                        if (thing == "RUG")
                        {
                            if (events[1] == false) {
                                Console.WriteLine("Looking closer, the rug has a suspicious bump in the middle.");
                                Console.WriteLine("You lift up the rug and find a trapdoor underneath it!");
                            }
                            else
                            {
                                Console.WriteLine("The rug lies unused to the side of the room.");
                                Console.WriteLine("It would be far too heavy to take anywhere.");
                            }
                        } else if(thing == "TRAPDOOR")
                        {
                            if (events[1] == false)
                            {
                                Console.WriteLine("There is a small lock on the trapdoor.");
                                Console.WriteLine("It is made of solid wood, unbreakable with your old axe.");
                            }
                            else
                            {
                                Console.WriteLine("The trapdoor is open.");
                            }
                        }else if (thing == "BEDS" || thing == "BED")
                        {
                            Console.WriteLine("The beds are all plain and identical. ");
                            Console.WriteLine("White pillows on white mattresses.");
                        }else if (thing == "PILLOWS" || thing == "PILLOW")
                        {
                            Console.WriteLine("The pillows are made of a rather stiff material.");
                            Console.WriteLine("They would be very uncomfortable to sleep on.");
                            if (inventory[4] == false)
                            {
                                Console.WriteLine("Underneath one of the pillows you find a box of matches.");
                            }
                        }
                        else if(thing == "MATTRESS" || thing == "MATTRESSES")
                        {
                            Console.WriteLine("Under the blankets, these mattresses are covered in stains of various colours.");
                            Console.WriteLine("You probably don't want to know what those stains are.");
                        }else{
                            Console.WriteLine("You can't see that.");
                        }

                        
                            break;
                    case 7:
                        if (thing == "BOX" || thing == "BOXES")
                        {
                            Console.WriteLine("The boxes are filled with what looks and smells like spoiled food.");
                            Console.WriteLine("Even if you were starving, you couldn't bring yourself to touch it.");
                        } else if (thing == "SHELF" || thing == "SHELVES")
                        {
                            if (inventory[5] == false)
                            {
                                Console.WriteLine("The shelves are covered by a layer of dust and broken glass.");
                                Console.WriteLine("In one corner, you find a small but sharp saw.");
                            }else
                            {
                                Console.WriteLine("The shelves hold nothing but dust and broken glass.");
                            }
                        }
                        else if(thing == "FOOD")
                        {
                            Console.WriteLine("It looks absolutely disgusting.");
                        } else if (thing == "GLASS" || thing == "BROKEN GLASS")
                        {
                            Console.WriteLine("The glass looks as if it came from multiple sources.");
                            Console.WriteLine("It would be hopeless to try and reassemble it.");
                        }
                        else if(thing == "SAW" && inventory[5] == false)
                        {
                            Console.WriteLine("Despite how old it is, it is still rather sharp.");
                            Console.WriteLine("You could use it to cut through something.");
                        } else if (thing == "CHEST")
                        {
                            if (inventory[6] == false)
                            {
                                Console.WriteLine("The chest contains a wooden torch.");
                                Console.WriteLine("While it looks usable, there is no lighter or fuel.");
                            }
                            else
                            {
                                Console.WriteLine("The chest is empty.");
                            }
                        }
                        else if(thing == "TORCH" && inventory[6] == false)
                        {
                            Console.WriteLine("While it looks usable, there is no lighter or fuel.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 8:
                        if (thing == "LADDER")
                        {
                            Console.WriteLine("Even though it looks old and flimsy, it can surprisingly hold your weight.");
                            Console.WriteLine("It leads back up to the trapdoor into the guard's quarters.");
                        }
                        else if (thing == "PUDDLE" || thing == "PUDDLES")
                        {
                            Console.WriteLine("The puddles are filled with stagnant, brackish water.");
                            Console.WriteLine("You have no way of knowing how deep they are, and don't want to risk finding out.");
                        }
                        else if (thing == "RING" || thing == "METAL RING")
                        {
                            if (events[9] == false)
                            {
                                Console.WriteLine("At first sight, you can't think of what it could be used for.");
                                Console.WriteLine("It does, however, look like you could tie something to it.");
                            }
                            else
                            {
                                Console.WriteLine("One end of the rope is tied to the metal ring.");
                            }
                        }
                        else if (thing == "ENTRANCE" || thing == "SEWERS")
                        {
                            if (events[3] == false)
                            {
                                Console.WriteLine("The darkness prevents you from seeing anything past the entrance.");
                            }
                            else
                            {
                                Console.WriteLine("Using the light from your torch, you can see where the sewer first splits.");
                            }
                        }
                        else if (thing == "ROPE" && events[9] == true)
                        {
                            Console.WriteLine("The rope leads deeper into the sewer.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 9:
                        Console.WriteLine("You can't do that in the darkness.");
                        break;
                    case 10:
                        if (thing == "ROPE")
                        {
                            Console.WriteLine("The rope leads deeper into the sewers.");
                        }else if (thing == "GRATE" || thing == "IRON GRATE")
                        {
                            if (events[5] == false)
                            {
                                Console.WriteLine("Iron bars cover the grate and block your way.");
                                Console.WriteLine("They look thick, but rusty enough to be cut through...");
                            }else
                            {
                                Console.WriteLine("The remains of the bars stick out of the top and bottom of the grate.");
                                Console.WriteLine("You are able to pass through them easily.");
                            }
                        }
                        else if (thing == "BARS" || thing == "IRON BARS")
                        {
                            if (events[5] == false)
                            {
                                Console.WriteLine("Long and hard, they stand erect in front of your face.");
                                Console.WriteLine("They look thick, but rusty enough to be cut through...");
                            }
                            else
                            {
                                Console.WriteLine("The bars lie off to the side, discarded and left to rust.");

                            }
                        }
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                }
            }



            //developer mode options; these help a lot with testing and debugging
            else if(action == "TELEPORT" && developermode == true) //teleports player to a certain room
            {
                room = Int32.Parse(thing);
            }else if(action == "GIVE" && developermode == true) //gives the player a certain item
            {
                Console.WriteLine(itemlist[Int32.Parse(thing) - 1] + " is now in your inventory.");
                inventory[Int32.Parse(thing) - 1] = true;
            }else if(action == "TRIGGER" && developermode == true) //triggers a certain event
            {
                Console.WriteLine("Event " + thing + " triggered.");
                events[Int32.Parse(thing) - 1] = true;
            }
            else
            {
                Console.WriteLine("Invalid command.");
                Console.WriteLine("Hint: Type 'help' for a list of options.");
            }

            return (room);
            
        }

    }
}
