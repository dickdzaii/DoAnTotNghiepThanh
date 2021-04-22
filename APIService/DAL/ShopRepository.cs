using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
  public partial  class ShopRepository
    {
        private IDatabaseHelper _dbHelper;
        public ShopRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<ShopModel> GetShop()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getShop");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ShopModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
