using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LTWeb09_Bai1.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=NhaSach")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<ThamGIa> ThamGIas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.DaThanhToan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sach>()
                .Property(e => e.AnhBia)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.Moi)
                .IsFixedLength();

            modelBuilder.Entity<TacGia>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);
        }
        public void InsertOnSubmit(Sach Sach)
        {
            Saches.Add(Sach);
        }
        public void UpdateOnSubmit(Sach Sach)
        {
            Saches.AddOrUpdate(Sach);
        }
        public void DeleteOnSubmit(Sach Sach)
        {
            Saches.Remove(Sach);
        }
        public void SubmitSaveChanges()
        {
            SaveChanges();
        }
    }
}
