using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaConsoleAppV1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize variables
            int nameCounter = 0;
            string secretSantaName;
            Dictionary<string, int> secretSantaFamilyGroup = new Dictionary<string, int>();
            List<string> nameSlips = new List<string>();
            List<string> secretSantaMatchup = new List<string>();
            Random randomNumber = new Random();
            int randomNum;
            string randomName;
            bool repeatNameDraw;
            int secretSantaIndex;

            //User instructions
            Console.WriteLine();
            Console.WriteLine("Enter name of Secret Santa participant or 'end' when finished entering names");

            //Enter names
            do
            {
                nameCounter++;
                Console.Write($"Secret Santa #{nameCounter}: ");
                secretSantaName = Console.ReadLine();

                //Add names to lists, or end entry
                if (secretSantaName.ToLower() != "end")
                {
                    secretSantaFamilyGroup.Add(secretSantaName, 1);
                    nameSlips.Add(secretSantaName);
                }
                else
                {
                    break;
                }
            } while (secretSantaName.ToLower() != "end");

            do
            {
                repeatNameDraw = false;
                secretSantaIndex = 0;
                foreach (var secretSanta in secretSantaFamilyGroup)
                {
                    //draw names until 1 name is left
                    if (secretSantaIndex < secretSantaFamilyGroup.Count - 1)
                    {
                        do
                        {
                            randomNum = randomNumber.Next(0, nameSlips.Count);
                            randomName = nameSlips[randomNum];
                        } while (secretSanta.Key == randomName);
                        secretSantaMatchup.Add(randomName);
                        nameSlips.Remove(randomName);
                        secretSantaIndex++;
                    }
                    //check last slip to make sure it doesn't match secret santa
                    else
                    {
                        if (secretSanta.Key == nameSlips[0])
                        {
                            repeatNameDraw = true;
                            secretSantaIndex = 0;
                            nameSlips.Clear();
                            secretSantaMatchup.Clear();
                            foreach (var name in secretSantaFamilyGroup)
                            {
                                nameSlips.Add(name.Key);
                            }
                        }
                        else
                        {
                            secretSantaMatchup.Add(nameSlips[0]);
                        }
                    }
                }
            } while (repeatNameDraw);

            //Print all secret santas and assignments to console
            secretSantaIndex = 0;
            foreach (var secretSanta in secretSantaFamilyGroup)
            {
                Console.WriteLine($"{secretSanta.Key} has {secretSantaMatchup[secretSantaIndex]}");
                secretSantaIndex++;
            }
        }
    }
}
