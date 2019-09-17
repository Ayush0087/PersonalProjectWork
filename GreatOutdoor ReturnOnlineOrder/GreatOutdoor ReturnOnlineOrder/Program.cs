using System;
using System.Collections.Generic;
using System.Text;
using GreatOutdoor.Entity;
using GreatOutdoor.BusinessLayer;
using GreatOutdoor.Exception;

namespace GreatOutdoor.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddOnlineReturn();
                        break;
                    case 2:
                        ListOnlineReturn();
                        break;
                    case 3:
                        GetOnlineReturnByReturnID();
                        break;
                    case 4:
                        UpdateOnlineReturn();
                        break;
                    case 5:
                        DeleteOnlineReturn();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void DeleteOnlineReturn()
        {
            try
            {
                int deleteReturnID;
                Console.WriteLine("Enter ReturnID to Delete:");
                deleteReturnID = Convert.ToInt32(Console.ReadLine());
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
               OnlineReturn deleteOnlineReturn = onlineReturnBL.GetOnlineReturnByReturnIDBL(deleteReturnID);
                if (deleteOnlineReturn != null)
                {
                    bool onlineReturndeleted = OnlineReturnBL.DeleteOnlineReturnBL(deleteReturnID);
                    if (onlineReturndeleted)
                        Console.WriteLine("Online Return Deleted");
                    else
                        Console.WriteLine("Online Return not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Online Details Available");
                }


            }
            catch (OnlineReturnException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateOnlineReturn()
        {
            try
            {
                int updateReturnID;
                Console.WriteLine("Enter ReturnID to Update Details:");
                updateReturnID = Convert.ToInt32(Console.ReadLine());
                OnlineReturnBL onlineReturnBL = new OnlineReturnBL();
                OnlineReturn updatedOnlineReturn = onlineReturnBL.(updateReturnID);
                if (updatedOnlineReturn != null)
                {
                    Console.WriteLine("Update Purpose Of Return :");
                    updatedOnlineReturn.PurposeOfReturn = Console.ReadLine();
                    Console.WriteLine("Update No :");
                    updatedOnlineReturn.NoOfReturn = Console.ReadLine();
                    bool guestUpdated = GuestBL.UpdateGuestBL(updatedGuest);
                    if (guestUpdated)
                        Console.WriteLine("Guest Details Updated");
                    else
                        Console.WriteLine("Guest Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }


            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchGuestByID()
        {
            try
            {
                int searchGuestID;
                Console.WriteLine("Enter GuestID to Search:");
                searchGuestID = Convert.ToInt32(Console.ReadLine());
                Guest searchGuest = GuestBL.SearchGuestBL(searchGuestID);
                if (searchGuest != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("GuestID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchGuest.GuestID, searchGuest.GuestName, searchGuest.GuestContactNumber);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }

            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void ListAllGuests()
        {
            try
            {
                List<Guest> guestList = GuestBL.GetAllGuestsBL();
                if (guestList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("GuestID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    foreach (Guest guest in guestList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", guest.GuestID, guest.GuestName, guest.GuestContactNumber);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Guest Details Available");
                }
            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddOnlineReturn()
        {
            try
            {
                OnlineReturn newOnlineReturn = new OnlineReturn();
                Console.WriteLine("Enter ReturnID :");
                newOnlineReturn.ReturnID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Purpose Of Return :");
                Console.WriteLine("Choose purpose of return");
                Console.WriteLine("EnterA: Unsatisfactory Product ");
                Console.WriteLine("EnterB: Defective product");
                Console.WriteLine("EnterC: Incomplete Product ");
                Console.WriteLine("EnterD: Wrong Product Ordered ");
                Console.WriteLine("EnterF: wrong Product shipped");
                newOnlineReturn.GuestName = Console.ReadLine();
                Console.WriteLine("Enter PhoneNumber :");
                newGuest.GuestContactNumber = Console.ReadLine();
                bool guestAdded = GuestBL.AddGuestBL(newGuest);
                if (guestAdded)
                    Console.WriteLine("Guest Added");
                else
                    Console.WriteLine("Guest not Added");
            }
            catch (GuestPhoneBookException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Guest PhoneBook Menu***********");
            Console.WriteLine("1. Add Guest");
            Console.WriteLine("2. List All Guests");
            Console.WriteLine("3. Search Guest by ID");
            Console.WriteLine("4. Update Guest");
            Console.WriteLine("5. Delete Guest");
            Console.WriteLine("6. Exit");
            Console.WriteLine("******************************************\n");

        }
    }
}
