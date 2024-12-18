INSERT INTO ProductCategories (Name, CreatedAt) VALUES 
('Cotton', GETDATE()),
('Exclusives', GETDATE()),
('Seasonal Genevieve', GETDATE()),
('Seasonal Qalbi', GETDATE())
;

INSERT INTO Discounts(Name, DiscountPercent, Active, CreatedAt) VALUES 
('N/A',0.00, 1, GETDATE()),
('15% off', 15.00,0,GETDATE()),
('20% off',20.00, 0, GETDATE()),
('50% off',50.00, 0, GETDATE())
;

DELETE FROM Discounts;
DELETE FROM ProductCategories;
DELETE FROM Products;
DELETE FROM ProductVariants;

DBCC CHECKIDENT ('ProductCategories', RESEED, 0);
DBCC CHECKIDENT ('Discounts', RESEED, 0);
DBCC CHECKIDENT ('Products', RESEED, 0);
DBCC CHECKIDENT ('ProductVariants', RESEED, 0);



INSERT INTO Products (ProductName, CategoryID, ProductPrice, Description, ImageFile, CreatedAt, DiscountID, Stock, Quantity) VALUES 
('No Item', 1, 0.00,'No item available yet', 'Black Ribbon.JPG', GETDATE(), 1, 1, 50),
('No Item', 1, 0.00,'No item available yet', 'Black Ribbon.JPG', GETDATE(), 1, 1, 50),
('No Item', 1, 0.00,'No item available yet', 'Black Ribbon.JPG', GETDATE(), 1, 1, 50),
('No Item', 2, 0.00,'No item available yet', 'Black Ribbon.JPG', GETDATE(), 1, 1, 50),
('No Item', 2, 0.00,'No item available yet', 'Black Ribbon.JPG', GETDATE(), 1, 1, 50),
('No Item', 2, 0.00,'No item available yet', 'Black Ribbon.JPG', GETDATE(), 1, 1, 50),
('Adelaide Collection',3, 30.00, 'Silk Ribbon x Lines Shawl', 'tfl_adelaide_ps2.jpg', GETDATE(),1,50, 50),
('Blair Collection',3, 30.00, 'Vintage Ribbon Shawl', 'tfl_blair_ps1.jpg', GETDATE(),1,50, 50),
('Camille Collection',3,30.00, 'Criss Crossed Ribbon','tfl_camille_ps2.jpeg', GETDATE(),1,50, 50),
('Delilah Collection', 3, 30.00, 'Elegant Bows', 'tfl_delilah_ps4.jpg',GETDATE(),1,50, 50),
('Evangeline Collection',3,30.00,'Floral Embrace','tfl_evangeline_ps1.jpg', GETDATE(),1,50, 50),
('Felicia Collection',3,30.00,'Soft Satin Swirls','tfl_felicia_ps4.jpg', GETDATE(),1,50, 50),
('Isadora Collection',3,30.00,'Blossoms & Bows','tfl_isadora_ps4.jpg', GETDATE(),1,50, 50),
('Ophelia Collection',3,30.00,'Wrapped in Bloom', 'tfl_ophelia_ps2.jpg', GETDATE(),1,50, 50),
('Sirena Collection',3,30.00,'Bows Over Denim','tfl_sirena_ps3.jpg', GETDATE(),1,50, 50),
('Ruhi Collection',4, 28.00, 'Abstract Floral Pattern Scarf','tfl_ruhi_beige_ps.jpeg', GETDATE(),1,50, 50),
('Sanadi Collection',4, 28.00,'Hearts and Polka Dots Scarf', 'tfl_sanadi_lightblue_ps2.jpeg', GETDATE(),1,50, 50),
('Helwa Collection',4, 28.00, 'Leaf Scarf', 'tfl_helwa_beige_ps.jpeg', GETDATE(),1,50, 50),
('Hayati Collection',4,28.00,'Chained Hearts Scarf', 'tfl_hayati_black&white_ps.jpeg', GETDATE(),1,50, 50),
('Eyuni Collection',4, 28.00,'Heart-Dotted Scarf','tfl_eyuni_pink&purple_ps.jpeg', GETDATE(),1,50, 50)
;

