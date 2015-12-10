using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BL_T1
/// </summary>
public class BL_T1
{
    public BL_T1()
    {
    }

    public void Check(String text)
    {
        if(text == null)
        {
            return;
        }

        char[] tempLine = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            char temp = text.ElementAt(i);

            if (Char.IsLetter(temp))
            {
                tempLine[i] = temp;
            }
        }

        string newLine = tempLine.ToString();
    }
}