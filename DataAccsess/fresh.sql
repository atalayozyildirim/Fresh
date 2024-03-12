CREATE DATABASE mango;
Create Table Users
(
    Id INT PRIMARY KEY NOT NULL,
);

CREATE TABLE Post
(
    Id INT PRIMARY KEY NOT NULL ,
    Title VARCHAR(255) NOT NULL ,
    Content TEXT NOT NULL ,
    CreatedDate DATETIME NOT NULL ,
    UserId INT NOT NULL ,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
Create Table Comment
(
    Id INT PRIMARY KEY NOT NULL ,
    UserId INT NOT NULL ,
    PostId INT NOT NULL ,
    Content TEXT NOT NULL,
    CreatedAt DATETIME NOT NULL
        FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (PostId) REFERENCES Post(Id)
);


CREATE TABLE Likes
(
    Id INT NOT NULL ,
    PostId INT NOT NULL ,
    UserId INT NOT NULL ,
    PostUserId INT NOT NULL,
    Likes NVARCHAR(50) NOT NULL
);



