using System;
using System.Linq;

public class Clinic
{
    public Clinic(string name, int roomsCount)
    {
        if (roomsCount % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        this.Name = name;
        this.Rooms = new Room[roomsCount];

        for (int i = 0; i < roomsCount; i++)
        {
            this.Rooms[i] = new Room();
        }
    }

    public string Name { get; private set; }

    public Room[] Rooms { get; private set; }

    public bool Add(Pet pet)
    {
        if (!this.HasEmptyRooms())
        {
            return false;
        }

        int firstAddIndex = (this.Rooms.Length / 2);

        int steps = 1;
        int addIndex = firstAddIndex;

        for (int i = 0; i < this.Rooms.Length; i++)
        {
            if (this.Rooms[addIndex].Pet == null)
            {
                this.Rooms[addIndex].Pet = pet;
                return true;
            }

            if (addIndex >= firstAddIndex)
            {
                addIndex = firstAddIndex - steps;
            }
            else
            {
                addIndex = firstAddIndex + steps;
                steps++;
            }
        }

        return false;
    }

    public bool Release()
    {
        int firstReleaseIndex = (this.Rooms.Length / 2);

        for (int i = firstReleaseIndex; i < this.Rooms.Length; i++)
        {
            if (this.Rooms[i].Pet != null)
            {
                this.Rooms[i].Pet = null;
                return true;
            }
        }

        for (int i = 0; i < firstReleaseIndex; i++)
        {
            if (this.Rooms[i].Pet != null)
            {
                this.Rooms[i].Pet = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.Rooms.Any(r => r.Pet == null);
    }

    public void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine, this.Rooms.ToList()));
    }

    public void Print(int roomNum)
    {
        Console.WriteLine(this.Rooms[roomNum - 1]);
    }
}