USE TuneStock;
SHOW TABLES;

DESCRIBE Labels;
DESCRIBE Sound;
DESCRIBE SoundsLabels;
DESCRIBE User;
DESCRIBE UserDownloads;
DESCRIBE UserPurchases;
DESCRIBE UserSoundStock;

SELECT * FROM Labels;
SELECT * FROM Sound;
SELECT * FROM SoundsLabels;
SELECT * FROM User;
SELECT * FROM UserDownloads WHERE UserID_FK = 1;
SELECT * FROM UserPurchases;
SELECT * FROM UserSoundStock;

INSERT INTO Labels (Labelname, Description, IsDeleted, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate)
VALUES ('Synthwave Guitar Riff', 'A guitar riff with synthwave vibes', FALSE, 'Starryboy', CURRENT_TIMESTAMP(), 'Starryboy', CURRENT_TIMESTAMP());

INSERT INTO User (Username, Email, Password, IsDeleted, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate)
VALUES ('SarboyCool', 'StarboyCool@outlook.com', 'StarboyCool', FALSE, 'Starryboy', CURRENT_TIMESTAMP(), 'Starryboy', CURRENT_TIMESTAMP());

CALL InsertSoundAndLabel(1, 'Synthwave Guitar Riff', '/SynthGuitarRiff.mp3', TRUE, 10.50, FALSE, 'Starryboy', CURRENT_TIMESTAMP(), 'Starryboy', CURRENT_TIMESTAMP(), 1);

INSERT INTO UserPurchases (PurchasedDate, SoundPrice, PaymentStatus, PaymentMethod, UserID_FK, SoundID_FK, IsDeleted, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate)
VALUES (CURRENT_TIMESTAMP(), 10.50, TRUE, 'CREDIT CARD', 1, 1, FALSE, 'Starryboy', CURRENT_TIMESTAMP(), 'Starryboy', CURRENT_TIMESTAMP());

INSERT INTO UserDownloads (SoundID_FK, UserID_FK, DownloadedDate)
VALUES (1, 1, CURRENT_TIMESTAMP());

-- WARNING DON'T BE DUMB -------------------------
DELETE FROM Labels;
DELETE FROM Sound;
DELETE FROM SoundsLabels;
DELETE FROM User;
DELETE FROM UserDownloads;
DELETE FROM UserPurchases;
DELETE FROM UserSoundStock;

ALTER TABLE Labels AUTO_INCREMENT = 1;
ALTER TABLE Sound AUTO_INCREMENT = 1;
ALTER TABLE User AUTO_INCREMENT = 1;
ALTER TABLE UserDownloads AUTO_INCREMENT = 1;
ALTER TABLE UserPurchases AUTO_INCREMENT = 1;















