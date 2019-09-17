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

            Regex regex1 = new Regex("^[A-zZ-a ]*$");
            bool b = regex1.IsMatch(onlineReturn.PurposeOfReturn);
            //if (b == true)
            //{
            //    int a = int.Parse(onlineReturn.PurposeOfReturn);
            //    if (a == 1)
            //    {
            //        onlineReturn.PurposeOfReturn = "Unsatisfactory Product";
            //    }
            //    else if (a == 2)
            //    {
            //        onlineReturn.PurposeOfReturn = "Defective product";
            //    }
            //    else if (a == 3)
            //    {
            //        onlineReturn.PurposeOfReturn = "Incomplete Product";
            //    }
            //    else if (a == 4)
            //    {
            //        onlineReturn.PurposeOfReturn = "Wrong Product Ordered";
            //    }
            //    else if (a == 5)
            //    {
            //       onlineReturn.PurposeOfReturn = "wrong Product shipped";
            //    }

            //    if (onlineReturn.PurposeOfReturn == string.Empty)
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


        

         public List<OnlineReturn> GetOnlineReturnByRPurposeOfReturnBL(string searchPurposeOfReturn)
         {
              List<OnlineReturn> GetPurposeOfReturn = new List<OnlineReturn>();
              try
              {
              OnlineReturnDAL onlineReturnDAL = new OnlineReturnDAL();
              GetPurposeOfReturn = onlineReturnDAL.GetOnlineReturnByRPurposeOfReturnDAL(searchPurposeOfReturn);
              }

              catch (System.Exception ex)
              {
               throw new OnlineReturnException(ex.Message);
              }
              return GetPurposeOfReturn;

         }

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
