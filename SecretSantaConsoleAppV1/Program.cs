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
            //SecretSanta secretSanta;
            int nameCounter = 0;
            string secretSantaName;
            //List<SecretSanta> listOfSecretSantas = new List<SecretSanta>();
            Dictionary<string, int> secretSantaFamilyGroup = new Dictionary<string, int>();
            List<string> nameSlips = new List<string>();
            List<string> secretSantaMatchup = new List<string>();
            Random randomNumber = new Random();
            //int numChosen;
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
                //secretSanta = new SecretSanta();
                Console.Write($"Secret Santa #{nameCounter}: ");
                secretSantaName = Console.ReadLine();

                //Add names to lists, or end entry
                if (secretSantaName.ToLower() != "end")
                {
                    //secretSanta.Name = nameEntry;
                    //listOfSecretSantas.Add(secretSanta);
                    secretSantaFamilyGroup.Add(secretSantaName, 1);
                    nameSlips.Add(secretSantaName);
                }
                else
                {
                    break;
                }
            } while (secretSantaName.ToLower() != "end");

            //
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
                        //Console.WriteLine($"{secretSanta.Key} has {secretSantaMatchup[secretSantaIndex]}");
                        //Console.WriteLine($"{secretSanta.Key} has {randomName}");
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
                            //Console.WriteLine($"{secretSanta.Key} has {nameSlips[0]}");
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

            //for (int i = 0; i < listOfSecretSantas.Count; i++)
            //{
            //    if (i < listOfSecretSantas.Count - 1)
            //    {
            //        Console.Write(listOfSecretSantas[i].Name + ", ");
            //    }
            //    else
            //    {
            //        Console.WriteLine(listOfSecretSantas[i].Name + "");
            //    }
            //}

            //for (int i = 0; i < listOfSecretSantas.Count; i++)
            //{
            //    int numberTries = 0;
            //    do
            //    {
            //        numChosen = randomNumber.Next(0, listOfSecretSantas.Count);
            //        randomName = listOfSecretSantas[numChosen].Name;
            //        Console.WriteLine(randomName);
            //        numberTries++;
            //    } while ((randomName == listOfSecretSantas[i].Name || listOfSecretSantas[numChosen].WasChosen) && numberTries < 10);

            //    if(numberTries < 10)
            //    {
            //        listOfSecretSantas[i].BuyingFor = randomName;
            //        listOfSecretSantas[numChosen].WasChosen = true;
            //    }

            //    Console.WriteLine(listOfSecretSantas[i].Name + " has " + listOfSecretSantas[i].BuyingFor);
            //}

        }
    }

    //internal class SecretSanta
    //{
    //    internal SecretSanta()
    //    {
    //        this.Name = "";
    //        this.GroupNum = 0;
    //        this.WasChosen = false;
    //        this.BuyingFor = "";
    //    }

    //    internal string Name { get; set; }
    //    internal int GroupNum { get; set; }
    //    internal bool WasChosen { get; set; }
    //    internal string BuyingFor { get; set; }

    //}
}
