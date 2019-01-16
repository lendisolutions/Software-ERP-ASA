using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion
{
    public class Ribbon
    {
        //DataTable _data;

        List<LoginAccessBE> _objList = new List<LoginAccessBE>();
        RibbonControl _objRibbon;

        public delegate void delegateRibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase);
        public event delegateRibbonClick RibbonClick;

        public Ribbon(RibbonControl objRibbon, List<LoginAccessBE> menu)
        {
            _objList = menu;
            _objRibbon = objRibbon;
        }

        public void Fill()
        {
            //Obtenemos un DataView filtrando todos o que tengan el tipo Tab
            //entonces el campo MenuTipoID debe ser igual a 1
            //DataView dvHijos = new DataView(_data);
            //dvHijos.RowFilter = "MenuTipoID=1";
            var ListHijos =
                from p in _objList
                where p.IdTypeMenu == 1
                select p;

            foreach (var Hijos in ListHijos)
            {
                RibbonPage rbTab = new RibbonPage();

                // Creamos el Tab
                rbTab.Text = Hijos.MenuDescription.ToString().Trim();
                _objRibbon.Pages.Add(rbTab);
                //DataView dvGroups = new DataView(_data);
                //dvGroups.RowFilter = "MenuPadreID=" + drvHijos["MenuID"].ToString().Trim();
                var ListGrupos =
                    from g in _objList
                    where g.IdMenuFather == Hijos.IdMenu
                    select g;
                ListGrupos = ListGrupos.OrderBy(o => o.MenuCode);
                foreach (var Grupos in ListGrupos)
                {
                    RibbonPageGroup rbGroup = new RibbonPageGroup();
                    // Creamos el Grupo
                    rbGroup.Text = Grupos.MenuDescription.ToString().Trim();
                    rbTab.Groups.Add(rbGroup);
                    // Busquemos sus botones para agregar
                    //DataView dvItems = new DataView(_data);
                    //dvItems.RowFilter = "MenuPadreID=" + drvGroupItem["MenuID"].ToString().Trim();
                    var ListButtons =
                        from b in _objList
                        where b.IdMenuFather == Grupos.IdMenu
                        select b;
                    ListButtons = ListButtons.OrderBy(o => o.MenuCode);
                    foreach (var Item in ListButtons)
                    {
                        if (Item.IdTypeMenu == 2)
                        {
                            // Creamos el Boton
                            BarButtonItem rbutton;
                            rbutton = new BarButtonItem();
                            rbutton.Caption = Item.MenuDescription.ToString().Trim();
                            rbutton.Name = Item.MenuCode.ToString().Trim() + ";" + Item.Assembly.ToString().Trim()+ ";" + Item.Class.ToString().Trim();

                            // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                            // ResourceImage de la base de datos    
                            if (Item.Picture.ToString().Trim() != "")
                            {
                                if (Item.LargePicture == true)
                                {
                                    rbutton.LargeGlyph = (Image)ERP.Presentacion.Properties.Resources.ResourceManager.GetObject(Item.Picture.ToString().Trim());
                                    //rbutton.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
                                }
                                else
                                    rbutton.Glyph = (Image)ERP.Presentacion.Properties.Resources.ResourceManager.GetObject(Item.Picture.ToString().Trim());
                            }
                            rbutton.Tag = Item.WindowLoadMode.ToString().Trim();
                            rbGroup.ItemLinks.Add(rbutton);
                            // Asignamos el evento para saber cuando pulsamos el boton
                            rbutton.ItemClick += new ItemClickEventHandler(rbutton_Click);
                        }
                        else if (Item.IdTypeMenu == 5)
                        {
                            // Creamos el Boton
                            BarSubItem rSubButton;
                            rSubButton = new BarSubItem();
                            rSubButton.Caption = Item.MenuDescription.ToString().Trim();
                            rSubButton.Name = Item.MenuCode.ToString().Trim() + ";" + Item.Assembly.ToString().Trim() + ";" + Item.Class.ToString().Trim();

                            // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                            // ResourceImage de la base de datos    
                            if (Item.Picture.ToString().Trim() != "")
                            {
                                if (Item.LargePicture == true)
                                {
                                    rSubButton.LargeGlyph = (Image)ERP.Presentacion.Properties.Resources.ResourceManager.GetObject(Item.Picture.ToString().Trim());
                                    //rbutton.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
                                }
                                else
                                    rSubButton.Glyph = (Image)ERP.Presentacion.Properties.Resources.ResourceManager.GetObject(Item.Picture.ToString().Trim());
                            }
                            rSubButton.Tag = Item.WindowLoadMode.ToString().Trim();
                            rbGroup.ItemLinks.Add(rSubButton);
                            // Asignamos el evento para saber cuando pulsamos el boton
                            //rSubButton.ItemClick += new ItemClickEventHandler(rbutton_Click);

                            //Verificamos si tiene sub elementos
                            var ListSubButtons =
                            from sb in _objList
                            where sb.IdMenuFather == Item.IdMenu
                            select sb;
                            ListSubButtons = ListSubButtons.OrderBy(o => o.MenuCode);
                            foreach (var SubItem in ListSubButtons)
                            {
                                if (SubItem.IdTypeMenu == 6)
                                {
                                    // Creamos el Boton
                                    BarButtonItem rSubButtonItem;
                                    rSubButtonItem = new BarButtonItem();
                                    rSubButtonItem.Caption = SubItem.MenuDescription.ToString().Trim();
                                    rSubButtonItem.Name = SubItem.MenuCode.ToString().Trim() + ";" + SubItem.Assembly.ToString().Trim() + ";" + SubItem.Class.ToString().Trim();

                                    // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                                    // ResourceImage de la base de datos    
                                    if (SubItem.Picture.ToString().Trim() != "")
                                        rSubButtonItem.Glyph = (Image)ERP.Presentacion.Properties.Resources.ResourceManager.GetObject(SubItem.Picture.ToString().Trim());
                                    rSubButtonItem.Tag = SubItem.WindowLoadMode.ToString().Trim();
                                    rSubButton.ItemLinks.Add(rSubButtonItem);
                                    // Asignamos el evento para saber cuando pulsamos el boton
                                    rSubButtonItem.ItemClick += new ItemClickEventHandler(rbutton_Click);
                                }
                            }

                        }
                    }

                }
            }
        }

        void rbutton_Click(object sender, ItemClickEventArgs e)
        {
            //Verificamos que se aya llamado al evento para luego invocarlo
            if (RibbonClick != null)
            {
                string[] _info = e.Item.Name.ToString().Split(';');
                RibbonClick(_info[0], _info[1], e.Item.Tag.ToString(), e.Item.Caption, _info[2]);
            }
        
        }
    }
}
