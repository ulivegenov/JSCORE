using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Clinic
{
    public string Name { get; set; }

    private int countOfRooms;

    private Pet[] pets;

    public int CenterRoom => this.pets.Length / 2;

    public Clinic(string name, int countOfRooms)
    {
        this.ValidateRoomCount(countOfRooms);
        this.pets = new Pet[countOfRooms];
        this.Name = name;
        
    }

    private void ValidateRoomCount(int countOfRooms)
    {
        if (countOfRooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        this.countOfRooms = countOfRooms;
    }

    public bool HasEmptyRooms(Clinic clinicToCheck)
    {
        return clinicToCheck.pets.Any(p => p == null);
    }

    public bool Add(Pet petToAdd, Clinic clinicToAdd)
    {
        int currentRoom = this.CenterRoom;

        for (int i = 0; i < this.pets.Length; i++)
        {
            if (i % 2 == 0)
            {
                currentRoom += i;
            }
            else
            {
                currentRoom -= i;
            }
            if (clinicToAdd.pets[currentRoom] == null)
            {
                clinicToAdd.pets[currentRoom] = petToAdd;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            int currentRoom = (this.CenterRoom + i) % this.pets.Length;

            if (this.pets[currentRoom] != null)
            {
                this.pets[currentRoom] = null;
                return true;
            }
        }

        return false;
    }

    public void Print(Clinic clinicToPrint, int numberOfRoom)
    {
        for (int i = 0; i < clinicToPrint.pets.Length; i++)
        {
            if (i == numberOfRoom - 1)
            {
                if (clinicToPrint.pets[i] == null)
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine(clinicToPrint.pets[i]);
                }
            }
        }    
    }

    public void Print(Clinic clinicToPrint)
    {
        for (int i = 0; i < clinicToPrint.pets.Length; i++)
        {
            if (clinicToPrint.pets[i] == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(clinicToPrint.pets[i]);
            }
        }
    }
}

