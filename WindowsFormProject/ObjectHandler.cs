using DairyDelightsLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DairyDelightsLibrary.DL.FileHandling;
using DairyDelightsLibrary.DL.DataBase;


namespace WindowsFormProject
{
    public class ObjectHandler
    {
        static string Connection = "Data Source=MALIK;Initial Catalog=Final_Project;Integrated Security=True;";
        static string PathUserFile = @"E:\University\semester 2\OOP\Bussiness App\Final App\ConsoleAppProject\ConsoleAppProject\bin\UserDetails.txt";
        public static IUser GetUserInstance()
        {
            IUser user = UserDL.GetInstance(Connection);
            //IUser user = UserDL.GetInstance(PathUserFile);
            return user;
        }
        public static IWorker GetWorkerInstance()
        {
            IWorker worker = WorkerDL.GetInstance(Connection);
            return worker;
        }
        public static iDeliveryBoy GetDeliveryBoyInstance()
        {
            iDeliveryBoy boy = DeliveryBoyDL.GetInstance(Connection);
            return boy;
        }
        public static IProduct GetProductInstance()
        {
            IProduct product = ProductDL.GetInstance(Connection);
            return product;
        }
        public static ICustomer GetCustomerInstance()
        {
            ICustomer customer = CustomerDL.GetInstance(Connection);
            return customer;
        }
        public static ICart GetCartInstance()
        {
            ICart cart = CartDL.GetInstance(Connection);
            return cart;
        }
        public static IOrder GetOrderInstance()
        {
            IOrder order = OrderDL.GetInstance(Connection);
            return order;
        }
    }
}
