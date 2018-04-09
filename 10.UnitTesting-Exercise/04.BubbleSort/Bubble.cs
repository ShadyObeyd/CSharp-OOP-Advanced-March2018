using System;

public class Bubble
{
    private int[] arr;

    public Bubble(params int[] parameters)
    {
        this.arr = parameters ?? throw new ArgumentException("Input cannot be null!");
    }

    public int[] SortArr()
    {
        if (this.arr.Length == 0)
        {
            throw new InvalidOperationException("Cannot sort an empty collection!");
        }

        bool isSwapped;

        do
        {
            isSwapped = false;

            for (int i = 0; i < this.arr.Length - 1; i++)
            {
                if (this.arr[i] > arr[i + 1])
                {
                    int temp = this.arr[i];
                    this.arr[i] = this.arr[i + 1];
                    this.arr[i + 1] = temp;
                    isSwapped = true;
                }
            }
        } while (isSwapped);

        return this.arr;
    }

}