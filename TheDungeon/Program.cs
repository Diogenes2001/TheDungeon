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
            int potion = 2; //the potion you are carrying
            int randomnum = 0;
            int shelf = randomizer.Next(1, 9);
            Boolean[] events = new Boolean[9]; //list of events that can occur and affect game world, events that have occured are 'true'
            Boolean[] inventory = new Boolean[10]; //items that the player can obtain, ones that the player has are 'true'
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
            String[] itemlist = new String[] { "CLOTH", "ROPE", "AXE", "KEY", "MATCHES", "SAW", "TORCH", "OIL CAN", "POTION", "DOG TREATS"};
            //list of possible items, corresponds to 'Boolean[] inventory', shows the ones that the player has obtained when "INVENTORY" is entered
            Program p = new TheDungeon.Program();
            
            
            



            //game intro
            Console.WriteLine("You wake in a dark room. Groggily, you rise and take note of your surroundings. ");
            Console.WriteLine("You appear to be in some sort of dungeon, yet you cannot remember why you are here. ");
            Console.WriteLine("All you know is that you must escape…");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            
            if (name.ToUpper() == "DEVELOPER" || name.ToUpper() == "TESTER")
            {
                developermode = true;
            }
            

                //actual game, runs procedures until game is won



                do
            {
                Console.Clear();
                room = p.location(events, inventory, p, itemlist, room, maze, developermode, potion, shelf); //returns a direction in which the player will move
                if (room < 0) //shows the room again after the potion minigame
                {
                    potion = (room * -1);
                    room = 19;
                }
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
                if (room == 20)
                {
                    victory = true; //player wins when player gets to the last room
                }
            } while (victory == false);
            Console.Clear();
            
            //victory screen
            Console.WriteLine("You leave the darkness of the dungeon behind you, and emerge into bright sunlight.");
            Console.WriteLine("Looking around, you have no idea wher you are.");
            Console.WriteLine("Despite this, you know that you will soon find your way home.");
            Console.WriteLine("\nTHANK YOU, {0}, FOR PLAYING 'THE DUNGEON'!", name);
            Console.ReadKey();
        }
        







        //runs code where different things can happen depending on the player's location
        public int location(Boolean[] events, Boolean[] inventory, Program p, String[] itemlist, int room, string[] maze, Boolean developermode, int potion, int shelf)
        {
            int currentroom = room;
            string input; //what the player enters into the console
            //describes the room the player is in
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
                if (events[5] == true)
                {
                    Console.WriteLine("The rope showing the way through extends deeper into the sewer.");
                }else if(events[3] == true && events[4] == true){
                    Console.WriteLine("With your torch in one hand and the rope in the other, you are ready to go deeper into the sewer.");
                }
                else
                {
                    Console.WriteLine("You don't feel that you have everything you need to enter the sewer.");
                    Console.WriteLine("First, you would need a way to see into the darkness of the sewers.");
                    Console.WriteLine("And no matter what light source you use, you would need some sort of fuel for it...");
                    Console.WriteLine("Second, you would need a way to find your way back if you get lost in there.");
                    Console.WriteLine("You vaguely remember a story about someone named Theseus who needed the same thing...");
                    Console.WriteLine("HINT: Try collecting more items and using them on each other.");
                }
                break;
                case 9:
                    if (events[5] == false)
                    {
                        Boolean correct = true;
                        correct = p.sewermaze(correct, maze);
                        if (correct == true)
                        {
                            Console.Clear();
                            Console.WriteLine("After some time, you begin to see a light in the distance.");
                            Console.WriteLine("You have almost reached the other side of the maze.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            room = 10;
                            events[5] = true;
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
                    if (events[6] == false)
                    {
                        Console.WriteLine("Iron bars cover the grate, preventing you from going any further.");
                    }else
                    {
                        Console.WriteLine("The iron bars that once covered it have been sawed off, allowing you to pass through them.");
                    }
                break;
                case 11:
                    Console.WriteLine("You are standing on an embankment at the bottom of the pit you saw earlier.");
                    Console.WriteLine("Along the bank runs a wide river of murky water, with a revolting stench rising off of it.");
                    Console.WriteLine("There is a line of boxes stacked haphazardly up against the nearby wall.");
                    Console.WriteLine("To the east is a set of stairs leading up, while to the west is the sewer grate you emerged from.");
                break;
                case 12:
                    Console.WriteLine("You are standing on the opposite side of the pit from where you awoke.");
                    Console.WriteLine("There is a small, squat building nearby that you were not able to see from the other side.");
                    Console.WriteLine("The door to the building is ajar, inviting you inside.");
                    Console.WriteLine("To the west is a set of stairs leading down, while to the east is some sort of wooden platform.");
                break;
                case 13:
                    Console.WriteLine("You are in a small room with no windows and a large lever in the middle.");
                    if (events[7] == false)
                    {
                        Console.WriteLine("The lever is attached to a gear in the ground, and appears to be stuck.");
                    }
                    else
                    {
                        Console.WriteLine("The lever has already been oiled and pulled, and is now locked in the 'on' position.");
                    }
                    Console.WriteLine("Next to the door that leads out is a small table and a chair.");
                    Console.WriteLine("Despite the dust covering it, the table looks set for a dinner for one.");
                break;
                case 14:
                    Console.WriteLine("You are standing on a wooden dock, which is situated on the edge of another river.");
                    Console.WriteLine("It originates as a waterfall in the southern wall, and flows northward into a tunnel.");
                    if (events[7] == false)
                    {
                        Console.WriteLine("Currently, the water is far below you, but you can see a boat bobbing up and down on the surface.");
                    }
                    else
                    {
                        Console.WriteLine("Pulling the lever has raised the water level, and the boat is now bobbing up and down in front of you.");
                        Console.WriteLine("Inside the boat are a set of oars, which would allow you to head north into the tunnel.");
                    }
                    Console.WriteLine("To the west is the pit with the original river at the bottom.");
                break;
                case 15:
                    Console.WriteLine("You are on a dock at the northern end of the tunnel, where the river passes through a set of iron bars.");
                    Console.WriteLine("Beyond the bars, it continues for another twenty metres, then forms another waterfall leading down into a pit.");
                    Console.WriteLine("Your boat would be unable to fit through the bars, and they look far too thick to saw through.");
                    Console.WriteLine("There is a ladder on the dock leading upward, and the boat is availible to take you back south.");
                break;
                case 16:
                    Console.WriteLine("You are in what looks like a large storage room, with a hole in the ground that you emerged from.");
                    Console.WriteLine("The room is lineds with rows of shelves labelled from 1 to 8. There could be something of use in one of them.");
                    Console.WriteLine("You can see what you hope are rats scurrying in the shadows, spreading fleas and other undesirables.");
                    Console.WriteLine("There is a door to the west, and also the hole with the ladder that leads down.");
                break;
                case 17:
                    Console.WriteLine("You are in what remains of the entrance hall to the castle containing the dungeon.");
                    Console.WriteLine("Time has taken its toll on the once-great room, with chunks of the walls and ceiling having crumbled away.");
                    Console.WriteLine("Along with the broken furniture and shattered glass, they form piles of rubble on the ground.");
                    Console.WriteLine("The collapsed pillars that once held up the hall prevent passage through many of its exits.");
                    Console.WriteLine("There are only three open exits: to the north, east, and west.");
                break;
                case 18:
                    Console.WriteLine("You have reached the gate of the castle, and you can see clear blue sky past the portcullis.");
                        Console.WriteLine("However, your path is blocked by a gigantic guard dog, almost the size of an elephant.");
                        Console.WriteLine("You can tell that it is starving to the point where its bones are showing, but could still easily tear you apart.");
                        Console.WriteLine("It looks rabid and ready to devour you, but luckily it is chained to the wall and cannot reach you.");
                        Console.WriteLine("You can go east back inside the castle.");
                    
                break;
                case 19:
                    Console.WriteLine("You are in a small laboratory of some sort, with strange contraptions all over the place.");
                    Console.WriteLine("One of these catches your eye, and with your limited knowledge you recognize it as a functional potion stand.");
                    Console.WriteLine("Next to the stand are some ingredients and a heavy book, open to a page listing various potions.");
                    Console.WriteLine("Behind you is the way back to the entrance hall.");
                break;
            }
            
            while (room == currentroom)//allows the player to enter commands until they move to a different room
            {
                Console.Write("     >");
                input = Console.ReadLine();
                input = input.ToUpper();
                
                    room = p.command(input, events, inventory, itemlist, room, maze, developermode, p, potion, currentroom, shelf);
                    
            }
            return (room);
        }
        
        
        
        
        
        
        
        
        
        public int command(string input, Boolean[] events, Boolean[] inventory, String[] itemlist, int room, string[] maze, Boolean developermode, Program p, int potion, int currentroom, int shelf)
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
                if (developermode == true)
                {
                    Console.WriteLine("\nDEVELOPER OPTIONS:");
                    Console.WriteLine("TELEPORT <ROOM #>: Teleport to a certain room.");
                    Console.WriteLine("GIVE <ITEM #>: Give yourself a certain item.");
                    Console.WriteLine("TRIGGER <EVENT #>: Trigger a certain event.");
                }
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
                if ((thing == "CLOTH" || thing == "SCRAPS") && inventory[0] == false && room == 1)
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
                else if ((thing == "SEWER KEY" || thing == "KEY") && inventory[3] == false && room == 5)
                {
                    Console.WriteLine("You take the key to the sewers from the drawer and put it in your inventory.");
                    inventory[3] = true;
                }
                else if ((thing == "MATCHES" || thing == "BOX") && inventory[4] == false && room == 6)
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
                    else if (thing == "OIL CAN" && room == 11 && inventory[7] == false)
                {
                    Console.WriteLine("You take the oil can from inside the box and put it in your inventory.");
                    inventory[7] = true;
                }
                else if ((thing == "POTION" || thing == "FLASK") && inventory[8] == false && room == 13)
                {
                    Console.WriteLine("You take the potion flask from the table and put it in your inventory.");
                    inventory[8] = true;
                }
                
                else if (thing == "DOG TREATS" && inventory[9] == false && room == 16)
                {
                    Console.WriteLine("You take the dog treats from the shelf and put it in your inventory.");
                    inventory[9] = true;
                }
                else
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
                    if (thing == "CLOTH" && target == "TORCH" && inventory[6] == true && events[2] == false) //puts cloth in torch
                    {
                        Console.WriteLine("You take some of the cloth and put it in the torch.");
                        Console.WriteLine("It is now ready to be lit.");
                        events[2] = true;
                    } else if (thing == "AXE" && target == "DOOR" && events[0] == false && room == 2) //chops down door
                    {
                        Console.WriteLine("Using the axe, you begin to chop down the old door.");
                        Console.WriteLine("It gives way after a few swings, and you look inside.");
                        Console.WriteLine("It appears to be some sort of sleeping quarters.");
                        Console.WriteLine("You can now go west.");
                        events[0] = true;
                    }
                    else if (thing == "ROPE" && target == "RING" && room == 8 && events[4] == false) //ties rope to ring
                    {
                        Console.WriteLine("You take a long piece of rope and tie it securely to the ring.");
                        Console.WriteLine("This way, you can hold on to it and return here if you get lost.");
                        events[4] = true;
                        if (events[3] == true)
                        {
                            Console.WriteLine("With your torch in one hand and the rope in the other, you are ready go deeper into the sewer.");
                        }
                    }
                    else if (thing == "KEY" && target == "TRAPDOOR" && events[1] == false && room == 6) //unlocks trapdoor
                    {
                        Console.WriteLine("You unlock the trapdoor underneath the carpet.");
                        Console.WriteLine("Below, a ladder extends into the darkness.");
                        Console.WriteLine("You can now go down.");
                        events[1] = true;
                    } else if (thing == "MATCHES" && target == "TORCH" && events[3] == false && events[2] == true) //lights torch
                    {
                        Console.WriteLine("You take a match and ignite the torch.");
                        Console.WriteLine("It allows you to see further in the darkness.");
                        events[3] = true;
                        if (events[4] == true && room == 8)
                        {
                            Console.WriteLine("With your torch in one hand and the rope in the other, you are ready to go deeper into the sewer.");
                        }
                    } else if (thing == "SAW" && (target == "BARS" || target == "GRATE") && events[6] == false && room == 10) //saws through bars
                    {
                        Console.WriteLine("Using the saw, you make short work of the rusty bars.");
                        Console.WriteLine("You are now free to explore the rest of the dungeon.");
                        Console.WriteLine("You can now go east.");
                        events[6] = true;
                    }
                    else if (thing == "OIL CAN" && (target == "LEVER" || target == "GEAR") && room == 13 && events[7] == false) //greases and pulls lever
                    {
                        Console.WriteLine("Using the oil in the can, you grease up the gear at the base of the lever and pull it.");
                        Console.WriteLine("Immediately, you hear a great rumbling noise, and can feel something moving nearby.");
                        Console.WriteLine("When you try pulling it again, you find that the lever has been locked into the 'on' position.");
                        events[7] = true;
                    }
                    else if (thing == "POTION" && target == "DOG TREATS" && events[8] == false && inventory[8] == true) //laces treats with potion
                    {
                        Console.WriteLine("You mix some of the potion into the dog treats.");
                        events[8] = true;
                    }
                    else if (thing == "POTION" && room == 19 && (target == "STAND" || target == "POTION STAND")) //brews new potion
                    {
                        Console.Clear();
                        Console.WriteLine("You open and dump out the contents of the flask before placing it in the brewing stand.");
                        Console.WriteLine("Using the ingredients around the cellar, you prepare to brew a new potion.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        events[8] = false;
                        potion = p.potionbrewing(potion);
                        room = (potion * -1);
                        //NOTE: Because of a weird bug, I have to set the room to a negative number and use 
                        //it to record the potion created, before changing the room back to what it should be.
                    }
                    else if (thing == "DOG TREATS" && target == "DOG" && room == 18) //gives a treat to the dog
                    {
                        Console.WriteLine("You toss a dog treat to the giant guard dog.");
                        if (potion == 7 && events[8] == true) //if the treats are laced with potion 7, the dog won't eat them
                        {
                            Console.WriteLine("However, the scent of the potion is so strong that the dog won't even touch the treat.");
                        }
                        else //if the treats aren't laced, nothing happens
                        {
                            Console.WriteLine("It quickly gobbles it up, and then goes back to guard the door.");
                        }
                        if (events[8] == true)
                        {
                            //gives a message depending on what the treats were laced with
                            switch (potion)
                            {
                                case 1: 
                                    Console.WriteLine("When you approach it again, it rushes over to where you are almost immediately and begins growling.");
                                    Console.WriteLine("It seems that the potion had the effect of making the dog move faster.");
                                    break;
                                case 2:
                                    Console.WriteLine("Soon the dog lies down and begins rolling around with its tongue out.");
                                    Console.WriteLine("Though the potion seems to have made the dog happy, it still growls when you try to pass.");
                                    break;
                                case 3:
                                    Console.WriteLine("Soon the dog begins aggresively barking at thin air and foaming at the mouth.");
                                    Console.WriteLine("The potion seems to have made the dog even more rabid, and you don't dare approach it now.");
                                    break;
                                case 4:
                                    Console.WriteLine("The dog now seems to be even more energized, more determined to prevent you from passing.");
                                    Console.WriteLine("The potion has revitalized the dog, making your escape even more difficult.");
                                    break;
                                case 5:
                                    //if the treats contained sleeping potion, the dog falls asleep and the player can sneak past and escape
                                    Console.WriteLine("After a while, the dog's eyes begin to droop, and soon it is snoring away on the ground.");
                                    Console.WriteLine("You take advantage of this while you can, and sneak past it to the outside world.");
                                    Console.WriteLine("Press any key to continue:");
                                    Console.ReadKey();
                                    Console.Clear();
                                    room = 20;
                                    break;
                                case 6:
                                    Console.WriteLine("Suddenly the dog looks around, as if it has somehow forgotten what it was supposed to be doing.");
                                    Console.WriteLine("When you try to pass, however, the dog growls and barks at you out of instinct.");
                                    break;
                            }
                            if (potion != 5)
                            {
                                Console.WriteLine("It seems that you need a different potion...");
                            }
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
                    
                }
                 }
            
            
            








            
            else if(action == "GO") //if the user tried to go in a certain direction
                 {
                     
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
                        }else if (thing == "DEEPER" || thing == "IN" || thing == "IN SEWER")
                        {
                            if (events[3] == true && events[4] == true)
                            {
                                room = 9;
                            }
                            else
                            {
                                Console.WriteLine("You are not ready to go into the sewers yet.");
                            }
                        }break;
                    case 9:
                        if (thing == "GRATE" || thing == "TO SEWER GRATE" || thing == "TO GRATE")
                        {
                            room = 10;
                        }else if (thing == "TRAPDOOR" || thing == "TO TRAPDOOR")
                        {
                            room = 8;
                        }
                        break;
                    case 10:
                        if (thing == "DEEPER" || thing == "IN" || thing == "IN SEWER")
                        {
                            room = 9;
                        }
                        else if (thing == "EAST" && events[6] == true)
                        {
                            room = 11;
                        }
                        break;
                    case 11:
                        if (thing == "EAST" || thing == "UP")
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
                        else if (thing == "WEST" || thing == "DOWN")
                        {
                            room = 11;
                        }
                        else if (thing == "IN" || thing == "INSIDE")
                        {
                            room = 13;
                        }break;
                    case 13:
                        if (thing == "OUT" || thing == "OUTSIDE")
                        {
                            room = 12;
                        }
                        break;
                    case 14:
                        if (thing == "WEST")
                        {
                            room = 12;
                        }
                        else if (thing == "NORTH" && events[7] == true)
                        {
                            Console.Clear();
                            Console.WriteLine("You get in the boat and start rowing. After some time, you reach another area...");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            room = 15;
                        }
                        break;
                    case 15:
                        if (thing == "UP" || thing == "UPWARD")
                        {
                            room = 16;
                        }
                        else if (thing == "SOUTH")
                        {
                            Console.Clear();
                            Console.WriteLine("You get in the boat and start rowing. After some time, you reach another area...");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            room = 14;
                        }
                        break;
                    case 16:
                        if (thing == "WEST")
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
                        else if (thing == "EAST")
                        {
                            room = 16;
                        }
                        else if (thing == "NORTH")
                        {
                            room = 19;
                        }
                        break;
                    case 18:
                        if (thing == "EAST")
                        {
                            room = 17;
                        }
                        break;
                    case 19:
                        if (thing == "SOUTH")
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
                        else if(thing == "DRAWERS" || thing == "DRAWER")
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
                            Console.WriteLine("The beds are all plain and identical, white pillows on white mattresses. ");
                            Console.WriteLine("Everything seems to be flame-retardant, and would not catch fire easily.");
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
                            if (events[4] == false)
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
                        else if (thing == "ROPE" && events[4] == true)
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
                            if (events[6] == false)
                            {
                                Console.WriteLine("Iron bars cover the grate and block your way.");
                                Console.WriteLine("They look thick, but rusty enough to be cut through...");
                            }else
                            {
                                Console.WriteLine("The remains of the bars stick out of the top and bottom of the grate.");
                                Console.WriteLine("You would be able to pass through them easily.");
                            }
                        }
                        else if (thing == "BARS" || thing == "IRON BARS")
                        {
                            if (events[6] == false)
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
                        if (thing == "BOX" || thing == "BOXES")
                        {
                            Console.WriteLine("The boxes are all made of wood, and many of them have begun rotting from the moisture.");
                            if (inventory[7] == false)
                            {
                                Console.WriteLine("Inside one of them, you find a partially filled oil can.");
                            }
                            else
                            {
                                Console.WriteLine("You look inside all of them, but find nothing of interest.");
                            }
                        }
                        else if (thing == "RIVER")
                        {
                            Console.WriteLine("The river flows from west to east, and in the distance you can see the side on which you awoke.");
                            Console.WriteLine("The colour of the water is a greyish-green, and you definitely do not wish to touch it.");
                        }
                        else if (thing == "WATER")
                        {
                            Console.WriteLine("A foul stench rises from the greyish-green water.");
                            Console.WriteLine("It smells like a cross between rotten eggs and untreated sewage.");
                        }
                        else if (thing == "BANK" || thing == "EMBANKMENT")
                        {
                            Console.WriteLine("Made of stone, it is old enough to have deep cracks running through it.");
                            Console.WriteLine("You can see where the edges of the bank have been eroded by the rushing water.");
                        }
                        else if (thing == "WALL")
                        {
                            Console.WriteLine("The wall is covered by moss that has grown due to the moisture in the air.");
                        }
                        else if (thing == "STAIRS")
                        {
                            Console.WriteLine("The lead up to the opposite side of the pit from where you awoke.");
                            Console.WriteLine("If you went up the stairs, you would be where the collapsed bridge used to lead.");
                        }
                        else if (thing == "GRATE" || thing == "IRON GRATE")
                        {
                                Console.WriteLine("The remains of the bars stick out of the top and bottom of the grate.");
                                Console.WriteLine("You would be able to pass through them easily.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                        break;
                    case 12:
                        if (thing == "PIT")
                        {
                            Console.WriteLine("The darkness prevents you from seeing it, but you can still hear the rushing of the river.");
                            Console.WriteLine("From this side, you can just make out the remains of the bridge on the other side.");
                        }else if(thing == "BUILDING")
                        {
                            Console.WriteLine("Looking closer, you can see a sign next to the door that reads 'CONTROL ROOM'.");
                        }else if (thing == "DOOR")
                        {
                            Console.WriteLine("From the outside, it looks like a regular door.");
                        }
                        else if (thing == "STAIRS")
                        {
                            Console.WriteLine("The stairs lead back down to the sewer grate you emerged from.");
                        }
                        else if (thing == "PLATFORM" || thing == "WOODEN PLATFORM")
                        {
                            Console.WriteLine("You can tell that it's made of wood, but can't make out any other details about it.");
                            Console.WriteLine("You need to get closer for a better look.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 13:
                            if (thing == "LEVER" || thing == "GEAR")
                            {
                                if (events[7] == false)
                                {
                                    Console.WriteLine("Upon closer inspection, you realize that the gear has become rusted and immovable from disuse.");
                                    Console.WriteLine("If you used something to loosen it up, you could get it working again...");
                                }
                                else
                                {
                                    Console.WriteLine("The gear is now well-oiled, and the lever worked like a charm.");
                                    Console.WriteLine("Of course, that doesn't help you when it is locked in place.");
                                }
                            }
                            else if (thing == "DOOR")
                            {
                                Console.WriteLine("From the inside, it still looks like a regular door.");
                            }
                            else if (thing == "TABLE")
                            {
                                Console.WriteLine("The table is perfectly set, with a plate, utensils, and even a vase with a now-dried flower.");
                                Console.WriteLine("Everything looks untouched, which makes the scene feel even lonelier...");
                                if (inventory[8] == false)
                                {
                                    Console.WriteLine("Next to the plate is an potion flask that reads 'FOR DEPRESSION'.");
                                }
                            }
                            else if (thing == "CHAIR")
                            {
                                Console.WriteLine("It looks small and flimsy, having been weakened by age.");
                                Console.WriteLine("If you sat on it, it would probably break under your weight.");
                            }
                            else if (thing == "VASE" || thing == "FLOWER")
                            {
                                Console.WriteLine("The flower inside the vase must have lost its fragrance long ago.");
                                Console.WriteLine("It is dried beyond identification, and would likely crumble between your fingers.");
                            }
                            else if (thing == "POTION" || thing == "FLASK")
                            {
                                Console.WriteLine("The concoction inside is a bright yellow, and has a thick, syrup-like consistency.");
                                Console.WriteLine("When you open it, its sickly-sweet aroma hits you immediately.");
                            }
                            else
                            {
                                Console.WriteLine("You can't see that.");
                            }
                        break;
                    case 14:
                        if (thing == "DOCK")
                        {
                            Console.WriteLine("The dock is made of thick wood, and is more than sturdy enough to support your weight.");
                            Console.WriteLine("It extends about a fifth of the way across the river, held up by massive stone beams.");
                        }else if (thing == "RIVER")
                        {
                            Console.WriteLine("This river is obviously not the same one as before, being narrower and moving more slowly.");
                            Console.WriteLine("However, it shares the same greyish-green colour and putrid stench.");
                        }
                        else if(thing == "WALL" || thing == "WALLS")
                        {
                            Console.WriteLine("The walls are all made of stone bricks, which have held despite their age.");
                            Console.WriteLine("One of the walls has the waterfall coming out of it like a fountain.");
                        }else if (thing == "WATERFALL")
                        {
                            Console.WriteLine("The brackish water spews forth voluminously from a hole in the wall.");
                        }
                        else if (thing == "TUNNEL")
                        {
                            Console.WriteLine("The tunnel looks wide enough for an entire galleon to fit through.");
                            Console.WriteLine("It leads north into the distance, and you can't see where it ends.");
                        }
                        else if (thing == "BOAT")
                        {
                            if (events[7] == false)
                            {
                                Console.WriteLine("The boat is too far away to make out any details.");
                            }else
                            {
                                Console.WriteLine("It is a simple rowboat, and appears dirty and weathered. The oars inside are chipped and cracked.");
                                Console.WriteLine("However, they should be able to get the job done, and get you to the other end of the tunnel.");
                            }
                        }
                        else if (thing == "OARS")
                        {
                            Console.WriteLine("The oars are chipped and cracked, almost as if they had been smashed against something.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 15:
                        if (thing == "DOCK")
                        {
                            Console.WriteLine("This dock is smaller than the other one, roughly the size of a pair of double doors.");
                            Console.WriteLine("It is still made of wooden planks, and you must take to care to avoid splinters.");
                        }
                        else if (thing == "RIVER")
                        {
                            Console.WriteLine("The river is still absolutely disgusting to smell or to look at.");
                            Console.WriteLine("You would like to get as far away from it as you can, as soon as possible.");
                        }
                        else if (thing == "BARS" || thing == "IRON BARS")
                        {
                            Console.WriteLine("These bars are over twice as thick as the ones from before, almost like small tree trunks.");
                            Console.WriteLine("It would be a waste of time to try and saw through them.");
                        }
                        else if (thing == "PIT")
                        {
                            Console.WriteLine("You can't see the pit very well from where you are, but you can just discern the outline.");
                            Console.WriteLine("It is a dark and empty void, with seemingly no end in sight.");
                        }
                        else if (thing == "BOAT")
                        {
                            Console.WriteLine("It is a simple rowboat, and appears dirty and weathered. The oars inside are chipped and cracked.");
                            Console.WriteLine("However, they should be able to get the job done, and get you to the other end of the tunnel.");
                        }
                        else if (thing == "LADDER")
                        {
                            Console.WriteLine("The ladder is made of solid wood, and feels like it could easily support your weight.");
                            Console.WriteLine("It appears to lead up through a hole into another room.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                            break;
                    case 16:
                            if (thing == "SHELVES" || thing == "ROWS")
                            {
                                Console.Write("Which row do you look in? ");
                                int entry = Int32.Parse(Console.ReadLine());
                                if (entry == shelf)
                                {
                                    Console.WriteLine("In that row you find a box of dog treats.");
                                }
                                else
                                {
                                    Console.WriteLine("That row is empty.");
                                }
                            }
                            else if (thing == "HOLE")
                            {
                                Console.WriteLine("Roughly two meters across, it lets cold air into the room and is obviously not meant to exist.");
                                Console.WriteLine("It looks as if something had smashed through the floorboards at some time in the past.");
                            }
                            else if (thing == "RATS" || thing == "SHADOWS")
                            {
                                Console.WriteLine("If those really are rats, then they would have to be at least the length of your arm.");
                                Console.WriteLine("Of course, rats would probably be preferrable to the alternatives...");
                            }
                            else if (thing == "LADDER")
                            {
                                Console.WriteLine("The ladder is made of solid wood, and feels like it could easily support your weight.");
                                Console.WriteLine("It leads back down into the dungeon, where the boat is.");
                            }
                            else if (thing == "DOOR")
                            {
                                Console.WriteLine("This door is larger and different from the ones down in the dungeon.");
                                Console.WriteLine("It is decorated and ornate, and would not be out of place in a palace or something.");
                            }
                            else
                            {
                                Console.WriteLine("You can't see that.");
                            }
                        break;
                    case 17:
                        if (thing == "WALLS" || thing == "CEILING" || thing == "ROOM" || thing == "HALL")
                        {
                            Console.WriteLine("The entire room looks to made of white marble, which has cracked and crumbled in places.");
                            Console.WriteLine("Somehow, the ruined nature of the hall gives it a strange beauty.");
                        }
                        else if (thing == "BROKEN FURNITURE" || thing == "FURNITURE")
                        {
                            Console.WriteLine("The remains of chairs, cabinets and tables lie scattered around the room.");
                            Console.WriteLine("Some are still fairly intact, while others are beyond recognition.");
                        }
                        else if (thing == "GLASS" || thing == "SHATTERED GLASS")
                        {
                            Console.WriteLine("Most of the glass seems to have come from a chandelier that fell from the ceiling.");
                            Console.WriteLine("You make sure to watch your step and avoid impaling yourself on the glass shards.");
                        }
                        else if (thing == "CHANDELIER")
                        {
                            Console.WriteLine("The once-great feature now lies broken in the middle of the room.");
                            Console.WriteLine("Surrounded by sharp glass, you avoid getting any closer to it.");
                        }
                        else if (thing == "RUBBLE")
                        {
                            Console.WriteLine("The rubble is made from bits and pieces of the furniture and the hall itself.");
                            Console.WriteLine("Obviously, no one has cleaned this place up in a long time.");
                        }
                        else if (thing == "EXITS" || thing == "EXIT")
                        {
                            Console.WriteLine("While there are many exits to the hall, all but three are currently blocked.");
                            Console.WriteLine("It would be impossible for you to unblock them alone and without any tools.");
                        }
                        else if (thing == "PILLARS" || thing == "PILLAR")
                        {
                            Console.WriteLine("The pillars are thicker than any tree you have seen, and taller as well.");
                            Console.WriteLine("However, they now lie on their sides, broken and in pieces.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                        break;
                    case 18:
                        if (thing == "GATE" || thing == "PORTCULLIS")
                        {
                            Console.WriteLine("The portcullis is made from criss-crossing iron bars, which form a tight network of squares.");
                            Console.WriteLine("Had it not been already partially open, you would have been unable to pass through it.");
                        }
                        else if (thing == "SKY")
                        {
                            Console.WriteLine("It is a bright, sunny day today, which makes the outside world all the more tantalizing.");
                        }
                        else if (thing == "DOG" || thing == "GUARD DOG")
                        {
                            Console.WriteLine("It seems that no one has fed the dog in a long time, probably not since the castle fell into ruin.");
                            Console.WriteLine("The dog would probably eat whatever you gave it, even if the food was drugged...");
                        }
                        else if (thing == "WALL" || thing == "CHAIN")
                        {
                            Console.WriteLine("The dog's chain prevents it from straying too far from the wall.");
                            Console.WriteLine("However, it could still reach you if you tried to sneak by.");
                        }
                        else
                        {
                            Console.WriteLine("You can't see that.");
                        }
                        break;
                    case 19:
                        if (thing == "BOOK" || thing == "PAGE")
                        {
                            Console.WriteLine("The page lists various potions and their ingredients:\n");
                            Console.WriteLine("POTION CELERITAS             POTION BEATITAS");
                            Console.WriteLine("Pomegranate Seeds            Dried Rosebuds");
                            Console.WriteLine("Cactus Juice                 Wildflower Honey");
                            Console.WriteLine("Squid Ink                    Holy Basil\n");
                            Console.WriteLine("POTION RABIES                POTION VITALIS");
                            Console.WriteLine("Death Caps                   Dried Rosebuds");
                            Console.WriteLine("Cactus Juice                 Bezoar Powder");
                            Console.WriteLine("Snail Mucus                  Sea Salt\n");
                            Console.WriteLine("POTION SOMNUS                POTION AMNESIA");
                            Console.WriteLine("Birch Sap                    Ground Mealworms");
                            Console.WriteLine("Beeswax                      Basilisk Venom");
                            Console.WriteLine("Eucalyptus Oil               Eucalyptus Oil\n");
                        }
                        else if (thing == "CONTRAPTIONS")
                        {
                            Console.WriteLine("You have no idea what most of them do, but don't want to risk finding out.");
                            Console.WriteLine("For all you know, one of them could self-destruct the castle and bring it crashing down.");
                        }
                        else if (thing == "STAND" || thing == "POTION STAND")
                        {
                            Console.WriteLine("The potion stand looks rather old, but still in good shape considering its age.");
                            Console.WriteLine("There is a tube attaching it to a large tank of water for potion-brewing.");
                        }
                        else if (thing == "TANK" || thing == "WATER TANK")
                        {
                            Console.WriteLine("There is enough water in there for you to use indefinitely.");
                        }
                        else if (thing == "INGREDIENTS")
                        {
                            Console.WriteLine("There are a wide variety of ingredients at your disposal, from rosebuds to sea salt.");
                            Console.WriteLine("It must have taken quite some effort to gather all these ingredients into one place.");
                        }
                        else if (thing == "TUBE")
                        {
                            Console.WriteLine("The tube is made of clear plastic, and about the thickness of your arm.");
                        }else
                        {
                            Console.WriteLine("You can't see that.");
                        }
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
            else //if the user enters a command that is not recognized, a message appears
            {
                Console.WriteLine("Invalid command.");
                Console.WriteLine("Hint: Type 'help' for a list of options.");
            }

            return (room);
            
        }
        public Boolean sewermaze(Boolean correct, string[] maze) //prompts the user for directions through the sewer maze and judges if they took the correct path
        {
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
            return (correct);
        }
        public int potionbrewing(int potion)
            //prompts the user for ingredients, then creates an appropriate potion
        {
            string ingredients, ing1, ing2, ing3;
            Console.Clear();
            Console.WriteLine("First you add in some...");
            Console.WriteLine("1. Dried Rosebuds");
            Console.WriteLine("2. Ground Mealworms");
            Console.WriteLine("3. Death Caps");
            Console.WriteLine("4. Birch Sap");
            Console.WriteLine("5. Pomegranate Seeds");
            ing1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Then you mix in a bit of...");
            Console.WriteLine("1. Beeswax");
            Console.WriteLine("2. Cactus Juice");
            Console.WriteLine("3. Basilisk Venom");
            Console.WriteLine("4. Wildflower Honey");
            Console.WriteLine("5. Bezoar Powder");
            ing2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You finish the potion with a dash of...");
            Console.WriteLine("1. Holy Basil");
            Console.WriteLine("2. Snail Mucus");
            Console.WriteLine("3. Eucalyptus Oil");
            Console.WriteLine("4. Sea Salt");
            Console.WriteLine("5. Squid Ink");
            ing3 = Console.ReadLine();
            Console.Clear();
            ingredients = string.Concat(ing1, ing2, ing3);
            //Console.WriteLine(ingredients);
            Console.WriteLine("After letting the mixture settle, you take a good look at your product.");
            if (ingredients == "525") //Potion Celeritas: potion of speed
            {
                Console.WriteLine("You have created a a clear potion with a clear, light blue colour");
                Console.WriteLine("Looking at it, it reminds you of the sky on a clear day.");
                potion = 1;
            }
            else if (ingredients == "141") //potion beatitas: potion of happiness
            {
                Console.WriteLine("You have created a bright yellow, thick, syrup-like potion.");
                Console.WriteLine("It also has a sickly-sweet aroma that hits you immediately.");
                potion = 2;
            }else if (ingredients == "322") //potion rabies: potion of madness
            {
                Console.WriteLine("You have created a pink and purple potion with a swirling pattern.");
                Console.WriteLine("The colour changes back and forth as you look at it.");
                potion = 3;
            }else if (ingredients == "154") //potion vitalis: potion of health
            {
                Console.WriteLine("You have created a potion with a striking red colour.");
                Console.WriteLine("Just breathing in its vapours fills you with energy.");
                potion = 4;
            }else if (ingredients == "413") //potion somnus: potion of sleeping
            {
                Console.WriteLine("You have created a potion of pure, smooth, milky white.");
                Console.WriteLine("It is completely uniform in colour, and slightly resembles a cloud.");
                potion = 5;
            }else if (ingredients == "233") //potion amnesia: potion of...amnesia.
            {
                Console.WriteLine("You have created a grey, semi-clear potion resembling liquid smoke.");
                Console.WriteLine("Inside the smoke, you can see vague shapes fading in and out of existence.");
                potion = 6;
            }
            else //did not follow the recipe, created disgusting, useless potion
            {
                Console.WriteLine("You have created a black potion with a sludge-like consistency.");
                Console.WriteLine("Its noxious smell burns away at the inside of your nose.");
                potion = 7;
            }
            Console.WriteLine("You take your new potion from the stand and put it in your inventory.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return (potion);
        }
        
    }
}
