using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    // Квитанция, Накладная, Документ, Чек, Дата, Организация.
    //Собрать Бухгалтерию.
    //Найти суммарную стоимость продукции заданного наименования по всем накладным, количество чеков. Вывести две документы за указанный период времени.

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Анна", "Витушко");
            Client client2 = new Client("Яна", "Жогло");

            Waybill waybill = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Белспецэнерго"), 7800);
            Receipt receipt = new Receipt("Квитанция об оплате", new DateTime(2020, 05, 12), client, new Organization("Белспецэнерго"), 49);
            Check check = new Check("Чек", new DateTime(2020, 10, 15), client, new Organization("Белспецэнерго"), 5);

            Waybill waybill6 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client2, new Organization("Белспецэнерго"), 7800);
            Receipt receipt2 = new Receipt("Квитанция об оплате", new DateTime(2020, 05, 12), client2, new Organization("Белспецэнерго"), 49);
            Check check2 = new Check("Чек", new DateTime(2020, 10, 15), client2, new Organization("Белспецэнерго"), 5);

            Waybill waybill2 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Белспецэнерго"), 7800);
            Waybill waybill3 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client2, new Organization("Бедспецэнерго"), 7800);
            Waybill waybill4 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Белспецэнерго"), 7800);
            Waybill waybill5 = new Waybill("Накладная на машину", new DateTime(2012, 05, 12), client, new Organization("Белспецэнерго"), 7800);


            Bookkeeping bkkeeping = new Bookkeeping();
            BookkeepingController controll = new BookkeepingController();
            bkkeeping.AddReceipt(receipt);
            bkkeeping.AddWaybill(waybill);
            bkkeeping.AddCheck(check);

            bkkeeping.AddReceipt(receipt2);
            bkkeeping.AddWaybill(waybill6);
            bkkeeping.AddCheck(check2);


            bkkeeping.AddWaybill(waybill2);
            bkkeeping.AddWaybill(waybill3);
            bkkeeping.AddWaybill(waybill4);
            bkkeeping.AddWaybill(waybill5);

            bkkeeping.ShowList();
            Console.WriteLine();

            Console.WriteLine("Суммарную стоимость продукции заданного наименования по всем накладным = {0}", bkkeeping.GetWaybillPrice("Накладная на машину"));
            Console.WriteLine();

            bkkeeping.GetDocuments(new DateTime(2020, 01, 01), new DateTime(2021, 01, 01));
            Console.WriteLine();
            Console.WriteLine("Количество чеков: {0}", controll.Count(bkkeeping));

            Console.ReadKey();
        }
    }
}





/*
______________________________________________________________________________________________________________________________________________________________________
enum DayTime
{
    Morning=5,
    Afternoon,
    Evening,
    Night
}
_________________________________________________________________________________________________________________________________________________________________________

 abstract class Person
{
    public string Name { get; set; }
 
    public Person(string name)
    {
        Name = name;
    }
 
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
 
class Client : Person
{
    public int Sum { get; set; }    // сумма на счету
 
    public Client(string name, int sum)
        : base(name)
    {
        Sum = sum;
    }
}
 
class Employee : Person
{
    public string Position { get; set; } // должность
 
    public Employee(string name, string position) 
        : base(name)
    {
            Position = position;
    }
}

__________________________________________________________________________________________________________________________________________________________

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Display()
    {
        Console.WriteLine(Name);
    }
}

class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
    }

    public override void Display()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}
*/