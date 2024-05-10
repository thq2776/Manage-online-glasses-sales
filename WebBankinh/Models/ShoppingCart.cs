using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBankinh.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, int SoLuong)
        {
            var checkExits = Items.FirstOrDefault(x => x.IdSanPham == item.IdSanPham);
            if (checkExits != null)
            {
                checkExits.SoLuong += SoLuong;
                checkExits.TongGiaBan = checkExits.GiaBan * checkExits.SoLuong;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.IdSanPham == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }

        public void UpdateSoLuong(int id, int soluong) //tăng số lượng sản phẩm được thêm
        {
            var checkExits = Items.SingleOrDefault(x => x.IdSanPham == id);
            if (checkExits != null)
            {
                checkExits.SoLuong = soluong;
                checkExits.TongGiaBan = checkExits.GiaBan * checkExits.SoLuong;
            }
        }

        public double? GetTotalPrice()
        {
            return Items.Sum(x => x.TongGiaBan);
        }
        public int GetTotalQuantity()
        {
            return Items.Sum(x => x.SoLuong);
        }
        public void ClearCart()
        {
            Items.Clear();

        }
        public class ShoppingCartItem
        {
            public int IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string TenLoaiSanPham { get; set; }
            public string HinhAnh { get; set; }
            public int SoLuong { get; set; }
            public double? KhuyenMai { get; set; }
            public double? GiaBan { get; set; }
            public double? TongGiaBan { get; set; }
        }
    }
}