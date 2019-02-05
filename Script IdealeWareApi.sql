CREATE DATABASE idealewaredb;

USE idealewaredb;

CREATE TABLE category(
idCategory int unsigned auto_increment primary key,
name varchar(255) not null,
description varchar(255));

CREATE TABLE product(
idProduct int unsigned auto_increment primary key,
idCategory int unsigned,
name varchar(255) not null,
description varchar(255),
quantity int unsigned not null,
price decimal(10,2) not null,
foreign key (idCategory) references category(idCategory));
