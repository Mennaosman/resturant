namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welecome to Reservation Feature ");
            Console.WriteLine("This All Tables In Our Restaurant");
            DiningTable diningtable = new DiningTable();
            
            diningtable.ShowTables();

            Console.WriteLine("please enter your Name");

            string ReservantName = (Console.ReadLine());
            Console.WriteLine("please enter your Phone ");
            string ReservantPhone = (Console.ReadLine());
            Console.WriteLine("please enter TableNo");
            int ReservantTableno = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter Reserve Number");
            int ReserveTime = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter Reserve Date");
            int ReserveDate = int.Parse(Console.ReadLine());

            Reservations reservant = new Reservations(ReservantName, ReservantPhone, ReservantTableno);
            reservant.CheckReservation(ReservantTableno, ReserveTime, ReserveDate);
            reservant.AddToReservation();

            reservant.SaveReservationToJson(@"C:\Users\Mega Store\Source\Repos\Restaurant-C-Projectg\Reservations.json");

           // Customer.ShowNotification("Reservation");
        }
    }
}
