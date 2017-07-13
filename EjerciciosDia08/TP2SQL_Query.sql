--1
SELECT * FROM Productos
ORDER BY pNombre;
--2
SELECT * FROM Proveedores
WHERE localidad = 'Capital';
--3
SELECT * FROM Envios
WHERE cantidad>=200 AND cantidad<=300;
--4
SELECT SUM(Cantidad) as CantidadTotal FROM Envios;
--5
SELECT AVG(Precio) as PromedioPrecio FROM Productos;
--6
SELECT (e.Cantidad * p.Precio) as Monto 
FROM Envios e INNER JOIN Productos p ON e.pNumero=p.pNumero;
--7
SELECT SUM(Cantidad) as Cant_Prod1_Prov102
FROM Envios
WHERE pNumero = 1 AND Numero = 102; 
--8
SELECT pNumero FROM Envios
WHERE numero = (SELECT numero FROM Proveedores
				WHERE Localidad = 'Avellaneda');
--9
SELECT Domicilio, Localidad FROM Proveedores
WHERE nombre LIKE '%i%';
--10
INSERT INTO Productos VALUES (4,'Chocolate',0.35,'Chico');
--11
INSERT INTO Proveedores (Numero,Nombre) 
				VALUES (103, 'Gonzalez');
--12
INSERT INTO Proveedores (Numero,Nombre,Localidad) 
				VALUES (107,'Rosales','La Plata');
--13
UPDATE Productos 
SET Precio = 7.5
WHERE Tamaño = 'Grande';  
--14
UPDATE Productos
SET Tamaño='Mediano'
FROM Productos p INNER JOIN Envios e ON e.pNumero = p.pNumero
WHERE Tamaño = 'Chico' AND e.Cantidad >= 300;
--15
DELETE FROM Productos 
WHERE pNumero = 1;
--16
DELETE FROM Proveedores
WHERE Numero NOT IN(SELECT p.Numero FROM Proveedores p 
				INNER JOIN Envios e on p.Numero=e.Numero);   
 
