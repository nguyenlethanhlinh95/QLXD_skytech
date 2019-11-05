using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PhanMemQuanLyCongTrinh.BUS;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh
{
    public partial class frm_NewOutCouponToConstructions : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        BUS.storehouseBus storehouse = new storehouseBus();
        BUS.constructionBus construction = new constructionBus();
        public frm_NewOutCouponToConstructions()
        {
            InitializeComponent();
        }
        supliesBus _sup = new supliesBus();
        storehouseDetailBus storehouseDetail = new storehouseDetailBus();
        private Int64 idSupplies = 0;

        List<Add_Supplies_And_Quantity> listObject = new List<Add_Supplies_And_Quantity>();
        List<Int64> ListID = new List<Int64>();
        private Int64 qty = 0;
        private decimal price = 0;


        private Int64 storehouseId = 0;
        private void LoadSearchLookUp()
        {
           
            //slue_Supplies.Properties.ValueMember = "supplies_id";
            //slue_Supplies.Properties.DisplayMember = "supplies_name";
            //slue_Supplies.Properties.DataSource = _sup.getAllSupliesInStorehouse(storehouseId);
            //slue_Supplies.Properties.ShowClearButton = false;
        }
        private void frm_NewOutCouponToConstructions_Load(object sender, EventArgs e)
        {
           
            StyleDevxpressGridControl.styleGridControl(gridControl1, gridView1);
            loadStoreHouse();
            loadConstruction();
        }

        public void loadStoreHouse()
        {
            lue_Storehouse.Properties.ValueMember = "storehouse_id";
            lue_Storehouse.Properties.DisplayMember = "storehouse_name";
            lue_Storehouse.Properties.DataSource = storehouse.getAllStorehouse();
        }
        public void loadConstruction()
        {
            lue_Construction.Properties.ValueMember = "construction_id";
            lue_Construction.Properties.DisplayMember = "construction_name";
            lue_Construction.Properties.DataSource = construction.getAllContruction();
        }

        private void slue_Supplies_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                idSupplies = Int64.Parse(slue_Supplies.EditValue.ToString());

                var totalRow = listObject.Count;

                if (totalRow > 0)
                {
                    // tim trong list co khong roi add vao
                    bool check = false;
                    foreach (var item in listObject)
                    {
                        if (item.id == idSupplies)
                        {
                            // update quantity len 1
                            
                            //var supplies1 = storehouseDetail.getQuality(idSupplies, storehouseId);

                            //Int64 qtyStorehouse = Convert.ToInt64(supplies1.GetType().GetProperty("storehouse_detail_quantity").GetValue(supplies1, null).ToString());
                            //if (qtyStorehouse > item.quantity)
                            //{
                            //    item.quantity += 1;
                            //}
                            //else
                            //{
                            //    messeage.error("Số Lượng Lớn Hơn Hàng Tồn");
                            //    item.quantity = qtyStorehouse;
                            //}
                            //check = true;
                            //break;
                        }
                    }

                    if (check == false)
                    {
                        Add_Supplies_And_Quantity item = new Add_Supplies_And_Quantity();
                        item.id = idSupplies;
                        item.quantity = 1;
                        listObject.Add(item);
                        //ListID.Add(idSupplies);
                    }

                }
                else
                {
                    // add vao
                    Add_Supplies_And_Quantity item = new Add_Supplies_And_Quantity();
                    item.id = idSupplies;
                    item.quantity = 1;

                    listObject.Add(item);
                    //ListID.Add(idSupplies);
                }



                // update GridView
                var datasource = from sup in db.ST_supplies
                                 join ven in db.ST_vendors on sup.vendor_id equals ven.vendor_id
                                 join unit in db.ST_units on sup.unit_id equals unit.unit_id
                                 join group_sup in db.ST_group_supplies on sup.group_supplies_id equals group_sup.group_supplies_id

                                 select new
                                 {
                                     sup.supplies_id,
                                     sup.supplies_id_custom,
                                     sup.supplies_name,
                                     unit.unit_name,
                                     group_sup.group_supplies_name,
                                     sup.supplies_wholesale_price,
                                     sup.supplies_entry_price,
                                     sup.supplies_commercial_price
                                 };


                DataTable table = new DataTable();

                table.Columns.Add("ID", typeof(string));
                table.Columns.Add("ID_custom", typeof(string));
                table.Columns.Add("supplies_name", typeof(string));
                table.Columns.Add("supplies_unit", typeof(string));
                table.Columns.Add("supplies_quantity", typeof(Int64));
                table.Columns.Add("supplies_price", typeof(Decimal));
                table.Columns.Add("supplies_wholesale_price", typeof(Decimal));
                table.Columns.Add("total", typeof(Decimal));

                var count = listObject.Count;
                foreach (var item in listObject)
                {
                    foreach (var itemList in datasource)
                    {
                        if (item.id == itemList.supplies_id)
                        {
                            DataRow newRow = table.NewRow();
                            newRow["ID"] = itemList.supplies_id; // remove this line
                            newRow["ID_custom"] = itemList.supplies_id_custom; // remove this line
                            newRow["supplies_name"] = itemList.supplies_name;
                            newRow["supplies_unit"] = itemList.unit_name;
                            newRow["supplies_quantity"] = item.quantity;
                            newRow["supplies_price"] = itemList.supplies_commercial_price;
                            newRow["total"] = item.quantity * itemList.supplies_commercial_price;
                            table.Rows.Add(newRow);
                            break;
                        }
                    }
                }
                gridControl1.DataSource = table;

                SumPrice();

            }
            catch (Exception)
            {
                messeage.error("Có lỗi hãy kiểm tra lại !!");
            }
        }
        public static string DoFormat(decimal myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }
        private void SumPrice()
        {

            string total_price_supplies = DoFormat(decimal.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString()));
           
            StyleDevxpressGridControl.styleTextBoxVND(txt_total);
          
            txt_total.Text = total_price_supplies.ToString();
            int percent = 0;
            percent = int.Parse(s_number.EditValue.ToString());
            decimal total = Convert.ToDecimal(total_price_supplies) - (percent * Convert.ToDecimal(total_price_supplies)/100);
            txt_total_yes.Text = total.ToString();
            txt_total_price.Text = total.ToString();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column == supplies_quantity)
            {
               
                var suppliesId = Convert.ToInt64(gridView1.GetFocusedRowCellValue(ID).ToString());
                qty = Convert.ToInt64(gridView1.GetFocusedRowCellValue(supplies_quantity).ToString());

                //var supplies1 = storehouseDetail.getQuality(suppliesId,storehouseId);

                //Int64 qtyStorehouse = Convert.ToInt64( supplies1.GetType().GetProperty("storehouse_detail_quantity").GetValue(supplies1, null).ToString());
                //if (qty == 0)
                //{
                //    messeage.error("Số Lượng Ít Nhất Bằng 1");
                //    foreach (var item in listObject)
                //    {
                //        gridView1.SetFocusedRowCellValue(supplies_quantity, "1");
                //        if (item.id == suppliesId)
                //        {
                //            item.quantity = 1;

                //        }
                //    }
                //}
                //else if (qty <= qtyStorehouse)
                //{
                    
                //    price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(supplies_price).ToString());
                //    decimal total1 = qty * price;
                //    gridView1.SetFocusedRowCellValue(total, total1.ToString());

                //    foreach (var item in listObject)
                //    {
                //        if (item.id == suppliesId)
                //        {
                //            item.quantity = qty;
                           
                //        }
                //    }
                    

                //    gridView1.RefreshData();
                //    SumPrice();
                //}
                //else
                //{
                //    messeage.error("Số Lượng không Đủ!");
                //    gridView1.SetFocusedRowCellValue(supplies_quantity, qtyStorehouse.ToString());
                //    decimal total1 = qtyStorehouse * price;
                //    gridView1.SetFocusedRowCellValue(total, total1.ToString());
                  

                //    foreach (var item in listObject)
                //    {
                //        if (item.id == suppliesId)
                //        {
                //            item.quantity = qty;

                //        }
                //    }

                //    SumPrice();
                //    gridView1.RefreshData();
                //}
               
            }
           
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void lue_Storehouse_EditValueChanged(object sender, EventArgs e)
        {
            if (storehouseId == 0)
            {
                storehouseId = Convert.ToInt64(lue_Storehouse.EditValue);
                LoadSearchLookUp();
            }
            else
            {
                bool isChangeStorehouse = messeage.info("Bạn Có Muốn Đổi Kho.Khi Đổi Sẽ Mất Hết Vật Tư Đã Nhập","");
                if (isChangeStorehouse == true)
                {
                    storehouseId = Convert.ToInt64(lue_Storehouse.EditValue);
                    LoadSearchLookUp();
                }
                else
                {
                    lue_Storehouse.EditValue = storehouseId;
                }
            }

        }

        private void s_number_EditValueChanged(object sender, EventArgs e)
        {
            SumPrice();
        }

        private string checkNull()
        {
            if (lue_Construction.Text == "")
            {
                lue_Construction.Focus();
                return "Xin Nhập Công Trình";
            }
            else if (gridView1.RowCount == 0)
            {
                slue_Supplies.Focus();
                return "Xin Nhập Vật Tư";
            }
            else if (txt_number.Text == "")
            {
                txt_number.Focus();
                return "Xin Nhập Số Phiếu";
            }
            else
            return "true";
        }


        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            string check = checkNull();
            if (check == "true")
            {
                //thêm phiếu xuất

                //DTO.ST_out_coupon_supply newOutCoupon = new ST_out_coupon_supply();
                //newOutCoupon.construction_id = Convert.ToInt64( lue_Construction.EditValue);
                //newOutCoupon.out_coupon_supplies_number = txt_number.Text;
                //newOutCoupon.




            }
            else
            {
                 messeage.error(check);
            }
        }

        

        
    }
}