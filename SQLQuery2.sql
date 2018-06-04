 CREATE PROC USP_DangNhap
 @TaiKhoan nvarchar(200),@MatKhau nvarchar(200)
 AS
 BEGIN
    Select * from TaiKhoan where TaiKhoan = @TaiKhoan and MatKhau = @MatKhau
 END
 GO
 CREATE PROC USP_UpdateAccounts
@userName NVARCHAR(200), @displayName NVARCHAR(100), @password NVARCHAR(200), @newPassword NVARCHAR(200)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.TaiKhoan WHERE TaiKhoan = @userName AND MatKhau = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.TaiKhoan SET TenDN = @displayName WHERE TaiKhoan = @userName
		END		
		ELSE
			UPDATE dbo.TaiKhoan SET TenDN = @displayName, MatKhau = @newPassword WHERE TaiKhoan = @userName
	end
END
GO
CREATE PROCEDURE Nhap
@mahh INT,
@SL INT,
@gianhap FLOAT,
@giaxuat FLOAT,
@ghichu NVARCHAR(200),
@manv NVARCHAR(200),
@ngaynhap DATE
AS
DECLARE @Mapn INT
BEGIN
INSERT INTO dbo.PhieuNhap
        ( NgayNhap )
VALUES  ( @ngaynhap -- NgayNhap - date
          )
SELECT @Mapn=SCOPE_IDENTITY()
INSERT INTO dbo.ChiTietPhieuNhap
        ( MaHH ,
          MaPN ,
          Counts ,
          Gianhap ,
          GhiChu ,
          MaNV ,
          Giaxuat
        )
VALUES  ( @mahh , -- MaHH - nvarchar(200)
          @Mapn, -- MaPN - int
          @SL, -- Counts - int
          @gianhap , -- Gianhap - float
          @ghichu , -- GhiChu - nvarchar(200)
          @manv , -- MaNV - nvarchar(200)
          @giaxuat  -- Giaxuat - float
        )
END
EXEC dbo.Nhap @mahh = 1, -- int
    @SL = 5, -- int
    @gianhap = 6000000.0, -- float
    @giaxuat = 6500000.0, -- float
    @ghichu = N'', -- nvarchar(200)
    @manv = 1, -- nvarchar(200)
    @ngaynhap = '2018-06-03 14:26:26' -- date
GO
SELECT dbo.ChiTietPhieuNhap.MaCTPN,dbo.ChiTietPhieuNhap.MaHH,dbo.ChiTietPhieuNhap.Counts,dbo.ChiTietPhieuNhap.Gianhap,dbo.ChiTietPhieuNhap.GhiChu,dbo.ChiTietPhieuNhap.MaNV,dbo.ChiTietPhieuNhap.Giaxuat,dbo.PhieuNhap.NgayNhap
FROM dbo.ChiTietPhieuNhap,dbo.PhieuNhap
WHERE ChiTietPhieuNhap.MaPN=PhieuNhap.MaPN
GO

CREATE PROCEDURE Xoanhap
@maCTPN INT
AS
BEGIN
DELETE dbo.ChiTietPhieuNhap WHERE dbo.ChiTietPhieuNhap.MaCTPN=@maCTPN
END
GO
CREATE TRIGGER KTxoanhap
ON dbo.ChiTietPhieuNhap
FOR DELETE
as
BEGIN
DECLARE @mapn INT
SELECT @mapn=Deleted.MaPN FROM Deleted
DELETE dbo.PhieuNhap WHERE dbo.PhieuNhap.MaPN=@mapn
END
EXEC dbo.Xoanhap @maCTPN = 0 -- int
GO
CREATE PROC updatenhap
@mahh INT,
@SL INT,
@gianhap FLOAT,
@giaban FLOAT,
@manv NVARCHAR(200),
@ngaynhap DATE,
@ghichu NVARCHAR(200),
@maCTPN INT
AS
BEGIN
UPDATE dbo.ChiTietPhieuNhap SET MaHH=@mahh,Counts=@SL,Gianhap=@gianhap,Giaxuat=@giaban,MaNV=@manv,GhiChu=@ghichu WHERE MaCTPN=@maCTPN
UPDATE dbo.PhieuNhap SET NgayNhap=@ngaynhap WHERE MaPN=(SELECT dbo.ChiTietPhieuNhap.MaPN FROM dbo.ChiTietPhieuNhap WHERE MaCTPN=@maCTPN)
END
GO
EXEC dbo.updatenhap @mahh = 0, -- int
    @SL = 0, -- int
    @gianhap = 0.0, -- float
    @giaban = 0.0, -- float
    @manv = N'', -- nvarchar(200)
    @ngaynhap = '2018-06-03 17:35:36', -- date
    @ghichu = N'', -- nvarchar(200)
    @maCTPN = 0 -- int
-------------------------
SELECT * FROM dbo.NhaCC
INSERT INTO dbo.NhaCC
        ( TenNCC, DiaChi, SDT, Email )
VALUES  ( N'', -- TenNCC - nvarchar(200)
          N'', -- DiaChi - nvarchar(200)
          N'', -- SDT - nvarchar(20)
          N''  -- Email - nvarchar(200)
          )
		  GO
   
          GO
          CREATE PROC thongke
		  @mahh NVARCHAR(200)
		  AS
          BEGIN
          DECLARE @a INT
		  DECLARE @b INT
		  SELECT @a=SUM(dbo.ChiTietPhieuNhap.Counts)FROM dbo.ChiTietPhieuNhap WHERE dbo.ChiTietPhieuNhap.MaHH=@mahh
		  SELECT @b=ISNULL(SUM(dbo.ChiTietPhieuXuat.Counts),0)FROM dbo.ChiTietPhieuXuat WHERE dbo.ChiTietPhieuXuat.MaHH=@mahh
		  SELECT @a-@b
		  END
          EXEC dbo.thongke @mahh = 2 -- nvarchar(200)
          
          GO
CREATE PROCEDURE Xuat
@mahh INT,
@SL INT,
@ghichu NVARCHAR(200),
@makh NVARCHAR(200),
@ngayxuat DATE
AS
DECLARE @Mapx INT
BEGIN
INSERT INTO dbo.PhieuXuat
        ( NgayXuat )
VALUES  ( @ngayxuat  -- NgayXuat - date
          )
SELECT @Mapx=SCOPE_IDENTITY()
INSERT INTO dbo.ChiTietPhieuXuat
        ( MaHH, MaKH, MaPX, Counts, GhiChu )
VALUES  ( @mahh, -- MaHH - nvarchar(200)
          @makh, -- MaKH - int
          @Mapx, -- MaPX - int
          @SL, -- Counts - int
          @ghichu  -- GhiChu - nvarchar(200)
          )

END
EXEC dbo.Xuat @mahh = 0, -- int
    @SL = 0, -- int
    @ghichu = N'', -- nvarchar(200)
    @makh = N'', -- nvarchar(200)
    @ngayxuat = '2018-06-04 09:43:05' -- date
