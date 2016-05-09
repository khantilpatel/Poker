using Poker.Entity;
using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests
{
    class PokerSimulatorTest
    {
       

        static void Main()
        {
                       
            IPokerHandService pokerHandService = new PokerHandService();
            PokerService service = new PokerService(pokerHandService);

            Console.WriteLine("## Welcome to the Ultimate Poker Arena ##");

            Console.WriteLine("Enter your name:");

            string playerName = Console.ReadLine();
            while (true) // Loop indefinitely
            {
                try
                {
                    Console.WriteLine("**************** New Round ****************:");
                    Deck deck = new Deck();
                    deck.shuffle();
                  
                    List<Player> players = new List<Player>(4);

                    players.Add(new Player(playerName, PokerSimulatorTest.getRandHand(deck)));
                    players.Add(new Player("Bob", PokerSimulatorTest.getRandHand(deck)));
                    players.Add(new Player("Andrew", PokerSimulatorTest.getRandHand(deck)));
                    //  players.Add(new Player("Stam", PokerSimulatorTest.getRandHand(deck)));
                    //  players.Add(new Player("Joe", PokerSimulatorTest.getRandHand(deck)));

                    // Print the dealt cards

                    foreach (Player player in players)
                    {
                        Console.WriteLine(player.Name + ":: " + player.Hand.ToString() + "\n");

                    }

                    // The Library Function to call for evaluating the hand
                    List<Player> result = service.evaluateHands(players);

                    // Print the result
                    Console.WriteLine("** Player(s) Winning the round **");

                    StringBuilder builder = new StringBuilder();

                    foreach (Player player in result)
                    {
                        builder.Append(player.Name).Append(" won with ").Append(player.Hand.PokerHandScore.Type).Append(" ");

                    }

                    Console.WriteLine(builder.ToString() + "\n");                        

                    // Keep the console window open in debug mode.
                    //Console.WriteLine("Press any key to exit.");
                    //Console.ReadKey();                

                    Console.WriteLine("Press Enter key to continue or type exit");
                    string line = Console.ReadLine(); // Get string from user
                    if (line == "exit") // Check string
                    {
                        break;
                    }
                }
                catch (PokerGenericException e)
                {
                    Console.WriteLine("PokerException: {0}", e.Message);
                }
            }
        }

        static Hand getRandHand(Deck deck)
        {

            return new Hand(new List<Card>()
            {              
                deck.dealCard(),
                deck.dealCard(),
                deck.dealCard(),
                deck.dealCard(),
                deck.dealCard()
            });   
        
        }


    }
}
