using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoor.Entity;
using GreatOutdoor.DataAccessLayer;
using GreatOutdoor.Exception;
using System.Text.RegularExpressions;


namespace GreatOutdoor.BusinessLayer
{
   
    public class OnlineReturnBL
    {
        //validate OnlineReturn before Adding and updating
        private bool ValidateOnlineReturnBL(OnlineReturn onlineReturn)
        {
            //create String Builder
            StringBuilder sb = new StringBuilder();
            bool validOnlineReturnBL = true;


            if (onlineReturn.ReturnID <= 0)
            {
                validOnlineReturnBL = false;
                sb.Append(Environment.NewLine + "Invalid Online Return ID");

            }

            Regex regex1 = new Regex("^[A-Fa-f. ]*$");
            bool b = regex1.IsMatch(onlineReturn.PurposeOfReturn);
            if (onlineReturn.PurposeOfReturn == string.Empty)
            {
                validOnlineReturnBL = false;
                sb.Append(Environment.NewLine + "Invalid Purpose of Return");

            }
            if (onlineReturn.DateOfReturn.AddDays(10) < DateTime.Now)
            {
                validOnlineReturnBL = false;
                sb.Append(Environment.NewLine + "Online Return Valid Only for 10 Days from Order");
            }
            if (validOnlineReturnBL == false)
                throw new OnlineReturnException(sb.ToString());
            return validOnlineReturnBL;
        }


        //Adding OnlineReturn To List
        public  bool AddOnlineReturnBL(OnlineReturn newOnlineReturn)
        {
            bool onlineReturnAdded = false;
            try
            {
                if (ValidateOnlineReturnBL(newOnlineReturn)) //Validating OnlineReturn
                {
                    OnlineReturnDALAbstract onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnAdded = onlineReturnDAL.AddOnlineReturnDAL(newOnlineReturn); //Adding Data To List
                }
            }
            catch (System.Exception ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
           

            return onlineReturnAdded;
        }

        //searching OnlineReturn By ReturnID
        public OnlineReturn GetOnlineReturnByReturnIDBL(int searchReturnID)
        {
            OnlineReturn searchOnlineReturnBL = null;
            try
            {
                OnlineReturnDALAbstract onlineReturnDAL = new OnlineReturnDAL();
                searchOnlineReturnBL = onlineReturnDAL.GetOnlineReturnByReturnIDDAL(searchReturnID);
            }
            catch (System.Exception ex)
            {

                throw new OnlineReturnException(ex.Message);
            }
            return searchOnlineReturnBL;
        }


        //public static List<OnlineReturnBL> GetAllOnlineReturnBL(int ReturnID)
        //{
        //    List<OnlineReturnBL> onlineReturnList = null;
        //    try
        //    {
        //        OnlineReturnDAL onlineReturn = new OnlineReturnDAL();
        //        onlineReturnList = OnlineReturnDAL.GetAllReturnOnlineOrderDAL(ReturnID);
        //    }
        //    catch (GreatOutdoorException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return onlineReturnList;
        //}

        //public List<OnlineReturn> GetOnlineReturnByRPurposeOfReturnBL(string searchPurposeOfReturn)
        //{
        //    OnlineReturnBL GetPurposeOfReturn = null;
        //    try
        //    {
        //        OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
        //        GetPurposeOfReturn = onlineReturnDAL.GetOnlineReturnByRPurposeOfReturnDAL(searchPurposeOfReturn);
        //    }
           
        //    catch (System.Exception ex)
        //    {
        //        throw new OnlineReturnException (ex.Message);
        //    }
        //    return GetPurposeOfReturn;

        //}

        public bool UpdateOnlineReturnBL(OnlineReturn updateonlineReturn)
        {
            bool onlineReturnUpdated = false;
            try
            {
                if (ValidateOnlineReturnBL(updateonlineReturn))
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnUpdated = onlineReturnDAL.UpdateOnlineReturnDetailDAL(updateonlineReturn);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
           

            return onlineReturnUpdated;
        }

        public static bool DeleteOnlineReturnBL(int deleteReturnID)
        {
            bool onlineReturnDeletedBL = false;
            try
            {
                if (deleteReturnID > 0)
                {
                    OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                    onlineReturnDeletedBL = onlineReturnDAL.DeleteOnlineReturnDAL(deleteReturnID);
                }
                else
                {
                    throw new OnlineReturnException("Invalid Return ID");
                }
            }
            catch (OnlineReturnException)
            {
                throw;
            }
           

            return onlineReturnDeletedBL;
        }
        //Serialize
        public void Serialize()
        {
            try
            {
                OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                onlineReturnDAL.Serialize();
            }
            catch(System.Exception ex)
            {
                throw new OnlineReturnException(ex.Message);
            }
        }
        //Deserialize
        public void Deserialize()
        {
            try
            {
                OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
                onlineReturnDAL.Deserialize();
            }
            catch (System.Exception)
            {

                throw;
            }
        }



    }

    


}
