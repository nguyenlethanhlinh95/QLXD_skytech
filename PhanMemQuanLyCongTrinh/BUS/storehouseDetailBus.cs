using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class StorehouseDetailBus
    {
        DAO.StorehouseDetailDao store = new DAO.StorehouseDetailDao();



        // khi xóa kho hàng thì chuyển tất cả hàng hóa vào kho mặc định
        public bool changeIdParent(Int64 groupId)
        {
            return store.changeIdParent(groupId);
        }

        public object getSuppliesAndQuantityWithStoreHouse(Int64 storehouseId)
        {
            return store.getSuppliesAndQuantityWithStoreHouse(storehouseId);
        }

        public object getAllStorehouseDetail()
        {
            return store.getAllStorehouseDetail();
        }
        public object getStorehouseDetailWithGroup(Int64 storehouseId)
        {
            return store.getStorehouseDetailWithGroup(storehouseId);
        }

        public bool insert(Int64 storeHo, Int64 idSupplies, Int32 quantity)
        {
            return store.insert(storeHo, idSupplies, quantity);
        }

        public bool isCheckSupplies(Int64 id)
        {
            return store.isCheckSupplies(id);
        }

        public bool updateQuality(Int64 idSup, int quality, Int64 storehousesId)
        {
            return store.updateQuality(idSup, quality, storehousesId);
        }

        public bool updateQuality(Int64 quality, Int64 storehousesId)
        {
            return store.updateQuality( quality, storehousesId);
        }

        public bool updateQuantityDiv(Int64 idSup , int quality, Int64 storehousesId)
        {
            return store.updateQuantityDiv(idSup, quality, storehousesId);
        }

        public Object getQuality(Int64 suppliesId, Int64 storeHouseId)
        {
            return store.getQuality(suppliesId, storeHouseId);
        }

        public bool updateEnterSuppliesQuality(Int64 storehouseId, Int64 suppliesId, Int64 quality)
        {
            return store.updateEnterSuppliesQuality(storehouseId, suppliesId, quality);
        }

        public bool updateOutSuppliesQuality(Int64 storehouseId, Int64 suppliesId, Int64 quality)
        {
            return store.updateOutSuppliesQuality(storehouseId, suppliesId, quality);
        }
    }
}
