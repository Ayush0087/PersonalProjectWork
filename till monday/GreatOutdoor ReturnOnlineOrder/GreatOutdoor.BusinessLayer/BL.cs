﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoor.Entity;
using GreatOutdoor.DataAccessLayer;

namespace GreatOutdoor.BusinessLayer
{
   
    public class OnlineReturnBL
    {
        private static bool ValidateOnlineReturnBL(OnlineReturn onlineReturn)
        {
            StringBuilder sb = new StringBuilder();
            bool validOnlineReturnBL = true;
            if (onlineReturn.ReturnID <= 0)
            {
                validOnlineReturnBL = false;
                sb.Append(Environment.NewLine + "Invalid Online Return ID");

            }
            if (onlineReturn.PurposeofReturn == string.Empty)
            {
                validOnlineReturnBL = false;
                sb.Append(Environment.NewLine + "Invalid Purpose of Return");

            }
            if (onlineReturn.DateOfReturn.AddDays(10) < DateTime.Now)
            {
                validOnlineReturnBL = false;
                sb.Append(Environment.NewLine + "Return Date Over");
            }
            if (validOnlineReturnBL == false)
                throw new Exception(sb.ToString());
            return validOnlineReturnBL;
        }

        public static bool AddOnlineReturnBL(OnlineReturn newOnlineReturn)
        {
            bool onlineReturnAdded = false;
            try
            {
                if (ValidateOnlineReturnBL(newOnlineReturn))
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnAdded = onlineReturnDAL.AddOnlineReturnDAL(newOnlineReturn);
                }
            }
            catch (GreatOutdoorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return onlineReturnAdded;
        }

        public static List<OnlineReturnBL> GetAllGuestsBL()
        {
            List<OnlineReturnBL> onlineReturnList = null;
            try
            {
                OnlineReturnDAL onlineReturn = new OnlineReturnDAL();
                onlineReturnList = OnlineReturnDAL.GetAllReturnOnlineOrderDAL();
            }
            catch (GreatOutdoorException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return onlineReturnList;
        }

        public static OnlineReturnBL SearchOnlineReturn(int searchReturnID)
        {
            OnlineReturnBL searchOnlineReturn = null;
            try
            {
                OnlineReturnDAL onlineReturn = new OnlineReturnDAL();
                searchOnlineReturn = OnlineReturnDAL.SearchOnlineReturnDAL(searchReturnID);
            }
            catch (GreatOutdoorException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchOnlineReturn;

        }

        public static bool UpdateOnlineReturnBL(OnlineReturnBL updateonlineReturn)
        {
            bool onlineReturnUpdated = false;
            try
            {
                if (ValidateOnlineReturn(updateOnlineReturn))
                {
                    OnlineReturnDAL onlineReturn = new OnlineReturnDAL();
                    onlineReturnUpdated = OnlineReturnDAL.UpdateOnlineReturnDAL(updateonlineReturn);
                }
            }
            catch (GreatOutdoorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return onlineReturnUpdated;
        }

        public static bool DeleteOnlineReturnBL(int deleteReturnID)
        {
            bool onlineReturnDeleted = false;
            try
            {
                if (deleteReturnID > 0)
                {
                    OnlineReturnDAL onlineReturn = new OnlineReturnDAL();
                    onlineReturnDeleted = OnlineReturnDAL.DeleteReturnOnlineOrderDAL(deleteReturnID);
                }
                else
                {
                    throw new GreatOutdoorException("Invalid ReturnOnlineOrder ID");
                }
            }
            catch (GreatOutdoorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return onlineReturnDeleted;
        }
       
    }
}
