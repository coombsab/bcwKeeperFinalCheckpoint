-- Active: 1667581625209@@SG-brawny-mantis-3541-6847-mysql-master.servers.mongodirector.com@3306@keeper

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg MEDIUMTEXT COMMENT 'User Cover Image',
        bio MEDIUMTEXT COMMENT 'User Bio',
        hobbies MEDIUMTEXT COMMENT 'User Hobbies'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps (
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL COMMENT 'Creator Id',
        name VARCHAR(255) NOT NULL COMMENT 'Name of keep',
        description MEDIUMTEXT NOT NULL COMMENT 'Description of keep',
        img MEDIUMTEXT NOT NULL COMMENT 'Image of keep',
        views INT NOT NULL CHECK(views >= 0),
        tags VARCHAR(255) COMMENT 'Comma separated list of tags',
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

ALTER TABLE
    keeps MODIFY COLUMN views INT NOT NULL CHECK(views >= 0);

CREATE TABLE
    IF NOT EXISTS vaults (
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL COMMENT 'Creator Id',
        name VARCHAR(255) NOT NULL COMMENT 'Name of vault',
        description VARCHAR(255) NOT NULL COMMENT 'Description of vault',
        img MEDIUMTEXT NOT NULL COMMENT 'Cover image of vault',
        isPrivate bool NOT NULL DEFAULT 0,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

ALTER TABLE vaults
ADD
    COLUMN img MEDIUMTEXT NOT NULL COMMENT 'Image of vault',
    DROP COLUMN coverImg;

CREATE TABLE
    IF NOT EXISTS vaultKeeps (
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary Key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL COMMENT 'Creator Id',
        vaultId INT NOT NULL COMMENT 'Vault Id',
        keepId INT NOT NULL COMMENT 'Keep Id',
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';