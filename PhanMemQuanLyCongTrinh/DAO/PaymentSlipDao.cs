using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;

namespace PhanMemQuanLyCongTrinh.DAO
{
    public class PaymentSlipDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext( );

        public IEnumerable<object> getAllPaymentSlips( )
        {
            var dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu ...", "Thông báo");
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var datasource = from pm in db.ST_payment_slips
                                 select pm;
                return datasource;
            }
            catch ( Exception )
            {
                return null;
            }
            finally
            {
                dlg.Close( );
            }
        }

        public Int64 getIdPaymentSlipsFromEnter(Int64 idEnter)
        {
            try
            {
                var data = (from b in db.ST_payment_slips
                            where b.enter_coupon_supplies_id == idEnter
                            orderby b.payment_slip_created_date ascending
                            select new { b.payment_slip_id }).First( );
                if ( data != null )
                {
                    return Int64.Parse(data.ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public object getPaymentSlip(Int64 paymentId)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                var unit = (from t1 in db.ST_payment_slips
                            where t1.payment_slip_id == paymentId
                            select t1).First( );
                return unit;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public bool deletePaymentSlip(Int64 paymentId)
        {
            try
            {
                var delete = db.ST_payment_slips.Where(p => p.payment_slip_id.Equals(paymentId)).SingleOrDefault( );

                db.ST_payment_slips.DeleteOnSubmit(delete);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Int64 insertPaymentSlip(DTO.ST_payment_slip payment)
        {
            try
            {
                db.ST_payment_slips.InsertOnSubmit(payment);
                db.SubmitChanges( );
                return payment.payment_slip_id;
            }
            catch ( Exception )
            {
                return 0;
            }
        }

        public bool updatePaymentSlip(DTO.ST_payment_slip pay)
        {
            try
            {
                var updatePay = db.ST_payment_slips.Where(p => p.payment_slip_id.Equals(pay.payment_slip_id)).SingleOrDefault( );

                //var updatePay = (from p in db.ST_payment_slips
                //                 where p.payment_slip_id == pay.payment_slip_id
                //                orderby p.payment_slip_id ascending
                //                select p
                //                ).First();
                updatePay.payment_slip_id = pay.payment_slip_id;
                updatePay.employee_id = pay.employee_id;
                updatePay.vendor_id = pay.vendor_id;
                updatePay.construction_id = pay.construction_id;
                updatePay.enter_coupon_supplies_id = pay.enter_coupon_supplies_id;
                updatePay.payment_slip_No = pay.payment_slip_No;
                updatePay.payment_slip_Co = pay.payment_slip_Co;
                updatePay.customer_id = pay.customer_id;
                updatePay.payment_slip_receiver = pay.payment_slip_receiver;
                updatePay.payment_slip_address = pay.payment_slip_address;
                updatePay.payment_slip_document = pay.payment_slip_document;
                updatePay.payment_slip_total_price = pay.payment_slip_total_price;
                updatePay.detail_income_and_expenditure_pattern_id = pay.detail_income_and_expenditure_pattern_id;
                updatePay.payment_slip_created_date = pay.payment_slip_created_date;
                updatePay.employee_created = pay.employee_created;

                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }
    }
}
