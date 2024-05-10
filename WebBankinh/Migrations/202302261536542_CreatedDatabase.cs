namespace WebBankinh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BienTheSanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdSanPham = c.String(),
                        GhiChu = c.String(),
                        GiaNhap = c.Single(nullable: false),
                        GiaBan = c.Single(nullable: false),
                        KhuyenMai = c.Single(nullable: false),
                        IdHinhAnh = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChiTietDonHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDonHang = c.Int(nullable: false),
                        BienTheSanPham = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        SoLuong = c.Single(nullable: false),
                        PhanTramGiam = c.Single(nullable: false),
                        TongTienGiam = c.Single(nullable: false),
                        ThanhToan = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChiTietGioHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGioHang = c.Int(nullable: false),
                        IdBienTheSanPham = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DaMua = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdNguoiDung = c.Int(nullable: false),
                        TongSoLuong = c.Int(nullable: false),
                        TongTien = c.Single(nullable: false),
                        TongTienGiam = c.Single(nullable: false),
                        KhachPhaiTra = c.Single(nullable: false),
                        DaThanhToan = c.Boolean(nullable: false),
                        PhuongThucThanhToan = c.Int(nullable: false),
                        NgayTaoDonhang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GioHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdNguoiDung = c.Int(nullable: false),
                        NgayTao = c.String(),
                        NguoiTao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HinhAnh",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DuongDan = c.String(),
                        KichThuoc = c.String(),
                        DoPhanGiai = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenVietTat = c.String(),
                        TenLoai = c.String(),
                        GhiChu = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTaiKhoan = c.Int(nullable: false),
                        Email = c.String(),
                        SoDienThoai = c.String(),
                        DiaChi = c.String(),
                        IdHinhAnh = c.Int(nullable: false),
                        CanhBao = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhuongThucThanhToan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenVietTat = c.Int(nullable: false),
                        TenPhuongThuc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(),
                        IdLoaiSanPham = c.String(),
                        GhiChu = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        LoaiTaiKhoan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TonKho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdBienThe = c.Int(nullable: false),
                        SoLuongNhap = c.Int(nullable: false),
                        SoLuongConLai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TonKho");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.SanPham");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhuongThucThanhToan");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.HinhAnh");
            DropTable("dbo.GioHang");
            DropTable("dbo.DonHang");
            DropTable("dbo.ChiTietGioHang");
            DropTable("dbo.ChiTietDonHang");
            DropTable("dbo.BienTheSanPham");
        }
    }
}
