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
    public partial class frm_UpdateOutCouponToConstructions : DevExpress.XtraEditors.XtraForm
    {
        public Int64 outCouponId { get; set; }
        DataClasses1DataContext db = new DataClasses1DataContext();

        BUS.StorehouseBus storehouse = new BUS.StorehouseBus();
        BUS.ConstructionBus construction = new BUS.ConstructionBus();
        BUS.OutCouponSuppliesToConstructionBus outCouponConstruction = new BUS.OutCouponSuppliesToConstructionBus();
        BUS.DetailOutCouponSuppliesBus detailOCSBus = new BUS.DetailOutCouponSuppliesBus();
        BUS.ConstructionItemBus constructionItemBus = new BUS.ConstructionItemBus();
        BUS.StorehouseDetailBus storehouseDetailBus = new BUS.StorehouseDetailBus();
        SupliesBus _sup = new SupliesBus();
        StorehouseDetailBus storehouseDetail = new StorehouseDetailBus();
        List<Add_Supplies_And_Quantity> listObject = new List<Add_Supplies_And_Quantity>();
        List<Int64> ListID = new List<Int64>();

        Int64 constructionItemId;
        Int64 storehouseId;
        private Int64 idSupplies = 0; 
        private decimal totalPrice = 0;
        private Int64 qty = 0;
        private decimal price = 0;
        private bool isStart = true;



        public frm_UpdateOutCouponToConstructions()
        {
            InitializeComponent();
        }
        private void loadStorehouse()
        {
            lue_Storehouse.Properties.DisplayMember = "storehouse_name";
            lue_Storehouse.Properties.ValueMember = "storehouse_id";
            lue_Storehouse.Properties.DataSource = storehouse.getAllStorehouse();
        }
        public void loadConstruction()
        {
            lue_Construction.Properties.ValueMember = "construction_id";
            lue_Construction.Properties.DisplayMember = "construction_name";
            lue_Construction.Properties.DataSource = construction.getAllContruction();
        }
        public void loadConstructionItem(Int64 constructionId)
        {
            lue_ConstructionItem.Properties.DisplayMember = "construction_item_name";
            lue_ConstructionItem.Properties.ValueMember = "construction_item_id";
            lue_ConstructionItem.Properties.DataSource = constructionItemBus.getContructionItemWithGroup(constructionId);
          
        }
        private void LoadSearchLookUp()
        {

            slue_Supplies.Properties.ValueMember = "supplies_id";
            slue_Supplies.Properties.DisplayMember = "supplies_name";
            slue_Supplies.Properties.DataSource = _sup.getAllSupliesInStorehouse(storehouseId);
            slue_Supplies.Properties.ShowClearButton = false;
        }

        public void LoadOutCoupon()
        {
            try
            {
                var outCoupon = outCouponConstruction.getOutCouponToConstruction(outCouponId);
                storehouseId = Convert.ToInt64(outCoupon.GetType( ).GetProperty("storehouse_id").GetValue(outCoupon, null).ToString( ));
                lue_Storehouse.EditValue = storehouseId;

                constructionItemId = Convert.ToInt64(outCoupon.GetType( ).GetProperty("construction_item_id").GetValue(outCoupon, null).ToString( ));
                lue_ConstructionItem.EditValue = constructionItemId.ToString( );
                lue_Construction.EditValue = outCoupon.GetType( ).GetProperty("construction_id").GetValue(outCoupon, null).ToString( );
                txt_number.Text = outCoupon.GetType( ).GetProperty("out_coupon_supplies_number").GetValue(outCoupon, null).ToString( );
                txt_deliver.Text = outCoupon.GetType( ).GetProperty("out_coupon_supplies_receiver").GetValue(outCoupon, null).ToString( );

                decimal price = Convert.ToDecimal(outCoupon.GetType( ).GetProperty("out_coupon_supplies_total_price").GetValue(outCoupon, null));

                txt_total_price.Text = StyleDevxpressGridControl.convertDecimaToNumberic(price);
                s_number.Text = outCoupon.GetType( ).GetProperty("out_coupon_supplies_total_percent_discount").GetValue(outCoupon, null).ToString( );
                txt_description.Text = outCoupon.GetType( ).GetProperty("out_coupon_supplies_description").GetValue(outCoupon, null).ToString( );
                decimal total = Convert.ToDecimal(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString( ));
                txt_total.Text = StyleDevxpressGridControl.convertDecimaToNumberic(total); 
            }
            catch(Exception)
            {
                messeage.err();
            }
            


        }



        private void loadDetailOCP()
        {
            var detailOCS = detailOCSBus.getAllDetailOCP(outCouponId);
            int i = 0;
            try
                {
                    DataTable table = new DataTable();

                    table.Columns.Add("ID", typeof(string));
                    table.Columns.Add("ID_custom", typeof(string));
                    table.Columns.Add("supplies_name", typeof(string));
                    table.Columns.Add("supplies_unit", typeof(string));
                    table.Columns.Add("supplies_quantity", typeof(Int64));
                    table.Columns.Add("supplies_price", typeof(Decimal));
                    table.Columns.Add("supplies_wholesale_price", typeof(Decimal));
                    table.Columns.Add("total", typeof(Decimal));




                foreach (var item in detailOCS)
                  {
                      Add_Supplies_And_Quantity item1 = new Add_Supplies_And_Quantity();
                      item1.id =Convert.ToInt64( item.GetType().GetProperty("supplies_id").GetValue(item, null).ToString());
                      item1.quantity = Convert.ToInt64(item.GetType().GetProperty("detail_out_coupon_supplies_quantity").GetValue(item, null).ToString());
                      listObject.Add(item1);

                      DataRow newRow = table.NewRow();
                      newRow["ID"] = Convert.ToInt64(item.GetType().GetProperty("supplies_id").GetValue(item, null).ToString()); // remove this line
                      newRow["ID_custom"] = item.GetType().GetProperty("supplies_id_custom").GetValue(item, null).ToString(); // remove this line
                      newRow["supplies_name"] = item.GetType().GetProperty("supplies_name").GetValue(item, null).ToString() ;
                      newRow["supplies_unit"] = item.GetType().GetProperty("unit_name").GetValue(item, null).ToString() ;

                      Int64 quality = Convert.ToInt64(item.GetType().GetProperty("detail_out_coupon_supplies_quantity").GetValue(item, null).ToString());
                      Decimal price = Convert.ToDecimal(item.GetType().GetProperty("supplies_commercial_price").GetValue(item, null).ToString());
                      newRow["supplies_quantity"] = quality;
                      newRow["supplies_price"] = price;
                      newRow["total"] = quality * price;
                      table.Rows.Add(newRow);


                      }
                gridControl1.DataSource = table;
                }
            catch (Exception)
            {
                messeage.error("Có lỗi hãy kiểm tra lại !!");
            }

        }




        private void frm_UpdateOutCouponToConstructions_Load(object sender, EventArgs e)
        {
            StyleDevxpressGridControl.styleGridControl(gridControl1, gridView1);
            loadDetailOCP();
            LoadOutCoupon();
            loadStorehouse();
            loadConstruction();
            LoadSearchLookUp();
            isStart = false;

            this.AcceptButton = btn_Update;
        }

        private void lue_Construction_EditValueChanged(object sender, EventArgs e)
        {
            lue_ConstructionItem.EditValue = constructionItemId.ToString();

            loadConstructionItem(Convert.ToInt64(lue_Construction.EditValue));
        }

        private void slue_Supplies_EditValueChanged(object sender, EventArgs e)
        {
          
            if(isStart==false)
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

                            var supplies1 = storehouseDetail.getQuality(idSupplies, storehouseId);

                            Int64 qtyStorehouse = Convert.ToInt64(supplies1.GetType().GetProperty("storehouse_detail_quantity").GetValue(supplies1, null).ToString());
                            if (qtyStorehouse > item.quantity)
                            {
                                item.quantity += 1;
                            }
                            else
                            {
                                messeage.error("Số Lượng Lớn Hơn Hàng Tồn");
                                item.quantity = qtyStorehouse;
                            }
                            check = true;
                            break;
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
        }


        private void SumPrice()
        {
            decimal total_price_supplies = decimal.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString());
            txt_total.Text = StyleDevxpressGridControl.convertDecimaToNumberic(total_price_supplies);
            int percent = 0;
            percent = int.Parse(s_number.EditValue.ToString());
            totalPrice = Convert.ToDecimal(total_price_supplies) - (percent * Convert.ToDecimal(total_price_supplies) / 100);
            txt_total_price.Text = StyleDevxpressGridControl.convertDecimaToNumberic(totalPrice);

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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (isStart == false)
                {
                    if (e.Column == supplies_quantity)
                    {

                        var suppliesId = Convert.ToInt64(gridView1.GetFocusedRowCellValue(ID).ToString());
                        qty = Convert.ToInt64(gridView1.GetFocusedRowCellValue(supplies_quantity).ToString());

                        var supplies1 = storehouseDetail.getQuality(suppliesId, storehouseId);

                        Int64 qtyStorehouse = Convert.ToInt64(supplies1.GetType().GetProperty("storehouse_detail_quantity").GetValue(supplies1, null).ToString());
                        if (qty == 0)
                        {
                            messeage.error("Số Lượng Ít Nhất Bằng 1");
                            foreach (var item in listObject)
                            {
                                gridView1.SetFocusedRowCellValue(supplies_quantity, "1");
                                if (item.id == suppliesId)
                                {
                                    item.quantity = 1;

                                }
                            }
                        }
                        else if (qty <= qtyStorehouse)
                        {

                            price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(supplies_price).ToString());
                            decimal total1 = qty * price;
                            gridView1.SetFocusedRowCellValue(total, total1.ToString());

                            foreach (var item in listObject)
                            {
                                if (item.id == suppliesId)
                                {
                                    item.quantity = qty;

                                }
                            }


                            gridView1.RefreshData();
                            SumPrice();
                        }
                        else
                        {
                            messeage.error("Số Lượng không Đủ!");
                            gridView1.SetFocusedRowCellValue(supplies_quantity, qtyStorehouse.ToString());
                            decimal total1 = qtyStorehouse * price;
                            gridView1.SetFocusedRowCellValue(total, total1.ToString());


                            foreach (var item in listObject)
                            {
                                if (item.id == suppliesId)
                                {
                                    item.quantity = qty;

                                }
                            }

                            SumPrice();
                            gridView1.RefreshData();
                        }

                    }

                }
            }
            catch (Exception)
            {
                messeage.err();
            }
        }

        private void lue_Storehouse_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isStart == false)
                {


                    if (storehouseId == 0)
                    {
                        storehouseId = Convert.ToInt64(lue_Storehouse.EditValue);
                        LoadSearchLookUp();
                    }
                    else
                    {
                        bool isChangeStorehouse = messeage.info("Bạn Có Muốn Đổi Kho.Khi Đổi Sẽ Mất Hết Vật Tư Đã Nhập", "");
                        if (isChangeStorehouse == true)
                        {
                            storehouseId = Convert.ToInt64(lue_Storehouse.EditValue);
                            LoadSearchLookUp();
                            gridControl1.DataSource = null;
                        }
                        else
                        {
                            lue_Storehouse.EditValue = storehouseId;
                        }
                    }
                }
            }
            catch (Exception)
            {
                messeage.err();
            }
        }

        private void s_number_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isStart == false)
                    SumPrice();
            }
            catch (Exception)
            {
                messeage.err();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}