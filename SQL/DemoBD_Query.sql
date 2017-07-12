--SELECT * FROM Persona;

--INSERT INTO Persona VALUES (67,'Andres',34);

--SELECT nombre, edad FROM Persona WHERE nombre LIKE 'Maxi';

--UPDATE Persona SET nombre='Pepito' WHERE nombre LIKE 'Ricardo';

--DELETE FROM Persona WHERE nombre='Andres';

--SELECT * FROM persona WHERE	nombre LIKE '%ito%';

SELECT MIN(edad) as Edad_Min, MAX(edad) as Edad_Max FROM Persona;