INSERT INTO ProductVariants (ProductID,Color, Price, Stock, ImageFile, CreatedAt) VALUES
(7,'Black', 30.00, 50, 'Adelaide_black_mtrl.JPG', GETDATE()),
(7,'Blue', 30.00 , 50 ,'Adelaide_blue_mtrl.JPG', GETDATE()),
(7,'Pink', 30.00, 50, 'Adelaide_pink_mtrl.JPG', GETDATE()),
(8,'Grey', 30.00, 50, 'Blair_Grey_mtrl.JPG', GETDATE()),
(8,'Black', 30.00, 50, 'Blair_black_mtrl.JPG', GETDATE()),
(9,'Light-Pink', 30.00, 50, 'Camille_lightpink_mtrl.jpeg', GETDATE()),
(9,'Black', 30.00, 50, 'Camille_black_mtrl.jpeg', GETDATE()),
(10,'Teal', 30.00, 50, 'Delilah_teal_mtrl.JPG', GETDATE()),
(10,'Black', 30.00, 50,'Delilah_black_mtrl.JPG', GETDATE()),
(11,'Nude-Pink', 30.00, 50, 'Evangeline_nudepink_mtrl.JPG', GETDATE()),
(11,'Blue', 30.00, 50, 'Evangeline_blue_mtrl.JPG', GETDATE()),
(11,'Black', 30.00, 50, 'Evangeline_black_mtrl.JPG', GETDATE()),
(12,'Blue&White', 30.00, 50, 'Felicia_blue&white_mtrl.JPG', GETDATE()),
(12, 'Nude-Cream', 30.00, 50, 'Felicia_nudecream_mtrl.JPG', GETDATE()),
(13, 'Pastel-Blue', 30.00, 50, 'Isadora_pastelblue_mtrl.JPG', GETDATE()),
(13, 'Black', 30.00, 50, 'Isadora_black_mtrl.JPG', GETDATE()),
(13, 'Cream', 30.00, 50, 'Isadora_cream_mtrl.JPG', GETDATE()),
(13, 'Grey', 30.00, 50, 'Isadora_grey_mtrl.JPG', GETDATE()),
(13, 'Pink', 30.00, 50, 'Isadora_pink_mtrl.JPG', GETDATE()),
(14, 'Dark-Blue', 30.00, 50, 'Ophelia_darkblue_mtrl.JPG', GETDATE()),
(14, 'Black', 30.00, 50, 'Ophelia_black_mtrl.JPG', GETDATE()),
(15, 'Blue-Jeans', 30.00, 50, 'Sirena_bluejeans_mtrl.JPG', GETDATE()),
(16,'Light-Pink', 28.00, 50, 'Ruhi_lightpink_mtrl.jpeg', GETDATE()),
(16,'Beige', 28.00, 50, 'Ruhi_beige_mtrl.jpeg', GETDATE()),
(16,'Emerald-Green', 28.00, 50, 'Ruhi_emeraldgreen_mtrl.jpeg', GETDATE()),
(16,'Light-Blue', 28.00, 50, 'Ruhi_lightblue_mtrl.jpeg', GETDATE()),
(16,'Nude-Pink', 28.00, 50, 'Ruhi_nudepink_mtrl.jpeg', GETDATE()),
(17,'Light-Blue', 28.00, 50, 'Sanadi_lightblue_mtrl.jpeg', GETDATE()),
(17,'Pastel-Maroon', 28.00, 50, 'Sanadi_pastelmaroon_mtrl.jpeg', GETDATE()),
(17,'Purple', 28.00, 50, 'Sanadi_purple_mtrl.jpeg', GETDATE()),
(18, 'Beige', 28.00, 50, 'Helwa_beige_mtrl.jpeg', GETDATE()),
(18, 'Black', 28.00, 50, 'Helwa_black_mtrl.jpeg', GETDATE()),
(18, 'Dark-Maroon', 28.00, 50, 'Helwa_darkmaroon_mtrl.jpeg', GETDATE()),
(18, 'Light-Blue', 28.00, 50, 'Helwa_lightblue_mtrl.jpeg', GETDATE()),
(18, 'Light-Pink', 28.00, 50, 'Helwa_lightpink_mtrl.jpeg', GETDATE()),
(18, 'Sandy-Brown', 28.00, 50, 'Helwa_sandybrown_mtrl.jpeg', GETDATE()),
(19, 'Light-Blue', 28.00, 50, 'Hayati_lightblue_mtrl.jpeg', GETDATE()),
(19, 'Black', 28.00, 50, 'Hayati_black_mtrl.jpeg', GETDATE()),
(19, 'Burgundy', 28.00, 50, 'Hayati_burgundy_mtrl.jpeg', GETDATE()),
(19, 'Cream&Teal', 28.00, 50, 'Hayati_cream&teal_mtrl.jpeg', GETDATE()),
(19, 'Emerald-Green', 28.00, 50, 'Hayati_emeraldgreen_mtrl.jpeg', GETDATE()),
(19, 'Golden-Yellow', 28.00, 50, 'Hayati_goldenyellow_mtrl.jpeg', GETDATE()),
(19, 'Light-Pink', 28.00, 50, 'Hayati_lightpink_mtrl.jpeg', GETDATE()),
(19, 'Nude-Brown', 28.00, 50, 'Hayati_nudebrown_mtrl.jpeg', GETDATE()),
(19, 'White', 28.00, 50, 'Hayati_white_mtrl.jpeg', GETDATE()),
(20, 'Light-Pink', 28.00, 50, 'Eyuni_lightpink_mtrl.jpeg', GETDATE()),
(20, 'Black', 28.00, 50, 'Eyuni_black_mtrl.jpeg', GETDATE()),
(20, 'Dark-Red', 28.00, 50, 'Eyuni_darkred_mtrl.jpeg', GETDATE()),
(20, 'Light-Blue', 28.00, 50, 'Eyuni_lightblue_mtrl.jpeg', GETDATE()),
(20, 'Purple', 28.00, 50, 'Eyuni_purple_mtrl.jpeg', GETDATE())
;

SELECT * FROM ProductCategories
SELECT * FROM Discounts
SELECT * FROM Products
SELECT * FROM ProductVariants