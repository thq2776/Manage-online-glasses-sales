using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;
using static WebBankinh.Models.ShoppingCart;

namespace WebBankinh.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        public ActionResult CheckOut() //thanh toán
        {
            ViewBag.PhuongThucThanhToan = new SelectList(db.PhuongThucThanhToans.ToList(), "Id", "TenPhuongThuc");            
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        public async Task<ActionResult> CheckOutSuccess(DonHang pt) //Đặt hàng 
        {   
            if(pt.Id == 3)
            {
                /*string finaltotal = tongtiengiam.ToString();
                string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
                string partnerCode = "MOMOOJOI20210710";
                string accessKey = "iPXneGmrJH0G8FOP";
                string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
                string orderInfo = "Đơn hàng của  " + tenkh + " " + mdh;
                string returnUrl = "https://localhost:44336/GioHangs/ReturURL";
                string notifyurl = "https://3d0f-2001-ee0-537b-1970-291a-94d2-a413-6c84.ap.ngrok.io/Home/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

                string amount = finaltotal;
                string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
                string requestId = DateTime.Now.Ticks.ToString();
                string extraData = "";

                //Before sign HMAC SHA256 signature
                string rawHash = "partnerCode=" +
                    partnerCode + "&accessKey=" +
                    accessKey + "&requestId=" +
                    requestId + "&amount=" +
                    amount + "&orderId=" +
                    orderid + "&orderInfo=" +
                    orderInfo + "&returnUrl=" +
                    returnUrl + "&notifyUrl=" +
                    notifyurl + "&extraData=" +
                    extraData;

                MoMoSecurity crypto = new MoMoSecurity();
                //sign signature SHA256
                string signature = crypto.signSHA256(rawHash, serectkey);

                //build body json request
                JObject message = new JObject
                            {
                            { "partnerCode", partnerCode },
                            { "accessKey", accessKey },
                            { "requestId", requestId },
                            { "amount", amount },
                            { "orderId", orderid },
                            { "orderInfo", orderInfo },
                            { "returnUrl", returnUrl },
                            { "notifyUrl", notifyurl },
                            { "extraData", extraData },
                            { "requestType", "captureMoMoWallet" },
                            { "signature", signature }
                          };
                string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

                JObject jmessage = JObject.Parse(responseFromMomo);

                return Redirect(jmessage.GetValue("payUrl").ToString());*/
            }
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            NguoiDung nd = (NguoiDung)Session["User"];
            var createOrder = new DonHang
            {
                IdNguoiDung = nd.Id,
                TongSoLuong = cart.GetTotalQuantity(),
                TongTien = cart.GetTotalPrice(),
                DaThanhToan = 0,
                NgayTaoDonhang = DateTime.Now,
                IdPhuongThucThanhToan = pt.Id,            
            };
            db.DonHangs.Add(createOrder);

            db.SaveChanges();
            
            var getOrder = await db.DonHangs.OrderByDescending(x => x.Id).FirstOrDefaultAsync(); // Orderbyde.. lấy thứ tự đơn hàng từ lớn đến bé theo id

            foreach (var item in cart.Items) //Chi tiết đơn hàng
            {
                var createDetailOrder = new ChiTietDonHang
                {
                    IdDonHang = getOrder.Id,
                    IdBienTheSanPham = item.IdSanPham,
                    DonGia = item.GiaBan,
                    SoLuong = item.SoLuong,
                    ThanhTien = item.TongGiaBan
                };
                db.ChiTietDonHangs.Add(createDetailOrder);
            }
            db.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(DonHang donHang) //Đặt hàng thành công
        {
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null)
                {
                    return RedirectToAction("CheckOutSuccess", donHang);
                }
            }
            return View(donHang);
        }

        public ActionResult Partial_Item_Cart() //Giao diện load giỏ hàng
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult ShowCount() //hiện thị sản phẩm được thêm
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int soluong) //thêm sản phẩm vào giỏ hàng
        {   
            var code = new { Success = false,/* msg = "", */code = -1, Count = 0 }; //trả về thông tin kết quả của thao tác
            var db = new ApplicationDbContext();
            var checkProduct = db.BienTheSanPhams.FirstOrDefault(x => x.Id == id);
            if (checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    IdSanPham = checkProduct.Id,
                    TenSanPham = checkProduct.SanPham.TenSanPham,
                    HinhAnh = checkProduct.HinhAnh.DuongDan,
                    TenLoaiSanPham = checkProduct.SanPham.LoaiSanPham.TenLoai,
                    GiaBan = checkProduct.GiaBan,
                    KhuyenMai = checkProduct.KhuyenMai,
                    SoLuong = soluong,
                    TongGiaBan = soluong * checkProduct.GiaBan,
                };
                item.GiaBan = item.GiaBan - (item.GiaBan * item.KhuyenMai / 100);
                item.TongGiaBan = item.SoLuong * item.GiaBan;
                cart.AddToCart(item, soluong);
                Session["Cart"] = cart;
                code = new { Success = true,/* msg = "Thêm sản phẩm vào giỏ hàng thành công!", */code = 1, Count = cart.Items.Count };
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult Update(int id, int soluong) //cập nhật số lượng sản phẩm trong giỏ hàng
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateSoLuong(id, soluong);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.IdSanPham == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult DeleteAll() //xoá tất cả các sản phẩm đã thêm
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true});
            }
            return Json(new { Success = true });

        }

    }
}