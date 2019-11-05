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
    public partial class frm_AddNewEnterCouponSupplies : DevExpress.XtraEditors.XtraForm
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public frm_AddNewEnterCouponSupplies( )
        {
            InitializeComponent( );
        }

        supliesBus _sup = new supliesBus();
        vendorBus _vender = new vendorBus();
        storehouseBus _store = new storehouseBus();
        EnterCouponSuppliesBus _en = new EnterCouponSuppliesBus();
        PaymentSlipBus _pay = new PaymentSlipBus();
        pulicDebtBus _pub = new pulicDebtBus();
        detailEnterCouponSuppliesBus _de_en = new detailEnterCouponSuppliesBus();
        detailPulicDebtBus _de_public_debt = new detailPulicDebtBus( );
        storehouseDetailBus _storeDetail = new storehouseDetailBus();

        private Int64 idSupplies = 0;
        private Int64 idNCC = 0;
        private Int64 idKho = 0;

        List<Add_Supplies_And_Quantity> listObject = new List<Add_Supplies_And_Quantity>( );
        List<Int64> ListID = new List<Int64>();

        private void frm_AddNewEnterCouponSupplies_Load(object sender, EventArgs e)
        {
            LoadSearchLookUp();
            LoadNCC();
            LoadKho();
            repositoryItem_quantity.EditValueChanged += new EventHandler(repositoryItemComboBox1_EditValueChanged);

            StyleDevxpressGridControl.styleGridControl(gridControl1, gridView1);
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender, EventArgs e)
        {
            //The Current selected value in the dropdownlist  
            TextEdit t = sender as TextEdit;
            string editvalue =  t.EditValue.ToString();
            //messeage.success(editvalue);

        }
  
        

        #region Load

        private void LoadKho()
        {
            lue_Kho.Properties.DataSource = _store.getAllStorehouse();
            lue_Kho.Properties.ValueMember = "storehouse_id";
            lue_Kho.Properties.DisplayMember = "storehouse_name";
        }

        private void LoadSearchLookUp( )
        {
            slue_Supplies.Properties.DataSource = _sup.getAllSuplies_LoadSerach( );
            slue_Supplies.Properties.ValueMember = "supplies_id";
            slue_Supplies.Properties.DisplayMember = "supplies_name";
            slue_Supplies.Properties.ShowClearButton = false;
        }
        private void LoadNCC()
        {
           var getAllNCC = _vender.loadAllVendor();
           lue_NCC.Properties.DataSource = getAllNCC;

           lue_NCC.Properties.ValueMember = "vendor_id";
           lue_NCC.Properties.DisplayMember = "vendor_name";

        }
        

        #endregion End Load
        private bool checkNull()
        {
            if (txt_number.Text == "" )
            {
                return false;
            }
            else
            {
                if (_en.isCheckNumber(txt_number.Text.ToString()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        #region Event
        private void reset()
        {
            txt_ChungTu.Text = "";
            txt_deliver.Text = "";
            txt_descriptoon.Text ="";
            txt_number.EditValue = 0;
            txt_total.Text = "";
            txt_total_price.Text ="";
            txt_total_yes.Text = "";
            gridControl1.DataSource = null;
            idSupplies = 0;
            idNCC = 0;
            idKho = 0;
            LoadKho();
            LoadSearchLookUp();
            

        }
        private void btn_AddNewSuppelies_Click(object sender, EventArgs e)
        {
            frm_AddNewSupplies frm = new frm_AddNewSupplies( );
            frm.FormClosed += new FormClosedEventHandler(dongformSearch);
            frm.ShowDialog( );
        }



        private void txt_percent_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void s_number_EditValueChanged(object sender, EventArgs e)
        {
            int percent = 0;
            percent = int.Parse(s_number.EditValue.ToString( ));
            //messeage.success(percent.ToString());
            Decimal summaryValue = Decimal.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString( ));
            if ( percent > 0 && percent <= 100 )
            {
                Decimal s = (Decimal) percent / 100;
                Decimal total = summaryValue - summaryValue * s;
                txt_total_price.Text = total.ToString( );
            }
            else
            {
                txt_total_price.Text = summaryValue.ToString( );
            }


        }

        private void lue_NCC_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            idNCC = Convert.ToInt32(edit.EditValue);
        }

        private void lue_Kho_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            idKho = Convert.ToInt32(edit.EditValue);
        }

        private void slue_Supplies_EditValueChanged(object sender, EventArgs e)
        {
            try{
                idSupplies = Int64.Parse(slue_Supplies.EditValue.ToString( ));
                
                var totalRow = listObject.Count;

                if ( totalRow > 0 )
                {
                    // tim trong list co khong roi add vao
                    bool check = false;
                    foreach ( var item in listObject )
                    {
                        if ( item.id == idSupplies )
                        {
                            // update quantity len 1
                            item.quantity += 1;
                            check = true;
                            break;
                        }
                    }

                    if ( check == false )
                    {
                        Add_Supplies_And_Quantity item = new Add_Supplies_And_Quantity( );
                        item.id = idSupplies;
                        item.quantity = 1;

                        listObject.Add(item);
                    }

                }
                else
                {
                    // add vao
                    Add_Supplies_And_Quantity item = new Add_Supplies_And_Quantity( );
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

                                 };



                DataTable table = new DataTable( );
                table.Columns.Add("ID", typeof(string));
                table.Columns.Add("ID_custom", typeof(string));
                table.Columns.Add("supplies_name", typeof(string));
                table.Columns.Add("supplies_unit", typeof(string));
                table.Columns.Add("supplies_quantity", typeof(Int64));
                table.Columns.Add("supplies_price", typeof(Decimal));
                table.Columns.Add("supplies_wholesale_price", typeof(Decimal));
                table.Columns.Add("total", typeof(Decimal));

                var count = listObject.Count;
                foreach ( var item in listObject )
                {
                    foreach ( var itemList in datasource )
                    {
                        if ( item.id == itemList.supplies_id )
                        {
                            DataRow newRow = table.NewRow();
                            newRow["ID"] = itemList.supplies_id; // remove this line
                            newRow["ID_custom"] = itemList.supplies_id_custom; // remove this line
                            newRow["supplies_name"] = itemList.supplies_name;
                            newRow["supplies_unit"] = itemList.unit_name;
                            newRow["supplies_quantity"] = item.quantity;
                            newRow["supplies_price"] = itemList.supplies_entry_price;
                            newRow["supplies_wholesale_price"] = itemList.supplies_wholesale_price;
                            newRow["total"] = item.quantity * itemList.supplies_entry_price;

                            table.Rows.Add(newRow);

                            break;
                        }
                    }
                }
                gridControl1.DataSource = table;

                var total_price_supplies = double.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString());
                StyleDevxpressGridControl.styleTextBoxVND(txt_total);
                txt_total.Text = total_price_supplies.ToString();

                int percent = 0;
                percent = int.Parse(s_number.Value.ToString( ));

                Decimal summaryValue = Decimal.Parse(gridView1.Columns["total"].SummaryItem.SummaryValue.ToString( ));
                if ( percent > 0 && percent <= 100 )
                {
                    Decimal s = (Decimal) percent / 100;
                    Decimal total = summaryValue - summaryValue * s;
                    txt_total_price.Text = total.ToString( );
                }
                else
                {
                    txt_total_price.Text = summaryValue.ToString( );
                } 

            }
            catch(Exception)
            {
                messeage.error("Có lỗi hãy kiểm tra lại !!");
            }
            
        }

        private void dongformSearch(object sender, EventArgs e)
        {
            LoadSearchLookUp( );
        }
        #endregion End Event
        // add new phieu nhap
        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            try{
            Decimal tienTra = 0;
            Decimal tienCanTraNCC = 0;
            // so tien khac rong
            if ( txt_total_price.Text != "")
            {
                if (idNCC == 0)
                {
                    messeage.error("Bạn chưa chọn Nhà cung cấp !");
                }
                else
                {
                    if (idKho == 0)
                    {
                        messeage.error("Bạn chưa chọn Nhà kho !");
                    }
                    else
                    {
                        if ( txt_total_yes.Text == "" )
                        {
                            // them vao cong no
                            #region Thêm công nợ
                            if ( checkNull( ) )
                            {
                                // tao phieu nhap
                                ST_enter_coupon_supply enter = new ST_enter_coupon_supply( );
                                enter.vendor_id = idNCC;
                                enter.storehouse_id = idKho;
                                enter.enter_coupon_supplies_number = txt_number.Text;
                                enter.enter_coupon_supplies_description = txt_descriptoon.Text;
                                enter.enter_coupon_supplies_total_price = Decimal.Parse(txt_total_price.Text);
                                enter.enter_coupon_supplies_total_percent_discount = int.Parse(s_number.Value.ToString( ));
                                enter.enter_coupon_supplies_created_date = DateTime.Now;
                                enter.enter_coupon_supplies_document = txt_ChungTu.Text;
                                enter.employee_created = frm_Main.Vitual_id;
                                Int64 idEnter = _en.insertEnterCouponSupplies(enter);

                                // tao chi tiet phieu nhap
                                for ( int i = 0; i < gridView1.DataRowCount; i++ )
                                {
                                    Int64 supplies_id = Int64.Parse(gridView1.GetRowCellValue(i, "ID").ToString( ));
                                    int quantity = int.Parse(gridView1.GetRowCellValue(i, "supplies_quantity").ToString( ));

                                    ST_detail_enter_coupon_supply _detail_en = new ST_detail_enter_coupon_supply( );
                                    _detail_en.supplies_id = supplies_id;
                                    _detail_en.detail_enter_coupon_supplies_quatity = int.Parse(quantity.ToString( ));
                                    _detail_en.enter_coupon_supplies_id = idEnter;
                                    _detail_en.detail_enter_coupon_supplies_total = supplies_id * quantity;

                                    _de_en.insert(_detail_en);
                                }


                                //tao phieu chi
                                ST_payment_slip pay = new ST_payment_slip( );
                                pay.vendor_id = idNCC;
                                pay.payment_slip_receiver = txt_deliver.Text;
                                pay.payment_slip_description = "Nhập vật tư";
                                pay.payment_slip_total_price = 0;
                                pay.enter_coupon_supplies_id = idEnter;
                                pay.payment_slip_created_date = DateTime.Now;
                                pay.employee_created = frm_Main.Vitual_id;
                                pay.detail_income_and_expenditure_pattern_id = 611;
                                pay.payment_slip_Co = 311; // chua toan het
                                pay.payment_slip_No = 611;
                                Int64 idPaymentSlip = _pay.insertPaymentSlip(pay);

                                // co ncc thi them vao chi tiet cong no
                                if ( _pub.checkVender(idNCC) )
                                {

                                    ST_detail_pulic_debt _detail_pub = new ST_detail_pulic_debt( );
                                    _detail_pub.pulic_debt_id = _pub.getPublicFromVenderID(idNCC);
                                    _detail_pub.payment_slip_id = idPaymentSlip;

                                    //var tienTraNCC = 0;
                                    var tienMuaHang = Decimal.Parse(txt_total_price.Text);
                                    Decimal tienNo = tienMuaHang;

                                    _detail_pub.detail_pulic_debt_total = tienNo;

                                    _de_public_debt.insertDetailPulicDebts(_detail_pub);
                                }
                                else
                                {
                                    // tao moi cong no
                                    ST_pulic_debt congno = new ST_pulic_debt( );
                                    congno.vendor_id = idNCC;
                                    Int64 idCongNo = _pub.insertPulicDebt(congno);

                                    //chi tiet cong no
                                    ST_detail_pulic_debt _detail_pub = new ST_detail_pulic_debt( );
                                    _detail_pub.pulic_debt_id = idCongNo;
                                    _detail_pub.payment_slip_id = idPaymentSlip;

                                    //var tienTraNCC = 0;
                                    var tienMuaHang = Decimal.Parse(txt_total_price.Text);
                                    Decimal tienNo = tienMuaHang;

                                    _detail_pub.detail_pulic_debt_total = tienNo;
                                    _de_public_debt.insertDetailPulicDebts(_detail_pub);
                                }

                                // tang so luong trong kho
                                for ( int i = 0; i < gridView1.DataRowCount; i++ )
                                {
                                    Int64 supplies_id = Int64.Parse(gridView1.GetRowCellValue(i, "ID").ToString( ));
                                    int quantity = int.Parse(gridView1.GetRowCellValue(i, "supplies_quantity").ToString( ));
                                    if ( _storeDetail.isCheckSupplies(supplies_id) )
                                    {
                                        _storeDetail.updateQuality(supplies_id, quantity, idKho);
                                    }
                                    else
                                    {
                                        _storeDetail.insert(idNCC, supplies_id, quantity);
                                    }
                                }

                                reset( );
                                messeage.success("Thêm mới thành công !"); 
                            }
                            else
                            {
                                messeage.error("Bạn chưa nhập Số phiếu nhập hoặc đã trùng !");
                            }

                            #endregion 
                        }
                        else
                        {
                            
                            tienTra = Decimal.Parse(txt_total_yes.Text.ToString( ));
                            tienCanTraNCC = Decimal.Parse(txt_total_price.Text.ToString( ));
                            if ( tienTra > tienCanTraNCC )
                            {
                                messeage.error("Số tiền trả nhà Cung cấp phải bằng số tiền cần trả !");
                            }
                            else
                            {
                                #region Tien tra = nha cung cap
                                if ( tienTra == tienCanTraNCC )
                                {
                                    if ( checkNull())
                                    {
                                        // tao phieu nhap
                                        ST_enter_coupon_supply enter = new ST_enter_coupon_supply( );
                                        enter.vendor_id = idNCC;
                                        enter.storehouse_id = idKho;
                                        enter.enter_coupon_supplies_number = txt_number.Text;
                                        enter.enter_coupon_supplies_description = txt_descriptoon.Text;
                                        enter.enter_coupon_supplies_total_price = Decimal.Parse(txt_total_price.Text);
                                        enter.enter_coupon_supplies_total_percent_discount = int.Parse(s_number.Value.ToString());
                                        enter.enter_coupon_supplies_created_date = DateTime.Now;
                                        enter.enter_coupon_supplies_document = txt_ChungTu.Text;
                                        enter.employee_created = frm_Main.Vitual_id;
                                        Int64 idEnter = _en.insertEnterCouponSupplies(enter);

                                        // tao chi tiet phieu nhap
                                        for(int i = 0; i < gridView1.DataRowCount; i++)
                                        {
                                            Int64 supplies_id = Int64.Parse(gridView1.GetRowCellValue(i, "ID").ToString( ));
                                            int quantity = int.Parse(gridView1.GetRowCellValue(i, "supplies_quantity").ToString( ));

                                            ST_detail_enter_coupon_supply _detail_en = new ST_detail_enter_coupon_supply();
                                            _detail_en.supplies_id = supplies_id;
                                            _detail_en.detail_enter_coupon_supplies_quatity = int.Parse(quantity.ToString());
                                            _detail_en.enter_coupon_supplies_id = idEnter;
                                            _detail_en.detail_enter_coupon_supplies_total = supplies_id * quantity;

                                            _de_en.insert(_detail_en);
                                        }
                                        

                                        //tao phieu chi
                                        ST_payment_slip pay = new ST_payment_slip();
                                        pay.vendor_id = idNCC;
                                        pay.payment_slip_receiver = txt_deliver.Text;
                                        pay.payment_slip_description = "Nhập vật tư";
                                        pay.payment_slip_total_price = Decimal.Parse(txt_total_yes.Text);
                                        pay.enter_coupon_supplies_id = idEnter;
                                        pay.payment_slip_created_date = DateTime.Now;
                                        pay.employee_created = frm_Main.Vitual_id;
                                        pay.detail_income_and_expenditure_pattern_id = 611;
                                        pay.payment_slip_Co = 111; // thanh toan het
                                        pay.payment_slip_No = 611;
                                        _pay.insertPaymentSlip(pay);

                                        // tang so luong trong kho
                                        for ( int i = 0; i < gridView1.DataRowCount; i++ )
                                        {
                                            Int64 supplies_id = Int64.Parse(gridView1.GetRowCellValue(i, "ID").ToString( ));
                                            int quantity = int.Parse(gridView1.GetRowCellValue(i, "supplies_quantity").ToString( ));
                                            if ( _storeDetail.isCheckSupplies(supplies_id) )
                                            {
                                                _storeDetail.updateQuality(supplies_id, quantity, idKho);
                                            }
                                            else
                                            {
                                                _storeDetail.insert(idNCC,supplies_id, quantity);
                                            }
                                        }


                                        messeage.success("Thêm mới thành công !");
                                        reset();
                                    }
                                    else
                                    {
                                        messeage.error("Bạn chưa nhập Số phiếu nhập hoặc đã trùng !");
                                    }
                                    

                                }
                                #endregion

                                #region Tien tra < nha cung cap
                                else if ( tienTra < tienCanTraNCC )
                                {
                                    
                                    // tao phieu chi  + tao phieu nhap
                                    // tao phieu nhap
                                    ST_enter_coupon_supply enter = new ST_enter_coupon_supply( );
                                    enter.vendor_id = idNCC;
                                    enter.storehouse_id = idKho;
                                    enter.enter_coupon_supplies_number = txt_number.Text;
                                    enter.enter_coupon_supplies_description = txt_descriptoon.Text;
                                    enter.enter_coupon_supplies_total_price = Decimal.Parse(txt_total_price.Text);
                                    enter.enter_coupon_supplies_total_percent_discount = int.Parse(s_number.Value.ToString( ));
                                    enter.enter_coupon_supplies_created_date = DateTime.Now;
                                    enter.enter_coupon_supplies_document = txt_ChungTu.Text;
                                    enter.employee_created = frm_Main.Vitual_id;

                                    Int64 idEnter = _en.insertEnterCouponSupplies(enter);

                                    // tao chi tiet phieu nhap
                                    for ( int i = 0; i < gridView1.DataRowCount; i++ )
                                    {
                                        Int64 supplies_id = Int64.Parse(gridView1.GetRowCellValue(i,"ID").ToString());
                                        int quantity = int.Parse(gridView1.GetRowCellValue(i, "supplies_quantity").ToString( ));
                                        //int quantity = int.Parse(i["supplies_quantity"].ToString( ));


                                            if ( _storeDetail.isCheckSupplies(supplies_id) )
                                            {
                                                _storeDetail.updateQuality(supplies_id, quantity, idKho);
                                            }
                                            else
                                            {
                                                _storeDetail.insert(idNCC, supplies_id, quantity);
                                            }

                                            ST_detail_enter_coupon_supply _detail_en = new ST_detail_enter_coupon_supply( );
                                            _detail_en.supplies_id = Int64.Parse(supplies_id.ToString());
                                            _detail_en.detail_enter_coupon_supplies_quatity = int.Parse(quantity.ToString( ));
                                            _detail_en.enter_coupon_supplies_id = idEnter;
                                            _detail_en.detail_enter_coupon_supplies_total = supplies_id * quantity;

                                            _de_en.insert(_detail_en);
                                        }


                                    //tao phieu chi
                                    ST_payment_slip pay = new ST_payment_slip( );
                                    pay.vendor_id = idNCC;
                                    pay.payment_slip_receiver = txt_deliver.Text;
                                    pay.payment_slip_description = "Nhập vật tư";
                                    pay.payment_slip_total_price = Decimal.Parse(txt_total_yes.Text);
                                    pay.enter_coupon_supplies_id = idEnter;
                                    pay.payment_slip_created_date = DateTime.Now;
                                    pay.employee_created = frm_Main.Vitual_id;
                                    pay.detail_income_and_expenditure_pattern_id = 611;
                                    pay.payment_slip_Co = 331; // thanh toan 1 phan
                                    pay.payment_slip_No = 611;
                                    Int64 idPaymentSlip = _pay.insertPaymentSlip(pay);

                                    // co ncc thi them vao chi tiet cong no
                                    if (_pub.checkVender(idNCC))
                                    {
                                        
                                        ST_detail_pulic_debt _detail_pub = new ST_detail_pulic_debt( );
                                        _detail_pub.pulic_debt_id = _pub.getPublicFromVenderID(idNCC);
                                        _detail_pub.payment_slip_id = idPaymentSlip;

                                        var tienTraNCC =Decimal.Parse(txt_total_yes.Text);
                                        var tienMuaHang = Decimal.Parse(txt_total_price.Text);
                                        Decimal tienNo = tienMuaHang - tienTraNCC;

                                        _detail_pub.detail_pulic_debt_total = tienNo;

                                        _de_public_debt.insertDetailPulicDebts(_detail_pub);
                                    }
                                    else
                                    {
                                        // tao moi cong no
                                        ST_pulic_debt congno = new ST_pulic_debt( );
                                        congno.vendor_id = idNCC;
                                        Int64 idCongNo = _pub.insertPulicDebt(congno);

                                        //chi tiet cong no
                                        ST_detail_pulic_debt _detail_pub = new ST_detail_pulic_debt( );
                                        _detail_pub.pulic_debt_id = idCongNo;
                                        _detail_pub.payment_slip_id = idPaymentSlip;

                                        var tienTraNCC = Decimal.Parse(txt_total_yes.Text);
                                        var tienMuaHang = Decimal.Parse(txt_total_price.Text);
                                        Decimal tienNo = tienMuaHang - tienTraNCC;

                                        _detail_pub.detail_pulic_debt_total = tienNo;
                                        _de_public_debt.insertDetailPulicDebts(_detail_pub);
                                    }


                                    // tang so luong trong kho
                                    for ( int i = 0; i < gridView1.DataRowCount; i++ )
                                    {
                                        Int64 supplies_id = Int64.Parse(gridView1.GetRowCellValue(i, "ID").ToString( ));
                                        int quantity = int.Parse(gridView1.GetRowCellValue(i, "supplies_quantity").ToString( ));

                                        if ( _storeDetail.isCheckSupplies(supplies_id) )
                                        {
                                            _storeDetail.updateQuality(supplies_id, quantity, idKho);
                                        }
                                        else
                                        {
                                            _storeDetail.insert(idNCC, supplies_id, quantity);
                                        }
                                    }


                                    reset();
                                    messeage.success("Thêm mới thành công !");
                                }
                            }
                            #endregion
                            }
                    }
                }
                
            }
            else
            {
                messeage.error("Bạn chưa chọn mặt hàng !");
            }
            }

            catch(Exception)
            {
                messeage.error("Không thể thêm mới");
            }
            

        }

        
    }
}