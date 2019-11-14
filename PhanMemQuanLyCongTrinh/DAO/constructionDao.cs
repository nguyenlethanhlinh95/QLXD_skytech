﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhanMemQuanLyCongTrinh.DTO;
namespace PhanMemQuanLyCongTrinh.DAO
{
    class ConstructionDao
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public object getAllContruction()
        {
            try
            {
                db.Dispose();
                db = new DTO.DataClasses1DataContext();
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var buildingContractor = from t1 in db.ST_constructions
                                         select new
                                         {
                                             t1.construction_id,
                                             t1.construction_id_custom,
                                             t1.construction_name,
                                             t1.construction_addresss,
                                            
                                         }
                                              ;
                return buildingContractor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool deleteContruction(Int64 id)
        {
            try
            {
                var delete = db.ST_constructions.Where(p => p.construction_id.Equals(id)).SingleOrDefault();

                db.ST_constructions.DeleteOnSubmit(delete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public object getContruction(Int64 constructionId)
        {
            try
            {
                db.Dispose( );
                db = new DTO.DataClasses1DataContext( );
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                var buildingContractor = from t1 in db.ST_constructions
                                         join t2 in db.ST_customers
                                         on t1.customer_id equals t2.customer_id
                                         where t1.construction_id == constructionId
                                         select t1;
                return buildingContractor.First( );
            }
            catch ( Exception )
            {
                return null;
            }
        }


        public bool insertContstruction(DTO.ST_construction constraction)
        {
            try
            {
                db.ST_constructions.InsertOnSubmit(constraction);
                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateStatusContstruction(Int64 constractionID, int status)
        {
            try
            {
                var updateConstruction = db.ST_constructions.Where(p => p.construction_id.Equals(constractionID)).SingleOrDefault( );
                updateConstruction.construction_status = status;
                db.SubmitChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }


        }

        public bool updateContstruction(DTO.ST_construction constraction)
        {
            try
            {
                var updateConstruction = db.ST_constructions.Where(p => p.construction_id.Equals(constraction.construction_id)).SingleOrDefault( );

                updateConstruction.construction_name = constraction.construction_name;
                updateConstruction.customer_id = constraction.customer_id;
                updateConstruction.construction_addresss = constraction.construction_addresss;
                updateConstruction.construction_contract_number = constraction.construction_contract_number;
                updateConstruction.construction_total_price = constraction.construction_total_price;

                updateConstruction.construction_file_name = constraction.construction_file_name;

                updateConstruction.construction_file = constraction.construction_file;


                updateConstruction.construction_date_start = constraction.construction_date_start;


                updateConstruction.construction_date_end = constraction.construction_date_end;


                updateConstruction.construction_date_start_guarantee = constraction.construction_date_start_guarantee;
                updateConstruction.construction_date_end_guarantee = constraction.construction_date_end_guarantee;



                updateConstruction.construction_image = constraction.construction_image;


                db.SubmitChanges( );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int checkContructionSuccess(Int64 idContruct)
        {
            // 1 chua thuc hien, 2 dang thuc hien, 3 hoan thanh
            try
            {
                var data = from b in db.ST_construction_items
                           where b.construction_id == idContruct
                           select b;
                int soluong = data.Count();
                int soLuongNgayBatDau = 0;
                int soLuongNgayKetThuc = 0;
                if ( soluong > 0)
                {
                    // duyet qua tung phan tu hang muc kiem tra if tat ca ngay thuc hien == null thi chua thuc hien, if  tat ca lon hon > 0 va <  ngay thuc hien 
                    foreach (var item in data)
                    {
                        if (item.construction_item_date_start_real != null)
                        {
                            soLuongNgayBatDau += 1;
                        }
                        if (item.construction_item_date_end_real != null)
                        {
                            soLuongNgayKetThuc += 1;
                        }
                    }

                    if ( soLuongNgayBatDau == 0)
                    {
                        return 1; // chua thuc hien
                    }

                    if ( soLuongNgayBatDau == soluong && soLuongNgayKetThuc == soluong )
                    {
                        return 3; // hoan thanh
                    }

                    return 2; // dang thuc hien
                }
                else
                {
                    return 0;
                }
                
            }
            catch(Exception)
            {
                return 0; // bi loi
            }
        }

        public IEnumerable<Object> getAllContruct_DangThucHien()
        {
            try
            {
                var data = from b in db.ST_constructions
                            where b.construction_status == 0
                            select b;
                if ( data.Any())
                    return data;
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public IEnumerable<Object> getAllContruct_DaThucHien( )
        {
            try
            {
                var data = from b in db.ST_constructions
                           where b.construction_status == 2
                           select b;
                if ( data.Any( ) )
                    return data;
                return null;
            }
            catch ( Exception )
            {
                return null;
            }
        }
    }
}
