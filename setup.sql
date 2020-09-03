/* CREATE TABLE cars (
    id INT NOT NULL AUTO_INCREMENT,
    make VARCHAR(255) NOT NULL,
    model VARCHAR(255) NOT NULL,
    year INT,
    imgUrl VARCHAR(255) NOT NULL,
    price INT,
    description VARCHAR(255),
    user VARCHAR(255) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE favoriteCars(
    id INT NOT NULL AUTO_INCREMENT,
    carId INT NOT NULL,
    userId VARCHAR(255) NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(carId)
    REFERENCES cars(id)
    ON DELETE CASCADE
) */
/* DROP TABLE favoriteCars;
DROP TABLE cars; */

/* 
INSERT INTO cars
(make, model, year, price, imgUrl, description, userId)
VALUES
("Chevy", "Tracker", 1989, 2000, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQiEdhq7a4aHGvv8FxjKUpAg_godVfcyLzHSg&usqp=CAU", "Itsa trackin", "D$SUPERSECRETUSERID") */


SELECT * FROM cars

