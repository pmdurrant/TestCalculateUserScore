// ***********************************************************************
// Assembly         : ConsoleApp1
// Author           : pdurr
// Created          : 01-30-2023
//
// Last Modified By : pdurr
// Last Modified On : 01-30-2023
// ***********************************************************************
// <copyright file="Program.cs" company="ConsoleApp1">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ConsoleApp1;


//Read names from file

var items = System.IO.File.ReadAllText(@"names.csv");

List<Person> persons = new List<Person>();

var tt = items.Split(',');



// Sort list 

var sortedlist = tt.OrderBy(X => X);

//remove unnecessary linefeeds 
foreach (var item in sortedlist)
{
    persons.Add(new Person() { PersonName = (item.Trim().ToLower().Replace("\r\n", string.Empty)).ToUpperInvariant() });
}



#region Calculate Score for each Person
Person newp = new Person();
List<Person> list = new List<Person>();


foreach (Person item in persons)

{

    int index = Array.IndexOf(sortedlist.ToArray(), item.PersonName.ToLower());

    Int16 intscore = 0;

    foreach (var itemchr in item.PersonName)
    {
        var charpos = Convert.ToInt16(itemchr - 64);
        intscore += charpos;
    }


    // store values to properties
    if (index != 0)
    {
        newp.Score = intscore * index;
    }
    else { newp.Score = intscore; }

    newp.PersonName = item.PersonName;
    newp.IndexPosition = index;
    newp.InternalCharscore = intscore;

    // add to collection
    list.Add(newp);

    // create new blank item
    newp = new Person();
}
#endregion
#region Select 2 items from list


// Should Output "Person:COLIN InternalCharScore:53 FileIndexPositon:772 Score:40916 " 
var findSelectedItem = list.Find(c => c.PersonName == "COLIN");

if (findSelectedItem != null)
{
    string Outputdata = string.Format("Person:{0} InternalCharScore:{1} FileIndexPositon:{3} Score:{2} ", findSelectedItem.PersonName, findSelectedItem.InternalCharscore, findSelectedItem.Score, findSelectedItem.IndexPosition);
    Console.WriteLine(Outputdata);

}



// Should Output Person:ADAMN InternalCharScore:33  FileIndexPositon:17 Score:561
findSelectedItem = list.Find(c => c.PersonName == "ADAMN");

if (findSelectedItem != null)
{
    string Outputdata = string.Format("Person:{0} InternalCharScore:{1}  FileIndexPositon:{3} Score:{2}", findSelectedItem.PersonName, findSelectedItem.InternalCharscore, findSelectedItem.Score, findSelectedItem.IndexPosition);

    Console.WriteLine(Outputdata);
}
#endregion


var totalScore = list.Sum<Person>(c => c.Score);

Console.WriteLine(string.Format("totalScore:{0}",totalScore));
