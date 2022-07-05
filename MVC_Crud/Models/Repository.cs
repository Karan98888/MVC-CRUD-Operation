using System;
using System.Collections.Generic;

namespace MVC_Crud.Models
{
    public static class Repository
    {
        private static List<Customers> allCustomers = new List<Customers>();
        public static List<Customers> AllCustomers
        {
            get { return allCustomers; }
        }

        public static void Create(Customers customers)
        {
            allCustomers.Add(customers);
        }

        public static void Delete(int custId)
        {
            if(custId > 0)
            {
                foreach (var item in allCustomers)
                {
                    if(item.custId == custId)
                    {
                        allCustomers.Remove(item);
                        break;
                    }
                }
            }
        }

        // public static void Update(Customers customers)
        // {
        //     if(customers.custId > 0)
        //     {
        //         foreach (var item in allCustomers)
        //         {
        //             if(item.custId == custId)
        //             {
        //                 allCustomers.Remove(item);
        //                 break;
        //             }
        //         }
        //     }
        // }


    }
}
