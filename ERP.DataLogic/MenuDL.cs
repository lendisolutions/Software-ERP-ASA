using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.BusinessEntity;
using System.Collections.Generic;

namespace ERP.DataLogic
{
    public class MenuDL
    {
        public MenuDL() { }

        public List<MenuBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnERPBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Menu_SeleccionaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MenuBE> menulist = new List<MenuBE>();
            MenuBE menu;
            while (reader.Read())
            {
                menu = new MenuBE();
                menu.IdMenu = Int32.Parse(reader["IdMenu"].ToString());
                menu.MenuCode = reader["MenuCode"].ToString();
                menu.IdMenuFather = Int32.Parse(reader["IdMenuFather"].ToString());
                menu.MenuDescription = reader["MenuDescription"].ToString();
                menu.Picture = reader["Picture"].ToString();
                menu.LargePicture = Boolean.Parse(reader["LargePicture"].ToString());
                menu.Class = reader["Class"].ToString();
                menu.Assembly = reader["Assembly"].ToString();
                menu.IdTypeMenu = Int32.Parse(reader["IdTypeMenu"].ToString());
                menu.WindowLoadMode = reader["WindowLoadMode"].ToString();
                menu.FlagState = Boolean.Parse(reader["FlagState"].ToString());
                menulist.Add(menu);
            }
            reader.Close();
            reader.Dispose();
            return menulist;
        }
    }
}
