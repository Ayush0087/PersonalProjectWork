using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoor.Entity;
using GreatOutdoor.Exception;

namespace GreatOutdoor.DataAccessLayer
{
    public class OnlineReturnDAL
    {
        public static List<OnlineReturn> onlineReturnList = new List<OnlineReturn>();

        public bool AddOnlineReturnDAL(OnlineReturn newonlineReturn)
            //adding return order
        {
            bool onlineReturnAdded = false;
            try
            {
                onlineReturnList.Add(newonlineReturn);
                onlineReturnAdded = true;
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return onlineReturnAdded;

        }

        public List<OnlineReturn> GetAllOnlineReturnDAL()
        {
            return onlineReturnList;
        }

        public  OnlineReturn SearchOnlineReturnDAL(int searchReturnID)
            //returnonlineorderby returnID
        {
            OnlineReturn searchOnlineReturnDAL = null;
            try
            {
                foreach (OnlineReturn item in onlineReturnList)
                {
                    if (OnlineReturn.ReturnID == searchReturnID)
                    {
                        searchOnlineReturnDAL = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorException(ex.Message);
            }
            return searchOnlineReturnDAL;
        }

        public List<OnlineReturn> GetOnlineReturnByPurposeOfReturnDAL(string onlineReturnPurposeOfReturn)
        {
            List<OnlineReturn> searchOnlineReturnDAL = new List<OnlineReturn>();
            try
            {
                foreach (OnlineReturn item in onlineReturnList)
                {
                    if (item.PurposeofReturn == onlineReturnPurposeOfReturn)
                    {
                       searchOnlineReturnDAL.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return searchOnlineReturnDAL;
        }

        public bool UpdateOnlineReturnDAL(OnlineReturn updateonlineReturn, int retId)
        {
            bool onlineReturnUpdated = false;
            try
            {
                foreach(OnlineReturn item in onlineReturnList)
                {
                    item.ReturnID==retId
                }
               // for (int i = 0; i < onlineReturnList.Count; i++)
               // {
               //     if (OnlineReturnDAL.onlineReturnList.Contains(updateonlineReturn))
               //     {
               //         updateonlineReturn.PurposeofReturn = onlineReturnList[i].PurposeofReturn;
               //         updateonlineReturn.NoOfReturn =onlineReturnList[i].NoOfReturn;
               //         updateonlineReturn.DateOfReturn = onlineReturnList[i].DateOfReturn;
               //         onlineReturnUpdated = true;
               //     }
               // }
            }
            catch (SystemException ex)
            {
                throw new Exception(ex.Message);
            }
            return onlineReturnUpdated;

        }

        public bool DeleteOnlineReturnDAL(int deleteReturnID)
        {
            bool onlineReturnDeleted = false;
            try
            {
                OnlineReturn deleteOnlineReturn = null;
                foreach (OnlineReturn item in onlineReturnList)
                {
                    if (item.ReturnID == deleteReturnID)
                    {
                        deleteOnlineReturn = item;
                    }
                }

                if (deleteOnlineReturn != null)
                {
                    onlineReturnList.Remove(deleteOnlineReturn);
                    onlineReturnDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return onlineReturnDeleted;

        }

    }
}
