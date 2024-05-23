CREATE DATABASE TuneStock;
USE TuneStock;

-- Tables ---------------------------------------
CREATE TABLE User(
    ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Password VARCHAR(20) NOT NULL,
    IsDeleted BOOLEAN NOT NULL DEFAULT FALSE,
    CreatedBy VARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedBy VARCHAR(50) NOT NULL,
    UpdatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Sound(
    ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    UserID INT NOT NULL,
    SoundName VARCHAR(50) NOT NULL,
    File VARCHAR(100) NOT NULL,
    IsPremiun BOOLEAN DEFAULT FALSE,
    Price DOUBLE NOT NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,
    CreatedBy VARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedBy VARCHAR(50) NOT NULL,
    UpdatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE UserPurchases(
    ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    PurchasedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    SoundPrice DOUBLE NOT NULL,
    PaymentStatus BOOLEAN DEFAULT FALSE,
    PaymentMethod VARCHAR(20) NOT NULL,
    UserID_FK INT NOT NULL,
    SoundID_FK INT NOT NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,
    CreatedBy VARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedBy VARCHAR(50) NOT NULL,
    UpdatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE UserDownloads(
    ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    SoundID_FK INT NOT NULL,
    UserID_FK INT NOT NULL,
    DownloadedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Labels(
    ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Labelname VARCHAR(50) NOT NULL,
    Description VARCHAR(100) NOT NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,
    CreatedBy VARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedBy VARCHAR(50) NOT NULL,
    UpdatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE UserSoundStock(
    UserID_FK INT NOT NULL,
    SoundID_FK INT NOT NULL
);

CREATE TABLE SoundsLabels(
    SoundID_FK INT NOT NULL,
    LabelID_FK INT NOT NULL
);

-- Foreign Keys --------------------------------
ALTER TABLE UserDownloads
ADD CONSTRAINT UserID_FK_UserDownloads
FOREIGN KEY (UserID_FK) REFERENCES User(ID);

ALTER TABLE UserDownloads
ADD CONSTRAINT SoundID_FK_UserDownloads
FOREIGN KEY (SoundID_FK) REFERENCES Sound(ID);

ALTER TABLE UserSoundStock
ADD CONSTRAINT UserID_FK_UserSoundStock
FOREIGN KEY (UserID_FK) REFERENCES User(ID);

ALTER TABLE UserSoundStock
ADD CONSTRAINT SoundID_FK_UserSoundStock
FOREIGN KEY (SoundID_FK) REFERENCES Sound(ID);

ALTER TABLE UserPurchases
ADD CONSTRAINT UserID_FK_UserPurchases
FOREIGN KEY (UserID_FK) REFERENCES User(ID);

ALTER TABLE UserPurchases
ADD CONSTRAINT SoundID_FK_UserPurchases
FOREIGN KEY (SoundID_FK) REFERENCES Sound(ID);

ALTER TABLE SoundsLabels
ADD CONSTRAINT SoundID_FK_SoundsLabels
FOREIGN KEY (SoundID_FK) REFERENCES Sound(ID);

ALTER TABLE SoundsLabels
ADD CONSTRAINT LabelID_FK_SoundsLabels
FOREIGN KEY (LabelID_FK) REFERENCES Labels(ID);

SELECT
    CONSTRAINT_NAME,
    TABLE_NAME,
    COLUMN_NAME,
    REFERENCED_TABLE_NAME,
    REFERENCED_COLUMN_NAME
FROM
    INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE
    TABLE_SCHEMA = 'TuneStock'
    AND REFERENCED_TABLE_NAME IS NOT NULL;


DELIMITER $$
CREATE TRIGGER TRG_INSERT_UserPurchases
AFTER INSERT ON UserPurchases
FOR EACH ROW
BEGIN
    INSERT INTO UserSoundStock (UserID_FK, SoundID_FK)
    VALUES (NEW.UserID_FK, NEW.SoundID_FK);
END$$

DELIMITER ;

DELIMITER $$

DROP PROCEDURE IF EXISTS InsertSoundAndLabel$$

CREATE PROCEDURE InsertSoundAndLabel(
    IN p_UserID INT,
    IN p_SoundName VARCHAR(50),
    IN p_File VARCHAR(100),
    IN p_IsPremiun BOOLEAN,
    IN p_Price DOUBLE,
    IN p_IsDeleted BOOLEAN,
    IN p_CreatedBy VARCHAR(50),
    IN p_CreatedDate DATETIME,
    IN p_UpdatedBy VARCHAR(50),
    IN p_UpdatedDate DATETIME,
    IN p_LabelID INT
    )
BEGIN
    DECLARE newSoundID INT;

    -- Insertar en la tabla Sound
    INSERT INTO Sound(
        UserID,
        SoundName,
        File,
        IsPremiun,
        Price,
        IsDeleted,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate
    ) VALUES (
        p_UserID,
        p_SoundName,
        p_File,
        p_IsPremiun,
        p_Price,
        p_IsDeleted,
        p_CreatedBy,
        p_CreatedDate,
        p_UpdatedBy,
        p_UpdatedDate
    );

    -- Obtener el ID del nuevo registro insertado en Sound
    SET newSoundID = LAST_INSERT_ID();

    -- Insertar en la tabla SoundsLabels
    INSERT INTO SoundsLabels (SoundID_FK, LabelID_FK)
    VALUES (newSoundID, p_LabelID);
END$$

DELIMITER ;


CALL InsertSoundAndLabel(
    1,                  -- p_UserID
    'Skrillex',-- p_SoundName
    '/ruta/al/archivo.mp3',  -- p_File
    FALSE,               -- p_IsPremiun
    0.0,               -- p_Price
    FALSE,              -- p_IsDeleted
    'Usuario123',       -- p_CreatedBy
    NOW(),              -- p_CreatedDate
    'Usuario123',       -- p_UpdatedBy
    NOW(),              -- p_UpdatedDate
    2                   -- p_LabelID
);


